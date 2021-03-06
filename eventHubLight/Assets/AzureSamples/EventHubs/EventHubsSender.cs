﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Net;
using System.Net.Security;
using UnityEngine.UI;
using Microsoft.Azure.EventHubs;
using Microsoft.Azure.EventHubs.Amqp;
#if !UNITY_WSA || UNITY_EDITOR
//#if !WINDOWS_UWP
using System.Security.Cryptography.X509Certificates;
#endif

public class EventHubsSender : BaseEventHubs
{

    private static EventHubClient eventHubClient;
    
    [HideInInspector]
    public Text DebugText;


#if !UNITY_WSA || UNITY_EDITOR
    //#if !WINDOWS_UWP

    private class CustomCertificatePolicy : ICertificatePolicy
    {
        public bool CheckValidationResult(ServicePoint sp,
            X509Certificate certificate, WebRequest request, int error)
        {
            return true;
        }
    }
#endif

    // Use this for initialization
    public async void TestEventHubsSender()
    {
        Debug.Log("In TestEventHubsSender");

        try
        {
#if !UNITY_WSA || UNITY_EDITOR
            //#if !WINDOWS_UWP

            //Unity will complain that the following statement is deprecated
            //however, it's working :)
            ServicePointManager.CertificatePolicy = new CustomCertificatePolicy();
            
            //this 'workaround' seems to work for the .NET Storage SDK, but not here. Leaving this for clarity
            //ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
#endif

            var connectionStringBuilder = new EventHubsConnectionStringBuilder(EhConnectionString)
            {
                EntityPath = EhEntityPath
            };

            Debug.Log($"Endpoint> {connectionStringBuilder.Endpoint.ToString()}");
            Debug.Log($"EntityPath> {connectionStringBuilder.EntityPath.ToString()}");

            eventHubClient = EventHubClient.CreateFromConnectionString(connectionStringBuilder.ToString());
            Debug.Log($"EventHubName: {eventHubClient.EventHubName.ToString()}");

            await SendMessagesToEventHub(2);

        }
        catch (Exception ex)
        {
            Debug.Log($"ErrorNew: {ex} in EventHub!");
            //WriteLine(ex.Message);
        }
        finally
        {
            await eventHubClient.CloseAsync();
        }

    }

    // HACK - fix later
    public async void EventHubsSenderOff()
    {
        Debug.Log("In TestEventHubsSenderOff");

        // override for light to be always off
        LightState = false;

        try
        {
#if !UNITY_WSA || UNITY_EDITOR
            //#if !WINDOWS_UWP

            //Unity will complain that the following statement is deprecated
            //however, it's working :)
            ServicePointManager.CertificatePolicy = new CustomCertificatePolicy();

            //this 'workaround' seems to work for the .NET Storage SDK, but not here. Leaving this for clarity
            //ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
#endif

            var connectionStringBuilder = new EventHubsConnectionStringBuilder(EhConnectionString)
            {
                EntityPath = EhEntityPath
            };

            Debug.Log($"Endpoint> {connectionStringBuilder.Endpoint.ToString()}");
            Debug.Log($"EntityPath> {connectionStringBuilder.EntityPath.ToString()}");

            eventHubClient = EventHubClient.CreateFromConnectionString(connectionStringBuilder.ToString());
            Debug.Log($"EventHubName: {eventHubClient.EventHubName.ToString()}");

            await SendMessagesToEventHub(2);

        }
        catch (Exception ex)
        {
            Debug.Log($"ErrorNew: {ex} in EventHub!");
            //WriteLine(ex.Message);
        }
        finally
        {
            await eventHubClient.CloseAsync();
        }

    }

