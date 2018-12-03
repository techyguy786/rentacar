using System.ComponentModel.DataAnnotations;

namespace vega.Core.Models
{
    public class Feature
    {
        public int FeatureId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}