using AutoMapper;
using Domain.Instructors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Instructors
{
    public class InstructorProfile : Profile
    {
        public InstructorProfile()
        {
            CreateMap<CreateInstructor, Instructor>();

            CreateMap<UpdateInstructor, Instructor>()
                   .ForMember(destination => destination.Id, source => source.Ignore());

            CreateMap<Instructor, UpdateInstructor>();
                   
            CreateMap<Instructor, InstructorDTO>()
                .ConstructUsing(source => new InstructorDTO(source.Id, source.IdEntrenador, string.Concat(source.Nombre, " ", source.Apellido)));
        }
    }
}
