using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace donut_arugular_SPA.Controllers.Resources
{
    public class ModelResource
    {
        public ModelResource()
        {
            ModelFeatures = new Collection<ModelFeatureResource>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ModelFeatureResource> ModelFeatures { get; set; }
    }
}