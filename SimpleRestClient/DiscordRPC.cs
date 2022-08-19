using DiscordRPC;
using DiscordRPC.Logging;
using Button = DiscordRPC.Button;

namespace SimpleRestClient
{
    class DiscordRPC
    {
        /// <summary>
        /// The discord client
        /// </summary>
        private static DiscordRpcClient client;

        /// <summary>
        /// DiscordRPC Initilizer
        /// </summary>
        public static void Initilize()
        {
            client = new DiscordRpcClient("1010215811270582402");
            client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };
            client.Initialize();
            client.SetPresence(new RichPresence()
            {
                Details = "Executing Requests",
                Timestamps = Timestamps.Now,
                Assets = new Assets()
                {
                    LargeImageKey = "restclient_large",
                    LargeImageText = "MAUIRestClient"
                },
                Buttons = new Button[]
                {
                    new Button() { Label = "View Repository", Url = "https://github.com/elixss/MAUIRestClient" }
                }
            });
            Update();
        }

        /// <summary>
        /// Updating Discord Presence
        /// </summary>
        static void Update()
        {
            client.Invoke();
        }
    }
}
