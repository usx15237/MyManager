using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LoginBLL : BaseBLL
    {
        private LoginBLL() { }

        public static bool Login(string id, string password, out string error)
        {
            error = "";
            if (id == "")
            {
                error = "用户名不能为空";
                return false;
            }
            switch (id.ToLower()[0])
            {
                case 'a':
                    user = (Model.Admin)admins.Retrieve(id); break;
                case 't':
                    user = (Model.Teacher)teachers.Retrieve(id); break;
                case 's':
                    user = (Model.Student)students.Retrieve(id); break;
                default:
                    error = "用户ID格式不正确";
                    return false;
            }
            if (user == null)
            {
                error = "该用户不存在";
                return false;
            }
            if (user.Password != password)
            {
                error = "密码错误";
                return false;
            }
            return true;
        }
    }
}
