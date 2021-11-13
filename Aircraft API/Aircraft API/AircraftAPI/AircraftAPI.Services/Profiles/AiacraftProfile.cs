using AircraftAPI.Services.Models;
using ArcraftAPI.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftAPI.Services.Profiles
{
    public class AiacraftProfile : Profile
    {
        public AiacraftProfile()
        {
            CreateMap<Aircraft, AircraftDto>();
            CreateMap<AircraftDto, Aircraft>();
        }

    }
}
