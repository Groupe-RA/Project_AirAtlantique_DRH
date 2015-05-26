using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AirAtlantique.Database
{
    class UsersDao : CommonDao
    {
        public bool Login(string username, string password)
        {
            var hashed = HashPassword(password);
            var account = db.Login.FirstOrDefault(x => x.Login1 == username);
            if (account != null && account.Password == hashed)
                return true;
            else
                return false;
        }

        public void AddUser(string username, string password)
        {
            var nouveau = new Database.Login
            {
                Login1 = username,
                Password = HashPassword(password)
            };

            db.Login.Add(nouveau);
            db.SaveChanges();
        }

        public static string HashPassword(string value)
        {
            var sha1 = System.Security.Cryptography.SHA1.Create();
            var inputBytes = Encoding.ASCII.GetBytes(value);
            var hash = sha1.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

    }
}
