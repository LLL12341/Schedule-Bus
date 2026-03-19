using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TransportWebSystem.Models;
using TransportWebSystem.Data;
using TransportWebSystem.Services;
using System.Linq; 

namespace TransportWebSystem.Controllers;

public class HomeController : Controller
{
    public IActionResult Index(int? startStopId, int? endStopId)
    {
        var db = TransportDatabase.Instance;
        var viewModel = new HomeViewModel
        {
            Stops = db.Stops,
            Routes = db.Routes,
            StartStopId = startStopId,
            EndStopId = endStopId
        };

        if (startStopId.HasValue && endStopId.HasValue)
        {
            var startStop = db.Stops.FirstOrDefault(s => s.Id == startStopId.Value);
            var endStop = db.Stops.FirstOrDefault(s => s.Id == endStopId.Value);

            IRouteSearchStrategy strategy = new SmartRouteStrategy();
            RoutePlanner planner = new RoutePlanner(strategy);

            viewModel.SearchResult = planner.BuildRoute(startStop, endStop, db.Routes);
        }

        return View(viewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}