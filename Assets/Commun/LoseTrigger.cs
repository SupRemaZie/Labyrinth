using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class LoseTrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] public float respawnX;  
    [SerializeField] public float respawnY;     
    [SerializeField] public float respawnZ;      
    [SerializeField] UnityEvent onTriggerEnter;
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
        if (collider.CompareTag("Ball"))
        {
            collider.transform.position = new Vector3(respawnX, respawnY, respawnZ);
        }
    }
}
