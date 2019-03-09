using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class StudentBLL : BaseBLL
    {
        private StudentBLL() { }

        #region 个人信息管理
        public static bool ChangePassword(string id, string newPassword, out string error)
        {
            error = "";
            if (students.ChangPW(id, newPassword))
            {
                error = "修改成功";
                return true;
            }
            else
            {
                error = "修改失败";
                return false;
            }
        }
        #endregion

        #region 选修课程
        public static bool chooseCourse(string studentID, string courseID, out string error)
        {
            error = "";
            if (students.Retrieve(studentID) == null)
            {
                error = "该学生不存在";
                return false;
            }
            else
            {
                if (termCourses.RetrieveTermCourse(courseID) == null)
                {
                    error = "不存在该课程";
                    return false;
                }
                else
                {
                    if(termCourses.RetrieveTermCourse(courseID).JustifyStudent(studentID))
                    {
                        error = "该课程已选";
                        return false;
                    }
                    else
                    {
                        Model.TermCourse termcourse = termCourses.RetrieveTermCourse(courseID);
                        termcourse.AddStudent(studentID);
                        ((Model.Student)students.Retrieve(studentID)).AddCourse(new Model.ChoosedCourses(courseID));
                        error = "选课成功";
                        return true;
                    }
                }
            }
        }
        #endregion

        #region 退选课程
        public static bool WithdrawlCourse(string studentID,string courseID,out string error)
        {
            error = "";
            if(students.Retrieve(studentID)==null)
            {
                error = "没有该学生记录";
                return false;
            }
            else
            {
                if(termCourses.RetrieveTermCourse(courseID)==null)
                {
                    error = "没有该课程";
                    return false;
                }
                else
                {
                    if(termCourses.RetrieveTermCourse(courseID).JustifyStudent(studentID)==false)
                    {
                        error = "没有选择该课程";
                        return false;
                    }
                    else
                    {
                        termCourses.RetrieveTermCourse(courseID).RemoveStudent(studentID);
                        ((Model.Student)students.Retrieve(studentID)).RemoveCourse(courseID);
                        error = "退选成功";
                        return true;
                    }
                }
            }
        }
        #endregion

        #region 选修课程查询
        public static Model.TermCourse[] GetAllChoosedCourse(string studentid)
        {
            return termCourses.BeStudiedByCourses(studentid);
        }
        #endregion

        #region 成绩查询
        public static Model.ChoosedCourses[] GetAllChoosedCoursesGrade(string studentid)
        {
            return ((Model.Student)students.Retrieve(studentid)).GetCourseGrade();
        }
        #endregion
    }
}

