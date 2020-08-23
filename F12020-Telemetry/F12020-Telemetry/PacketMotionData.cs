using System.Runtime.InteropServices;

namespace F12020Telemetry
{
    /// <summary>
    /// Motion data for each car.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CarMotionData
    {
        /// <summary>
        /// World space X position
        /// </summary>
        public float worldPositionX;

        /// <summary>
        /// World space Y position
        /// </summary>
        public float worldPositionY;

        /// <summary>
        /// World space Z position
        /// </summary>
        public float worldPositionZ;

        /// <summary>
        /// Velocity in world space X
        /// </summary>
        public float worldVelocityX;

        /// <summary>
        /// Velocity in world space Y
        /// </summary>
        public float worldVelocityY;

        /// <summary>
        /// Velocity in world space Z
        /// </summary>
        public float worldVelocityZ;

        /// <summary>
        /// World space forward X direction (normalised)
        /// </summary>
        public short worldForwardDirX;

        /// <summary>
        /// World space forward Y direction (normalised)
        /// </summary>
        public short worldForwardDirY;

        /// <summary>
        /// World space forward Z direction (normalised)
        /// </summary>
        public short worldForwardDirZ;

        /// <summary>
        /// World space right X direction (normalised)
        /// </summary>
        public short worldRightDirX;

        /// <summary>
        /// World space right Y direction (normalised)
        /// </summary>
        public short worldRightDirY;

        /// <summary>
        /// World space right Z direction (normalised)
        /// </summary>
        public short worldRightDirZ;

        /// <summary>
        /// Lateral G-Force component
        /// </summary>
        public float gForceLateral;

        /// <summary>
        /// Longitudinal G-Force component
        /// </summary>
        public float gForceLongitudinal;

        /// <summary>
        /// Vertical G-Force component
        /// </summary>
        public float gForceVertical;

        /// <summary>
        /// Yaw angle in radians
        /// </summary>
        public float yaw;

        /// <summary>
        /// Pitch angle in radians
        /// </summary>
        public float pitch;

        /// <summary>
        /// Roll angle in radians
        /// </summary>
        public float roll;
    }

    /// <summary>
    /// Packet containing all motion data for all cars.
    /// Also provides extra data for the player car.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketMotionData
    {
        /// <summary>
        /// Header
        /// </summary>
        public PacketHeader header;

        /// <summary>
        /// Data for all cars on track
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        public CarMotionData[] carMotionData;

        // Extra player car ONLY data

        /// <summary>
        /// Suspension position of each wheel
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] m_suspensionPosition;

        /// <summary>
        /// Suspension velocity of each wheel
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] m_suspensionVelocity;

        /// <summary>
        /// Suspension acceleration of each wheel
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] m_suspensionAcceleration;

        /// <summary>
        /// Speed of each wheel
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] m_wheelSpeed;

        /// <summary>
        /// Slip ratio for each wheel
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] m_wheelSlip;

        /// <summary>
        /// Velocity in local space
        /// </summary>
        public float m_localVelocityX;

        /// <summary>
        /// Velocity in local space
        /// </summary>
        public float m_localVelocityY;

        /// <summary>
        /// Velocity in local space
        /// </summary>
        public float m_localVelocityZ;

        /// <summary>
        /// Angular velocity x-component
        /// </summary>
        public float m_angularVelocityX;

        /// <summary>
        /// Angular velocity y-component
        /// </summary>
        public float m_angularVelocityY;

        /// <summary>
        /// Angular velocity z-component
        /// </summary>
        public float m_angularVelocityZ;

        /// <summary>
        /// Angular acceleration x-component
        /// </summary>
        public float m_angularAccelerationX;

        /// <summary>
        /// Angular acceleration y-component
        /// </summary>
        public float m_angularAccelerationY;

        /// <summary>
        /// Angular acceleration z-component
        /// </summary>
        public float m_angularAccelerationZ;

        /// <summary>
        /// Current front wheels angle in radians
        /// </summary>
        public float m_frontWheelsAngle;
    }
}
