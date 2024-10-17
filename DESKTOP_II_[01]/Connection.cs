using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace DESKTOP_II__01_
{
    class Connection
    {
        public SqlConnection GetConnection()
        {
            SqlConnection connect = new SqlConnection("Data Source=LAPTOP-65G6I7P1;Initial Catalog=QuizinAja;Integrated Security=True");
            return connect;
        }

        public string HashedPass(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();

                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString().Substring(0, 20);
            }
        }
    }
}
