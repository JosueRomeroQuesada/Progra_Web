using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Rutinas
{
    public class UpdateRutina
    {
            public int Id { get; set; }

            public string Descripcion { get; set; }

            public string Series { get; set; }

            public string Repeticiones { get; set; }

            public string Peso { get; set; }
    }
}
