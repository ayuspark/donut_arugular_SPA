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
using donut_arugular_SPA.Persistence;

namespace donut_arugular_SPA.Controllers
{
    public class FeatureController : Controller
    {
        private readonly myDbContext _context;
        private readonly IMapper _mapper;

        public FeatureController(myDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("/api/features")]
        public async Task<IEnumerable<FeatureResource>> GetFeatures()
        {
            var features = await _context.Features.Include(f => f.ModelFeatures).ThenInclude(mf => mf.Feature).ToListAsync();

            return _mapper.Map<List<Feature>, List<FeatureResource>>(features);
        }

        [HttpGet("/api/model_features")]
        public async Task<IEnumerable<ModelFeatureResource>> GetStuff()
        {
            var model_features = await _context.ModelFeatures.Include(mf => mf.Feature).Include(mf => mf.Model).ToListAsync();

            return _mapper.Map<List<ModelFeature>, List<ModelFeatureResource>>(model_features);
        }
    }
}
