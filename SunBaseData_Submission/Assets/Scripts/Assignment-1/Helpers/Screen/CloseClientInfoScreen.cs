using System;
using UnityEngine;
using UnityEngine.UI;

public class CloseClientInfoScreen : MonoBehaviour
{
    [SerializeField] KeyCode closekey;

    public void OnClose()
    {
        GetComponent<Button>().onClick.Invoke();
    }
    void Update()
    {
        if (Input.GetKeyDown(closekey))
        {
            OnClose();
        }
    }
}
