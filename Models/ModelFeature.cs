using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace donut_arugular_SPA.Models
{
    public class ModelFeature
    {
        // join table for Features and Models
        [Key]
        public int Id { get; set; }
        [ForeignKey("Model")]
        public int ModelId { get; set; }
        public Model Model { get; set; }
        [ForeignKey("Feature")]
        public int FeatureId { get; set; }
        public Feature Feature { get; set; }
    }
}