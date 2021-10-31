using UnityEngine;
public class Ball : MonoBehaviour
{
    private bool m_IsQuitting;
    public AudioClip aclip;

    void OnEnable()
    {
        EventBus.StartListening("Drop", Drop);
    }
    void OnApplicationQuit()
    {
        m_IsQuitting = true;
    }
    void OnDisable()
    {
        if (m_IsQuitting == false)
        {
            EventBus.StopListening("Drop", Drop);
        }
    }
    void Drop()
    {
        Debug.Log("Received a launch event : dropping ball!");
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = aclip;
        audio.Play();
    }
}
