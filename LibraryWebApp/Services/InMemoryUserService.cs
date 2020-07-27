using LibraryWebApp.Domain;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.Services
{
    public class InMemoryUserService : IUserService
    {
         
        [Required]
        public List<MemberRecord> _allUser = new List<MemberRecord>();
        public InMemoryUserService()
        {

            DataBaseService dbService = new DataBaseService();
            _allUser = dbService.GetAllUser();
        }
       
      
        public MemberRecord GetOne(int id)
        {
            return _allUser.Where(u => u.User_Idint == id).First();
        }

        public MemberRecord Login(string user_name, string pw)
        {
            throw new NotImplementedException();
        }

        public MemberRecord GetOne(string user_name, string pw)
        {
            throw new NotImplementedException();
        }

        public MemberRecord GetAll(string user_name, string pw)
        {
            throw new NotImplementedException();
        }
    }
}
