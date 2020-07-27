using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryWebApp.Domain;

namespace LibraryWebApp.Services
{
    interface IUserService
    {
        public MemberRecord Login(string user_name, string pw);
        public MemberRecord GetOne(string user_name, string pw);
        public MemberRecord GetAll(string user_name, string pw);


    }
}
