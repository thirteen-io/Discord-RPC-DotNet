using System.Runtime.InteropServices;

namespace Discord.RPC
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void OnReady();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void OnDisconnect(int error, string message);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void OnError(int error, string message);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void OnJoinGame(string joinSecret);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void OnSpectateGame(string spectateSecret);

    public struct DiscordEventHandler
    {
        public OnReady onReady;
        public OnDisconnect onDisconnect;
        public OnError onError;
        public OnJoinGame onJoinGame;
        public OnSpectateGame onSpectateGame;
    }
}