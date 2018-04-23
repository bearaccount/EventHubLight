using HoloToolkit.Unity.InputModule;
using System.Collections.Generic;
using UnityEngine;

#if false
using System.Collections;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Net;
using System.Net.Security;
using UnityEngine.UI;
using Microsoft.Azure.EventHubs;
using Microsoft.Azure.EventHubs.Amqp;
#if !UNITY_WSA
using System.Security.Cryptography.X509Certificates;
#endif
#endif


public class FlashLights : MonoBehaviour, IInputClickHandler // right click error and say implement interface
{

    public void OnInputClicked(InputClickedEventData eventData) // used to be OnInputClicked(InputEventData eventData)
    {
        //throw new System.NotImplementedException();
        Debug.Log("Air Tap!");

        // Try Adding component
        EventHubsSender eventHubsSender = gameObject.GetComponent<EventHubsSender>();

        // set up handler to send out event
        //GameObject eventHubsSender = GameObject.Instantiate(EventHubsSender);

        eventHubsSender.EhConnectionString = "Endpoint=sb://oseventhub.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=YwRx2oOuw4JIx8C3AKq0qRWRa8j6Urj8ax21u93vKxk=";
        eventHubsSender.EhEntityPath = "HoloLensCmds";
        // Send event
        Debug.Log("Call TestEventHubsSender");

        eventHubsSender.EventHubsFlash();
    }

    void Start()
    {
        // Not sure what this does????
        InputManager.Instance.PushFallbackInputHandler(gameObject);

    }

    void Update()
    {
    }



}