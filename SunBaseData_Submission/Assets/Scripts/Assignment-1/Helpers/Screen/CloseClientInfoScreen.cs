using UnityEngine;
using UnityEngine.UI;

public class CloseClientInfoScreen : MonoBehaviour
{
    [SerializeField] KeyCode closekey;
    void Update()
    {
        if (Input.GetKeyDown(closekey))
        {
            GetComponent<Button>().onClick.Invoke();
        }
    }
}
