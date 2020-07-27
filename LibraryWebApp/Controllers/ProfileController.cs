using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibraryWebApp.Domain;
using Microsoft.Extensions.Logging;
using LibraryWebApp.Services;

namespace LibraryWebApp.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly DataBaseService _dbService;
        private static string user_name;
        public ProfileController(DataBaseService dbService)
        {
            _dbService = dbService;
        }

        public IActionResult Index()
        {
            user_name = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            var user = _dbService.GetOneUser(user_name);
            return View(new MemberRecord(user.User_Idint,user.User_Name, user.pw));
        }

        


        public MemberRecord GetCurrentUser()
        {
           MemberRecord user = _dbService.GetOneUser(user_name);

            return user;
        }




    }
}