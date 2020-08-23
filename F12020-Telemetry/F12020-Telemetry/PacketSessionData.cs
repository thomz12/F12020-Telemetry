using System.Runtime.InteropServices;

namespace F12020Telemetry
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MarshalZone
    {
        /// <summary>
        /// Fraction (0..1) of way through the lap the marshal zone starts
        /// </summary>
        public float zoneStart;

        /// <summary>
        /// -1 = invalid/unknown, 0 = none, 1 = green, 2 = blue, 3 = yellow, 4 = red
        /// </summary>
        public ZoneFlag zoneFlag;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct WeatherForecastSample
    {
        /// <summary>
        /// The current session type
        /// </summary>
        public SessionType sessionType;

        /// <summary>
        /// Time in minutes the forecast is for
        /// </summary>
        public byte timeOffset;

        /// <summary>
        /// The weather for this sample
        /// </summary>
        public Weather weather;

        /// <summary>
        /// Track temp. in degrees celsius
        /// </summary>
        public sbyte trackTemperature;

        /// <summary>
        /// Air temp. in degrees celsius
        /// </summary>
        public sbyte airTemperature;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketSessionData
    {
        /// <summary>
        /// Header
        /// </summary>
        public PacketHeader Header;

        /// <summary>
        /// The current weather
        /// </summary>
        public Weather weather;

        /// <summary>
        /// Track temp. in degrees celsius
        /// </summary>
        public sbyte trackTemperature;

        /// <summary>
        /// Air temp. in degrees celsius
        /// </summary>
        public sbyte airTemperature;

        /// <summary>
        /// Total number of laps in this race
        /// </summary>
        public byte totalLaps;

        /// <summary>
        /// Track length in metres
        /// </summary>
        public ushort trackLength;

        /// <summary>
        /// The current session type
        /// </summary>
        public SessionType sessionType;

        /// <summary>
        /// The current track ID
        /// </summary>
        public sbyte trackId;

        /// <summary>
        /// Type of Formula
        /// </summary>
        public Formula formula;

        /// <summary>
        /// Time left in session in seconds
        /// </summary>
        public ushort sessionTimeLeft;

        /// <summary>
        /// Session duration in seconds
        /// </summary>
        public ushort sessionDuration;

        /// <summary>
        /// Pit speed limit in kilometres per hour
        /// </summary>
        public byte pitSpeedLimit;

        /// <summary>
        /// Whether the game is paused
        /// </summary>
        public byte gamePaused;

        /// <summary>
        /// Whether the player is spectating
        /// </summary>
        public byte isSpectating;

        /// <summary>
        /// Index of the car being spectated
        /// </summary>
        public byte spectatorCarIndex;

        /// <summary>
        /// SLI Pro support, 0 = inactive, 1 = active
        /// </summary>
        public byte sliProNativeSupport;

        /// <summary>
        /// Number of marshal zones to follow
        /// </summary>
        public byte numMarshalZones;

        /// <summary>
        /// List of marshal zones – max 21
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 21)]
        public MarshalZone[] marshalZones;

        /// <summary>
        /// Current safety car status
        /// </summary>
        public SafetyCarStatus safetyCarStatus;

        /// <summary>
        /// 0 = offline, 1 = online
        /// </summary>
        public byte networkGame;

        /// <summary>
        /// Number of weather samples to follow
        /// </summary>
        public byte numWeatherForecastSamples;

        /// <summary>
        /// Array of weather forecast samples
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public WeatherForecastSample[] weatherForecastSamples;
    }
}
