using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.Domain
{
    public class Transactions
    {
        public int Trans_Id { get; set; }
        public int User_Idint { get; set; }
        public int book_id { get; set; }
        public DateTime date_of_issue { get; set; }
        public DateTime due_date { get; set; }




    }
}
