using Domain.Courses;
using Domain.Instructors;
using Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Clients
{
    public class Client : Entity
    {

        public Client()
        { }

        public static Client Create
            (int id, string idCliente, string nombre, string apellido,
            string peso, string altura, string preferencias)
        {
            return new()
            {
                Id = id,
                IdCliente = idCliente,
                Nombre = nombre,
                Apellido = apellido,
                Peso = peso,
                Altura = altura,
                Preferencias = preferencias
            };
        }

        public static Client Create
            (int id, Client client)
        {
            return new()
            {
                Id = id,
                IdCliente = client.IdCliente,
                Nombre = client.Nombre,
                Apellido = client.Apellido,
                Peso = client.Peso,
                Altura = client.Altura,
                Preferencias = client.Preferencias
            };
        }

        [Key]
        [JsonInclude]
        [JsonPropertyName("id")]
        public int Id { get; private set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(10, MinimumLength = 5)]
        [JsonInclude]
        [JsonPropertyName("idCliente")]
        public string IdCliente {  get; private set; }

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

        [Required(AllowEmptyStrings = false)]
        [StringLength(5, MinimumLength = 2)]
        [JsonInclude]
        [JsonPropertyName("peso")]
        public string Peso { get; private set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(5, MinimumLength = 3)]
        [JsonInclude]
        [JsonPropertyName("altura")]
        public string Altura { get; private set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 5)]
        [JsonInclude]
        [JsonPropertyName("preferencias")]
        public string Preferencias { get; private set; }

        /*[Column(TypeName = "decimal(2, 2)")]
        [JsonInclude]
        [JsonPropertyName("idCliente")]
        public string Peso { get; private set; }

        [Column(TypeName = "decimal(2, 2)")]
        [JsonInclude]
        [JsonPropertyName("altura")]
        public string Altura { get; private set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(40, MinimumLength = 3)]
        [JsonInclude]
        [JsonPropertyName("preferencias")]
        public string Preferencias { get; private set;}*/

        [JsonInclude]
        [JsonPropertyName("instructors")]
        public List<Instructor> Instructors { get; private set; } //de muchos a muchos  
    }
}
