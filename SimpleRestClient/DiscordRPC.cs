using DiscordRPC;
using DiscordRPC.Logging;

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
            client.OnReady += (sender, msg) =>
            {
                Console.WriteLine("Connected to discord with user {0}", msg.User.Username);
            };
            client.OnPresenceUpdate += (sender, e) =>
            {
                Console.WriteLine("Presence has been updated! {0}", e.Presence);
            };
            client.Initialize();
            client.SetPresence(new RichPresence()
            {
                Details = "Executing Requests",
                Timestamps = Timestamps.Now,
                Assets = new Assets()
                {
                    LargeImageKey = "restclient_large",
                    LargeImageText = "MAUIRestClient"
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
