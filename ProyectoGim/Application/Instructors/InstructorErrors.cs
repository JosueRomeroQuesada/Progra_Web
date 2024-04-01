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
        public static Error NotFound (string idEntrenador)=> 
            new Error("Instructors.NOT_FOUND", $"The Instructor with IdEntrenador {idEntrenador} was not found.");

        public static Error NotFound() =>
            new Error("Instructors.NOT_FOUND", $"The Instructor with IdEntrenador was not found.");

        public static Error NotCreated() =>
            new Error("Instructors.NOT_CREATED", $"The Instructor with IdEntrenador was not created.");

        public static Error NotUpdated() =>
           new Error("Instructors.NOT_UPDATED", $"The Instructor with IdEntrenador was not updated.");
    }
}
