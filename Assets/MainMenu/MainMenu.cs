using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    Timer timer;
    public void OnPlayClicked()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void OnOptionsClicked()
    {
        SceneManager.LoadScene("OptionMenu");
    }

    public void OnQuitClicked()
    {
        Destroy(timer);
        Application.Quit();
    }
}
