using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.Domain
{
    public class MemberRecord
    {
        public int User_Idint { get; set; }
        public string tipus { get; set; }
        public DateTime Date_of_Membership { get; set; }
        public int max_book_limit { get; set; }
        public int phone_no { get; set; }
        public string User_Name { get; set; }
        public string pw { get; set; }
        public int Is_amember { get; set; }

        public MemberRecord(string user_name, string pw, string pw1)
        {
            User_Name = user_name;
            this.pw = pw;
            
        }

        public MemberRecord(int user_Idint, string user_Name, string pw)
        {
            User_Idint = user_Idint;
            User_Name = user_Name;
            this.pw = pw;
        }

        public MemberRecord(string user_Name, string pw)
        {
            User_Name = user_Name;
            this.pw = pw;
        }
    }
}
