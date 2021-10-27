using UnityEngine;
public class Arrow : MonoBehaviour
{
    private bool m_IsQuitting;
    private bool m_IsLaunched = false;
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
        if (m_IsLaunched == false)
        {
            m_IsLaunched = true;
            Debug.Log("Received a launch event : shooting arrow!");
        }
    }
}
