using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void OnPlayClicked()
    {
        SceneManager.LoadScene(1);
    }

    public void OnOptionsClicked()
    {
        Debug.Log("Ouvrir Options");
    }

    public void OnQuitClicked()
    {
        Application.Quit();
    }
}
