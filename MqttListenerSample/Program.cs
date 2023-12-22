using System;
using System.Xml;

class Program
{
    static void Main()
    {

        // Default MQTT Broker informations
        // These informations are configurable in "config.xml"
        string brokerAddress = "192.168.10.10";
        int brokerPort = 1883;
        string topic = "your_topic";

        // Get MQTT Broker information from "config.xml" file
        try
        {
            string filePath = "config.xml";

            // Load the XML document
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);

            // Get the values from the XML elements
            brokerAddress = xmlDoc.SelectSingleNode("/config/broker_address").InnerText;
            topic = xmlDoc.SelectSingleNode("/config/topic").InnerText;
            brokerPort = int.Parse(xmlDoc.SelectSingleNode("/config/broker_port").InnerText);

            // Use the values as needed
            Console.WriteLine($"Broker Address: {brokerAddress}");
            Console.WriteLine($"Topic: {topic}");
            Console.WriteLine($"Broker Port: {brokerPort}");
        }
        catch (Exception ex)
        {
            // Handle exceptions
            Console.WriteLine($"Error: {ex.Message}");
        }

        // Create an instance of the MqttListener
        MqttListener mqttListener = new MqttListener(brokerAddress, brokerPort, topic);

        try
        {
            // Start the MQTT listener
            mqttListener.Start(topic);

            // Wait for user input to stop the listener
            Console.WriteLine("Press Enter to stop the MQTT listener.");
            Console.ReadLine();
        }
        finally
        {
            // Ensure the MQTT listener is stopped when done
            mqttListener.Stop();
        }
    }
}