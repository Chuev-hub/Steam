using Steam.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Steam.Infrastructure
{
    public static class SteamClient
    {
        const string baseUrl = "https://store.steampowered.com/api/appdetails?appids=";
        static WebClient webClient = new WebClient();
        //static Game GetGamesFromList(List<string> names)
        //{

        //}
    }
}
