using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Discord.RPC
{
    public class DiscordRPC
    {
        private static Thread loop;
        private static bool running = false;

        [DllImport(@"discord-rpc.dll", EntryPoint = "Discord_Initialize", CallingConvention = CallingConvention.Cdecl)]
        private static extern void RPCInitialize(string clientID, ref DiscordEventHandler handlers, bool autoRegister, string operationalSteamId);

        [DllImport(@"discord-rpc.dll", EntryPoint = "Discord_Shutdown", CallingConvention = CallingConvention.Cdecl)]
        private static extern void RPCShutdown();

        [DllImport(@"discord-rpc.dll", EntryPoint = "Discord_RunCallbacks", CallingConvention = CallingConvention.Cdecl)]
        private static extern void RPCRunCallbacks();

        [DllImport(@"discord-rpc.dll", EntryPoint = "Discord_UpdatePresence", CallingConvention = CallingConvention.Cdecl)]
        public static extern void UpdatePresence(ref DiscordPresence presence);

        [DllImport(@"discord-rpc.dll", EntryPoint = "Discord_ClearPresence", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ClearPresence();

        [DllImport(@"discord-rpc.dll", EntryPoint = "Discord_Respond", CallingConvention = CallingConvention.Cdecl)]
        public static extern void Respond(string userId, DiscordResponse reply);

        public static void RunCallbacks()
        {
            while ( running )
            {
                RPCRunCallbacks();
                Thread.Sleep(100);
            }
        }

        public static void Init(string clientID, ref DiscordEventHandler handlers, bool autoRegister, string operationalSteamId)
        {
            running = true;
            RPCInitialize(clientID, ref handlers, autoRegister, operationalSteamId);
            loop = new Thread(RunCallbacks);
            loop.Start();
        }
        
        public static void Shutdown()
        {
            loop.Abort();
            RPCShutdown();
        }
    }
}
