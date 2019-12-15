using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClimateVisualizer.Models
{
    public class PaginatedStationDetailList
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public int RecordCount;

        public IEnumerable<StationDetailModel> StationDetails { get; set; }

        public PaginatedStationDetailList(int count)
        {
            PageSize = 200;
            PageIndex = 1;

            RecordCount = count;
        }
    }
}
