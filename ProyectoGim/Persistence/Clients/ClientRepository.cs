using Application.Clients;
using Domain.Clients;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Repositories;
using System.Linq.Expressions;

namespace Persistence.Clients
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(ApplicationDbContext context)
            : base(context)
        {
            
        }
    }
}
