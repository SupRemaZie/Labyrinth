using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    Timer timer;
    public void OnPlayClicked()
    {
        SceneManager.LoadScene(2);
    }

    public void OnOptionsClicked()
    {
        SceneManager.LoadScene(1);
    }

    public void OnQuitClicked()
    {   
        Destroy(timer);
        Application.Quit();
        
    }
}
