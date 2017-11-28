using AutoMapper;
using donut_arugular_SPA.Controllers.Resources;
using donut_arugular_SPA.Models;

namespace donut_arugular_SPA.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Make, MakeResource>();   
            CreateMap<Model, ModelResource>();
            CreateMap<Feature, FeatureResource>();
            CreateMap<ModelFeature, ModelFeatureResource>();
        }
    }
}