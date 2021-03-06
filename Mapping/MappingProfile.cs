using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using donut_arugular_SPA.Controllers.Resources;
using donut_arugular_SPA.Models;

namespace donut_arugular_SPA.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to API Resources
            CreateMap<Make, MakeResource>();   
            CreateMap<Model, ModelResource>();
            CreateMap<Feature, FeatureResource>();
            CreateMap<ModelFeature, ModelFeatureResource>();
            CreateMap<Vehicle, SaveVehicleResource>()
                .ForMember(svr => svr.Contact, opt => opt.MapFrom(v => new ContactResource {
                Name = v.ContactName, 
                Email = v.ContactEmail,
                Phone = v.ContactPhone}))
                .ForMember(svr => svr.Features, opt => opt.MapFrom(v => v.Features.Select(vf => vf.FeatureId)));
            CreateMap<Vehicle, VehicleResource>()
                .ForMember(vr => vr.Make, opt => opt.MapFrom(v => v.Model.Make))
                .ForMember(vr => vr.Contact, opt => opt.MapFrom(v => new ContactResource
                {
                    Name = v.ContactName,
                    Email = v.ContactEmail,
                    Phone = v.ContactPhone
                }))
                .ForMember(vr => vr.Features, opt => opt.MapFrom(v => v.Features.Select(vf => new FeatureResource{ Id = vf.Feature.Id, Name = vf.Feature.Name })));

            // API Resources to Domain
            CreateMap<SaveVehicleResource, Vehicle>()
                .ForMember(v => v.Id, opt => opt.Ignore())
                .ForMember(v => v.ContactName, opt => opt.MapFrom(vr => vr.Contact.Name))
                .ForMember(v => v.ContactEmail, opt => opt.MapFrom(vr => vr.Contact.Email))
                .ForMember(v => v.ContactPhone, opt => opt.MapFrom(vr => vr.Contact.Phone))
                .ForMember(v => v.Features, opt => opt.Ignore())
                .AfterMap((vr, v) => {
                
                    // Select features that vehicleResource NOT has

                    var removeFeatures = v.Features.Where(vf => !vr.Features.Contains(vf.FeatureId));
                    
                    var temp = v.Features.ToList();
                    foreach (var f in removeFeatures.ToList())
                    {
                        temp.Remove(f);
                    }
                    v.Features = temp;

                    // Select features that's NOT what Vehicle already has, so that to add
                    var addedFeatures = vr.Features.Where(id => !v.Features.Any(f => f.FeatureId == id)).Select(id => new VehicleFeature {
                            FeatureId = id,
                            VehicleId = vr.Id,
                        });

                    foreach (var f in addedFeatures)
                    {
                        v.Features.Add(f);
                    }
                });
        }
    }
}