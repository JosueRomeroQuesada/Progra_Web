using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Clients
{
    public class Client
    {
        private Client()
        { }

        public static Client Create
            (int id, string batch, string firstName, string lastName,
                DateTime birthDate, string email, string phoneNumber,
                    bool active)
        {
            return new()
            {
                Id = id,
                Batch = batch,
                FirstName = firstName,
                LastName = lastName,
                BirthDate = birthDate,
                Email = email,
                PhoneNumber = phoneNumber,
                Active = active
            };
        }

        public static Client Create(int id, Client client)
        {
            return new()
            {
                Id = id,
                Batch = client.Batch,
                FirstName = client.FirstName,
                LastName = client.LastName,
                BirthDate = client.BirthDate,
                Email = client.Email,
                PhoneNumber = client.PhoneNumber,
                Active = client.Active
            };
        }

        [Key]
        public int Id { get; private set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(10, MinimumLength = 5)]
        public string Batch { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(40, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(40, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Range(typeof(DateTime), minimum: "1900-01-01", maximum: "2024-01-01")]
        public DateTime BirthDate { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(150, MinimumLength = 5)]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(15, MinimumLength = 8)]
        public string PhoneNumber { get; set; }

        [Required]
        public bool Active { get; set; }
    }
}
