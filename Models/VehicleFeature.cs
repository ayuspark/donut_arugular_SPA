using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace donut_arugular_SPA.Models
{
    public class VehicleFeature
    {
        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; } // navigation property
        public Vehicle Vehicle { get; set; }
        [ForeignKey("Feature")]
        public int FeatureId { get; set; }
        public Feature Feature { get; set; } //navigation prop

    }
}