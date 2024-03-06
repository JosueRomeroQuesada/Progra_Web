using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Instructors
{
    public static class InstructorErrors
    {
        public static Error NotFound(string batch) => 
            new Error("Clients.NOT_FOUND", $"The Client with Batch {batch} was not found.");

        public static Error NotFound() =>
            new Error("Instructors.NOT_FOUND", $"The Client was not found.");
    }
}
