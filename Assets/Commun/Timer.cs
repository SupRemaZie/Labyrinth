using UnityEngine;
using TMPro;



public class Timer : MonoBehaviour
{

    [Header("Chronometer Settings")]
    private float elapsedTime=0f; 
    private bool isRunning = false;

    [Header("UI")]
    public TMP_Text chronometerText;
    
    void Start()
    {   
        StartChronometer();
    }


    void FixedUpdate()
    {
        // Debug.Log(isRunning);
        if(isRunning){
            elapsedTime += Time.deltaTime;
            UpdateChronometerText();
        }

    }

    void OnDisable()
    {
        PlayerPrefs.SetString("timer", chronometerText.text);
    }

      private void UpdateChronometerText()
    {
        if (chronometerText != null)
        {
            int minutes = Mathf.FloorToInt(elapsedTime / 60F);
            int seconds = Mathf.FloorToInt(elapsedTime % 60F);
            chronometerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
      public void StartChronometer()
    {
        isRunning = true;
        Debug.Log("Chronometer started!");
    }

    public void StopTimer() {
        isRunning = false;
        Debug.Log("Chronometer stopped!");
    }
      public void ResetChronometer()
    {
        elapsedTime = 0f;
        UpdateChronometerText();
        Debug.Log("Chronometer reset!");
    }
    
}
