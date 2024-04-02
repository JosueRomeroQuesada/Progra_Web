
using Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Machines
{
    public class Machine : Entity
    {

        public Machine()
        { }

        public static Machine Create
            (int id, string codigo, string nombre, string descripcion)
        {
            return new()
            {
                Id = id,
                Codigo = codigo,
                Nombre = nombre,
                Descripcion = descripcion
            };
        }

        public static Machine Create
            (int id, Machine machine)
        {
            return new()
            {
                Id = id,
                Codigo = machine.Codigo,
                Nombre = machine.Nombre,
                Descripcion = machine.Descripcion
            };
        }

        [Key]
        [JsonInclude]
        [JsonPropertyName("id")]
        public int Id { get; private set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(10, MinimumLength = 5)]
        [JsonInclude]
        [JsonPropertyName("codigo")]
        public string Codigo {  get; private set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(40, MinimumLength = 3)]
        [JsonInclude]
        [JsonPropertyName("nombre")]
        public string Nombre { get; private set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(40, MinimumLength = 2)]
        [JsonInclude]
        [JsonPropertyName("descripcion")]
        public string Descripcion { get; private set; }

    }
}
