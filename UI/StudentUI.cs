using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class StudentUI
    {
        private StudentUI() { }
        #region 学生界面
        public static void Menu()
        {
            ShowTitle();
            while(true)
            {
                Console.Write("请选择操作(0~4)：");
                char c = char.Parse(Console.ReadLine());
                if (c == '0')
                    break;
                switch (c)
                {
                    case '1':
                        ChooseCourse();
                        ShowTitle();
                        break;
                    case '2':
                        WithdrawlCourse();
                        ShowTitle();
                        break;
                    case '3':
                        QueryGrades();
                        ShowTitle();
                        break;
                    case '4':
                        ChangePW();
                        ShowTitle();
                        break;
                    default:
                        Console.WriteLine("无效操作");
                        break;
                }
            }
        }

        private static void ChooseCourse()
        {
            string error = "";
            Model.Student student = BLL.BaseBLL.User as Model.Student;
            Console.WriteLine("课程选修");
            Console.WriteLine();
            Console.Write("请输入要选修的课程ID(按回车显示课程信息：");
            string courseid = Console.ReadLine();
            if(courseid=="")
            {
                QueryAllTermCourse();
            }
            else
            {
                if (BLL.StudentBLL.chooseCourse(student.ID, courseid, out error))
                {
                    Console.WriteLine(error);
                }
                else
                {
                    Console.WriteLine("错误:" + error);
                }
            }
        }

        private static void WithdrawlCourse()
        {
            string error = "";
            Model.Student student = BLL.BaseBLL.User as Model.Student;
            Console.WriteLine("课程退选");
            Console.WriteLine();
            Console.Write("请输入要退选的课程ID(按回车显示课程信息：");
            string courseid = Console.ReadLine();
            if (courseid == "")
            {
                QueryAllTermCourse();
            }
            else
            {
                if (BLL.StudentBLL.WithdrawlCourse(student.ID, courseid, out error))
                {
                    Console.WriteLine(error);
                }
                else
                {
                    Console.WriteLine("错误:" + error);
                }
            }
        }

        private static void QueryAllTermCourse()
        {
            string error;
            Console.WriteLine();
            Model.TermCourse[] termCourses = BLL.AdminBLL.RetrieveAllTermCourse();
            Console.WriteLine("学期课程ID\t  课程名\t  任课教师");
            Console.WriteLine("-----------------------------");
            for (int i = 0; i < termCourses.Length; i++)
            {
                Console.WriteLine("{0}\t  {1}\t  {2}", termCourses[i].ID, (BLL.AdminBLL.RetrieveCourse(termCourses[i].CourseID, out error)).Name, (BLL.AdminBLL.RetrieveTeacher(termCourses[i].TeacherID, out error)).Name);
            }
        }
        private static void QueryGrades()
        {
            Model.Student student = BLL.BaseBLL.User as Model.Student;
            Model.ChoosedCourses[] choosedcourses = BLL.StudentBLL.GetAllChoosedCoursesGrade(student.ID);
            Console.WriteLine("课程ID\t  成绩");
            for(int i=0;i<choosedcourses.Length;i++)
            {
                Console.WriteLine("{0}\t  {1}", choosedcourses[i].courseid, choosedcourses[i].Grade);
            }
            Console.WriteLine();
        }

        private static void ChangePW()
        {
            string error = "";
            Model.Student student = BLL.BaseBLL.User as Model.Student;
            Console.Write("请输入新密码：");
            string password = Console.ReadLine();
            if (BLL.StudentBLL.ChangePassword(student.ID, password, out error))
            {
                Console.WriteLine(error);
            }
            else
                Console.WriteLine("错误：" + error);
        }

        private static void ShowTitle()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("                学生界面              ");
            Console.WriteLine("       1.课程选修       2.课程退选        ");
            Console.WriteLine("       3.成绩查询       4.个人信息修改    ");
            Console.WriteLine("                 0.退出              ");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine();
        }
        #endregion
    }
}
