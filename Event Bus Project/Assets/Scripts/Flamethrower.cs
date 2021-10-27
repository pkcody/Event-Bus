using UnityEngine;
public class Flamethrower : MonoBehaviour
{
    private bool m_IsQuitting;
    void OnEnable()
    {
        EventBus.StartListening("Flame", Flame);
    }
    void OnApplicationQuit()
    {
        m_IsQuitting = true;
    }
    void OnDisable()
    {
        if (m_IsQuitting == false)
        {
            EventBus.StopListening("Flame", Flame);
        }
    }
    void Flame()
    {
        Debug.Log("Received a shoot event : flaming!");
    }
}