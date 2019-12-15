using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClimateVisualizer.ViewModels
{
    public class StationsViewModel
    {
        [Key]
        public int StationId { get; set; }

        [Required]
        //[Display(Name = "Station Name")]
        [StringLength(30)]
        public string StationName { get; set; }

        [Required]
        //[Display(Name = "Province")]
        [StringLength(20)]
        public string Province { get; set; }

        [Required]
        //[Display(Name = "Latitude")]
        public float Latitude { get; set; }

        [Required]
        //[Display(Name = "Longitude")]
        public float Longitude { get; set; }
    }
}
