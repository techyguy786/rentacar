using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace vega.DTOs
{
    public class SaveVehicleDto
    {
        public int VehicleId { get; set; }
        public int ModelId { get; set; }
        public bool isRegistered { get; set; }

        [Required]
        public ContactDto Contact { get; set; }
        public ICollection<int> Features { get; set; }

        public SaveVehicleDto()
        {
            Features = new Collection<int>();
        }
    }
}