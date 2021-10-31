using UnityEngine.Events;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EventBus : Singleton<EventBus>
{
    private Dictionary<string, UnityEvent> m_EventDictionary;

    int numEvents;
    bool isQue = false;
    private List<string> eventQue;
    private float delay = 1f;

    public override void Awake()
    {
        base.Awake();
        Instance.Init();
    }
    private void Init()
    {
        if (Instance.m_EventDictionary == null)
        {
            Instance.m_EventDictionary = new Dictionary<string, UnityEvent>();
        }
        if (Instance.eventQue == null)
        {
            Instance.eventQue = new List<string>();
        }
    }

    public static void AddEvent(string eventName)
    {
        Instance.eventQue.Add(eventName);
        Instance.numEvents++;
    }

    public IEnumerator RunEvent()
    {
        yield return new WaitForSeconds(delay);
        while (numEvents > 0)
        {
            TriggerEvent(Instance.eventQue[0]);
            Instance.eventQue.RemoveAt(0);
            Instance.numEvents--;
            yield return new WaitForSeconds(delay);
        }
        isQue = false;
    }
   
    public static void StartListening(string eventName, UnityAction
    listener)
    {
        UnityEvent thisEvent = null;
        if (Instance.m_EventDictionary.TryGetValue(eventName, out
        thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            Instance.m_EventDictionary.Add(eventName, thisEvent);
        }
    }
    public static void StopListening(string eventName, UnityAction
    listener)
    {
        UnityEvent thisEvent = null;
        if (Instance.m_EventDictionary.TryGetValue(eventName, out
        thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }
    public static void TriggerEvent(string eventName)
    {
        UnityEvent thisEvent = null;
        if (Instance.m_EventDictionary.TryGetValue(eventName, out
        thisEvent))
        {
            thisEvent.Invoke();
        }
    }

    public void Update()
    {
        if (isQue == false && numEvents > 0)
        {
            StartCoroutine("RunEvent");
            isQue = true;
        }
    }
}