using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESKTOP_II__01_
{
    class LoggedInUserInfo
    {
        private static LoggedInUser loggedInUser;

        public static LoggedInUser GetLoggedInUser()
        {
            return loggedInUser;
        }

        public static void SetLoggedInUser(LoggedInUser user)
        {
            loggedInUser = user;
        }
    }
}
