﻿using Domain.Clients;
using Domain.Instructors;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Clients
{
    public interface IClientService
    {
        Result<IList<Client>> List(bool includeInstructors = false);

        Result<Client> Get(string idCliente, bool includeInstructors = false);

        Result<Client> Get(int id, bool includeInstructors = false);

        Result Create(CreateClient createClient);

        Result Update(UpdateClient updateClient);

        Result Delete(int id);
    }
}