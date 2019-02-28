using FluentScheduler;
using Newtonsoft.Json;
using RestSharp;
using SRCalculator.Models;
using SRCalculator.SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SRCalculator.Scheduler.Jobs
{
    public class SRUpdater : IJob
    {
        public void Execute()
        {
            string serviceDomain = "http://overwatchy.com";
            string serviceURL = "/profile/pc/us/{0}";

            using (SRCalculatorContext db = new SRCalculatorContext())
            {
                RestClient client = GetClient(serviceDomain);

                List<Player> players = db.Players.ToList();
                foreach(Player player in players)
                {
                    string friendlyUsername = player.Username.Replace("#", "-");
                    string serviceCall = string.Format(serviceURL, friendlyUsername);
                    RestRequest request = GetRequest(serviceCall, Method.GET);
                    IRestResponse response = client.Execute(request);
                    if (response.IsSuccessful)
                    {
                        try
                        {
                            OverwatchAPIResponse apiResponse = JsonConvert.DeserializeObject<OverwatchAPIResponse>(response.Content);
                            db.Update(player);
                            player.PrivateProfile = apiResponse.isPrivate;
                            player.SR = apiResponse.competitive.rank;
                            player.RankImage = apiResponse.competitive.rank_img;
                        }
                        catch(Exception ex)
                        {
                            player.PrivateProfile = true;
                        }
                    }
                }

                db.SaveChanges();
            }
        }

        private RestClient GetClient(string serviceDomain)
        {
            return new RestClient(serviceDomain);
        }

        private RestRequest GetRequest(string requestUri, Method method)
        {
            return new RestRequest(requestUri, method);
        }
    }
}
