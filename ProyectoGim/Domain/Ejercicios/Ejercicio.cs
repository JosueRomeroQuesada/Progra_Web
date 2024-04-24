using Domain.Instructors;
using Domain.Ejercicios;
using Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Domain.Machines;
using Shared.Domain;

namespace Domain.Ejercicios
{
    public class Ejercicio : Entity
    {

        public Ejercicio()
        { }

        public static Ejercicio Create
            (int idEjercicio, string nombre, string zona, string descripcion)
        {
            return new()
            {
                IdEjercicio = idEjercicio,
                Nombre = nombre,
                Zona = zona,
                Descripcion = descripcion

            };
        }

        public static Ejercicio Create
            (int idEjercicio, Ejercicio ejercicio)
        {
            return new()
            {
                IdEjercicio = idEjercicio,
                Nombre = ejercicio.Nombre,
                Zona = ejercicio.Zona,
                Descripcion = ejercicio.Descripcion

            };
        }

        [Key]
        [JsonInclude]
        [JsonPropertyName("idEjercicio")]
        public int IdEjercicio { get; private set; }


        [Required(AllowEmptyStrings = false)]
        [StringLength(40, MinimumLength = 3)]
        [JsonInclude]
        [JsonPropertyName("nombre")]
        public string Nombre { get; private set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(40, MinimumLength = 2)]
        [JsonInclude]
        [JsonPropertyName("zona")]
        public string Zona { get; private set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 2)]
        [JsonInclude]
        [JsonPropertyName("descripcion")]
        public string Descripcion { get; private set; }


        [JsonInclude]
        [JsonPropertyName("machines")]
        public List<Machine> Machines { get; private set; } //de muchos a muchos  
    }
}
