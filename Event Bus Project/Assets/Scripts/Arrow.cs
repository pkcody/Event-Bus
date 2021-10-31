using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour
{
    private bool m_IsQuitting;
    public AudioClip aclip;
    void OnEnable()
    {
        EventBus.StartListening("Shoot Arrow", ShootArrow);
    }
    void OnApplicationQuit()
    {
        m_IsQuitting = true;
    }
    void OnDisable()
    {
        if (m_IsQuitting == false)
        {
            EventBus.StopListening("Shoot Arrow", ShootArrow);
        }
    }
    void ShootArrow()
    {
        Debug.Log("Received a launch event : shooting arrow!");
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = aclip;
        audio.Play();
        
    }
}
