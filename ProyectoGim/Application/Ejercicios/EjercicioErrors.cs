using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ejercicios

{
    public static class EjercicioErrors
    {
        public static Error NotFound(string idEjercicio) =>
            new Error("Clients.NOT_FOUND", $"The Ejercicio with IdEjercicio {idEjercicio} was not found.");

        public static Error NotFound() =>
            new Error("Clients.NOT_FOUND", $"The Ejercicio with IdEjercicio was not found.");

        public static Error NotCreated() =>
            new Error("Clients.NOT_CREATED", $"The Ejercicio with IdEjercicio was not created.");

        public static Error NotUpdated() =>
           new Error("Clients.NOT_UPDATED", $"The Ejercicio with IdEjercicio was not updated.");
    }
}
