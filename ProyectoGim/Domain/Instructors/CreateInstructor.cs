﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Instructors
{
    public class CreateInstructor
    {
        public string IdEntrenador { get; set; }

        public string Cedula { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }
        public int ClientId { get; set; }
    }
}
