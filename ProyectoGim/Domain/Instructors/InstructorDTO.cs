using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Instructors
{
    public class InstructorDTO
    {
        public InstructorDTO() { }

        public InstructorDTO(int id, string idEntrenador, string nombreCompleto, string cedula) 
        {
            Id = id;
            IdEntrenador = idEntrenador;
            Cedula = cedula;
            NombreCompleto = nombreCompleto;
        }

        public int Id { get; set; }

        public string IdEntrenador { get; set; }
        public string Cedula { get; set; }
        public string NombreCompleto { get; set; }
    }
}
