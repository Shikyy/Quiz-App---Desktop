using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESKTOP_II__01_
{
    class GuestInfo
    {
        private static GuestJoin guestJoin;
        public static GuestJoin GetGuestJoin()
        {
            return guestJoin;
        }
        public static void SetGuestInfo(GuestJoin guest)
        {
            guestJoin = guest;
        }
    }
}
