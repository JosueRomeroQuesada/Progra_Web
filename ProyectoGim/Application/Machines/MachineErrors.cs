using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Machines
{
    public static class MachineErrors
    {
        public static Error NotFound (string idMachine) => 
            new Error("Machine.NOT_FOUND", $"The Machine with IdMachine {idMachine} was not found.");

        public static Error NotFound() =>
            new Error("Machine.NOT_FOUND", $"The Machine with IdMachine was not found.");

        public static Error NotCreated() =>
            new Error("Machines.NOT_CREATED", $"The Machine with IdMachine was not created.");

        public static Error NotUpdated() =>
           new Error("Machines.NOT_UPDATED", $"The Machine with IdMachine was not updated.");
    }
}
