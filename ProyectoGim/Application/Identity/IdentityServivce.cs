using Shared;

namespace Application.Identity
{
    public class IdentityServivce : IIdentityService
    {
        private readonly IAccountService _authenticationService;

        public IdentityServivce(IAccountService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<Result> Signin(string email, string password)
        {
            // TODO: email and password validation => InputCredentials
            return await _authenticationService.Signin(email, password);
        }

        public async Task<Result> Signup(string email, string password)
        {
            // TODO: email and password validation => InputCredentials
            return await _authenticationService.Signin(email, password);
        }

        public async Task Signout()
        {
            await _authenticationService.Signout();
        }

        public Result HasAccess(string email, string controller, string action)
        {
            return _authenticationService.HasAccess(email, controller, action);
        }
    }
}
