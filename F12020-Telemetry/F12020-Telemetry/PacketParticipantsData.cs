using System.Runtime.InteropServices;

namespace F12020Telemetry
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ParticipantData
    {
        /// <summary>
        /// Whether the vehicle is AI (1) or Human (0) controlled
        /// </summary>
        byte aiControlled;

        /// <summary>
        /// Driver id - see appendix
        /// </summary>
        byte driverId;

        /// <summary>
        /// Team id - see appendix
        /// </summary>
        byte teamId;

        /// <summary>
        /// Race number of the car
        /// </summary>
        byte raceNumber;

        /// <summary>
        /// Nationality of the driver
        /// </summary>
        byte nationality;

        /// <summary>
        /// Name of participant in UTF-8 format – null terminated
        /// Will be truncated with … (U+2026) if too long
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
        char[] name;

        /// <summary>
        /// The player's UDP setting, 0 = restricted, 1 = public
        /// </summary>
        byte yourTelemetry;
    }

    /// <summary>
    /// This is a list of participants in the race.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketParticipantsData
    {
        /// <summary>
        /// Header
        /// </summary>
        public PacketHeader header;

        /// <summary>
        /// Number of active cars in the data – should match number of cars on HUD
        /// </summary>
        public byte numActiveCars;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        public ParticipantData[] participants;
    }
}
