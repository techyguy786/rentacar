using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace vega.DTOs
{
    public class VehicleDto
    {
        public int VehicleId { get; set; }
        public KeyValuePairDto Model { get; set; }
        public KeyValuePairDto Make { get; set; }
        public bool isRegistered { get; set; }
        public ContactDto Contact { get; set; }
        public DateTime LastUpdate { get; set; }
        public ICollection<KeyValuePairDto> Features { get; set; }
        public VehicleDto()
        {
            Features = new Collection<KeyValuePairDto>();
        }
    }
}