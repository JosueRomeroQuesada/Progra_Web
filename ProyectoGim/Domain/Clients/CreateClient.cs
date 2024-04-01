using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Clients
{
    public class CreateClient
    {
        public string IdCliente { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Peso { get; set; }

        public string Altura { get; set; }

        public string Preferencias { get; set; }
    }
}
