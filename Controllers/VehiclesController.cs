using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using vega.DTOs;
using vega.Models;

namespace vega.Controllers
{
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IMapper mapper;
        public VehiclesController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateVehicle([FromBody] VehicleDto vehicleDto)
        {
            var vehicle = mapper.Map<VehicleDto, Vehicle>(vehicleDto);
            return Ok(vehicle);
        }
    }
}