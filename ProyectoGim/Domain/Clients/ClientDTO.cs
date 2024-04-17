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

        public ClientDTO(int id, string idCliente, string nombreCompleto, string peso, string altura, string preferencias) 
        {
            Id = id;
            IdCliente = idCliente;
            NombreCompleto = nombreCompleto;
            Peso = peso;
            Altura = altura;
            Preferencias = preferencias;
        }

        public int Id { get; set; }

        public string IdCliente { get; set; }

        public string NombreCompleto { get; set; }
        public string Peso { get; }
        public string Altura { get; }
        public string Preferencias { get; }
    }
}
