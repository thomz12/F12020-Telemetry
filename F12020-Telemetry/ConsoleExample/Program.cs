using F12020Telemetry;
using System;

namespace ConsoleExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Listening for F1 2020...");

            // Create the client listening on port 20777. (default port)
            F12020TelemetryClient client = new F12020TelemetryClient(20777);

            // Hook to the telemetry event.
            client.OnCarTelemetryDataReceive += TelemetryUpdate;

            // Hook to the connection change event.
            client.OnConnectStatusChanged += OnConnectStatusChange;

            Console.CursorVisible = false;
            Console.Read();
        }

        /// <summary>
        /// Called whenever the connection status is changed.
        /// </summary>
        /// <param name="connected">The connection status. True if connected, false otherwise.</param>
        private static void OnConnectStatusChange(bool connected)
        {
            if (!connected)
            {
                // Clear the console when not connected and show message.
                Console.Clear();
                Console.WriteLine("Listening for F1 2020...");
            }
        }

        /// <summary>
        /// Called whenever a telemetry update is received.
        /// </summary>
        /// <param name="packet">Packet with telemetry data.</param>
        private static void TelemetryUpdate(PacketCarTelemetryData packet)
        {
            // The player index.
            int playerIndex = packet.Header.playerCarIndex;

            // Player car telemetry.
            CarTelemetryData playerData = packet.carTelemetryData[playerIndex];

            Console.SetCursorPosition(0, 0);

            // Write information to console.
            WriteLine($"Throttle: {playerData.throttle}");
            WriteLine($"Brake: {playerData.brake}");
            WriteLine($"Wheel: {playerData.steer}");
            WriteLine($"Speed: {playerData.speed}");
            WriteLine($"RPM: {playerData.engineRPM}");
            WriteLine($"REV %: {playerData.revLightsPercent}");
            WriteLine($"Gear: {playerData.gear} (suggested: {packet.suggestedGear})");
            WriteLine($"DRS: {(playerData.drs == 1 ? "open" : "closed")}");
            WriteLine($"Engine Temp: {playerData.engineTemperature}");
            WriteLine($"Session Time: {TimeSpan.FromSeconds(packet.Header.sessionTime)}");
        }

        /// <summary>
        /// Write a line to the console.
        /// </summary>
        /// <param name="input">The string to write.</param>
        private static void WriteLine(string input)
        {
            // Pad the string with spaces so it will override previous characters.
            Console.Write(input.PadRight(Console.WindowWidth, ' '));
        }
    }
}
