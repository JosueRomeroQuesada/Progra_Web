using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Clients
{
    //clase estatica con metodos para los errores
    public static class ClientErrors
    {
        //indica que el estudiante no fue encontrado por medio del batch
        public static Error NotFound(string batch) => 
            new Error("Clients.NOT_FOUND", $"The Client with Batch {batch} was not found.");

        //indica que el estudiante no fue encontrado por una busqueda general
        public static Error NotFound() =>
            new Error("Clients.NOT_FOUND", $"The Client was not found.");
    }
}
