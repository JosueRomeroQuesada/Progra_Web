using Domain.Rutinas;
using Domain.Weekdays;
using Domain.Ejercicios;
using Domain.Instructors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Shared.Domain;

namespace Domain.Rutinas
{
    public class Rutina : Entity
    {
        public Rutina() { }

        public static Rutina Create(int id, string idRutina, string descripcion, string series,
            string repeticiones, string peso)
        {
            return new()
            {
                Id = id,
                IdRutina = idRutina,
                Descripcion = descripcion,
                Series = series,
                Repeticiones = repeticiones,
                Peso = peso
            };
        }

        public static Rutina Create
            (int id, Rutina rutina)
        {
            return new()
            {
                Id = id,
                IdRutina = rutina.IdRutina,
                Descripcion = rutina.Descripcion,
                Series = rutina.Series,
                Repeticiones = rutina.Repeticiones,
                Peso = rutina.Peso
            };
        }

        [Key]
        [JsonInclude]
        [JsonPropertyName("id")]
        public int Id { get; private set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(10, MinimumLength = 5)]
        [JsonInclude]
        [JsonPropertyName("idRutina")]
        public string IdRutina { get; private set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 3)]
        [JsonInclude]
        [JsonPropertyName("descripcion")]
        public string Descripcion { get; private set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(40, MinimumLength = 2)]
        [JsonInclude]
        [JsonPropertyName("series")]
        public string Series { get; private set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(40, MinimumLength = 3)]
        [JsonInclude]
        [JsonPropertyName("repeticiones")]
        public string Repeticiones { get; private set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 2)]
        [JsonInclude]
        [JsonPropertyName("peso")]
        public string Peso { get; private set; }

        [JsonInclude]
        [JsonPropertyName("ejercicios")]
        public List<Ejercicio> Ejercicios { get; private set; } 

        [JsonInclude]
        [JsonPropertyName("dias")]
        public List<Weekday> dias { get; private set; } 
        
    }
}

