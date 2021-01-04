# F1 2020 Telemetry 
Receives and parses all telemetry packets from the F1 2020 game.
More info on the packets can be find in the UDP specification: https://forums.codemasters.com/topic/50942-f1-2020-udp-specification/ 

# Note
UDP telemetry must be turned on in the game for this to work. By default this is turned off. Find the telemetry settings in:

`Game Options > Settings > Telemetry Settings`

In here, turn on `UDP Telemetry` to `On`. By default the port is `20777`.

# Usage
To receive events, you have to create a `F12020TelemetryClient`. Here's an example:
```C#
// Create the client listening on port 20777.
F12020TelemetryClient client = new F12020TelemetryClient(20777);

// Hook to the telemetry event.
client.OnCarTelemetryDataReceive += TelemetryUpdate;
```

There is also a way to tell when we start and stop receiving updates:
```C#
  // Hook to the connection change event.
  client.OnConnectStatusChanged += OnConnectStatusChange;
```

There is a simple console application example showing the car telemetry data of the player.
![Alt text](telemetry-example.gif?raw=true "Console example")
