﻿using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using ClimateVisualizer.Interfaces;
using ClimateVisualizer.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;

namespace ClimateVisualizer.DBServices
{
    public class ClimateRecordRepository : IClimateRecordRepository
    {      
        private const string RecordPageQuery = "SELECT c.[RecordID], e.[StationName], e.[Province], e.[Latitude], e.[Longitude], c.[Month], " +
                "c.[MeanTemp], c.[HighestMonthlyMaxTemp], c.[LowestMonthlyMinTemp], c.[Snowfall], c.[TotalPrecipitation] " +
                "FROM [Warehouse].[dbo].[Recs] c INNER JOIN [Warehouse].[dbo].[Stations] e ON c.[StationID] = e.[StationId] ";
                
        private const string PagingClause = "ORDER BY c.[RecordID] OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

        private const string MonthFilteringClause = "c.[Month]=@Month ";

        private const string ProvinceFilteringClause = "e.[Province]=@Province ";

        private const string StationFilteringClause = "e.[StationName] LIKE %%@Filter%% ";

        private const string RecordCountQuery = "SELECT DISTINCT count(RecordID) FROM [Warehouse].[dbo].[Recs]";
        
        private readonly IConfiguration Configuration;

        public ClimateRecordRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IEnumerable<RecordModel> GetClimateRecordPage(int pageIndex, int pageSize)
        {
            string query = RecordPageQuery + PagingClause;

            using var dal = new DalSession(Configuration);

            return dal.Connection.Query<RecordModel>(query, new { Offset = (pageIndex - 1) * pageSize, PageSize = pageSize }).ToList();
        }

        public IEnumerable<RecordModel> GetFilteredRecords(string searchStation, string month, string province, int pageIndex, int pageSize)
        {
            string query = RecordPageQuery + "WHERE ";
            
            bool monthAdded = false;
            bool provinceAdded = false;

            query.Replace(MonthFilteringClause, "");
            query.Replace(ProvinceFilteringClause, "");
            query.Replace(StationFilteringClause, "");

            if (!string.IsNullOrEmpty(province))
            {
                query = query + ProvinceFilteringClause;
                provinceAdded = true;
            }

            if (!string.IsNullOrEmpty(month))
            {
                if (provinceAdded) query = query + "AND ";
                query = query + MonthFilteringClause;
                monthAdded = true;
            }

            if (!string.IsNullOrEmpty(searchStation))
            {
                if (monthAdded) query = query + "AND ";
                query = query + StationFilteringClause;
                
            }

            //query = query + PagingClause;
            DateTime? selectMonth = DateTime.ParseExact(month, "yyyy-MM-dd", new CultureInfo("en-US"));

            using var dal = new DalSession(Configuration);

            return dal.Connection.Query<RecordModel>(query, new { Offset = (pageIndex - 1) * pageSize, PageSize = pageSize, Month = selectMonth, Province = province, Filter = searchStation }).ToList();                        
        }

        public List<SelectListItem> GetMonths()
        {
            return new List<SelectListItem>
           {
               new SelectListItem{ Value = "", Text = "None"},
               new SelectListItem{ Value = "2017-01-15", Text = "January, 2017"},
               new SelectListItem{ Value = "2017-02-15", Text = "February, 2017"},
               new SelectListItem{ Value = "2017-03-15", Text = "March, 2017"},
               new SelectListItem{ Value = "2017-04-15", Text = "April, 2017"},
               new SelectListItem{ Value = "2017-05-15", Text = "May, 2017"},
               new SelectListItem{ Value = "2017-06-15", Text = "June, 2017"},
               new SelectListItem{ Value = "2017-07-15", Text = "July, 2017"},
               new SelectListItem{ Value = "2017-08-15", Text = "August, 2017"},
               new SelectListItem{ Value = "2017-09-15", Text = "September, 2017"},
               new SelectListItem{ Value = "2017-10-15", Text = "October, 2017"},
               new SelectListItem{ Value = "2017-11-15", Text = "November, 2017"},
               new SelectListItem{ Value = "2017-12-15", Text = "December, 2017"},
               new SelectListItem{ Value = "2018-01-15", Text = "January, 2018"},
               new SelectListItem{ Value = "2018-02-15", Text = "February, 2018"},
               new SelectListItem{ Value = "2018-03-15", Text = "March, 2018"},
               new SelectListItem{ Value = "2018-04-15", Text = "April, 2018"},
               new SelectListItem{ Value = "2018-05-15", Text = "May, 2018"},
               new SelectListItem{ Value = "2018-06-15", Text = "June, 2018"},
               new SelectListItem{ Value = "2018-07-15", Text = "July, 2018"},
               new SelectListItem{ Value = "2018-08-15", Text = "August, 2018"},
               new SelectListItem{ Value = "2018-09-15", Text = "September, 2018"},
               new SelectListItem{ Value = "2018-10-15", Text = "October, 2018"},
               new SelectListItem{ Value = "2018-11-15", Text = "November, 2018"},
               new SelectListItem{ Value = "2018-12-15", Text = "December, 2018"},
               new SelectListItem{ Value = "2019-01-15", Text = "January, 2019"},
               new SelectListItem{ Value = "2019-02-15", Text = "February, 2019"},
               new SelectListItem{ Value = "2019-03-15", Text = "March, 2019"},
               new SelectListItem{ Value = "2019-04-15", Text = "April, 2019"},
               new SelectListItem{ Value = "2019-05-15", Text = "May, 2019"},
               new SelectListItem{ Value = "2019-06-15", Text = "June, 2019"},

           };
        }

        public List<SelectListItem> GetProvinces()
        {
            return new List<SelectListItem>
            {
                new SelectListItem{ Value = "", Text = "None"},
                new SelectListItem{ Value = "BC", Text = "British Colombia"},
                new SelectListItem{ Value = "AB", Text = "Alberta"},
                new SelectListItem{ Value = "SK", Text = "Saskatchewan"},
                new SelectListItem{ Value = "MB", Text = "Manitoba"},
                new SelectListItem{ Value = "ON", Text = "Ontario"},
                new SelectListItem{ Value = "QC", Text = "Quebec"},
                new SelectListItem{ Value = "NL", Text = "Newfoundland"},
                new SelectListItem{ Value = "NB", Text = "New Brunswick"},
                new SelectListItem{ Value = "NS", Text = "Nova Scotia"},
                new SelectListItem{ Value = "PE", Text = "Prince Edward Island"},
                new SelectListItem{ Value = "YU", Text = "Yukon"},
                new SelectListItem{ Value = "NT", Text = "Northwest Territories"},
                new SelectListItem{ Value = "NU", Text = "Nunavit"},
            };
        }

        public int GetClimateRecordCount()
        {
            using var dal = new DalSession(Configuration);

            return dal.Connection.ExecuteScalar<int>(RecordCountQuery);            
        }
    }
}
