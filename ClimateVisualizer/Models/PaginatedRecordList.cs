using ClimateVisualizer.DBServices;
using ClimateVisualizer.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClimateVisualizer.Models
{
    public class PaginatedRecordList
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public List<SelectListItem> MonthSelectList { get; set; }
        public List<SelectListItem> ProvinceSelectList { get; set; }
        public SelectListItem SelectedMonth { get; set; }
        public SelectListItem SelectedProvince { get; set; }
        public string StationFilter { get; set; }

        public int RecordCount;

        public IEnumerable<RecordModel> Records { get; set; }

        public PaginatedRecordList(List<SelectListItem> months, List<SelectListItem> provinces, int count)
        {
            PageSize = 200;
            PageIndex = 1;
            MonthSelectList = months;
            ProvinceSelectList = provinces;
            RecordCount = count;
        }

    }
}
