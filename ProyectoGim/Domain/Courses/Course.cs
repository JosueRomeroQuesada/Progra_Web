using Domain.Clients;
using Domain.Instructors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Courses
{
    public class Course : Entity
    {
        public int Id { get; private set; }

        public string Name { get; private set; } 
        
        public bool Active { get; private set; }

        public List<Client> Clients { get; private set; }

        public List<Instructor> Instructors { get; private set; }
    }
}
