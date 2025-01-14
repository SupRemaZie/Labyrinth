using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    Timer timer;
    public void OnPlayClicked()
    {
        SceneManager.LoadScene(1);
        timer.StartChronometer();
    }

    public void OnOptionsClicked()
    {
        Debug.Log("Ouvrir Options");
    }

    public void OnQuitClicked()
    {   
        Destroy(timer);
        Application.Quit();
        
    }
}
