using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace donut_arugular_SPA.Models
{
    public class Feature
    {
        public Feature()
        {
            ModelFeatures = new Collection<ModelFeature>();
        }
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public ICollection<ModelFeature> ModelFeatures { get; set; }
    }
}