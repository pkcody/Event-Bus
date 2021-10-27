using UnityEngine;
public class EventPublisher : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown("s"))
        {
            EventBus.TriggerEvent("Shoot");
        }
        if (Input.GetKeyDown("l"))
        {
            EventBus.TriggerEvent("Launch");
        }
        if (Input.GetKeyDown("a"))
        {
            EventBus.TriggerEvent("Shoot Arrow");
        }
        if (Input.GetKeyDown("o"))
        {
            EventBus.TriggerEvent("Flame");
        }
        if (Input.GetKeyDown("d"))
        {
            EventBus.TriggerEvent("Drop");
        }
    }
}