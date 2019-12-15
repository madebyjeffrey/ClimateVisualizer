using ClimateVisualizer.Interfaces;
using ClimateVisualizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClimateVisualizer.DBServices
{
    public class StationService : IStationService
    {
        IStationRepository Repo;
        PaginatedStationList StationPage;
        PaginatedStationDetailList StationDetailPage;

        public StationService()
        {

        }

        public IEnumerable<StationDetailModel> GetStationDetails(int pageIndex, int pageSize, int id)
        {
            throw new NotImplementedException();
        }

        public int GetStationDetailsCount(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StationListModel> GetStationList(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public int GetStationListCount()
        {
            throw new NotImplementedException();
        }
    }
}
