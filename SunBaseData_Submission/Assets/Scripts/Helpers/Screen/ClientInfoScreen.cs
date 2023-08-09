using UnityEngine;
using DG.Tweening;
using TMPro;

public class ClientInfoScreen : MonoBehaviour
{
    public static ClientInfoScreen Instance { get; private set; }

    [SerializeField] GameObject screen;
    [SerializeField] TextMeshProUGUI nametmp, pointstmp, addresstmp;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    public void showClientInfo(string name, int points, string address)
    {
        nametmp.text = name;
        pointstmp.text = points.ToString();
        addresstmp.text = address;
        screen.transform.localScale = Vector3.zero;
        screen.SetActive(true);
        screen.transform.DOScale(1.2f, 1).SetEase(Ease.OutBack);
    }

    public void closeClientInfo()
    {
        screen.transform.DOScale(0, 1).SetEase(Ease.InBack).onComplete = closedialog;
    }

    void closedialog()
    {
        screen.SetActive(false);
    }
}
