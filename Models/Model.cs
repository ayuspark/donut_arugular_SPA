using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace donut_arugular_SPA.Models
{
    public class Model
    {
        public Model()
        {
            ModelFeatures = new Collection<ModelFeature>();   
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [ForeignKey("Make")]
        public int MakeId { get; set; }
        public Make Make { get; set; }

        public ICollection<ModelFeature> ModelFeatures { get; set; }
    }
}