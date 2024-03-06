using AutoMapper;
using Domain.Instructors;

namespace Application.Instructors
{
    public class InstructorProfile : Profile
    {
        public InstructorProfile()
        {
            CreateMap<CreateInstructor, Instructor>()
                .ForMember(destination => destination.PhoneNumber,
                    source => source.MapFrom(s => s.MobileNumber));

            CreateMap<UpdateInstructor, Instructor>()
                .ForMember(destination => destination.Id, source => source.Ignore());
        }
    }
}
