# MQTT Listener Documentation

This project is a simple MQTT listener that allows you to subscribe to a specific topic on a broker and receive MQTT messages. The program is written in C# and consists of two classes: `Program` and `MqttListener`.

## Program Class

The `Program` class serves as the main entry point for the application. It reads the configuration for the MQTT broker from a file named `config.xml`. The configuration includes the broker's IP address, port, and the topic to subscribe to. The values are then used to instantiate an instance of the `MqttListener` class.

### Configuration File (config.xml)

```xml
<config>
    <broker_address>192.168.1.10</broker_address>
    <broker_port>1883</broker_port>
    <topic>MyTopic</topic>
</config>
```

### Usage
1. Open the `Program.cs` file.
2. Replace the placeholder values in the config.xml file with the actual configuration details for your MQTT broker. 
3. Run the program.

## MqttListener Class
The `MqttListener` class is responsible for connecting to the MQTT broker, subscribing to the specified topic, and handling incoming messages.

### Dependencies 

This project uses the following libraries, which are included in the `M2Mqtt.dll` assembly:

```
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
```

### Usage

Instantiate an object of the `MqttListener` class in the `Program` class.
Call the `Start` method to connect to the broker and start listening for messages.
Implement additional logic in the `Client_MqttMsgPublishReceived` event handler to manage the received messages.

```
MqttListener mqttListener = new MqttListener(brokerAddress, brokerPort, topic);
mqttListener.Start(topic);
```

## Note

This documentation serves as a basic guide, and you can expand the functionality of the program by adding more features and message handling capabilities based on your project's needs.