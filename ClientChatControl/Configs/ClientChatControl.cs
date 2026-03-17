using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChatControl.Configs
{
    public class ClientChatControlConfig
    {
        ///
        /// Dictionary of UUIDs and the expiration time of their mute in Unix Epoch Time. (-1 means no expiration).
        /// https://www.epochconverter.com/
        /// 
        public Dictionary<string, long> PlayerUIDsMuted { };
        public bool EnableBlockedChatMessageIndicator = true;
        public List<string> FilteredWordList { };
    }
}