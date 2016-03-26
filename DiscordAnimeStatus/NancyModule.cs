using System;
using Nancy;
using Nancy.Extensions;
using Nancy.ModelBinding;
using Discord;

namespace DiscordAnimeStatus
{
    public class NancyModule : Nancy.NancyModule
    {
        public NancyModule()
        {
            Get["/"] = _ => "Hello! This is an instance of DiscordAnimeStatus.";

            Post["/update_status"] = _ =>
            {
                var data = this.Bind<RequestModel>();
                Console.Write("Received update: ");

                if (data.playstatus.Equals("playing"))
                {
                    var statusString = data.ToStatusString();

                    Console.WriteLine(statusString);
                    DiscordAnimeStatus.DiscordClient.SetGame(statusString);
                }
                else
                {
                    Console.WriteLine("Stopped playback.");
                    DiscordAnimeStatus.DiscordClient.SetGame(null);                    
                }

                return 200;
            };
        }
    }
}