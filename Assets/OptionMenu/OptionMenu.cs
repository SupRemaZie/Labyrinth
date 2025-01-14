using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionMenu : MonoBehaviour
{
    public void OnSaveClicked()
    {
        // Save the options
        SceneManager.LoadScene(0);
    }

    public void OnCancelClicked()
    {
        SceneManager.LoadScene(0);
    }
}
