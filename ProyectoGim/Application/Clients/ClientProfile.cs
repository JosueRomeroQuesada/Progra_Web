﻿using AutoMapper;
using Domain.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Clients
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<CreateClient, Client>();

            CreateMap<UpdateClient, Client>()
                   .ForMember(destination => destination.Id, source => source.Ignore());

            CreateMap<Client, UpdateClient>();
                   
            CreateMap<Client, ClientDTO>()
                .ConstructUsing(source => new ClientDTO(source.Id, source.IdCliente, string.Concat(source.Nombre, " ", source.Apellido)));
        }
    }
}
