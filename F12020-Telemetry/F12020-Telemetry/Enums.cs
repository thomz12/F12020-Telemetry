using System;

namespace F12020Telemetry
{
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
    /// Enum for zone flags
    /// </summary>
    public enum ZoneFlag : sbyte
    {
        INVALID = -1,
        NONE = 0,
        GREEN = 1,
        BLUE = 2,
        YELLOW = 3,
        RED = 4
    }

    /// <summary>
    /// Enum for the session type
    /// </summary>
    public enum SessionType : byte
    {
        UNKNOWN = 0,
        PRACTICE_1 = 1,
        PRACTICE_2 = 2,
        PRACTICE_3 = 3,
        SHORT_PRACTICE = 4,
        QUALIFYING_1 = 5,
        QUALIFYING_2 = 6,
        QUALIFYING_3 = 7,
        SHORT_QUALIFYING = 8,
        ONE_SHOT_QUALIFYING = 9,
        RACE = 10,
        RACE_2 = 11,
        TIME_TRAIL = 12
    }

    /// <summary>
    /// Enum for weather types
    /// </summary>
    public enum Weather : byte
    {
        CLEAR = 0,
        LIGHT_CLOUD = 1,
        OVERCAST = 2,
        LIGHT_RAIN = 3,
        HEAVY_RAIN = 4,
        STORM = 5
    }

    /// <summary>
    /// Enum for Formula types
    /// </summary>
    public enum Formula : byte
    {
        F1_MODERN = 0,
        F1_CLASSIC = 1,
        F2 = 2,
        F1_GENERIC = 3
    }

    /// <summary>
    /// Enum for safety car statuses
    /// </summary>
    public enum SafetyCarStatus : byte
    {
        NO_SAFETY_CAR = 0,
        FULL_SAFETY_CAR = 1,
        VIRTUAL_SAFETY_CAR = 2
    }

    /// <summary>
    /// Enum for car pit status
    /// </summary>
    public enum PitStatus : byte
    {
        NONE = 0,
        PITTING = 1,
        IN_PIT_AREA = 2
    }

    /// <summary>
    /// Enum for all sectors
    /// </summary>
    public enum Sector : byte
    {
        SECTOR_1 = 0,
        SECTOR_2 = 1,
        SECTOR_3 = 2,
    }

    /// <summary>
    /// Enum for driver statuses
    /// </summary>
    public enum DriverStatus : byte
    {
        IN_GARAGE = 0,
        FLYING_LAP = 1,
        IN_LAP = 2,
        OUT_LAP = 3,
        ON_TRACK = 4
    }

    /// <summary>
    /// Enum for result statuses
    /// </summary>
    public enum ResultStatus : byte
    {
        INVALID = 0,
        INACTIVE = 1,
        ACTIVE = 2,
        FINISHED = 3,
        DISQUALIFIED = 4,
        NOT_CLASSIFIED = 5,
        RETIRED = 6
    }

    /// <summary>
    /// Enum for button flags
    /// </summary>
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
    /// MFD panel index for single player race.
    /// May vary depending on game mode
    /// </summary>
    public enum MFDPanel : byte
    {
        /// <summary>
        /// MFD panel closed
        /// </summary>
        CLOSED = 255,

        /// <summary>
        /// MFD panel on car setup info
        /// </summary>
        CAR_SETUP = 0,

        /// <summary>
        /// MFD panel on pits info
        /// </summary>
        PITS = 1,

        /// <summary>
        /// MFD on damage info
        /// </summary>
        DAMAGE = 2,

        /// <summary>
        /// MFD on engine info
        /// </summary>
        Engine = 3,

        /// <summary>
        /// MFD on temperature info
        /// </summary>
        Temperatures = 4
    }
}
