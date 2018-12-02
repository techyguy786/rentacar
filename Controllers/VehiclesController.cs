using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vega.DTOs;
using vega.Models;
using vega.Persistence;

namespace vega.Controllers
{
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IMapper mapper;
        private readonly IVehicleRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public VehiclesController(IMapper mapper, IVehicleRepository repository, 
            IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] SaveVehicleDto vehicleDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicle = mapper.Map<SaveVehicleDto, Vehicle>(vehicleDto);
            vehicle.LastUpdate = DateTime.Now;
            
            repository.Add(vehicle);
            await unitOfWork.CompleteAsync();
            
            vehicle = await repository.GetVehicle(vehicle.VehicleId);

            var result = mapper.Map<Vehicle, VehicleDto>(vehicle);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] SaveVehicleDto vehicleDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicle = await repository.GetVehicle(id);

            if (vehicle == null)
            {
                return NotFound("Invalid Id");
            }
            mapper.Map<SaveVehicleDto, Vehicle>(vehicleDto, vehicle);
            vehicle.LastUpdate = DateTime.Now;
            
            await unitOfWork.CompleteAsync();

            vehicle = await repository.GetVehicle(vehicle.VehicleId);
            var result = mapper.Map<Vehicle, VehicleDto>(vehicle);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle = await repository.GetVehicle(id, includeRelated: false);

            if (vehicle == null)
                return NotFound();
            
            repository.Delete(vehicle);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var vehicle = await repository.GetVehicle(id);

            if (vehicle == null)
                return NotFound();
            
            var vehicleDto = mapper.Map<Vehicle, VehicleDto>(vehicle);

            return Ok(vehicleDto);
        }
    }
}