using System;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Collections;
using UnityEngine.Networking;
using TMPro;
using DG.Tweening;

public enum FilterAPIDataMode
{
    AllClients,
    ManagersOnly,
    NonManagers
}

public class SetupUi : MonoBehaviour
{
    [SerializeField] string APIURL;
    [SerializeField] GameObject ListItemPrefab, LoadingScreen, ListParent;
    public static jsonData obj;

    private void Awake()
    {
        LoadingScreen.SetActive(true);
        StartCoroutine("FetchData");
    }

    IEnumerator FetchData()
    {
        yield return null;

        UnityWebRequest webRequest = UnityWebRequest.Get(APIURL);

        yield return webRequest.SendWebRequest();

        if (webRequest.result != UnityWebRequest.Result.Success)
            yield break;

        string json = webRequest.downloadHandler.text.Trim();

        obj = JsonConvert.DeserializeObject<jsonData>(json);

        StartCoroutine("FilterAPIData", FilterAPIDataMode.AllClients);
    }

    IEnumerator FilterAPIData(FilterAPIDataMode filtermode)
    {
        if (obj == null)
            yield break;

        LoadingScreen.transform.DOScale(0, 1).SetEase(Ease.InBack).OnComplete(() =>
        {
            LoadingScreen.SetActive(false);
        });

        for (int i = 0; i < ListParent.transform.childCount; i++)
        {
            Destroy(ListParent.transform.GetChild(i).gameObject);
        }

        List<Animator> animators = new List<Animator>();

        for (int i = 0; i < obj.clients.Count; i++)
        {
            try
            {
                if (filtermode == FilterAPIDataMode.ManagersOnly)
                    if (!obj.clients[i].isManager)
                        continue;
                if (filtermode == FilterAPIDataMode.NonManagers)
                    if (obj.clients[i].isManager)
                        continue;
                GameObject listitemn = Instantiate(ListItemPrefab, ListParent.transform);
                animators.Add(listitemn.GetComponent<Animator>());

                listitemn.transform.Find("Number").GetComponent<TextMeshProUGUI>().text = (i + 1).ToString();

                Transform labelPoint = listitemn.transform.Find("Label&Point");
                labelPoint.Find("Label").GetComponent<TextMeshProUGUI>().text = obj.clients[i].label;
                labelPoint.Find("Point").GetComponent<TextMeshProUGUI>().text = obj.data[obj.clients[i].id].points.ToString();
            }
            catch { }

            yield return null;
        }

        for (int i = 0; i < animators.Count; i++)
            animators[i].enabled = true;
    }

    public void onFilterChange(int filtermode)
    {
        StartCoroutine("FilterAPIData", (FilterAPIDataMode)filtermode);
    }
}

[Serializable]
public class jsonData
{
    public List<CompanyData> clients = new List<CompanyData>();

    public Dictionary<int, ClientsData> data = new Dictionary<int, ClientsData>();
    public string label;
}

[Serializable]
public class CompanyData
{
    public bool isManager;
    public int id;
    public string label;
}

[Serializable]
public class ClientsData
{
    public string address, name;
    public int points;
}
