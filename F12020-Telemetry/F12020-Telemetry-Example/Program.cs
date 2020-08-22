using System;
using System.IO.Ports;
using System.Threading;
using F12020Telemetry;

namespace F12020TelemetryExample
{
    class Program
    {
        private static SerialPort _serialPort;

        static void Main(string[] args)
        {
            F12020TelemetryClient client = new F12020TelemetryClient(20777);

            _serialPort = new SerialPort();
            _serialPort.PortName = "COM3";
            _serialPort.BaudRate = 9600;
            _serialPort.Open();

            Console.WriteLine("Listening for F1 2020...");

            client.OncarTelemetryDataReceive += (telemetry) =>
            {
                Console.SetCursorPosition(0, 0);

                int playerIndex = telemetry.Header.playerCarIndex;

                CarTelemetryData data = telemetry.carTelemetryData[playerIndex];

                Console.WriteLine($"Throttle: {data.throttle}                ");
                Console.WriteLine($"Brake: {data.brake}                      ");
                Console.WriteLine($"Wheel: {data.steer}                      ");
                Console.WriteLine($"Speed: {data.speed}                      ");
                Console.WriteLine($"RPM: {data.engineRPM}                    ");
                Console.WriteLine($"REV %: {data.revLightsPercent}           ");
                Console.WriteLine($"Gear: {data.gear} (suggested: {telemetry.suggestedGear})                      ");
                Console.WriteLine($"DRS: {(data.drs == 1 ? "open" : "closed")}                  ");
                Console.WriteLine($"Engine Temp: {data.engineTemperature}                       ");
                Console.WriteLine($"Session Time: {TimeSpan.FromSeconds(telemetry.Header.sessionTime)}        ");

                //_serialPort.Write(new byte[] { (byte)data.gear }, 0, 1);

                byte[] speed = BitConverter.GetBytes(data.speed);

                _serialPort.Write(new byte[]
                {
                    (byte)data.gear,
                    speed[0], speed[1],
                    data.revLightsPercent
                }, 0, 4);
            };

            Console.ReadLine();
        }
    }
}
