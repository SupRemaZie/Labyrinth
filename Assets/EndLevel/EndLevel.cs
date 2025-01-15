using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class EndLevel : MonoBehaviour
{
    [SerializeField]
    public string _level;

    public void OnHomeClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnRetryClicked()
    {
        SceneManager.LoadScene(_level);
    }

    public void OnNextClicked()
    {
        char lastcaracter = _level[^1];
        int level = (int)char.GetNumericValue(lastcaracter);
        SceneManager.LoadScene("Level_" + (level + 1));
    }
}
