using LibraryWebApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.Services
{
    public interface IDataBaseService
    {
        public MemberRecord GetOneUser(string user_name);
        public MemberRecord Login(string user_name, string pw);
        public List<MemberRecord> GetAllUser();
    }
}
