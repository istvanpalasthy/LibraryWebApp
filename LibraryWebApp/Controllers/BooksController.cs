using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryWebApp.Services;
using LibraryWebApp.Domain;

namespace LibraryWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : Controller
    {

        DataBaseService sanyika = new DataBaseService();


        public IActionResult Index()
        {
            var lofasz = sanyika.GetThreeBook();
            return View("Books", lofasz);
        }

        [HttpGet]
        public List<Books> GetAllBooks()
        {
            DataBaseService datadb = new DataBaseService();
            return datadb.GetThreeBook();
        }

        [HttpPost]
        [Route("UpdateBooks")]
        public void UpdateBooks([FromForm]string book_Title, [FromForm]string book_author, [FromForm]string lang)
        {

            sanyika.AddBooks(book_Title, book_author, lang);
        }
        [HttpPost]
        [Route("DeleteBook")]
        public void DeleteBook([FromForm]int book_id)
        {
            sanyika.DeleteBook(book_id);
        }

        [HttpPost]
        [Route("AddBookToProfile")]
        public void AddBookToProfile([FromForm]int book_id)
        {
            ProfileController cigo = new ProfileController(sanyika);
            int valtozo = cigo.GetCurrentUser().User_Idint;
            sanyika.LinkBookToProfile(book_id,valtozo);
        }

        [HttpGet]
        [Route("DrawBookToProfile")]
        public List<Books> DrawBookToProfile()
        {
            ProfileController cigo = new ProfileController(sanyika);
            MemberRecord menjma = cigo.GetCurrentUser();
           return sanyika.BookOnProfile(menjma.User_Idint);


        }

        [HttpPost]
        [Route("ModifyBooks")]
        public void ModifyBooks([FromForm]string realbooktitle, [FromForm]string book_title, [FromForm]string book_author, [FromForm]string lang)
        {

            sanyika.ModifyBook(realbooktitle,book_title, book_author, lang);
        }

        [HttpPost]
        [Route("RegisterUser")]
        public void RegisterUser([FromForm]string user_name, [FromForm]string pw)
        {

            sanyika.AddUsers(user_name, pw);

        }


        [HttpPost]
        [Route("DeletefromProfile")]
        public void DeletefromProfile([FromForm]int book_id)
        {

            sanyika.DeleteFromProfile(book_id);

        }


    }
}