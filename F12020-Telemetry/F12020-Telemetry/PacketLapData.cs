using System.Runtime.InteropServices;

namespace F12020Telemetry
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct LapData
    {
        /// <summary>
        /// Last lap time in seconds
        /// </summary>
        public float lastLapTime;

        /// <summary>
        /// Current time around the lap in seconds
        /// </summary>
        public float currentLapTime;

        /// <summary>
        /// Sector 1 time in milliseconds
        /// </summary>
        public ushort sector1TimeInMS;

        /// <summary>
        /// Sector 2 time in milliseconds
        /// </summary>
        public ushort sector2TimeInMS;

        /// <summary>
        /// Best lap time of the session in seconds
        /// </summary>
        public float bestLapTime;

        /// <summary>
        /// Lap number best time achieved on
        /// </summary>
        public byte bestLapNum;

        /// <summary>
        /// Sector 1 time of best lap in the session in milliseconds
        /// </summary>
        public ushort bestLapSector1TimeInMS;

        /// <summary>
        /// Sector 2 time of best lap in the session in milliseconds
        /// </summary>
        public ushort bestLapSector2TimeInMS;

        /// <summary>
        /// Sector 3 time of best lap in the session in milliseconds
        /// </summary>
        public ushort bestLapSector3TimeInMS;

        /// <summary>
        /// Best overall sector 1 time of the session in milliseconds
        /// </summary>
        public ushort bestOverallSector1TimeInMS;

        /// <summary>
        /// Lap number best overall sector 1 time achieved on
        /// </summary>
        public byte bestOverallSector1LapNum;

        /// <summary>
        /// Best overall sector 2 time of the session in milliseconds
        /// </summary>
        public ushort bestOverallSector2TimeInMS;

        /// <summary>
        /// Lap number best overall sector 2 time achieved on
        /// </summary>
        public byte bestOverallSector2LapNum;

        /// <summary>
        /// Best overall sector 3 time of the session in milliseconds
        /// </summary>
        public ushort bestOverallSector3TimeInMS;

        /// <summary>
        /// Lap number best overall sector 3 time achieved on
        /// </summary>
        public byte bestOverallSector3LapNum;

        /// <summary>
        /// Distance vehicle is around current lap in metres
        /// could be negative if line hasn’t been crossed yet
        /// </summary>
        public float lapDistance;

        /// <summary>
        /// Total distance travelled in session in metres
        /// could be negative if line hasn’t been crossed yet
        /// </summary>
        public float totalDistance;

        /// <summary>
        /// Delta in seconds for safety car
        /// </summary>
        public float safetyCarDelta;

        /// <summary>
        /// Car race position
        /// </summary>
        public byte carPosition;

        /// <summary>
        /// Current lap number
        /// </summary>
        public byte currentLapNum;

        /// <summary>
        /// Current pit status
        /// </summary>
        public PitStatus pitStatus;

        /// <summary>
        /// Current sector
        /// </summary>
        public Sector sector;

        /// <summary>
        /// Current lap invalid - 0 = valid, 1 = invalid
        /// </summary>
        public byte currentLapInvalid;

        /// <summary>
        /// Accumulated time penalties in seconds to be added
        /// </summary>
        public byte penalties;

        /// <summary>
        /// Grid position the vehicle started the race in
        /// </summary>
        public byte gridPosition;

        /// <summary>
        /// Current driver status
        /// </summary>
        public DriverStatus driverStatus;

        /// <summary>
        /// Current result status
        /// </summary>
        public ResultStatus resultStatus;
    }

    /// <summary>
    /// The lap data packet gives details of all the cars in the session.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketLapData
    {
        /// <summary>
        /// Header
        /// </summary>
        public PacketHeader header;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        public LapData[] lapData;
    }
}
