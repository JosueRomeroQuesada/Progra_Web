using Domain.Courses;
using Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Instructors
{
    public class Instructor : Entity
    {

        public Instructor()
        { }

        public static Instructor Create
            (int id, string idEntrenador, string cedula, string nombre, string apellido)
        {
            return new()
            {
                Id = id,
                IdEntrenador = idEntrenador,
                Cedula = cedula,
                Nombre = nombre,
                Apellido = apellido
            };
        }

        public static Instructor Create
            (int id, Instructor instructor)
        {
            return new()
            {
                Id = id,
                IdEntrenador = instructor.IdEntrenador,
                Cedula = instructor.Cedula,
                Nombre = instructor.Nombre,
                Apellido = instructor.Apellido
            };
        }

        [Key]
        [JsonInclude]
        [JsonPropertyName("id")]
        public int Id { get; private set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(10, MinimumLength = 5)]
        [JsonInclude]
        [JsonPropertyName("idEntrenador")]
        public string IdEntrenador {  get; private set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(10, MinimumLength = 5)]
        [JsonInclude]
        [JsonPropertyName("cedula")]
        public string Cedula { get; private set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(40, MinimumLength = 3)]
        [JsonInclude]
        [JsonPropertyName("nombre")]
        public string Nombre { get; private set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(40, MinimumLength = 2)]
        [JsonInclude]
        [JsonPropertyName("apellido")]
        public string Apellido { get; private set; }
        /*
        [JsonIgnore]
        public List<Course> Courses { get; private set; } 
        */
    }
}
