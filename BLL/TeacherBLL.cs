using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TeacherBLL : BaseBLL
    {
        private TeacherBLL() { }

        #region 课程成绩登记
        public static void Marking(string termcourseid,Model.HasStudents[] stu)
        {
            Model.TermCourse termcourse = termCourses.RetrieveTermCourse(termcourseid);
            string[] studentID = termcourse.GetAllStudent();
            for(int i=0;i<studentID.Length;i++)
            {
                ((Model.Student)students.Retrieve(studentID[i])).BeMarked(termcourseid, stu[i].Grade);
            }
        }
        public static void MarkingAStudent(string termcourseid,string studentid,double grade)
        {
            if(students.Retrieve(studentid)==null)
            {
                return ;
            }
            Model.TermCourse termcourse = termCourses.RetrieveTermCourse(termcourseid);
            ((Model.Student)students.Retrieve(studentid)).BeMarked(termcourseid, grade);
        }
        #endregion

        #region 所授课程查询
        public static Model.TermCourse[] QueryTeachCourse(string teacherid)
        {
            return termCourses.TeachCourses(teacherid);
        }
        #endregion

        #region 个人信息
        public static bool ChangePassword(string teacherid,string newPassword,out string error)
        {
            error = "";
            if(teachers.Retrieve(teacherid)==null)
            {
                error = "没有该教师记录";
                return false;
            }
            else
            {
                teachers.ChangPW(teacherid, newPassword);
                error = "修改成功";
                return true;
            }
        }
        #endregion
    }
}
