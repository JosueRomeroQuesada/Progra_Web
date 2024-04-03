using Domain.Rutinas;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Rutinas
{
    public interface IRutinaClient
    {
        Task<List<RutinaDTO>> List();

        Task<Result> Create(CreateRutina createRutina);

        Task<Result> Update(UpdateRutina updateRutina);

        Task<Result<Rutina>> Get(string idRutina);
    }
}
