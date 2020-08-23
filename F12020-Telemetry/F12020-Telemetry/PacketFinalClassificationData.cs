using System.Runtime.InteropServices;

namespace F12020Telemetry
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FinalClassificationData
    {
        /// <summary>
        /// Finishing position
        /// </summary>
        public byte position;

        /// <summary>
        /// Number of laps completed
        /// </summary>
        public byte numLaps;

        /// <summary>
        /// Grid position of the car
        /// </summary>
        public byte gridPosition;

        /// <summary>
        ///  Number of points scored
        /// </summary>
        public byte points;

        /// <summary>
        /// Number of pit stops made
        /// </summary>
        public byte numPitStops;

        /// <summary>
        /// Result status
        /// </summary>
        public ResultStatus resultStatus;

        /// <summary>
        /// Best lap time of the session in seconds
        /// </summary>
        public float bestLapTime;

        /// <summary>
        /// Total race time in seconds without penalties
        /// </summary>
        public double totalRaceTime;

        /// <summary>
        /// Total penalties accumulated in seconds
        /// </summary>
        public byte penaltiesTime;

        /// <summary>
        /// Number of penalties applied to this driver
        /// </summary>
        public byte numPenalties;

        /// <summary>
        /// Number of tyres stints up to maximum
        /// </summary>
        public byte numTyreStints;

        /// <summary>
        /// Actual tyres used by this driver
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] tyreStintsActual;

        /// <summary>
        /// Visual tyres used by this driver
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] tyreStintsVisual;
    }

    /// <summary>
    /// This packet details the final classification at the end of the race, 
    /// and the data will match with the post race results screen.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketFinalClassificationData
    {
        /// <summary>
        /// Header
        /// </summary>
        public PacketHeader header;

        /// <summary>
        /// Number of cars in the final classification
        /// </summary>
        public byte numCars;

        /// <summary>
        /// Classification data
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        public FinalClassificationData classificationData;
    }
}
