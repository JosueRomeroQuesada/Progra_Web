using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Clients
{
    public class ClientDTO
    {
        public ClientDTO() { }

        public ClientDTO(int id, string idCliente, string nombreCompleto) 
        {
            Id = id;
            IdCliente = idCliente;
            NombreCompleto = nombreCompleto;
        }

        public int Id { get; set; }

        public string IdCliente { get; set; }

        public string NombreCompleto { get; set; }
    }
}
