using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class LoginUI
    {
        private LoginUI() { }
        public static string UserType()
        {
            string error, result="";
            ShowTitle();
            Console.Write("请输入用户名:");
            string id = Console.ReadLine();
            Console.Write("请输入密码:");
            string password = Console.ReadLine();
            bool flag=BLL.LoginBLL.Login(id, password, out error);
            if (flag)
            {
                Welcome();
                result = BLL.BaseBLL.User.GetUserType();
            }
            else
                ShowErrorMessage(error);
            return result;
        }

        private static void ShowErrorMessage(string error)
        {
            Console.WriteLine("错误:" + error);
        }

        private static void Welcome()
        {
            Console.WriteLine("欢迎您，{0}，现在是{1}", BLL.BaseBLL.User.Name, DateTime.Now.ToString());
        }

        private static void ShowTitle()
        {
            Console.WriteLine("******用户登陆******\n");
        }
    }
}
