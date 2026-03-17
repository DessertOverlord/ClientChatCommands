using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientChatControl.Configs
{
    public class ClientChatControlConfig
    {
        //public List<string> PlayerUUIDsCurrentlyMuted
        ///
        /// Dictionary of UUIDs and for how long they are muted (-1 means forever)
        /// 
        public Dictionary<string, int> PlayerUUIDsMuted { };
        public bool EnableBlockedChatMessageIndicator = true;
    }
}