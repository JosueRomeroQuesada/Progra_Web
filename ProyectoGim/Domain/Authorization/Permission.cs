using Microsoft.EntityFrameworkCore;
using Shared.Domain;

namespace Domain.Authorization
{
    [PrimaryKey(nameof(Email), nameof(Controller), nameof(Action))]
    public class Permission : Entity
    {
        public string Email { get; private set; }

        public string Controller { get; private set; }

        public string Action { get; set; }
    }
}
