using UnityEngine;
using UnityEngine.AI;

public class SkeletonIA : MonoBehaviour
{
    public NavMeshAgent _agent;
// UnityEditor.TransformWorldPlacementJSON:{"position":{"x":-11.401252746582032,"y":2.561049461364746,"z":-0.12267494201660156},"rotation":{"x":-0.0033389870077371599,"y":0.6889145970344544,"z":0.0031631621532142164,"w":0.7248278856277466},"scale":{"x":1.0,"y":1.0,"z":1.0}}
    private Vector3[] _destinations = 
    {
        new(12, 0, -14),
        new(-12, 0, -14),
        new(-12, 0, 0),
        new(12, 0, -14),
        new(-12, 0, -14),
        new(11, 0, 1)
    };

    private int _select = 0;

    private bool destinationReached = false;

    private Animator _animator;
    private bool waitToMove = false;
    private float timer = 0;
    private float WaitTime = 5f;

    void Awake()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    // Point 1 : -14 0 -15 | Point Base : 11 0 1
    void FixedUpdate()
    {
        if (waitToMove)
        {
            _animator.SetFloat("speedh", 0);
            _animator.SetFloat("speedv", 0);
            //if timer is less than 10
            if (timer < WaitTime)
            {
                //add Time.deltaTime each time we hit this point
                timer += Time.deltaTime;
            }
            //no longer waiting because timer is greater than 10
            else
            { 

                waitToMove = false;
                timer = 0;
            }
        }
        else
        {
            if(_agent.hasPath)
            {
                var dir = (_agent.steeringTarget - transform.position).normalized;
                var animDir = transform.InverseTransformDirection(dir);
                
                _animator.SetFloat("speedh", animDir.x);
                _animator.SetFloat("speedv", animDir.z);
            }
            else
            {
                _animator.SetFloat("speedh", 0);
                _animator.SetFloat("speedv", 0);
            }


            if(destinationReached)
            {
                _select = (_select + 1) % _destinations.Length;
                destinationReached = false;
                _agent.SetDestination(_destinations[_select]);
                Debug.Log("Je change d'itinéraire !");
            }
            else
            {
                if (_agent.remainingDistance < 1)
                {
                    destinationReached = true;
                    waitToMove = true;
                    Debug.Log("J'ai atteint la destination !");
                }
            }
        }
    }
}
