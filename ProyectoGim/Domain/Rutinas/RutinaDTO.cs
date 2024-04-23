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

        //public RutinaDTO(int id, string idRutina, string descripcion)
        //{
        //    Id = id;
        //    IdRutina = idRutina;
        //    Descripcion = descripcion;
        //}

        public RutinaDTO(int id, string idRutina, string descripcion, string series, string repeticiones, string peso)
        {
            Id = id;
            IdRutina = idRutina;
            Descripcion = descripcion;
            Series = series;
            Repeticiones = repeticiones;
            Peso = peso;
        }

        public int Id { get; set; }

        public string IdRutina { get; set; }

        public string Descripcion { get; set; }

        public string Series { get; set; }

        public string Repeticiones { get; set; }

        public string Peso { get; set; }
    }
}
