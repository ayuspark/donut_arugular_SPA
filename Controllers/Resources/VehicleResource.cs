using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace donut_arugular_SPA.Controllers.Resources
{
    public class VehicleResource
    {
        public VehicleResource()
        {
            Features = new Collection<FeatureResource>();
        }
        public int Id { get; set; }
        public MakeResource Make { get; set; }
        
        public ModelResource Model { get; set; } // navigation property
        public bool isRegistered { get; set; }
        public ContactResource Contact { get; set; }
        public DateTime LastUpdate { get; set; }
        public ICollection<FeatureResource> Features { get; set; }

    }
}