using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using donut_arugular_SPA.Models;
using AutoMapper;
using donut_arugular_SPA.Controllers.Resources;

namespace donut_arugular_SPA.Controllers
{
    public class MakeController : Controller
    {
        private readonly myDbContext _context;
        private readonly IMapper _mapper;

        public MakeController(myDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("/api/makes")]
        public async Task<IEnumerable<MakeResource>> GetMake()
        {
            var makes = await _context.Makes.Include(m => m.Models).ThenInclude(model => model.ModelFeatures).ThenInclude(mf => mf.Feature).ToListAsync();

            // CANNOT use this because of self-ref loop
            // return await _context.Makes.Include(m => m.Models).ToListAsync();

            return _mapper.Map<List<Make>, List<MakeResource>>(makes);
        }
    }
}
