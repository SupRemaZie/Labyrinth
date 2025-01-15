using System.Numerics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class WinTrigger : MonoBehaviour
{

    [SerializeField] UnityEvent onTriggerEnter;

    private bool _isAudioListenerRespawned;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _isAudioListenerRespawned = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDisable()
    {
        PlayerPrefs.SetString("level", SceneManager.GetActiveScene().name);
    }

    void OnTriggerEnter(Collider collider)
    {
        onTriggerEnter.Invoke();

        UnityEngine.Vector3 lastPosition = collider.transform.position;

        if(!_isAudioListenerRespawned)
        {
            Instantiate(gameObject.AddComponent<AudioListener>(), lastPosition, new UnityEngine.Quaternion(0f, 0f, 0f, 0f));
            _isAudioListenerRespawned = true;
        }

        Destroy(collider.gameObject);

        SceneManager.LoadScene("EndLevel");
    }
}
