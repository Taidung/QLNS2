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
        public tb_Users getItem(int id)
        {
            return db.tb_Users.FirstOrDefault(x => x.id == id);
        }
        public List<tb_Users> getList()
        {
            return db.tb_Users.ToList();
        }
        public tb_Users Add(tb_Users user)
        {
            try
            {
                db.tb_Users.Add(user);
                db.SaveChanges();
                return user;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public tb_Users Update(tb_Users user)
        {
            try
            {
                var _user = db.tb_Users.FirstOrDefault(x => x.id == user.id);
                _user.username = user.username;
                _user.password = user.password;
                _user.role = user.role;
                db.SaveChanges();
                return user;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public void Delete(int id)
        {

            try
            {
                var _user = db.tb_Users.FirstOrDefault(x => x.id == id);
                db.tb_Users.Remove(_user);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }
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
