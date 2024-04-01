﻿using AutoMapper;
using AutoMapper.Configuration.Conventions;
using Domain.Clients;
using Shared;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Application.Clients
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Result<IList<Client>> List()
        {
            return Result.Success<IList<Client>>(_repository.GetAll());
        }

        public Result<Client> Get(string idCliente)
        {
            var client = _repository.Get(s=>s.IdCliente == idCliente);
            
            if (client == null)
            {
                return Result.Failure<Client>(ClientErrors.NotFound(idCliente));
            }
                return Result.Success(client);
            }
        
        public Result<Client> Get(int id)
        {
            var client = _repository.Get(s => s.Id == id);
            
            if (client is null)
            {
                return Result.Failure<Client>(ClientErrors.NotFound());
            }

                return Result.Success(client);
            }

        public Result Create(CreateClient createClient)
        {
            var client = _mapper.Map<CreateClient, Client>(createClient);
            _repository.Insert(Client.Create(0, client));
            _repository.Save();
            return Result.Success();
        }

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

