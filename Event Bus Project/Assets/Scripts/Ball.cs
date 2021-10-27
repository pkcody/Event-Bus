using UnityEngine;
public class Ball : MonoBehaviour
{
    private bool m_IsQuitting;
    private bool m_IsLaunched = false;
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
        if (m_IsLaunched == false)
        {
            m_IsLaunched = true;
            Debug.Log("Received a launch event : dropping ball!");
        }
    }
}
