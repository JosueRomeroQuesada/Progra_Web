using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Clients
{
    public static class ClientErrors
    {
        public static Error NotFound (string idCliente)=> 
            new Error("Clients.NOT_FOUND", $"The Client with IdCliente {idCliente} was not found.");

        public static Error NotFound() =>
            new Error("Clients.NOT_FOUND", $"The Client with IdCliente was not found.");

        public static Error NotCreated() =>
            new Error("Clients.NOT_CREATED", $"The Client with IdCliente was not created.");

        public static Error NotUpdated() =>
           new Error("Clients.NOT_UPDATED", $"The Client with IdCliente was not updated.");
    }
}
