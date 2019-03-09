using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowTitle();
            switch(LoginUI.UserType())
            {
                case "管理员":
                    AdminUI.Menu();
                    break;
                case "教师":
                    TeacherUI.Menu();
                    break;
                case "学生":
                    StudentUI.Menu();
                    break;
            }
        }

        private static void ShowTitle()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("                           ");
            Console.WriteLine("         教务管理系统        ");
            Console.WriteLine("    Copyright(C) 2009-2017 ");
            Console.WriteLine("                           ");
            Console.WriteLine("---------------------------");
        }
    }
}
