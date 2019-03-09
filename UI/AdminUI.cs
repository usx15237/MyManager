
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class AdminUI
    {
        private AdminUI() { }
        #region 系统菜单
        public static void Menu()
        {
            ShowTitle();
            while (true)
            {
                Console.Write("请选择操作(0~4):");
                string cmd = Console.ReadLine();
                if (cmd == "0")
                    break;
                switch (cmd)
                {
                    case "1":
                        TeacherAdmin();
                        ShowTitle();
                        break;
                    case "2":
                        StudentAdmin();
                        ShowTitle();
                        break;
                    case "3":
                        CourseAdmin();
                        ShowTitle();
                        break;
                    case "4":
                        TermCourseAdmin();
                        ShowTitle();
                        break;
                    default:
                        Console.WriteLine("无效的选择，请重试");
                        break;
                }
            }
            BLL.BaseBLL.SaveALL();
        }
        private static void ShowTitle()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("               系统管理菜单             ");
            Console.WriteLine("       1.教师管理       2.学生管理      ");
            Console.WriteLine("       3.课程管理       4.学期课程管理   ");
            Console.WriteLine("              0.退出系统               ");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine();
        }
        #endregion

        #region 课程管理菜单
        private static void CourseAdmin()
        {
            ShowCourseAdminTitle();
            while (true)
            {
                Console.Write("请选择操作(0~4):");
                string cmd = Console.ReadLine();
                if (cmd == "0")
                    break;
                switch (cmd)
                {
                    case "1":
                        AddCourse();
                        break;
                    case "2":
                        DeleteCourse();
                        break;
                    case "3":
                        QueryCourse();
                        break;
                    default:
                        Console.WriteLine("无效的选择，请重试");
                        break;
                }
            }
        }

        private static void QueryCourse()
        {
            string error = "";
            Console.WriteLine();
            Console.Write("请选择(1--查询某门课程信息  2--查询所有课程信息):");
            string cmd = Console.ReadLine();
            if (cmd == "1")
            {
                Console.Write("请输入该课程的ID:");
                string id = Console.ReadLine();
                Model.Course course = BLL.AdminBLL.RetrieveCourse(id, out error);
                Console.WriteLine("课程信息：");
                Console.WriteLine("课程ID\t  课程名");
                Console.WriteLine("---------------");
                Console.WriteLine("{0}\t  {1}", course.CourseID, course.Name);
            }
            else if (cmd == "2")
            {
                Model.Course[] courses = BLL.AdminBLL.RetrieveAllCourse();
                Console.WriteLine("课程信息");
                Console.WriteLine("课程ID\t  课程名");
                Console.WriteLine("---------------");
                for (int i = 0; i < courses.Length; i++)
                {
                    Console.WriteLine("{0}\t  {1}", courses[i].CourseID, courses[i].Name);
                }
            }
            else
                Console.WriteLine("无效的操作");
        }

        private static void DeleteCourse()
        {
            Console.WriteLine();
            Console.WriteLine("删除课程记录");
            Console.Write("请输入要删除的课程ID： ");
            string id = Console.ReadLine();
            string error;
            Model.Course course = BLL.AdminBLL.RetrieveCourse(id, out error);
            if (course == null)
            {
                Console.WriteLine("错误:" + error);
            }
            else
            {
                Console.WriteLine("\t课程名称： {0}", course.Name);
                Console.Write("确认要删除该课程吗？(Y/N)");
                char c = char.Parse(Console.ReadLine());
                if (c == 'y' || c == 'Y')
                {
                    bool result = BLL.AdminBLL.DeleteCourse(id, out error);
                    if (result)
                    {
                        Console.WriteLine("删除成功");
                    }
                    else
                    {
                        Console.WriteLine("错误:" + error);
                    }
                }
                else if (c == 'n' || c == 'N')
                {
                    Console.WriteLine("操作已取消");
                }
                else
                {
                    Console.WriteLine("无效的操作");
                }
            }
            Console.WriteLine();
        }

        private static void AddCourse()
        {
            Console.WriteLine();
            Console.WriteLine("添加课程");
            Console.Write("请输入新课程的ID： ");
            string id = Console.ReadLine();
            Console.Write("请输入新课程的名称：");
            string name = Console.ReadLine();
            Console.Write("请输入新课程的学分数：");
            double point = double.Parse(Console.ReadLine());
            string error;
            bool result = BLL.AdminBLL.AddCourse(id, name, point, out error);
            if (result)
            {
                Console.WriteLine("添加成功");
            }
            else
            {
                Console.WriteLine("错误:" + error);
            }
            Console.WriteLine();
        }

        private static void ShowCourseAdminTitle()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("               课程管理菜单            ");
            Console.WriteLine("       1.增加课程       2.删除课程      ");
            Console.WriteLine("       3.查询课程                     ");
            Console.WriteLine("              0.返回上一级               ");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine();
        }
        #endregion

        #region 学期课程管理菜单
        private static void TermCourseAdmin()
        {
            ShowTermCourseAdminTitle();
            while (true)
            {
                Console.Write("请选择操作(0~4):");
                char c = char.Parse(Console.ReadLine());
                if (c == '0')
                    break;
                switch (c)
                {
                    case '1':
                        AddTermCourse();
                        break;
                    case '2':
                        DeleteTermCourse();
                        break;
                    case '3':
                        QueryTermCourse();
                        break;
                    default:
                        Console.WriteLine("无效的选择，请重试");
                        break;
                }
            }
        }

        private static void AddTermCourse()
        {
            Console.WriteLine();
            Console.WriteLine("添加学期课程");
            string courseID;
            while (true)
            {
                Console.Write("请输入要添加学期课程的ID(按回车键查询课程信息)： ");
                courseID = Console.ReadLine();
                if (courseID == "")
                    QueryCourse();
                else
                    break;
            }
            string teacherID;
            while (true)
            {
                Console.Write("请输入课程任课教师的ID(按回车键查询教师信息)： ");
                teacherID = Console.ReadLine();
                if (teacherID == "")
                    QueryTeacher();
                else
                    break;
            }
            string error;
            bool result = BLL.AdminBLL.AddTermCourse(courseID, teacherID, out error);
            if (result)
            {
                Console.WriteLine("添加成功");
            }
            else
            {
                Console.WriteLine("错误：" + error);
            }
            Console.WriteLine();
        }

        private static void DeleteTermCourse()
        {
            Console.WriteLine();
            Console.WriteLine("删除学期课程");
            Console.Write("请输入要删除的学期课程ID： ");
            string id = Console.ReadLine();
            string error;
            Model.TermCourse termCourse = BLL.AdminBLL.RetrieveTermCourse(id, out error);
            if (termCourse == null)
            {
                Console.WriteLine("错误：" + error);
            }
            else
            {
                Console.WriteLine("学期课程信息： {0}", termCourse.ID);
                Console.Write("确认要删除该学期课程吗？(Y/N)");
                char c = char.Parse(Console.ReadLine());
                if (c == 'y' || c == 'Y')
                {
                    bool result = BLL.AdminBLL.DeleteTermCourse(id, out error);
                    if (result)
                    {
                        Console.WriteLine("删除成功");
                    }
                    else
                    {
                        Console.WriteLine("错误：" + error);
                    }
                }
                else if (c == 'n' || c == 'N')
                {
                    Console.WriteLine("操作被取消！");
                }
                else
                    Console.WriteLine("无效的操作");
            }
            Console.WriteLine();
        }

        private static void QueryTermCourse()
        {
            string error;
            Console.WriteLine();
            Console.WriteLine("请选择操作(1--查询学期课程  2--查询所有学期课程");
            char c = char.Parse(Console.ReadLine());
            if (c == '1')
            {
                Console.Write("请输入该学期课程的ID:");
                string id = Console.ReadLine();
                Model.TermCourse termCourse = BLL.AdminBLL.RetrieveTermCourse(id, out error);
                Console.WriteLine("学期课程信息：");
                Console.WriteLine("学期课程ID\t  课程名\t  任课教师");
                Console.WriteLine("-------------------------");
                Console.WriteLine("{0}\t  {1}\t  {2}", termCourse.ID, (BLL.AdminBLL.RetrieveCourse(termCourse.CourseID, out error)).Name, BLL.AdminBLL.RetrieveTeacher(termCourse.TeacherID, out error).Name);
            }
            else if (c == '2')
            {
                Model.TermCourse[] termCourses = BLL.AdminBLL.RetrieveAllTermCourse();
                Console.WriteLine("课程信息");
                Console.WriteLine("学期课程ID\t  课程名\t  任课教师");
                Console.WriteLine("---------------");
                for (int i = 0; i < termCourses.Length; i++)
                {
                    Console.WriteLine("{0}\t  {1}\t  {2}", termCourses[i].ID, (BLL.AdminBLL.RetrieveCourse(termCourses[i].CourseID, out error)).Name, (BLL.AdminBLL.RetrieveTeacher(termCourses[i].TeacherID, out error)).Name);
                }
            }
            else
                Console.WriteLine("无效的操作");
        }

        private static void ShowTermCourseAdminTitle()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("              学期课程管理菜单            ");
            Console.WriteLine("       1.增加学期课程       2.删除学期课程  ");
            Console.WriteLine("       3.查询学期课程                     ");
            Console.WriteLine("              0.返回上一级               ");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine();
        }
        #endregion

        #region 学生管理菜单
        private static void StudentAdmin()
        {
            ShowStudentAdminTitle();
            while (true)
            {
                Console.Write("请选择操作(0~4):");
                char c = char.Parse(Console.ReadLine());
                if (c == '0')
                    break;
                switch (c)
                {
                    case '1':
                        AddStudent();
                        break;
                    case '2':
                        DeleteStudent();
                        break;
                    case '3':
                        QueryStduent();
                        break;
                    default:
                        Console.WriteLine("无效的选择，请重试");
                        break;
                }
            }
        }

        private static void AddStudent()
        {
            string error = "";
            Console.WriteLine();
            Console.WriteLine("添加学生");
            Console.Write("请输入要添加的学生姓名:");
            string name = Console.ReadLine();
            Console.Write("请输入该学生的密码：");
            string password = Console.ReadLine();
            if (BLL.AdminBLL.AddStudent(name, password, out error))
            {
                Console.WriteLine(error);
            }
            else
            {
                Console.WriteLine("错误:" + error);
            }
        }

        private static void DeleteStudent()
        {
            string error;
            Console.WriteLine();
            Console.WriteLine("删除学生");
            Console.WriteLine("请输入要删除的学生ID：");
            string id = Console.ReadLine();
            Model.Person student = BLL.AdminBLL.RetrieveStudent(id, out error);
            if (student != null)
            {
                Console.WriteLine("学生ID{0}，学生姓名{1}", id, student.Name);
                Console.Write("确定要删除该学生吗？(Y/N):");
                char c = char.Parse(Console.ReadLine());
                if (c == 'y' || c == 'Y')
                {
                    BLL.AdminBLL.DeleteStudent(id, out error);
                    Console.WriteLine(error);
                }
                else if (c == 'n' || c == 'N')
                {
                    Console.WriteLine("操作被取消");
                }
                else
                    Console.WriteLine("无效操作");
            }
            else
                Console.WriteLine("错误" + error);
        }

        private static void QueryStduent()
        {
            string error = "";
            Console.WriteLine();
            Console.WriteLine("学生查询");
            Console.WriteLine("请选择(1--查询某个学生信息  2--查询所有学生信息):");
            char c = char.Parse(Console.ReadLine());
            if (c == '1')
            {
                Console.Write("请输入要查询的学生的ID:");
                string id = Console.ReadLine();
                Model.Person student = BLL.AdminBLL.RetrieveStudent(id, out error);
                if (student == null)
                {
                    Console.WriteLine("错误" + error);
                }
                else
                {
                    Console.WriteLine("学生ID\t  学生姓名");
                    Console.WriteLine("-----------------");
                    Console.WriteLine("{0}\t  {1}", id, student.Name);
                }
            }
            else if (c == '2')
            {
                Console.WriteLine("学生ID\t  学生姓名");
                Console.WriteLine("-----------------");
                Model.Person[] students = BLL.AdminBLL.RetrieveAllStudent();
                if (students == null)
                {
                    Console.WriteLine("错误" + error);
                }
                else
                {
                    for (int i = 0; i < students.Length; i++)
                    {
                        Console.WriteLine("{0}\t  {1}", students[i].ID, students[i].Name);
                    }
                }
            }
            else
                Console.WriteLine("无效操作");
        }

        private static void ShowStudentAdminTitle()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("               学生管理菜单             ");
            Console.WriteLine("       1.添加学生       2.删除学生      ");
            Console.WriteLine("       3.查询学生                      ");
            Console.WriteLine("              0.退出系统               ");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine();
        }
        #endregion

        #region 教师管理菜单
        private static void TeacherAdmin()
        {
            ShowTeacherAdminTitle();
            while (true)
            {
                Console.Write("请选择操作(0~4):");
                char c = char.Parse(Console.ReadLine());
                if (c == '0')
                    break;
                switch (c)
                {
                    case '1':
                        AddTeacher();
                        break;
                    case '2':
                        DeleteTeacher();
                        break;
                    case '3':
                        QueryTeacher();
                        break;
                    default:
                        Console.WriteLine("无效的选择，请重试");
                        break;
                }
            }
        }

        private static void AddTeacher()
        {
            string error = "";
            Console.WriteLine();
            Console.WriteLine("添加教师");
            Console.Write("请输入要添加的教师姓名:");
            string name = Console.ReadLine();
            Console.Write("请输入该教师的密码：");
            string password = Console.ReadLine();
            if (BLL.AdminBLL.AddTeacher(name, password, out error))
            {
                Console.WriteLine(error);
            }
            else
            {
                Console.WriteLine("错误:" + error);
            }
        }

        private static void DeleteTeacher()
        {
            string error;
            Console.WriteLine();
            Console.WriteLine("删除教师");
            Console.WriteLine("请输入要删除的教师ID：");
            string id = Console.ReadLine();
            Model.Teacher teacher = (Model.Teacher)BLL.AdminBLL.RetrieveTeacher(id, out error);
            if (teacher != null)
            {
                Console.WriteLine("教师ID{0}，教师姓名{1}", id, teacher.Name);
                Console.Write("确定要删除该教师吗？(Y/N):");
                char c = char.Parse(Console.ReadLine());
                if (c == 'y' || c == 'Y')
                {
                    BLL.AdminBLL.DeleteTeacher(id, out error);
                    Console.WriteLine(error);
                }
                else if (c == 'n' || c == 'N')
                {
                    Console.WriteLine("操作被取消");
                }
                else
                    Console.WriteLine("无效操作");
            }
            else
                Console.WriteLine("错误" + error);
        }

        private static void QueryTeacher()
        {
            string error = "";
            Console.WriteLine();
            Console.WriteLine("教师查询");
            Console.WriteLine("请选择(1--查询某个教师信息  2--查询所有教师信息):");
            char c = char.Parse(Console.ReadLine());
            if (c == '1')
            {
                Console.Write("请输入要查询的教师的ID:");
                string id = Console.ReadLine();
                Model.Person teacher = BLL.AdminBLL.RetrieveTeacher(id, out error);
                if (teacher == null)
                {
                    Console.WriteLine("错误" + error);
                }
                else
                {
                    Console.WriteLine("教师ID\t  教师姓名");
                    Console.WriteLine("-----------------");
                    Console.WriteLine("{0}\t  {1}", id, teacher.Name);
                }
            }
            else if (c == '2')
            {
                Console.WriteLine("教师ID\t  教师姓名");
                Console.WriteLine("-----------------");
                Model.Person[] teachers = BLL.AdminBLL.RetrieveAllTeacher();
                if (teachers == null)
                {
                    Console.WriteLine("错误" + error);
                }
                else
                {
                    for (int i = 0; i < teachers.Length; i++)
                    {
                        Console.WriteLine("{0}\t  {1}", teachers[i].ID, teachers[i].Name);
                    }
                }
            }
            else
                Console.WriteLine("无效操作");
        }

        private static void ShowTeacherAdminTitle()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("               教师管理菜单             ");
            Console.WriteLine("       1.添加教师       2.删除教师      ");
            Console.WriteLine("       3.查询教师                      ");
            Console.WriteLine("              0.退出系统               ");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine();
        }
        #endregion
    }
}
