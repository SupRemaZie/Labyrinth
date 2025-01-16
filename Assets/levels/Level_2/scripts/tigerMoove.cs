
using UnityEngine;
using UnityEngine.Rendering;


public class tigerMoove : MonoBehaviour
{
    public GameObject tiger; 
    public GameObject ball; 
    public float speed ;
  
  
    

    void Start()
    {
      
    }

    
    void Update()
    {
        Vector3 direction = ball.transform.position - tiger.transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction); 
        tiger.transform.rotation = Quaternion.Slerp(tiger.transform.rotation, rotation, Time.deltaTime * speed);
      
    }
}
