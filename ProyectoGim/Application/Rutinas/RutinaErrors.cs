using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace Application.Rutinas
{
    public static class RutinaErrors
    {
        public static Error NotFound(string idRutina) =>
            new Error("Rutinas.NOT_FOUND", $"The Rutina with IdRutina {idRutina} was not found.");

        public static Error NotFound() =>
            new Error("Rutinas.NOT_FOUND", $"The Rutina with IdRutina was not found.");

        public static Error NotCreated() =>
            new Error("Rutinas.NOT_CREATED", $"The Rutina with IdRutina was not created.");

        public static Error NotUpdated() =>
           new Error("Rutinas.NOT_UPDATED", $"The Rutina with IdRutina was not updated.");
    }
}
