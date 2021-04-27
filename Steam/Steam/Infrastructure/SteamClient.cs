using CsQuery;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using Steam.DAL.Context;
using Steam.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Steam.Infrastructure
{
    public static class SteamClient
    {
        const string gamelistUrl = "https://api.steampowered.com/ISteamApps/GetAppList/v2/";
        const string baseUrl = "https://store.steampowered.com/api/appdetails?appids=";
        const string priceUrl = "https://store.steampowered.com/api/appdetails?filters=price_overview&appids=";
        const string fileName = "games.json";
        static WebClient webClient = new WebClient();

        static SteamContext sc = new SteamContext();

        public static void CheckData()
        {
            if (!File.Exists(fileName) || File.ReadAllText(fileName).Length == 0)
            {
                JObject obj = JsonConvert.DeserializeObject<JObject>(webClient.DownloadString(gamelistUrl));
                File.WriteAllText(fileName, obj["applist"].ToString());
            }
        }
        public static List<Game> GetAndSaveGamesByList(List<string> names)
        {
            CheckData();
            List<Game> games = sc.Game.ToList();
            for (int i = 0; i < names.Count; i++) 
            {
                if (games.Count <= i)
                    {
                        Game game = GetGameById(GetGameId(names[i]));
                        sc.Game.Add(game);
                        sc.SaveChanges();
                    }
            }
            return games;
        }


        static JObject obj = JsonConvert.DeserializeObject<JObject>(File.ReadAllText(fileName));
        public static int GetGameId(string name)
        {            
            JArray array = (JArray)obj["apps"];
            return Convert.ToInt32(array.Where(x => x["name"].ToString() == name).ToList()[0]["appid"]);
        }
        public static Game GetGameById(int id)
        {
            JObject data = JsonConvert.DeserializeObject<JObject>(webClient.DownloadString(baseUrl + id));
            if ((bool)data[id.ToString()]["success"])
            {
                JObject priceData = JsonConvert.DeserializeObject<JObject>(webClient.DownloadString(priceUrl + id));
                Game game = new Game();
                if (priceData[id.ToString()]["data"].First != null)
                {
                    priceData = (JObject)priceData[id.ToString()]["data"]["price_overview"];
                    game.Price = Convert.ToDecimal(priceData["initial"]) / 100;
                }
                data = (JObject)data[id.ToString()]["data"];
                game.GameName = data["name"].ToString();
                game.GameInfo = RefactoringHtmlString(data["about_the_game"].ToString());
                game.Description = RefactoringHtmlString(data["detailed_description"].ToString());
                game.HeaderImageURL = data["header_image"].ToString();
                game.Requirements = RefactoringHtmlString(data["pc_requirements"]["minimum"].ToString());
                game.RealeaseDate = data["release_date"]["date"].ToString();
                game.Currency = "UAH";
                List<Genre> genres = sc.Genres.ToList();
                foreach (JObject obj in data["genres"])
                {
                    if (genres.Where(x => x.GenreName == obj["description"].ToString()).Count() > 0)
                        foreach (Genre g in genres.Where(x => x.GenreName == obj["description"].ToString()).ToList())
                            game.Genres.Add(g);
                    else
                        game.Genres.Add(new Genre() { GenreName = obj["description"].ToString() });
                }
                List<Developer> developers = sc.Developers.ToList();
                if(data["developers"] != null)
                    foreach (JValue obj in data["developers"])
                    {
                        if (developers.Where(x => x.DeveloperName == obj.ToString()).Count() > 0)
                            foreach (Developer d in developers.Where(x => x.DeveloperName == obj.ToString()).ToList())
                                game.Developers.Add(d);
                        else
                            game.Developers.Add(new Developer() { DeveloperName = obj.ToString() });
                    }
                int i = 0;
                List<Screenshot> screenshots = sc.Screenshots.ToList();
                foreach (JObject obj in data["screenshots"])
                {
                    if (screenshots.Where(x => x.ScreenshotURL == obj.ToString()).Count() > 0)
                        foreach (Screenshot s in screenshots.Where(x => x.ScreenshotURL == obj.ToString()).ToList())
                            game.Screenshots.Add(s);
                    else
                        game.Screenshots.Add(new Screenshot() { ScreenshotURL = obj["path_thumbnail"].ToString() });
                    i++;
                    if (i == 5)
                        break;

                }
                genres.Clear();
                return game;
            }
            return null;
        }
        static string RefactoringHtmlString(string description)
        {
            if (!description.Contains("<"))
                return description;
            else
                return HtmlUtilities.ConvertToPlainText(description);
        }
    }
}
