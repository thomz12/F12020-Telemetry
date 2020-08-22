using System;

namespace F12020Telemetry
{
    /// <summary>
    /// Enum containing the Packet IDs
    /// </summary>
    public enum PacketID : byte
    {
        /// <summary>
        /// Contains all motion data for player’s car – only sent while player is in control
        /// </summary>
        MOTION = 0,

        /// <summary>
        /// Data about the session – track, time left
        /// </summary>
        SESSION = 1,

        /// <summary>
        /// Data about all the lap times of cars in the session
        /// </summary>
        LAP_DATA = 2,

        /// <summary>
        /// Various notable events that happen during a session
        /// </summary>
        EVENT = 3,

        /// <summary>
        /// List of participants in the session, mostly relevant for multiplayer
        /// </summary>
        PARTICIPANTS = 4,

        /// <summary>
        /// Packet detailing car setups for cars in the race
        /// </summary>
        CAR_SETUPS = 5,

        /// <summary>
        /// Telemetry data for all cars
        /// </summary>
        CAR_TELEMETRY = 6,

        /// <summary>
        /// Status data for all cars such as damage
        /// </summary>
        CAR_STATUS = 7,

        /// <summary>
        /// Final classification confirmation at the end of a race
        /// </summary>
        FINAL_CLASSIFICATION = 8,

        /// <summary>
        /// Information about players in a multiplayer lobby
        /// </summary>
        LOBBY_INFO = 9
    }

    /// <summary>
    /// All wheels are in the following order: 
    /// RL, RR, FL, FR
    /// </summary>
    public enum WheelInArray
    {
        /// <summary>
        /// Rear left wheel
        /// </summary>
        RL = 0,

        /// <summary>
        /// Rear right wheel
        /// </summary>
        RR = 1,

        /// <summary>
        /// Front left wheel
        /// </summary>
        FL = 2,

        /// <summary>
        /// Front right wheel
        /// </summary>
        FR = 3,
    }

    [Flags]
    public enum ButtonFlags : uint
    {
        /// <summary>
        /// Cross or A
        /// </summary>
        BUTTON_A = 0x0001,

        /// <summary>
        /// Triangle or Y
        /// </summary>
        BUTTON_Y = 0x0002,

        /// <summary>
        /// Circle or B
        /// </summary>
        BUTTON_B = 0x004,

        /// <summary>
        /// Square or X
        /// </summary>
        BUTTON_X = 0x008,

        /// <summary>
        /// D-pad left
        /// </summary>
        DPAD_LEFT = 0x0010,

        /// <summary>
        /// D-pad right
        /// </summary>
        DPAD_RIGHT = 0x0020,
        
        /// <summary>
        /// D-pad up
        /// </summary>
        DPAD_UP = 0x0040,

        /// <summary>
        /// D-pad down
        /// </summary>
        DPAD_DOWN = 0x0080,

        /// <summary>
        /// Options or Menu
        /// </summary>
        BUTTON_MENU = 0x0100,

        /// <summary>
        /// L1 or LB
        /// </summary>
        BUTTON_LB = 0x0200,

        /// <summary>
        /// R1 or RB
        /// </summary>
        BUTTON_RB = 0x0400,

        /// <summary>
        /// L2 or LT
        /// </summary>
        BUTTON_LT = 0x0800,

        /// <summary>
        /// R2 or RT
        /// </summary>
        BUTTON_RT = 0x1000,

        /// <summary>
        /// Left Stick Click
        /// </summary>
        BUTTON_LEFT_STICK = 0x2000,

        /// <summary>
        /// Right Stick Click
        /// </summary>
        BUTTON_RIGHT_STICK = 0x4000
    }

    /// <summary>
    /// MFD Panel index for single player race.
    /// May vary depending on game mode
    /// </summary>
    public enum MFDPanel : byte
    {
        CLOSED = 255,
        CAR_SETUP = 0,
        PITS = 1,
        DAMAGE = 2,
        Engine = 3,
        Temperatures = 4
    }
}
