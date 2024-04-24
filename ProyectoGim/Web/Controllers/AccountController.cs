using Application.Identity;
using Domain.Account;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> Signin()
        {
            return View(new AccountViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Signin(AccountViewModel model, [FromQuery] string returnUrl = null) 
        {
            if (ModelState.IsValid)
            { 
                var result = await _accountService.Signin(model.Email, model.Password);
                if (result.IsSuccess)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    { 
                        return LocalRedirect(returnUrl);
                    }

                    return RedirectToAction("index", "Home");
                }

                ModelState.AddModelError(string.Empty, result.Error.description);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View(new AccountViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Signup(AccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.Signup(model.Email, model.Password);
                if (result.IsSuccess)
                {
                    return RedirectToAction("index", "Home");
                }

                ModelState.AddModelError(string.Empty, result.Error.description);
            }

            return View(model);
        }

        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> Signout()
        {
            await _accountService.Signout();
            return RedirectToAction("index", "Home");
        }

    }
}
