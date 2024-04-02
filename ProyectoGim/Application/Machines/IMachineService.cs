using Domain.Machines;
using Domain.Instructors;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Machines
{
    public interface IMachineService
    {
        Result<IList<Machine>> List();

        Result<Machine> Get(string idMachine);

        Result<Machine> Get(int id);

        Result Create(CreateMachine createMachine);

        Result Update(UpdateMachine updateMachine);

        Result Delete(int id);
    }
}
