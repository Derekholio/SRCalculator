using Microsoft.AspNetCore.Mvc;
using SRCalculator.Models;
using SRCalculator.SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SRCalculator.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            using (SRCalculatorContext db = new SRCalculatorContext())
            {
                List<Player> players = db.Players.ToList();
                int targetSR = 2350;
                int playerCount = players.Count();
                double averageSR = Math.Round(db.Players.Select(x => x.SR).Average(), 0);

                ViewBag.AverageSR = averageSR;
                ViewBag.TargetSR = targetSR;
                ViewBag.MaxNewSR = Math.Abs((averageSR * playerCount) - (targetSR * (playerCount+1)));
                return View(players);
            }
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
