using HoloToolkit.Unity.InputModule;
using System.Collections.Generic;
using UnityEngine;

public class LightDetectClick : MonoBehaviour, IInputClickHandler //, IInputHandler // right click error and say implement interface
{
    public void OnInputClicked(InputClickedEventData eventData) // used to be OnInputClicked(InputEventData eventData)
    {
        Debug.Log("Light Clicked on");

        string LightName = gameObject.name.ToString();
        string LightNameID = (LightName.Substring(LightName.Length - 2)); // Last two digits

        Debug.Log(LightNameID);

        // Set up Event Hub message
        EventHubsSender eventHubsSender = gameObject.GetComponent<EventHubsSender>();
        //EventHubsSender eventHubsSender = gameObject.AddComponent<EventHubsSender>();

        // set up handler to send out event
        //GameObject eventHubsSender = GameObject.Instantiate(EventHubsSender);

        // Populate data
        eventHubsSender.EhConnectionString = "Endpoint=sb://oseventhub.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=YwRx2oOuw4JIx8C3AKq0qRWRa8j6Urj8ax21u93vKxk=";
        eventHubsSender.EhEntityPath = "HoloLensCmds";
        eventHubsSender.DataPacketStr = LightNameID;
        eventHubsSender.LightState = !eventHubsSender.LightState; // toggle on/off

        // Send event
        Debug.Log("Call TestEventHubsSender");

        eventHubsSender.TestEventHubsSender();

    }

#if false
    public void OnInputDown(InputEventData eventData)
    {
        Debug.Log("Input Down");
    }

    public void OnInputUp(InputEventData eventData)
    {
        Debug.Log("Input Up");
    }
#endif


}