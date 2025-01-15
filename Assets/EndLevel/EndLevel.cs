using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class EndLevel : MonoBehaviour
{
    [SerializeField]
    public int _level;

    public void OnHomeClicked()
    {
        SceneManager.LoadScene(0);
    }

    public void OnRetryClicked()
    {
        SceneManager.LoadScene(_level);
    }

    public void OnNextClicked()
    {
        SceneManager.LoadScene(_level + 1);
    }
}
