using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordAnimeStatus
{
    class RequestModel
    {
        public string user;
        public string name;
        public string ep;
        public string eptotal;
        public string score;
        public string picurl;
        public string playstatus;

        public override string ToString()
        {
            var output = "";
            output += $"User: {user}\n";
            output += $"Series title: {name}\n";
            output += $"Episode no.: {ep}\n";
            output += $"Total episode no.: {eptotal}\n";
            output += $"Score: {score}\n";
            output += $"Image URL: {picurl}\n";
            output += $"Playing status: {playstatus}\n";

            return output.Trim();
        }

        public string ToStatusString()
        {
            return $"({ep}/{eptotal}) {name}";
        }
    }
}