    // HACK - fix later
    public async void EventHubsSenderOn()
    {
        Debug.Log("In TestEventHubsSenderOff");

        // override for light to be always on
        LightState = true;

        try
        {
#if !UNITY_WSA || UNITY_EDITOR
            //#if !WINDOWS_UWP

            //Unity will complain that the following statement is deprecated
            //however, it's working :)
            ServicePointManager.CertificatePolicy = new CustomCertificatePolicy();

            //this 'workaround' seems to work for the .NET Storage SDK, but not here. Leaving this for clarity
            //ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
#endif

            var connectionStringBuilder = new EventHubsConnectionStringBuilder(EhConnectionString)
            {
                EntityPath = EhEntityPath
            };

            Debug.Log($"Endpoint> {connectionStringBuilder.Endpoint.ToString()}");
            Debug.Log($"EntityPath> {connectionStringBuilder.EntityPath.ToString()}");

            eventHubClient = EventHubClient.CreateFromConnectionString(connectionStringBuilder.ToString());
            Debug.Log($"EventHubName: {eventHubClient.EventHubName.ToString()}");

            await SendMessagesToEventHub(2);

        }
        catch (Exception ex)
        {
            Debug.Log($"ErrorNew: {ex} in EventHub!");
            //WriteLine(ex.Message);
        }
        finally
        {
            await eventHubClient.CloseAsync();
        }

    }

    // HACK
    public async void EventHubsFlash()
    {
        //Debug.Log("In TestEventHubsSender");

        try
        {
#if !UNITY_WSA || UNITY_EDITOR
            //#if !WINDOWS_UWP

            //Unity will complain that the following statement is deprecated
            //however, it's working :)
            ServicePointManager.CertificatePolicy = new CustomCertificatePolicy();

            //this 'workaround' seems to work for the .NET Storage SDK, but not here. Leaving this for clarity
            //ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
#endif

            var connectionStringBuilder = new EventHubsConnectionStringBuilder(EhConnectionString)
            {
                EntityPath = EhEntityPath
            };

            Debug.Log($"Endpoint> {connectionStringBuilder.Endpoint.ToString()}");
            Debug.Log($"EntityPath> {connectionStringBuilder.EntityPath.ToString()}");

            eventHubClient = EventHubClient.CreateFromConnectionString(connectionStringBuilder.ToString());
            Debug.Log($"EventHubName: {eventHubClient.EventHubName.ToString()}");

            int delay_ms = 200;
            int messagesToSend = 2;

            for (int i = 0; i < 5; ++i)
            {
                // turn on and off 01
                LightState = true;
                DataPacketStr = "01";
                await SendMessagesToEventHub(messagesToSend);
                await Task.Delay(delay_ms);

                LightState = false;
                DataPacketStr = "01";
                await SendMessagesToEventHub(messagesToSend);
                await Task.Delay(delay_ms);

                // turn on and off 04
                LightState = true;
                DataPacketStr = "04";
                await SendMessagesToEventHub(messagesToSend);
                await Task.Delay(delay_ms);

                LightState = false;
                DataPacketStr = "04";
                await SendMessagesToEventHub(messagesToSend);
                await Task.Delay(delay_ms);
            }


        }
        catch (Exception ex)
        {
            Debug.Log($"ErrorNew: {ex} in EventHub!");
            //WriteLine(ex.Message);
        }
        finally
        {
            await eventHubClient.CloseAsync();
        }

    }

    private async Task SendMessagesToEventHub(int numMessagesToSend)
    {
        for (var i = 0; i < numMessagesToSend; i++)
        {
            try
            {
                string message;
                if (LightState) // light on
                {
                    message = $"DMX:{DataPacketStr.ToString()}:1:255:{DateTime.Now}";
                }
                else // light off
                {
                    message = $"DMX:{DataPacketStr.ToString()}:1:0:{DateTime.Now}";
                }
                //WriteLine($"Sending message: {message}");
                Debug.Log($"Sending message: {message}");

                await eventHubClient.SendAsync(new EventData(Encoding.UTF8.GetBytes(message)));
            }
            catch (Exception exception)
            {
                //WriteLine($"{DateTime.Now} > Exception: {exception.Message}");
                Debug.Log($"{DateTime.Now} > Exception: {exception.Message}");
                //something happened so exit the loop
                break;
            }

            await Task.Delay(10);
        }

        //WriteLine($"{numMessagesToSend} messages sent.");
    }
}
