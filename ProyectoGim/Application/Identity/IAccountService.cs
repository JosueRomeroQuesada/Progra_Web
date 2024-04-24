using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Identity
{
    public interface IAccountService
    {
        Task<Result> Signup(string email, string password);

        Task<Result> Signin(string email, string password);

        Task Signout();

        Result HasAccess(string email, string controller, string action);
    }
}
