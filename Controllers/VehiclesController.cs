using Microsoft.AspNetCore.Mvc;
using donut_arugular_SPA.Controllers.Resources;
using donut_arugular_SPA.Models;
using AutoMapper;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using donut_arugular_SPA.Persisence;

namespace donut_arugular_SPA.Controllers
{
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IMapper _mapper;
        // private readonly myDbContext _context; // *** bcuz we use _repo and _uow now
        private readonly IVehicleRepository _repo;
        private readonly IUnitOfWork _uow;

        public VehiclesController(IMapper mapper, IVehicleRepository repo, IUnitOfWork uow)
        {
            _uow = uow;
            _repo = repo;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody]SaveVehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // var model = await _context.Models.FindAsync(vehicleResource.ModelId);

            // if(model == null)
            // {
            //     ModelState.AddModelError("ModelId", "Invalid model id");
            //     return BadRequest(ModelState);
            // }

            var vehicle = _mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource);
            vehicle.LastUpdate = DateTime.Now;

            // _context.Vehicles.Add(vehicle);
            _repo.Add(vehicle); // *** for OOP reason to decouple from DbContext, cuz it may change.
            await _uow.CompleteAsync();

            // Complete Vehicle object, incl. Make, Model obj etc.
            vehicle = await _repo.GetVehicleAsync(vehicle.Id);

            var result = _mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);
        }

        [HttpPut("{id}")] //route: /api/vehicles/id
        public async Task<IActionResult> UpdateVehicle([FromBody]SaveVehicleResource vehicleResource, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vehicle = await _repo.GetVehicleAsync(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            _mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource, vehicle);
            vehicle.LastUpdate = DateTime.Now;

            await _uow.CompleteAsync();

            var result = _mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicleAsync(int id)
        {
            var vehicle = await _repo.GetVehicleAsync(id, includeRelatedProp: false);

            if (vehicle == null)
            {
                return NotFound();
            }
            _repo.Remove(vehicle);
            await _uow.CompleteAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var vehicle = await _repo.GetVehicleAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            var vehicleResource = _mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(vehicleResource);
        }
    }
}