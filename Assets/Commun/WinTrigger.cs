using System.Numerics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

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

        UnityEngine.Vector3 lastPosition = collider.transform.position;

        Instantiate(gameObject.AddComponent<AudioListener>(), lastPosition, new UnityEngine.Quaternion(0f, 0f, 0f, 0f));

        Destroy(collider.gameObject);

        SceneManager.LoadScene("EndLevel");
    }
}
