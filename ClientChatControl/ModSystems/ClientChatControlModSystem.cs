using Vintagestory.API.Common;
using Vintagestory.API.Client;
using System.Diagnostics;
using ClientChatControl.Configs;
using System;

namespace ClientChatControl.ModSystems
{
    public abstract class ClientChatControlModSystem : ModSystem
    {
        protected ICoreClientApi capi;
        public ClientChatControlConfig config;
        private readonly string configName = "clientchatcontrol.json";
        private IClientPlayer cPlayer;
        private string cPlayerUID { get { return cPlayer.PlayerUID; } }

        public override void StartClientSide(ICoreClientApi api)
        {
            capi = api;
            LoadConfig();

            ///pseudo-code... idk what the syntax is without hand-holding from Visual Studio
            capi.event.ChatMessage += HandleChatMessages;
            cPlayer = capi.World.Player;
        }

        //protected abstract void RustwallStartServerSide();

        protected void LoadConfig()
        {
            try
            {
                config = capi.LoadModConfig<ClientChatControlConfig>(configName);
            }
            catch (Exception)
            {
                capi.Logger.Error("");
            }

            if (config == null)
            {
                config = new ClientChatControlConfig();
                capi.StoreModConfig(config, configName);
            }
        }

        private void RegisterClientChatCommands() 
        {
            capi.Register
        }

        ///psudo-code below... just outlining. Idk syntax
        /// 

        private void HandleChatMessages(int groupId, string message, EnumChatType chattype, string data)
        {
            //Q: how do I actually get the UID of the person sending the chat message?
            //Q: Do chat messages captured by this event actually provide any sort of information about who sent it?

            /// We can probably use the name of the player as input for the chat command, use that to look up the UID using
            /// IClientWorldAccessor's AllOnlinePlayers List, which includes IPlayer objects for all players currently connected.
            /// We can add that UID to our list of blocked players.
            /// Then, when we receive a chat command, we use that same list to look up the UID, find the player's name,
            /// and then filter out chat messages with that name. I think that should work.
            /// 
            /// We can add an option for UID blocking too if people care that much.
            /// 

            //We only want to block chat messages that are from other players, not server notifications or our own.
            if (chattype == EnumChatType.OthersMessage) 
            {
                //this command can be used to send a client-side notification to the player running the mod.
                ShowChatNotification("Blocked chat message from player " + senderPlayerName)
            }
        }   
    }
}