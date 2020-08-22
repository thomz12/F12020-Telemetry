using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace F12020Telemetry
{
    /// <summary>
    /// Client receiving telemetry updates from the F1 2020 game.
    /// </summary>
    public class F12020TelemetryClient
    {
        private UdpClient _client;
        private IPEndPoint _endPoint;

        // Delegates
        public delegate void MotionDataReceiveDelegate(PacketMotionData packet);
        public delegate void SessionDataReceiveDelegate(PacketSessionData packet);
        public delegate void LapDataReceiveDelegate(PacketLapData packet);
        public delegate void EventDataReceiveDelegate(PacketEventData packet);
        public delegate void ParticipantsDataReceiveDelegate(PacketParticipantsData packet);
        public delegate void CarTelemetryReceiveDelegate(PacketCarTelemetryData packet);

        // Packet events
        public event MotionDataReceiveDelegate OnMotionDataReceive;
        public event SessionDataReceiveDelegate OnSessionDataReceive;
        public event LapDataReceiveDelegate OnLapDataReceive;
        public event EventDataReceiveDelegate OnEventDataReceive;
        public event ParticipantsDataReceiveDelegate OnParticipantsDataReceive;
        public event CarTelemetryReceiveDelegate OnCarTelemetryReceive;

        public bool Connected { get; private set; }

        /// <summary>
        /// Constructs telemetry client and sets it up for receiving data.
        /// </summary>
        /// <param name="port">The port to listen to. This should match the game setting.</param>
        public F12020TelemetryClient(int port)
        {
            _client = new UdpClient(port);
            _endPoint = new IPEndPoint(IPAddress.Any, port);

            // Start receiving updates.
            _client.BeginReceive(new AsyncCallback(ReceiveCallback), null);
        }

        private void ReceiveCallback(IAsyncResult result)
        {
            // Get data we received.
            byte[] data = _client.EndReceive(result, ref _endPoint);

            GCHandle handle = GCHandle.Alloc(data, GCHandleType.Pinned);

            try
            {
                PacketHeader header = (PacketHeader)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(PacketHeader));

                switch (header.packetId)
                {
                    case PacketID.MOTION:
                        PacketMotionData motionData = (PacketMotionData)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(PacketMotionData));
                        OnMotionDataReceive?.Invoke(motionData);
                        break;
                    case PacketID.SESSION:
                        PacketSessionData sessionData = (PacketSessionData)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(PacketSessionData));
                        OnSessionDataReceive?.Invoke(sessionData);
                        break;
                    case PacketID.LAP_DATA:
                        PacketLapData lapData = (PacketLapData)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(PacketLapData));
                        OnLapDataReceive?.Invoke(lapData);
                        break;
                    case PacketID.EVENT:
                        PacketEventData eventData = (PacketEventData)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(PacketEventData));
                        OnEventDataReceive?.Invoke(eventData);
                        break;
                    case PacketID.PARTICIPANTS:
                        PacketParticipantsData participantsData = (PacketParticipantsData)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(PacketParticipantsData));
                        OnParticipantsDataReceive?.Invoke(participantsData);
                        break;
                    case PacketID.CAR_SETUPS:
                        break;
                    case PacketID.CAR_TELEMETRY:
                        PacketCarTelemetryData telemetryData = (PacketCarTelemetryData)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(PacketCarTelemetryData));
                        OnCarTelemetryReceive?.Invoke(telemetryData);
                        break;
                    case PacketID.CAR_STATUS:
                        break;
                    case PacketID.FINAL_CLASSIFICATION:
                        break;
                    case PacketID.LOBBY_INFO:
                        break;
                }
            }
            finally
            {
                handle.Free();
            }

            // Start receiving again.
            _client.BeginReceive(new AsyncCallback(ReceiveCallback), null);
        }
    }
}
