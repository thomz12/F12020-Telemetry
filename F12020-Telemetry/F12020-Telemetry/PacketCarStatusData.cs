using System.Runtime.InteropServices;

namespace F12020Telemetry
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CarStatusData
    {
        /// <summary>
        /// 0 (off) - 2 (high)
        /// </summary>
        public byte tractionControl;

        /// <summary>
        /// 0 (off) - 1 (on)
        /// </summary>
        public byte antiLockBrakes;

        /// <summary>
        /// Fuel mix - 0 = lean, 1 = standard, 2 = rich, 3 = max
        /// </summary>
        public byte fuelMix;

        /// <summary>
        /// Front brake bias (percentage)
        /// </summary>
        public byte frontBrakeBias;

        /// <summary>
        /// Pit limiter status - 0 = off, 1 = on
        /// </summary>
        public byte pitLimiterStatus;

        /// <summary>
        /// Current fuel mass
        /// </summary>
        public float fuelInTank;

        /// <summary>
        /// Fuel capacity
        /// </summary>
        public float fuelCapacity;

        /// <summary>
        /// Fuel remaining in terms of laps (value on MFD)
        /// </summary>
        public float fuelRemainingLaps;

        /// <summary>
        /// Cars max RPM, point of rev limiter
        /// </summary>
        public ushort maxRPM;

        /// <summary>
        /// Cars idle RPM
        /// </summary>
        public ushort idleRPM;

        /// <summary>
        /// Maximum number of gears
        /// </summary>
        public byte maxGears;

        /// <summary>
        /// 0 = not allowed, 1 = allowed, -1 = unknown
        /// </summary>
        public byte drsAllowed;


        /// <summary>
        /// 0 = DRS not available, non-zero - DRS will be available in [X] metres
        /// </summary>
        public ushort drsActivationDistance;

        /// <summary>
        /// Tyre wear percentage
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] tyresWear;

        /// <summary>
        /// F1 Modern - 16 = C5, 17 = C4, 18 = C3, 19 = C2, 20 = C1 7 = inter, 8 = wet<br/>
        /// F1 Classic - 9 = dry, 10 = wet<br/>
        /// F2 – 11 = super soft, 12 = soft, 13 = medium, 14 = hard, 15 = wet<br/>
        /// </summary>
        public byte actualTyreCompound;

        /// <summary>
        /// F1 visual (can be different from actual compound)<br/>
        /// 16 = soft, 17 = medium, 18 = hard, 7 = inter, 8 = wet<br/>
        /// F1 Classic – same as above<br/>
        /// F2 – same as above<br/>
        /// </summary>
        public byte visualTyreCompound;

        /// <summary>
        /// Age in laps of the current set of tyres
        /// </summary>
        public byte tyresAgeLaps;

        /// <summary>
        /// Tyre damage (percentage)
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] tyresDamage;

        /// <summary>
        /// Front left wing damage (percentage)
        /// </summary>
        public byte frontLeftWingDamage;

        /// <summary>
        /// Front right wing damage (percentage)
        /// </summary>
        public byte frontRightWingDamage;

        /// <summary>
        /// Rear wing damage (percentage)
        /// </summary>
        public byte rearWingDamage;

        /// <summary>
        /// Indicator for DRS fault, 0 = OK, 1 = fault
        /// </summary>
        public byte drsFault;

        /// <summary>
        /// Engine damage (percentage)
        /// </summary>
        public byte engineDamage;

        /// <summary>
        /// Gear box damage (percentage)
        /// </summary>
        public byte gearBoxDamage;

        /// <summary>
        /// Vehicle flag
        /// </summary>
        public ZoneFlag vehicleFiaFlags;

        /// <summary>
        /// ERS energy store in Joules
        /// </summary>
        public float ersStoreEnergy;

        /// <summary>
        /// Current ERS deploy mode
        /// </summary>
        public ERSDeployMode ersDeployMode;

        /// <summary>
        /// ERS energy harvested this lap by MGU-K
        /// </summary>
        public float ersHarvestedThisLapMGUK;

        /// <summary>
        /// ERS energy harvested this lap by MGU-H
        /// </summary>
        public float ersHarvestedThisLapMGUH;

        /// <summary>
        /// ERS energy deployed this lap
        /// </summary>
        public float ersDeployedThisLap;
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
