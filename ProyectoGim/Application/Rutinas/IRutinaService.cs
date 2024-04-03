using Domain.Rutinas;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Rutinas
{
    public interface IRutinaService
    { 
        /*REVISAR LO DE LIST*/
        Result<IList<Rutina>> List(bool includeDia = false, bool includeEjercicio = false);

        Result<Rutina> Get(string idRutina, bool includeDia = false, bool includeEjercicio = false);

        Result<Rutina> Get(int id, bool includeDia = false, bool includeEjercicio = false);

        Result Create(CreateRutina createRutina);

        Result Update(UpdateRutina updateRutina);

        Result Delete(int id);
    }
}
