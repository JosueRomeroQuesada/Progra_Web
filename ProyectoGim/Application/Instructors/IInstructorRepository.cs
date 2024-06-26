﻿using Application.Repositories;
using Domain.Instructors;
using Domain.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Instructors
{
    public interface IInstructorRepository : IRepositoryBase<Instructor>
    {
        void SubscribeIntructor(Instructor instructor, Client client);


    }


}
