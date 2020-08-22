using System.Runtime.InteropServices;

namespace F12020Telemetry
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct EventFastestLap
    {
        /// <summary>
        /// Vehicle index of car achieving fastest lap
        /// </summary>
        public byte vehicleIdx;

        /// <summary>
        /// Lap time is in seconds
        /// </summary>
        public float lapTime;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct EventRetirement
    {
        /// <summary>
        /// Vehicle index of car retiring
        /// </summary>
        public byte vehicleIdx;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct EventTeamMateInPits
    {
        /// <summary>
        /// Vehicle index of team mate
        /// </summary>
        public byte vehicleIdx;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct EventRaceWinner
    {
        /// <summary>
        /// Vehicle index of the race winner
        /// </summary>
        public byte vehicleIdx;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct EventPenalty
    {
        /// <summary>
        /// Penalty type
        /// </summary>
        public PenaltyType penaltyType;

        /// <summary>
        /// Infringement type – see https://forums.codemasters.com/topic/54423-f1%C2%AE-2020-udp-specification/
        /// </summary>
        public byte infringementType;

        /// <summary>
        /// Vehicle index of the car the penalty is applied to
        /// </summary>
        public byte vehicleIdx;

        /// <summary>
        /// Vehicle index of the other car involved
        /// </summary>
        public byte otherVehicleIdx;

        /// <summary>
        /// Time gained, or time spent doing action in seconds
        /// </summary>
        public byte time;

        /// <summary>
        /// Lap the penalty occurred on
        /// </summary>
        public byte lapNum;

        /// <summary>
        /// Number of places gained by this
        /// </summary>
        public byte placesGained;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct EventSpeedTrap
    {
        /// <summary>
        /// Vehicle index of the vehicle triggering speed trap
        /// </summary>
        public byte vehicleIdx;

        /// <summary>
        /// Top speed achieved in kilometres per hour
        /// </summary>
        public float speed;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct EventDataDetails
    {
        [FieldOffset(0)]
        public EventFastestLap fastestLap;

        [FieldOffset(0)]
        public EventRetirement retirement;

        [FieldOffset(0)]
        public EventTeamMateInPits teamMateInPits;

        [FieldOffset(0)]
        public EventRaceWinner raceWinner;

        [FieldOffset(0)]
        public EventPenalty penalty;

        [FieldOffset(0)]
        public EventSpeedTrap speedTrap;
    }

    /// <summary>
    /// This packet gives details of events that happen during the course of a session.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketEventData
    {
        /// <summary>
        /// Header
        /// </summary>
        public PacketHeader header;

        /// <summary>
        /// Event string code
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        char[] eventStringCode;

        /// <summary>
        /// Event details, use <see cref="eventStringCode"/> to determine which event to pick.
        /// </summary>
        EventDataDetails eventDataDetails;
    }
}
