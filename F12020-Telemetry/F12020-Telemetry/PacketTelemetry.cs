using System;
using System.Runtime.InteropServices;

namespace F12020Telemetry
{
    /// <summary>
    /// Car telemetry data
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CarTelemetryData
    {
        /// <summary>
        /// Speed of car in kilometres per hour
        /// </summary>
        public ushort speed;

        /// <summary>
        /// Amount of throttle applied (0.0 to 1.0)
        /// </summary>
        public float throttle;

        /// <summary>
        /// Steering (-1.0 (full lock left) to 1.0 (full lock right))
        /// </summary>
        public float steer;

        /// <summary>
        /// Amount of brake applied (0.0 to 1.0)
        /// </summary>
        public float brake;

        /// <summary>
        /// Amount of clutch applied (0 to 100)
        /// </summary>
        public byte clutch;

        /// <summary>
        /// Gear selected (1-8, N=0, R=-1)
        /// </summary>
        public sbyte gear;

        /// <summary>
        /// Engine RPM
        /// </summary>
        public ushort engineRPM;

        /// <summary>
        /// 0 = off, 1 = on
        /// </summary>
        public byte drs;

        /// <summary>
        /// Rev lights indicator (percentage)
        /// </summary>
        public byte revLightsPercent;

        /// <summary>
        /// Brakes temperature (celsius)
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public ushort[] brakesTemperature;

        /// <summary>
        /// Tyres surface temperature (celsius)
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] tyresSurfaceTemperature;

        /// <summary>
        /// Tyres inner temperature (celsius)
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] tyresInnerTemperature;

        /// <summary>
        /// Engine temperature (celsius)
        /// </summary>
        public ushort engineTemperature;

        /// <summary>
        /// Tyres pressure (PSI)
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] tyresPressure;

        /// <summary>
        /// Driving surface, see appendices
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] surfaceType;
    }

    /// <summary>
    /// This packet details telemetry for all the cars in the race. 
    /// It details various values that would be recorded on the car 
    /// such as speed, throttle application, DRS etc.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketCarTelemetry
    {
        /// <summary>
        /// Header
        /// </summary>
        public PacketHeader Header;

        /// <summary>
        /// Array containing telemetry data for all cars
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        public CarTelemetryData[] carTelemetryData;

        /// <summary>
        /// Bit flags specifying which buttons are being pressed currently
        /// </summary>
        public ButtonFlags buttonStatus;

        /// <summary>
        /// Index of MFD panel open (player 1)
        /// </summary>
        public MFDPanel mfdPanelIndex;

        /// <summary>
        /// Index of MFD panel open (player 2)
        /// </summary>
        public MFDPanel mfdPanelIndexSecondaryPlayer;

        /// <summary>
        /// Suggested gear for the player (1-8)
        /// 0 if no gear suggested
        /// </summary>
        public sbyte suggestedGear;
    }
}
