using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESKTOP_II__01_
{
    class LoggedInUser
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string DateOfBirth { get; set; }

        public LoggedInUser(int iD, string username, string fullName, string dateOfBirth)
        {
            this.ID = iD;
            this.Username = username;
            this.FullName = fullName;
            this.DateOfBirth = dateOfBirth;
        }
    }
}
