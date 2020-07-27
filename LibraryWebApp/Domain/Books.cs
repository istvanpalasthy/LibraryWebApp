using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.Domain
{
    public class Books
    {
      
        public int book_id { get; set; }
        public string Book_Title { get; set; }
        public string Book_Author { get; set; }
        public string lang { get; set; }
        public int No_Copies_Actual { get; set; }
        public int No_Copies_Current { get; set; }
        public int Publication_year { get; set; }

        public Books(int book_id,string book_title,string book_author,string lang, int no_copies_actual,int no_copies_current,int publication_year)
        {
            this.book_id = book_id;
            Book_Title = book_title;
            Book_Author = book_author;
            this.lang = lang;
            No_Copies_Actual = no_copies_actual;
            No_Copies_Current = no_copies_current;
            Publication_year = publication_year;




             
        }

        public Books(string book_Title, string book_Author, string lang)
        {
            Book_Title = book_Title;
            Book_Author = book_Author;
            this.lang = lang;
        }

        public Books(int book_id, string book_Title, string book_Author, string lang)
        {
            this.book_id = book_id;
            Book_Title = book_Title;
            Book_Author = book_Author;
            this.lang = lang;
        }
    }
}
