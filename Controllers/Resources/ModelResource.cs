using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace donut_arugular_SPA.Controllers.Resources
{
    public class ModelResource
    {
        public ModelResource()
        {
            Features = new Collection<FeatureResource>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<FeatureResource> Features { get; set; }
    }
}