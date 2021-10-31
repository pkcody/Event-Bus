using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour
{
    private bool m_IsQuitting;
    public AudioClip aclip;
    
    void OnEnable()
    {
        EventBus.StartListening("Shoot", Shoot);
    }
    void OnApplicationQuit()
    {
        m_IsQuitting = true;
    }
    void OnDisable()
    {
        if (m_IsQuitting == false)
        {
            EventBus.StopListening("Shoot", Shoot);
        }
    }
    void Shoot()
    {
        Debug.Log("Received a shoot event : shooting cannon!");

        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = aclip;
        audio.Play();
    }
}