using ClimateVisualizer.Interfaces;
using ClimateVisualizer.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ClimateVisualizer.DBServices
{
    public class StationRepository : IStationRepository, IDisposable
    {

        private static readonly string StationListQuery = "Select [StationId], [StationName], [Province], [Latitude], [Longitude] from [Warehouse].[dbo].[Stations] " + 
        "ORDER BY [StationId] OFFSET @Offset ROWS FETCH NEXT @Pagesize ROWS ONLY";

        private static readonly string StationDetailQuery = "";

        private static readonly string WhereClause = "WHERE e.[StationId] = @StationID";

        private readonly SqlConnection Connection;

        public StationRepository(SqlConnection connection)
        {
            Connection = connection;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Connection.Dispose();
            }
        }

        ~StationRepository()
        {
            Dispose(false);
        }


        public IEnumerable<StationListModel> GetStationList(int pageIndex, int pageSize)
        {
            List<StationListModel> list = new List<StationListModel>();

            list = Connection.Query<StationListModel>(StationListQuery, new { Offset = (pageIndex - 1) * pageSize, PageSize = pageSize }).ToList();

            return list;
        }

        public IEnumerable<StationDetailModel> GetStationDetails(int pageIndex, int pageSize, int id)
        {
            List<StationDetailModel> list = new List<StationDetailModel>();

            list = Connection.Query<StationDetailModel>(StationDetailQuery + WhereClause, new { Offset = (pageIndex - 1) * pageSize, PageSize = pageSize, StationID = id}).ToList();

            return list;
        }

        public int GetStationListCount()
        {
            throw new NotImplementedException();
        }

        public int GetStationDetailsCount(int id)
        {
            throw new NotImplementedException();
        }
    }
}
