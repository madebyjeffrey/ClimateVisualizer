using ClimateVisualizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClimateVisualizer.Interfaces
{
    public interface IStationRepository
    {
        IEnumerable<StationListModel> GetStationList(int pageIndex, int pageSize);
        IEnumerable<StationDetailModel> GetStationDetails(int pageIndex, int pageSize, int id);
        int GetStationListCount();
        int GetStationDetailsCount(int id);
        
    }
}
