using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// BaseBLL的摘要说明
    /// </summary>
    public class BaseBLL
    {
        protected static Model.Person user;
        protected static DAL.AdminDAL admins;
        protected static DAL.StudentDAL students;
        protected static DAL.TeacherDAL teachers;
        protected static DAL.CourseDAL courses;
        protected static DAL.TermCourseDAL termCourses;

        protected BaseBLL() { }
        static BaseBLL()
        {
            admins = DAL.DataFileAccess.GetAdmins();
            students = DAL.DataFileAccess.GetStudents();
            teachers = DAL.DataFileAccess.GetTeachers();
            courses = DAL.DataFileAccess.GetCourses();
            termCourses = DAL.DataFileAccess.GetTermCourses();
        }

        public static Model.Person User
        {
            get { return user; }
        }

        public static Model.TermCourse RetrieveTermCourse(string termCourseId)
        {
            return termCourses.RetrieveTermCourse(termCourseId);
        }

        public static void SaveALL()
        {
            DAL.DataFileAccess.SaveAdmins(admins);
            DAL.DataFileAccess.SaveCourses(courses);
            DAL.DataFileAccess.SaveStudents(students);
            DAL.DataFileAccess.SaveTeachers(teachers);
            DAL.DataFileAccess.SaveTermCourses(termCourses);
        }
    }
}
