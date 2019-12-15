using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClimateVisualizer.ViewModels
{
    public class StationDetailViewModel
    {
        [Key]
        public int StationId { get; set; }

        [Required]
        //[Display(Name = "Station Name")]
        [StringLength(30)]
        public string StationName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Month { get; set; }

        [Required]
        //[Display(Name = "Mean Temperature")]
        public float MeanTemp { get; set; }

        [Required]
        //[Display(Name = "Highest Monthly Max Temp")]
        public float HighestMonthlyMaxTemp { get; set; }

        [Required]
        //[Display(Name = "Lowest Monthly Min Temp")]
        public float LowestMonthlyMinTemp { get; set; }

        [Required]
        //[Display(Name = "Snowfall")]
        public float Snowfall { get; set; }

        [Required]
        //[Display(Name = "Total Precipitation")]
        public float TotalPrecipitation { get; set; }
    }
}
