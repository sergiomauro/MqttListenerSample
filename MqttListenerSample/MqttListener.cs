using System;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

/// <summary>
/// This class provides an example of an MQTT listener in C# using the M2Mqtt client library.
/// </summary>
/// <remarks>
/// Author: Sergio Mauro
/// License: MIT (See accompanying LICENSE file for details)
/// </remarks>
class MqttListener
{
    private MqttClient client;

    /// <summary>
    /// Initializes a new instance of the <see cref="MqttListener"/> class.
    /// </summary>
    /// <param name="brokerAddress">The address of the MQTT broker.</param>
    /// <param name="brokerPort">The port of the MQTT broker.</param>
    /// <param name="topic">The MQTT topic to subscribe to.</param>
    public MqttListener(string brokerAddress, int brokerPort, string topic)
    {
        try
        {
            client = new MqttClient(brokerAddress, brokerPort, false, null, null, null);
            client.MqttMsgPublishReceived += Client_MqttMsgPublishReceived;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    /// <summary>
    /// Starts the MQTT listener.
    /// </summary>
    public void Start(string topic)
    {
        try
        {
            if (client != null) { 

                // Connect to the MQTT broker
                client.Connect(Guid.NewGuid().ToString());

                // Subscribe to the specified topic
                client.Subscribe(new string[] { topic }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });

                Console.WriteLine($"Listening for messages on topic: {topic}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            // Here you can handle the exception appropriately
        }
    }

    /// <summary>
    /// Event handler for the MQTT message received event.
    /// </summary>
    /// <param name="sender">The object that triggered the event.</param>
    /// <param name="e">The MQTT message event arguments.</param>
    private void Client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
    {
        // Handle received message
        string message = Encoding.UTF8.GetString(e.Message);
        Console.WriteLine($"Received message: {message}");
    }

    /// <summary>
    /// Stops the MQTT listener and disconnects from the broker.
    /// </summary>
    public void Stop()
    {
        if (client != null)
        {
            if (client.IsConnected)
                client.Disconnect();
        }
    }
}