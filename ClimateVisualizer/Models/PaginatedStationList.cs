using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClimateVisualizer.Models
{
    public class PaginatedStationList
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public int RecordCount;

        public IEnumerable<StationListModel> Stations { get; set; }

        public PaginatedStationList(int count)
        {
            PageSize = 200;
            PageIndex = 1;
            
            RecordCount = count;
        }
    }
}
