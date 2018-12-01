using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using vega.Models;

namespace vega.DTOs
{
    public class VehicleDto
    {
        public int VehicleId { get; set; }
        public int ModelId { get; set; }
        public bool isRegistered { get; set; }
        public ContactDto Contact { get; set; }
        public ICollection<int> Features { get; set; }

        public VehicleDto()
        {
            Features = new Collection<int>();
        }
    }
}