using Microsoft.AspNetCore.Mvc;
using donut_arugular_SPA.Controllers.Resources;
using donut_arugular_SPA.Models;
using AutoMapper;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;

namespace donut_arugular_SPA.Controllers
{
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly myDbContext _context;

        public VehiclesController(IMapper mapper, myDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody]SaveVehicleResource vehicleResource)
        {
            if(!ModelState.IsValid)
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

            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();

            // Complete Vehicle object, incl. Make, Model obj etc.
            vehicle = await _context.Vehicles
            .Include(v => v.Features)
                .ThenInclude(f => f.Feature)
            .Include(v => v.Model)
                .ThenInclude(m => m.Make)
            // .ThenInclude(mk => mk.Models)
            // .ThenInclude(m => m.ModelFeatures)
            .SingleOrDefaultAsync(v => v.Id == vehicle.Id);

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

            var vehicle = await _context.Vehicles.Include(v => v.Features).SingleOrDefaultAsync(v => v.Id == id);
            
            if (vehicle == null)
            {
                return NotFound();
            }

            _mapper.Map<SaveVehicleResource, Vehicle>(vehicleResource, vehicle);
            vehicle.LastUpdate = DateTime.Now;

            await _context.SaveChangesAsync();

            var result = _mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicleAsync(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);

            if (vehicle == null)
            {
                return NotFound();
            }
            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var vehicle = await _context.Vehicles
            .Include(v => v.Features)
                .ThenInclude(f => f.Feature)
            .Include(v => v.Model)
                .ThenInclude(m => m.Make)
                    // .ThenInclude(mk => mk.Models)
                        // .ThenInclude(m => m.ModelFeatures)
            .SingleOrDefaultAsync(v => v.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }
            
            var vehicleResource = _mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(vehicleResource);
        }
    }
}