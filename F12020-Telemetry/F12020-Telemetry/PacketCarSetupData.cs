using System.Runtime.InteropServices;

namespace F12020Telemetry
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CarSetupData
    {
        /// <summary>
        /// Front wing aero
        /// </summary>
        public byte frontWing;

        /// <summary>
        /// Rear wing aero
        /// </summary>
        public byte rearWing;

        /// <summary>
        /// Differential adjustment on throttle (percentage)
        /// </summary>
        public byte onThrottle;

        /// <summary>
        /// Differential adjustment off throttle (percentage)
        /// </summary>
        public byte offThrottle;

        /// <summary>
        /// Front camber angle (suspension geometry)
        /// </summary>
        public float frontCamber;

        /// <summary>
        /// Rear camber angle (suspension geometry)
        /// </summary>
        public float rearCamber;

        /// <summary>
        /// Front toe angle (suspension geometry)
        /// </summary>
        public float frontToe;

        /// <summary>
        /// Rear toe angle (suspension geometry)
        /// </summary>
        public float rearToe;

        /// <summary>
        /// Front suspension
        /// </summary>
        public byte frontSuspension;

        /// <summary>
        /// Rear suspension
        /// </summary>
        public byte rearSuspension;

        /// <summary>
        /// Front anti-roll bar
        /// </summary>
        public byte frontAntiRollBar;

        /// <summary>
        /// Front anti-roll bar
        /// </summary>
        public byte rearAntiRollBar;

        /// <summary>
        /// Front ride height
        /// </summary>
        public byte frontSuspensionHeight;

        /// <summary>
        /// Rear ride height
        /// </summary>
        public byte rearSuspensionHeight;

        /// <summary>
        /// Brake pressure (percentage)
        /// </summary>
        public byte brakePressure;

        /// <summary>
        /// Brake bias (percentage)
        /// </summary>
        public byte brakeBias;

        /// <summary>
        /// Rear left tyre pressure (PSI)
        /// </summary>
        public float rearLeftTyrePressure;

        /// <summary>
        /// Rear right tyre pressure (PSI)
        /// </summary>
        public float rearRightTyrePressure;

        /// <summary>
        /// Front left tyre pressure (PSI)
        /// </summary>
        public float frontLeftTyrePressure;

        /// <summary>
        /// Front right tyre pressure (PSI)
        /// </summary>
        public float frontRightTyrePressure;

        /// <summary>
        /// Ballast
        /// </summary>
        public byte ballast;

        /// <summary>
        /// Fuel load
        /// </summary>
        public float fuelLoad;
    }

    /// <summary>
    /// This packet details the car setups for each vehicle in the session
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketCarSetupData
    {
        /// <summary>
        /// Header
        /// </summary>
        public PacketHeader header;

        /// <summary>
        /// All car setups. Note that in multiplayer other player cars will appear as blank.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        public CarSetupData[] carSetups;
    }
}
