using System.Collections.Generic;
using System.Collections.ObjectModel;
using donut_arugular_SPA.Models;

namespace donut_arugular_SPA.Controllers.Resources
{
    public class ModelFeatureResource
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        // CANNOT put <Model> Model here, because it causes loop reference for json
        // public Model Model { get; set; }

        public int FeatureId { get; set; }
        // public Feature Feature { get; set; }
       
    }
}