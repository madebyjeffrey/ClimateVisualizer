using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClimateVisualizer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClimateVisualizer.Controllers
{
    [Route("StationList")]
    public class StationListController : Controller
    {
        IStationService StationService;

        public StationListController(IStationService stationService)
        {
            StationService = stationService;
        }
        public IActionResult Index()
        {
            return View(StationService.GetStationList(1, 200));
        }


    }
}