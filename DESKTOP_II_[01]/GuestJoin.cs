using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESKTOP_II__01_
{
    class GuestJoin
    {
        public int QuizID { get; set; }
        public string NickName { get; set; }
        public string QuizCode { get; set; }

        public GuestJoin(int quizID, string nickName, string quizCode)
        {
            this.QuizID = quizID;
            this.NickName = nickName;
            this.QuizCode = quizCode;
        }
    }
}
