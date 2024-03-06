using Application.Contexts;
using Application.Clients;
using Domain.Clients;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System.Linq.Expressions;

namespace Persistence.Clients
{
    public class ClientRepository : IClientRepository
    {
        private readonly IApplicationDbContext _context;
        private readonly DbSet<Client> _clients;

        public ClientRepository(ApplicationDbContext context)
        {
            _context = context;
            _clients = _context.Clients;
        }

        public List<Client> GetAll()
        {
            return _clients.ToList();
        }

        public Client Get(Expression<Func<Client, bool>> predicate)
        {
            IQueryable<Client> query = _clients;
            query = query.Where(predicate);

            return query.FirstOrDefault();
        }

        public void Insert(Client client)
        {
            _clients.Add(client);
        }

        public void Update(Client client)
        {
            _clients.Update(client);
        }

        public void Delete(Client client)
        {
            _clients.Remove(client);
        }

        public void Save()
        {
            _context.Save();
        }
    }
}
