using Application.Repositories;
using Domain.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Clients
{
    public interface IClientRepository : IRepositoryBase<Client>
    {
        
    }
}
