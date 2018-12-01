using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vega.Models
{
    [Table("Vehicles")]
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; }
        public bool isRegistered { get; set; }

        [Required]
        [StringLength(255)]
        public string ContactName { get; set; }

        [StringLength(255)]
        public string ContactEmail { get; set; }

        [Required]
        [StringLength(255)]
        public string ContactPhone { get; set; }
        public DateTime LastUpdate { get; set; }
        public ICollection<VehicleFeature> VehicleFeatures { get; set; }
        public Vehicle()
        {
            VehicleFeatures = new Collection<VehicleFeature>();
        }
    }
}