using FluentScheduler;
using Newtonsoft.Json;
using RestSharp;
using SRCalculator.Models;
using SRCalculator.SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SRCalculator.Scheduler.Jobs
{
    public class SRUpdater : IJob
    {
        public void Execute()
        {
            var serviceDomain = "http://overwatchy.com";
            var serviceURL = "/profile/pc/us/{0}";

            using (var db = new SRCalculatorContext())
            {
                var client = GetClient(serviceDomain);

                List<Player> players = db.Players.ToList();
                foreach(var player in players)
                {
                    var friendlyUsername = player.Username.Replace("#", "-");
                    var serviceCall = string.Format(serviceURL, friendlyUsername);
                    var request = GetRequest(serviceCall, Method.GET);
                    var response = client.Execute(request);
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
