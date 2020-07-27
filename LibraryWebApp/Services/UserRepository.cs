using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LibraryWebApp.Services;
using LibraryWebApp.Domain;

namespace LibraryWebApp.Services
{
    public class UserRepository
    {
        [Required]
        private List<MemberRecord> _allUser = new List<MemberRecord>();

        public UserRepository()
        {

            DataBaseService dbService = new DataBaseService();
            _allUser = dbService.GetAllUser();
        }
        public MemberRecord GetByUsernameAndPassword(MemberRecord user)
        {
            return _allUser.Where(u => u.User_Name == user.User_Name & u.pw == user.pw).FirstOrDefault();
        }
    }
}
