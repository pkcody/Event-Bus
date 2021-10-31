using UnityEngine;
public class EventPublisher : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown("s"))
        {
            EventBus.AddEvent("Shoot");
        }
        if (Input.GetKeyDown("l"))
        {
            EventBus.AddEvent("Launch");
        }
        if (Input.GetKeyDown("a"))
        {
            EventBus.AddEvent("Shoot Arrow");
        }
        if (Input.GetKeyDown("o"))
        {
            EventBus.AddEvent("Flame");
        }
        if (Input.GetKeyDown("d"))
        {
            EventBus.AddEvent("Drop");
        }
    }
}