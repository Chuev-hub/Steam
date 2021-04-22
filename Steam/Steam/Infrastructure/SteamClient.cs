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
        const string fileName = "games.json";
        static WebClient webClient = new WebClient();
        static SteamContext sc = new SteamContext();
        //static ScreenshotRepository sr = new ScreenshotRepository(sc);
        //static DeveloperRepository dr = new DeveloperRepository(sc);
        //static GenreRepository gr = new GenreRepository(sc);
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
            //GameRepository gr = new GameRepository(sc);
            List<Game> games = new List<Game>();
            foreach (string name in names)
            {
                Game game = GetGameById(GetGameId(name));
                games.Add(game);
                sc.Game.Add(game);
            }
            sc.SaveChanges();
            return games;
        }
        public static int GetGameId(string name)
        {            
            JObject obj = JsonConvert.DeserializeObject<JObject>(File.ReadAllText(fileName));
            JArray array = (JArray)obj["apps"];
            return Convert.ToInt32(array.Where(x => x["name"].ToString() == name).ToList()[0]["appid"]);
        }
        public static Game GetGameById(int id)
        {
            JObject data = JsonConvert.DeserializeObject<JObject>(webClient.DownloadString(baseUrl + id));
            if ((bool)data[id.ToString()]["success"])
            {
                Game game = new Game();
                data = (JObject)data[id.ToString()]["data"];
                game.GameName = data["name"].ToString();
                game.GameInfo = data["about_the_game"].ToString();
                game.Description = data["detailed_description"].ToString();
                game.HeaderImageURL = data["header_image"].ToString();
                game.Requirements = GetRequirements(data["pc_requirements"]["minimum"].ToString());
                game.RealeaseDate = data["release_date"]["date"].ToString();
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
                //foreach (JObject obj in data["genres"])
                //    game.Genres.Add(new Genre() { GenreName = obj["description"].ToString() });
                //foreach (JValue obj in data["developers"])
                //    game.Developers.Add(new Developer() { DeveloperName = obj.ToString() });
                //int i = 0;
                //foreach (JObject obj in data["screenshots"])
                //{
                //    game.Screenshots.Add(new Screenshot() { ScreenshotURL = obj["path_thumbnail"].ToString() });
                //    i++;
                //    if (i == 5)
                //        break;
                //}
                return game;
            }
            return null;
        }
        static string GetRequirements(string html)
        {
            CQ cq = CQ.Create(html);
            string str = "";
            str += cq[0].FirstChild + "\n";
            List<string> list = new List<string>();
            foreach (IDomObject obj in cq.Find("strong"))
                list.Add(obj[0].ToString());
            int i = 0;
            foreach (IDomObject obj in cq.Find("li"))
            {
                int n = 0;
                if (i > 0)
                    n = 1;
                list[i] += obj[n].ToString();
                i++;
                if (i >= list.Count)
                    break;
            }
            foreach (string s in list)
                str += s + "\n";    
            return str;
        }
    }
}
