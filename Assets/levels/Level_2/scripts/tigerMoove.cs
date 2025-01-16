using UnityEngine;

public class tigerMoove : MonoBehaviour
{
    public GameObject targetObject; 
  
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixUpdate()
    {
        if (targetObject != null)
        {
            // Get the position of the target object
            Vector3 position = targetObject.transform.position;

            // Print the position to the console
            Debug.Log("Target Position: " + position);
        }
    }
}
