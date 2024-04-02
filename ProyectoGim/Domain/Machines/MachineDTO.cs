using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Machines
{
    public class MachineDTO
    {
        public MachineDTO() { }

        public MachineDTO(int id, string codigo, string nombre) 
        {
            Id = id;
            Codigo = codigo;
            Nombre = nombre;
        }

        public int Id { get; set; }

        public string Codigo { get; set; }

        public string Nombre { get; set; }
    }
}
