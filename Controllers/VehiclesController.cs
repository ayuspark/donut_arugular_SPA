using Microsoft.AspNetCore.Mvc;
using donut_arugular_SPA.Controllers.Resources;
using donut_arugular_SPA.Models;
using AutoMapper;
using System.Threading.Tasks;
using System;

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
        public async Task<IActionResult> CreateVehicle([FromBody]VehicleResource vehicleResource)
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

            var vehicle = _mapper.Map<VehicleResource, Vehicle>(vehicleResource);
            vehicle.LastUpdate = DateTime.Now;

            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);
        }
    }
}