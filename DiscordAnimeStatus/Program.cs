using System;
using Nancy.Hosting.Self;
using System.IO;
using Discord;
using System.Threading.Tasks;

namespace DiscordAnimeStatus
{
    class DiscordAnimeStatus
    {
        public static dynamic Config;
        public static DiscordClient DiscordClient;

        static void Main(string[] args)
        {
            Console.Title = "";            

            using (var streamReader = new StreamReader("config.yaml"))
            {
                var deserializer = new YamlDotNet.Serialization.Deserializer();
                DiscordAnimeStatus.Config = deserializer.Deserialize(streamReader);

                if (Config["discord_email"] == "change" || Config["discord_password"] == "change")
                {
                    Console.WriteLine("Please change your login details in config.yaml.");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Successfully loaded configuration.");
                }
            }

            var uri = new Uri(Config["url"]);

            var hostConfig = new HostConfiguration
            {
                UrlReservations = new UrlReservations { CreateAutomatically = true }
            };

            using (var host = new NancyHost(hostConfig, uri))
            {
                host.Start();

                Console.WriteLine("DiscordAnimeStatus is running on " + uri);

                DiscordClient = new DiscordClient(x =>
                {
                    x.AppName = "DiscordAnimeStatus";
                });

                DiscordClient.ExecuteAndWait(async () =>
                {
                    while (true)
                    {
                        try
                        {
                            await DiscordClient.Connect(Config["discord_email"], Config["discord_password"]);
                            break;
                        }
                        catch (Exception ex)
                        {
                            DiscordClient.Log.Error($"Login Failed", ex);
                            await Task.Delay(DiscordClient.Config.FailedReconnectDelay);
                        }
                    }

                    Console.WriteLine($"Connected to Discord as @{DiscordClient.CurrentUser.Name}.");
                    Console.WriteLine("=====================");

                    DiscordClient.SetGame(null);
                });
            }
        }
    }
}
