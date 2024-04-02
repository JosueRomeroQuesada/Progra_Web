using AutoMapper;
using Domain.Machines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Machines
{
    public class MachineProfile : Profile
    {
        public MachineProfile()
        {
            CreateMap<CreateMachine, Machine>();

            CreateMap<UpdateMachine, Machine>()
                   .ForMember(destination => destination.Id, source => source.Ignore());

            CreateMap<Machine, UpdateMachine>();
                   
            CreateMap<Machine, MachineDTO>()
                .ConstructUsing(source => new MachineDTO());
        }
    }
}
