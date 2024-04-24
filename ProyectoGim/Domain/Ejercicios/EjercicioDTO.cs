using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Ejercicios
{
    public class EjercicioDTO
    {
        public EjercicioDTO() { }

        public EjercicioDTO(int idEjercicio, string nombre, string zona, string descripcion)
        {
            IdEjercicio = idEjercicio;
            Nombre = nombre;
            Zona = zona;
            Descripcion = descripcion;
        }

        public int IdEjercicio { get; set; }

        public string Nombre { get; set; }

        public string Zona { get; set; }

        public string Descripcion { get; set; }
    }
}
