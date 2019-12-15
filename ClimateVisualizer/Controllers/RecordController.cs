using Microsoft.AspNetCore.Mvc;
using ClimateVisualizer.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClimateVisualizer.Controllers
{
    [Route("")]
    [Route("Record")]
    public class RecordController : Controller
    {
        IClimateRecordService ClimateRecordService;

        public RecordController(IClimateRecordService climateService)
        {
            ClimateRecordService = climateService;
        }

        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            return View(ClimateRecordService.GetDefaultRecords());
        }

        [Route("{pageIndex}")]
        [HttpGet]
        public IActionResult Index(int pageIndex)
        {
            return View(ClimateRecordService.GetRecordPage(pageIndex, 200));
        }

        [Route("Filtered")]
        public IActionResult Filtered(string StationFilter, string SelectedMonth, string SelectedProvince, int pageIndex, int pageSize = 200)
        {
            if(string.IsNullOrEmpty(StationFilter) && string.IsNullOrEmpty(SelectedMonth) && string.IsNullOrEmpty(SelectedProvince))
            {
                return View(ClimateRecordService.GetRecordPage(1, 200));
            }
            return View(ClimateRecordService.GetFilteredPage(StationFilter, SelectedMonth, SelectedProvince, 1, 200));
        }

    }
}