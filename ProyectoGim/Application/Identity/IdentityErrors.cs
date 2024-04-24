using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Identity
{
    public static class IdentityErrors
    {
        public static Error AccessDenied() =>
            new Error("Identity.ACCESS_DENIED", "The user has not access.");

        public static Error NotCreated() =>
            new Error("Identity.NOT_CREATE", "The user could not be created.");

        public static Error InvalidUserOrPassword() =>
            new Error("Identity.INVALID_USER_OR_PASSWORD", "The user and/or password are invalid.");
    }
}
