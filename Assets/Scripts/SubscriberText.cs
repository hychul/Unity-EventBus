using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class SubscriberText : MonoBehaviour
{
    public enum SupportEvent
    {
        String,
        Int,
    }

    [SerializeField]
    private SupportEvent supportEvent;

    private Text _text;

    void Awake()
    {
        _text = GetComponent<Text>();

        switch (supportEvent)
        {
            case SupportEvent.String:
                EventBus.Subscribe<string>(EventConfig.TEST_EVENT, OnEventString);
                break;
            case SupportEvent.Int:
                EventBus.Subscribe<int>(EventConfig.TEST_EVENT, OnEvnetInt);
                break;
        }
    }

    void OnDestroy()
    {
        switch (supportEvent)
        {
            case SupportEvent.String:
                EventBus.Unsubscribe<string>(EventConfig.TEST_EVENT, OnEventString);
                break;
            case SupportEvent.Int:
                EventBus.Unsubscribe<int>(EventConfig.TEST_EVENT, OnEvnetInt);
                break;
        }
    }

    void OnEventString(string message)
    {
        _text.text = message;
    }

    void OnEvnetInt(int message)
    {
        _text.text = message.ToString();
    }
}
