using Domain.Machines;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Machines
{
    public interface IMachineClient
    {  
        Task<List<MachineDTO>> List();

        Task<Result> Create(CreateMachine createMachine);

        Task<Result> Update(UpdateMachine updateMachine);

        Task<Result<Machine>> Get(string idMachine); 
    }
}
