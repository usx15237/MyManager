using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class TeacherUI
    {
        private TeacherUI() { }
        #region 教师界面
        public static void Menu()
        {
            ShowTitle();
            while(true)
            {
                Console.Write("请选择操作(0~3)：");
                char c = char.Parse(Console.ReadLine());
                if (c == '0')
                    break;
                switch(c)
                {
                    case '1':
                        QueryTeachCourse();
                        ShowTitle();
                        break;
                    case '2':
                        Mark();
                        ShowTitle();
                        break;
                    case '3':
                        ChangePW();
                        ShowTitle();
                        break;
                    default:
                        Console.WriteLine("无效操作");
                        break;
                }
            }
        }

        private static void QueryTeachCourse()
        {
            string error = "";
            Model.Teacher teacher = BLL.BaseBLL.User as Model.Teacher;
            Model.TermCourse[] termcourse = BLL.TeacherBLL.QueryTeachCourse(teacher.ID);
            Console.WriteLine("学期课程ID\t  课程名\t  学生人数");
            Console.WriteLine("------------------------------");
            for(int i=0;i<termcourse.Length;i++)
            {
                Console.WriteLine("{0}\t  {1}\t  {2}",termcourse[i].ID, (BLL.AdminBLL.RetrieveCourse(termcourse[i].CourseID, out error)).Name, termcourse[i].GetAllStudent().Length);
            }
        }

        private static void Mark()
        {
            string error = "";
            Console.Write("请输入要登记成绩的课程ID：");
            string courseid = Console.ReadLine();
            Model.TermCourse termcourse = BLL.AdminBLL.RetrieveTermCourse(courseid,out error);
            Console.Write("请选择(1--登记某个学生的成绩  2--等级所有学生的成绩");
            char c = char.Parse(Console.ReadLine());
            if (c == '1')
            {
                Console.Write("请输入该学生的学号：");
                string studentid = Console.ReadLine();
                Console.Write("{0}的成绩：");
                double grade = double.Parse(Console.ReadLine());
                BLL.TeacherBLL.MarkingAStudent(courseid, studentid, grade);
                Console.WriteLine("登记成功");
            }
            else if (c == '2')
            {
                List<Model.HasStudents> hasstudents = new List<Model.HasStudents>();
                for (int i = 0; i < termcourse.GetAllStudent().Length; i++)
                {
                    Console.Write("{0}的分数：", termcourse.GetAllStudent()[i]);
                    double grade = double.Parse(Console.ReadLine());
                    hasstudents.Add(new Model.HasStudents(termcourse.GetAllStudent()[i], grade));
                }
                BLL.TeacherBLL.Marking(courseid, hasstudents.ToArray());
                Console.WriteLine("登记成功");
            }
            else
                Console.WriteLine("无效操作");
        }

        private static void ChangePW()
        {
            string error = "";
            Model.Teacher teacher = BLL.BaseBLL.User as Model.Teacher;
            Console.Write("请输入新密码：");
            string password = Console.ReadLine();
            if (BLL.TeacherBLL.ChangePassword(teacher.ID, password, out error))
            {
                Console.WriteLine(error);
            }
            else
                Console.WriteLine("错误" + error);
        }

        private static void ShowTitle()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("                教师界面              ");
            Console.WriteLine("       1.所授课程查询    2.成绩登记      ");
            Console.WriteLine("       3.个人信息修改                      ");
            Console.WriteLine("                 0.退出              ");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine();
        }
        #endregion
    }
}
