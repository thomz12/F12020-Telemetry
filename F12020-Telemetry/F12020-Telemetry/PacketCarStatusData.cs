using System.Runtime.InteropServices;

namespace F12020Telemetry
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CarStatusData
    {
        /// <summary>
        /// 0 (off) - 2 (high)
        /// </summary>
        byte tractionControl;

        /// <summary>
        /// 0 (off) - 1 (on)
        /// </summary>
        byte antiLockBrakes;

        /// <summary>
        /// Fuel mix - 0 = lean, 1 = standard, 2 = rich, 3 = max
        /// </summary>
        byte fuelMix;

        /// <summary>
        /// Front brake bias (percentage)
        /// </summary>
        byte frontBrakeBias;

        /// <summary>
        /// Pit limiter status - 0 = off, 1 = on
        /// </summary>
        byte pitLimiterStatus;

        /// <summary>
        /// Current fuel mass
        /// </summary>
        float fuelInTank;

        /// <summary>
        /// Fuel capacity
        /// </summary>
        float fuelCapacity;

        /// <summary>
        /// Fuel remaining in terms of laps (value on MFD)
        /// </summary>
        float fuelRemainingLaps;

        /// <summary>
        /// Cars max RPM, point of rev limiter
        /// </summary>
        ushort maxRPM;

        /// <summary>
        /// Cars idle RPM
        /// </summary>
        ushort idleRPM;

        /// <summary>
        /// Maximum number of gears
        /// </summary>
        byte maxGears;

        /// <summary>
        /// 0 = not allowed, 1 = allowed, -1 = unknown
        /// </summary>
        byte drsAllowed;


        /// <summary>
        /// 0 = DRS not available, non-zero - DRS will be available in [X] metres
        /// </summary>
        ushort drsActivationDistance;

        /// <summary>
        /// Tyre wear percentage
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        byte[] tyresWear;

        /// <summary>
        /// F1 Modern - 16 = C5, 17 = C4, 18 = C3, 19 = C2, 20 = C1 7 = inter, 8 = wet<br/>
        /// F1 Classic - 9 = dry, 10 = wet<br/>
        /// F2 – 11 = super soft, 12 = soft, 13 = medium, 14 = hard, 15 = wet<br/>
        /// </summary>
        byte actualTyreCompound;

        /// <summary>
        /// F1 visual (can be different from actual compound)<br/>
        /// 16 = soft, 17 = medium, 18 = hard, 7 = inter, 8 = wet<br/>
        /// F1 Classic – same as above<br/>
        /// F2 – same as above<br/>
        /// </summary>
        byte visualTyreCompound;

        /// <summary>
        /// Age in laps of the current set of tyres
        /// </summary>
        byte tyresAgeLaps;

        /// <summary>
        /// Tyre damage (percentage)
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        byte[] tyresDamage;

        /// <summary>
        /// Front left wing damage (percentage)
        /// </summary>
        byte frontLeftWingDamage;

        /// <summary>
        /// Front right wing damage (percentage)
        /// </summary>
        byte frontRightWingDamage;

        /// <summary>
        /// Rear wing damage (percentage)
        /// </summary>
        byte rearWingDamage;

        /// <summary>
        /// Indicator for DRS fault, 0 = OK, 1 = fault
        /// </summary>
        byte drsFault;

        /// <summary>
        /// Engine damage (percentage)
        /// </summary>
        byte engineDamage;

        /// <summary>
        /// Gear box damage (percentage)
        /// </summary>
        byte gearBoxDamage;

        /// <summary>
        /// Vehicle flag
        /// </summary>
        ZoneFlag vehicleFiaFlags;

        /// <summary>
        /// ERS energy store in Joules
        /// </summary>
        float ersStoreEnergy;

        /// <summary>
        /// Current ERS deploy mode
        /// </summary>
        ERSDeployMode ersDeployMode;

        /// <summary>
        /// ERS energy harvested this lap by MGU-K
        /// </summary>
        float ersHarvestedThisLapMGUK;

        /// <summary>
        /// ERS energy harvested this lap by MGU-H
        /// </summary>
        float ersHarvestedThisLapMGUH;

        /// <summary>
        /// ERS energy deployed this lap
        /// </summary>
        float ersDeployedThisLap;
    }

    /// <summary>
    /// This packet details car statuses for all the cars in the race
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketCarStatusData
    {
        /// <summary>
        /// Header
        /// </summary>
        public PacketHeader header;

        /// <summary>
        /// Car statuses
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        public CarStatusData[] carStatusData;
    }
}
