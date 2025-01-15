using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class LoseTrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float respawnX = -5.42f;  
    public float respawnY = 1.5f;     
    public float respawnZ = 5.1f;      
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
