using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float elapsedTime; 
    public TMP_Text chronometerText;
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        // Convertir le temps écoulé en minutes et secondes
        int minutes = Mathf.FloorToInt(elapsedTime / 60F);
        int seconds = Mathf.FloorToInt(elapsedTime % 60F);

        // Formater le texte
        chronometerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
