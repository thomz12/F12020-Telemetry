using System.Runtime.InteropServices;

namespace F12020Telemetry
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FinalClassificationData
    {
        /// <summary>
        /// Finishing position
        /// </summary>
        byte position;

        /// <summary>
        /// Number of laps completed
        /// </summary>
        byte numLaps;

        /// <summary>
        /// Grid position of the car
        /// </summary>
        byte gridPosition;

        /// <summary>
        ///  Number of points scored
        /// </summary>
        byte points;

        /// <summary>
        /// Number of pit stops made
        /// </summary>
        byte numPitStops;

        /// <summary>
        /// Result status
        /// </summary>
        ResultStatus resultStatus;

        /// <summary>
        /// Best lap time of the session in seconds
        /// </summary>
        float bestLapTime;

        /// <summary>
        /// Total race time in seconds without penalties
        /// </summary>
        double totalRaceTime;

        /// <summary>
        /// Total penalties accumulated in seconds
        /// </summary>
        byte penaltiesTime;

        /// <summary>
        /// Number of penalties applied to this driver
        /// </summary>
        byte numPenalties;

        /// <summary>
        /// Number of tyres stints up to maximum
        /// </summary>
        byte numTyreStints;

        /// <summary>
        /// Actual tyres used by this driver
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        byte[] tyreStintsActual;

        /// <summary>
        /// Visual tyres used by this driver
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        byte[] tyreStintsVisual;
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
        byte numCars;

        /// <summary>
        /// Classification data
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        FinalClassificationData classificationData;
    }
}
