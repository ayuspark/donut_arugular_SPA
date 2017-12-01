using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace donut_arugular_SPA.Models
{
    public class Vehicle
    {
        public Vehicle()
        {
            Features = new List<VehicleFeature>();
        }
        public int Id { get; set; }
        [ForeignKey("Model")]
        public int ModelId { get; set; }
        public Model Model { get; set; } // navigation property
        public bool isRegistered { get; set; }
        [Required]
        [StringLength(255)]
        public string ContactName { get; set; }
        // [Required]
        [StringLength(255)]
        public string ContactEmail { get; set; }
        [Required]
        [StringLength(255)]
        public string ContactPhone { get; set; }
        public DateTime LastUpdate { get; set; }
        public ICollection<VehicleFeature> Features { get; set; }

    }
}