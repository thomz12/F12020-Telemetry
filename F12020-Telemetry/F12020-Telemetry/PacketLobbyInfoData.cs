using System.Runtime.InteropServices;

namespace F12020Telemetry
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct LobbyInfoData
    {
        /// <summary>
        /// Whether the vehicle is AI (1) or Human (0) controlled
        /// </summary>
        public byte aiControlled;

        /// <summary>
        /// Team id - see appendix (255 if no team currently selected)
        /// </summary>
        public byte teamId;

        /// <summary>
        /// Nationality of the driver
        /// </summary>
        public byte nationality;

        /// <summary>
        /// Name of participant in UTF-8 format – null terminated
        /// Will be truncated with ... (U+2026) if too long
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
        public char[] name;

        /// <summary>
        /// 0 = not ready, 1 = ready, 2 = spectating
        /// </summary>
        public byte readyStatus;
    }

    /// <summary>
    /// This packet details the players currently in a multiplayer lobby.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketLobbyInfoData
    {
        /// <summary>
        /// Header
        /// </summary>
        public PacketHeader header;

        /// <summary>
        /// Number of players in the lobby data
        /// </summary>
        public byte numPlayers;

        /// <summary>
        /// Lobby data
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        public LobbyInfoData[] lobbbyPlayers;
    }
}
