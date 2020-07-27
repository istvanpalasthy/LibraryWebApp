using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LibraryWebApp.Domain;
using LibraryWebApp.Services;
using Microsoft.AspNetCore.Authorization;

namespace LibraryWebApp.Controllers
{
   

    public class AccountController : Controller
    {

        DataBaseService dbszervice = new DataBaseService();

     
        // GET: Account
        
        private readonly ILogger<AccountController> _logger;
        private readonly IDataBaseService _dbService;

        public AccountController(ILogger<AccountController> logger, IDataBaseService dbService)
        {
            _logger = logger;
            _dbService = dbService;
        }
        [HttpGet]
        public IActionResult BookAdd()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public async Task<ActionResult> LoginAsync([FromForm] string user_name, [FromForm] string password)
        {
            MemberRecord user = _dbService.Login(user_name, password);
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email,user.User_Name),

                };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                //AllowRefresh = <bool>,
                // Refreshing the authentication session should be allowed.

                //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                // The time at which the authentication ticket expires. A 
                // value set here overrides the ExpireTimeSpan option of 
                // CookieAuthenticationOptions set with AddCookie.

                //IsPersistent = true,
                // Whether the authentication session is persisted across 
                // multiple requests. When used with cookies, controls
                // whether the cookie's lifetime is absolute (matching the
                // lifetime of the authentication ticket) or session-based.

                //IssuedUtc = <DateTimeOffset>,
                // The time at which the authentication ticket was issued.

                //RedirectUri = <string>
                // The full path or absolute URI to be used as an http 
                // redirect response value.
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            return RedirectToAction("Index", "Profile");
        }

        public IActionResult Register()
        {
            return View();
        }

       

    }
}