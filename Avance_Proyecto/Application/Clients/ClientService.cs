using AutoMapper;
using Domain.Clients;
using Shared;

namespace Application.Clients
{
    // Clase que implementa la interfaz IClientService y proporciona la lógica de negocio relacionada con los estudiantes
    public class ClientService : IClientService
    {
        // Dependencias necesarias para el servicio

        // Repositorio de estudiantes
        private readonly IClientRepository _repository; 
        // Objeto IMapper de AutoMapper para mapeo de objetos
        private readonly IMapper _mapper; 

        // Constructor que recibe las dependencias necesarias
        public ClientService(IClientRepository repository, IMapper mapper)
        {
            _repository = repository; // Inicializa el repositorio
            _mapper = mapper; // Inicializa el objeto IMapper
        }

        // Método para obtener la lista de estudiantes
        public Result<IList<Client>> List()
        {
            return Result.Success<IList<Client>>(_repository.GetAll());
        }

        // Método para obtener un estudiante por lote (batch)
        public Result<Client> Get(string batch)
        {
            var client = _repository.Get(s => s.Batch == batch);

            if (client == null)
            {
                return Result.Failure<Client>(ClientErrors.NotFound(batch));
            }

            return Result.Success(client);
        }

        // Método para obtener un estudiante por su ID
        public Result<Client> Get(int id)
        {
            var client = _repository.Get(s => s.Id == id);

            if (client is null)
            {
                return Result.Failure<Client>(ClientErrors.NotFound());
            }

            return Result.Success(client);
        }

        // Método para crear un nuevo estudiante
        public Result Create(CreateClient createClient)
        {
            var client = _mapper.Map<CreateClient, Client>(createClient);
            _repository.Insert(Client.Create(0, client));
            _repository.Save();
            return Result.Success();
        }

        // Método para actualizar la información de un estudiante
        public Result Update(UpdateClient updateClient)
        {
            var result = Get(updateClient.Id);
            if (result.IsFailure)
            {
                return Result.Failure(result.Error);
            }

            var client = result.Value;
            _mapper.Map<UpdateClient, Client>(updateClient, client);
            _repository.Update(client);
            _repository.Save();
            return Result.Success();
        }

        // Método para eliminar un estudiante por su ID
        public Result Delete(int id)
        {
            var result = Get(id);
            if (result.IsFailure)
            {
                return Result.Failure(result.Error);
            }

            var client = result.Value;
            _repository.Delete(client);
            _repository.Save();
            return Result.Success();
        }
    }
}
