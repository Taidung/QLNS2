using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class USER
    {
        QLNHANSUEntities db = new QLNHANSUEntities();
        public bool ValidateUser(string username, string password)
        {
            var user = db.tb_Users.FirstOrDefault(u => u.username == username);
            if (user != null)
            {
                // Kiểm tra mật khẩu đã mã hóa
                return user.password == password;
            }
            return false;
        }
    }
}
