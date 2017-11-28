using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace donut_arugular_SPA.Controllers.Resources
{

    public class VehicleResource
    {
        public VehicleResource()
        {
            Features = new Collection<int>();
        }
        public int Id { get; set; }
        [ForeignKey("Model")]
        public int ModelId { get; set; }
        public bool isRegistered { get; set; }
        public ContactResource Contact { get; set; }
        public ICollection<int> Features { get; set; }
    }
}