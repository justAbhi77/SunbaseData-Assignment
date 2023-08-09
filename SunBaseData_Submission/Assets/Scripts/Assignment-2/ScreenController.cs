using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenController : MonoBehaviour
{
    [SerializeField] GameObject loadingscreen;
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(.5f);

        loadingscreen.SetActive(false);
    }

    public void onRestartBtn()
    {
        loadingscreen.SetActive(true);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
