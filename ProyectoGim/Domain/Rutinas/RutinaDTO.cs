using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Rutinas
{
    public class RutinaDTO
    {
        public RutinaDTO() { }

        public RutinaDTO(int id, string idRutina)
        {
            Id = id;
            IdRutina = idRutina;
        }

        public int Id { get; set; }

        public string IdRutina { get; set; }

    }
}
