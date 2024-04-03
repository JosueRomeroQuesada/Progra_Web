using AutoMapper;
using Domain.Rutinas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Rutinas
{
    public class RutinaProfile : Profile
    {
        public RutinaProfile()
        {
            CreateMap<CreateRutina, Rutina>();

            CreateMap<UpdateRutina, Rutina>()
                   .ForMember(destination => destination.Id, source => source.Ignore());

            CreateMap<Rutina, UpdateRutina>();

            CreateMap<Rutina, RutinaDTO>()
                .ConstructUsing(source => new RutinaDTO(source.Id, source.IdRutina));
        }
    }
}
