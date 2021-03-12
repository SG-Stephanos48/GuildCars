using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class User 
    {

        public string Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }
        public string RoleId { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordConfirmed { get; set; }
        public int EmailConfirmed { get; set; }
        public int PhoneNumberConfirmed { get; set; }
        public int TwoFactorEnabled { get; set; }
        public int LockOutEnabled { get; set; }
        public int AccessFailedCount { get; set; }

    }
}
