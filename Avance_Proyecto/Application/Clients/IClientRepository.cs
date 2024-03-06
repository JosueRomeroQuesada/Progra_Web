using Domain.Clients;
using System.Linq.Expressions;

namespace Application.Clients
{
    //interfaz de estudiante
    //contiene las operaciones que se pueden hacer 
    public interface IClientRepository
    {
        //devuelve una lista de todos los estudiantes
        List<Client> GetAll();

        //filtra estudiantes segun el predicate
        Client Get(Expression<Func<Client, bool>> predicate);

        //agregar un nuevo estudiante al repositorio
        void Insert(Client client);

        //actualiza la informaciond del estudiante en el repo
        void Update(Client client);

        //elimina un estudiante del repo
        void Delete(Client client);

        //guarda los cambios en el repo
        void Save();
    }
}
