using Domain.Clients;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Clients
{
    //interfaz de estudiante
    //opreaciones que se pueden hacer en el service
    public interface IClientService

        //valida que el los get,list,create,update y delete se hagan correctamente
        //devuelve un result con el resultado de la operacion
    {
     
        Result<IList<Client>> List();

        Result<Client> Get(string batch);

        Result<Client> Get(int id);

        Result Create(CreateClient createClient);

        Result Update(UpdateClient updateClient);

        Result Delete(int id);
    }
}
