using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour
{
    private bool m_IsQuitting;
    public AudioClip aclip;

    void OnEnable()
    {
        EventBus.StartListening("Launch", Launch);
    }

    void OnApplicationQuit()
    {
        m_IsQuitting = true;
    }

    void OnDisable()
    {
        if (m_IsQuitting == false)
        {
            EventBus.StopListening("Launch", Launch);
        }
    }

    void Launch()
        {
            Debug.Log("Received a launch event : rocket launching!");
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = aclip;
            audio.Play();
        }
}
