using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using vega.DTOs;
using vega.Models;
using vega.Persistence;

namespace vega.Controllers
{
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IMapper mapper;
        private readonly VegaDbContext context;
        public VehiclesController(IMapper mapper, VegaDbContext context)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] VehicleDto vehicleDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // if API is public and we want to show the message to the user that
            // the property is missing. So,
            var model = await context.Models.FindAsync(vehicleDto.ModelId);
            if (model == null)
            {
                ModelState.AddModelError("ModelId", "Invalid Model Id");
                return BadRequest(ModelState);
            }

            var vehicle = mapper.Map<VehicleDto, Vehicle>(vehicleDto);
            vehicle.LastUpdate = DateTime.Now;
            
            context.Vehicles.Add(vehicle);
            await context.SaveChangesAsync();

            var result = mapper.Map<Vehicle, VehicleDto>(vehicle);
            return Ok(result);
        }
    }
}