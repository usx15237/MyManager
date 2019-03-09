using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DAL
{
    /// <summary>
    /// DataFileAccess的摘要说明
    /// </summary>
    public class DataFileAccess
    {
        private static string adminDocPath;
        private static string studentsDocPath;
        private static string teacherDocPath;
        private static string coursesDocPath;
        private static string termCourseDocPath;

        private DataFileAccess() { }

        static DataFileAccess()
        {
            adminDocPath = @"data/adminDoc.dat";
            studentsDocPath = @"data/studentsDoc.dat";
            teacherDocPath = @"data/teacherDoc.dat";
            coursesDocPath = @"data/courseDoc.dat";
            termCourseDocPath = @"data/termCourseDoc.dat";
        }

        /// <summary>
        /// 读取课程信息
        /// </summary>
        /// <returns></returns>
        public static CourseDAL GetCourses()
        {
            CourseDAL courses;
            if (File.Exists(coursesDocPath))
            {
                using (FileStream fs = new FileStream(coursesDocPath, FileMode.Open, FileAccess.Read))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    courses = (CourseDAL)bf.Deserialize(fs);
                }
            }
            else
            {
                using (FileStream fs = new FileStream(coursesDocPath, FileMode.CreateNew, FileAccess.Write))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    courses = new CourseDAL();
                    bf.Serialize(fs, courses);
                }

            }
            return courses;
        }

        /// <summary>
        /// 保存课程信息
        /// </summary>
        /// <param name="courses"></param>
        public static void SaveCourses(CourseDAL courses)
        {
            using (FileStream fs = new FileStream(coursesDocPath, FileMode.Create, FileAccess.Write))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, courses);
            }
        }

        /// <summary>
        /// 读取学期开设课程信息
        /// </summary>
        /// <returns></returns>
        public static TermCourseDAL GetTermCourses()
        {
            TermCourseDAL courses;
            if (File.Exists(termCourseDocPath))
            {
                using (FileStream fs = new FileStream(termCourseDocPath, FileMode.Open, FileAccess.Read))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    courses = (TermCourseDAL)bf.Deserialize(fs);
                }
            }
            else
            {
                using (FileStream fs = new FileStream(termCourseDocPath, FileMode.CreateNew, FileAccess.Write))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    courses = new TermCourseDAL();
                    bf.Serialize(fs, courses);
                }
            }
            return courses;
        }

        /// <summary>
        /// 保存学期开设课程信息
        /// </summary>
        /// <param name="courses"></param>
        public static void SaveTermCourses(TermCourseDAL courses)
        {
            using (FileStream fs = new FileStream(termCourseDocPath, FileMode.Create, FileAccess.Write))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, courses);
            }
        }

        /// <summary>
        /// 读取学生信息
        /// </summary>
        /// <returns></returns>
        public static StudentDAL GetStudents()
        {
            StudentDAL students;
            if (File.Exists(studentsDocPath))
            {
                using (FileStream fs = new FileStream(studentsDocPath, FileMode.Open, FileAccess.Read))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    students = (StudentDAL)bf.Deserialize(fs);
                }
            }
            else
            {
                students = new StudentDAL();
            }
            return students;
        }

        /// <summary>
        /// 保存学生信息
        /// </summary>
        /// <param name="students"></param>
        public static void SaveStudents(StudentDAL students)
        {
            using (FileStream fs = new FileStream(studentsDocPath, FileMode.Create, FileAccess.Write))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, students);
            }
        }

        /// <summary>
        /// 读取教师信息
        /// </summary>
        /// <returns></returns>
        public static TeacherDAL GetTeachers()
        {
            TeacherDAL teachers;
            if (File.Exists(teacherDocPath))
            {
                using (FileStream fs = new FileStream(teacherDocPath, FileMode.Open, FileAccess.Read))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    teachers = (TeacherDAL)bf.Deserialize(fs);
                }
            }
            else
            {
                using (FileStream fs = new FileStream(teacherDocPath, FileMode.CreateNew, FileAccess.Write))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    teachers = new TeacherDAL();
                    bf.Serialize(fs, teachers);
                }
            }
            return teachers;
        }

        /// <summary>
        /// 保存教师信息
        /// </summary>
        /// <param name="teachers"></param>
        public static void SaveTeachers(TeacherDAL teachers)
        {
            using (FileStream fs = new FileStream(teacherDocPath, FileMode.Create, FileAccess.Write))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, teachers);
            }
        }

        /// <summary>
        /// 读取管理员信息
        /// </summary>
        /// <returns></returns>
        public static AdminDAL GetAdmins()
        {
            AdminDAL admins;
            if (File.Exists(adminDocPath))
            {
                using (FileStream fs = new FileStream(adminDocPath, FileMode.Open, FileAccess.Read))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    admins = (AdminDAL)bf.Deserialize(fs);
                }
            }
            else
            {
                using (FileStream fs = new FileStream(adminDocPath, FileMode.CreateNew, FileAccess.Write))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    admins = new AdminDAL();
                    Model.Admin admin = new Model.Admin("A001", "管理员", "123");
                    admins.Add(admin);
                    bf.Serialize(fs, admins);
                }
            }
            return admins;
        }

        /// <summary>
        /// 保存管理员信息
        /// </summary>
        /// <param name="admins"></param>
        public static void SaveAdmins(AdminDAL admins)
        {
            using (FileStream fs = new FileStream(adminDocPath, FileMode.Create, FileAccess.Write))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, admins);
            }
        }
    }
}
