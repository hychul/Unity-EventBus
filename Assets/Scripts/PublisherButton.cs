using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublisherButton : MonoBehaviour
{
    public void OnClickString(string message)
    {
        EventBus.Publish<string>(EventConfig.TEST_EVENT, message);
    }

    public void OnClickInt(int message)
    {
        EventBus.Publish<int>(EventConfig.TEST_EVENT, message);
    }
}
