
using UnityEngine;
using UnityEngine.Rendering;


public class tigerMoove : MonoBehaviour
{   
    //Animator anim; 
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
            
    
        tiger.transform.SetPositionAndRotation(Vector3.MoveTowards(tiger.transform.position, ball.transform.position, speed * Time.deltaTime), Quaternion.Slerp(tiger.transform.rotation, rotation, Time.deltaTime * 5f));

        
        if (Vector3.Distance(tiger.transform.position, ball.transform.position) < 0.1f)
            {
                tiger.transform.position = ball.transform.position; 
                
            }
    }
}
