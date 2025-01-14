using UnityEngine;
using UnityEngine.Events;

public class WinTrigger : MonoBehaviour
{

    [SerializeField] UnityEvent onTriggerEnter;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        onTriggerEnter.Invoke();
    }
}
