using AutoMapper;
using Domain.Clients;
using Domain.Ejercicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ejercicios
{
    public class EjercicioProfile : Profile
    {
        public EjercicioProfile()
        {
            CreateMap<CreateEjercicio, Ejercicio>();

            CreateMap<UpdateEjercicio, Ejercicio>()
                   .ForMember(destination => destination.IdEjercicio, source => source.Ignore());

            CreateMap<Ejercicio, UpdateEjercicio>();
                   
            CreateMap<Ejercicio, EjercicioDTO>()
                .ConstructUsing(source => new EjercicioDTO(source.IdEjercicio,source.Nombre, source.Zona,source.Descripcion));
        }
    }
}
