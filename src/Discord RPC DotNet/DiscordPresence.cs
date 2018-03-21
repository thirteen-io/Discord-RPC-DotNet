using System;

namespace Discord.RPC
{
    [Serializable]
    public struct DiscordPresence
    {
        public string state;
        public string details;

        //Timestamps
        public long startTimestamp;
        public long endTimestamp;

        //Large Image
        public string largeImageKey;
        public string largeImageText;

        //Small Image
        public string smallImageKey;
        public string smallImageText;

        //Party
        public string partyId;
        public int partySize;
        public int partyMax;

        //Secrets
        public string matchSecret;
        public string joinSecret;
        public string spectateSecret;

        public byte instance;
    }
}