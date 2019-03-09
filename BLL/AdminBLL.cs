using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AdminBLL : BaseBLL
    {
        private AdminBLL() { }

        #region 教师管理
        public static bool AddTeacher(string name, string password, out string error)
        {
            error = "";
            Model.Person teacher = new Model.Teacher(name, password);
            if (teachers.Add(teacher))
            {
                error = "添加教师记录成功";
                return true;
            }
            else
            {
                error = "添加教师记录失败";
                return false;
            }
        }
        public static bool DeleteTeacher(string teacherid, out string error)
        {
            error = "";
            bool result = false;
            Model.TermCourse[] teachcourses = termCourses.TeachCourses(teacherid);
            if(teachcourses.Length!=0)
            {
                error = "该教师有课程，不能删除";
                result = false;
            }
            else
            {
                teachers.Remove(teacherid);
                error = "删除成功";
                result=true;
            }
            return result;
        }
        public static Model.Person RetrieveTeacher(string id, out string error)
        {
            Model.Person teacher =teachers.Retrieve(id);
            if (teacher == null)
            {
                error = "没有该教师";
                return null;
            }
            else
            {
                error = "查找成功";
                return teacher;
            }
        }
        public static Model.Person[] RetrieveAllTeacher()
        {
            return teachers.RetrieveAll();
        }
        #endregion

        #region 学生管理

        public static bool AddStudent(string name, string password, out string error)
        {
            error = "";
            Model.Person student = new Model.Student(name, password);
            if (students.Add(student))
            {
                error = "添加学生记录成功";
                return true;
            }
            else
            {
                error = "添加学生记录失败";
                return false;
            }
        }

        public static bool DeleteStudent(string studentid, out string error)
        {
            error = "";
            Model.Person student = students.Retrieve(studentid);
            if (student == null)
            {
                error = "没有该学生";
                return false;
            }
            else
            {
                Model.TermCourse[] termcourse = termCourses.BeStudiedByCourses(studentid);
                for(int i=0;i<termcourse.Length;i++)
                {
                    Model.TermCourse course = termcourse[i];
                    course.RemoveStudent(studentid);
                }
                students.Remove(studentid);
                error = "删除学生记录成功";
                return true;
            }
        }

        public static Model.Person RetrieveStudent(string studentid, out string error)
        {
            error = "";
            Model.Person student =students.Retrieve(studentid);
            if (student == null)
            {
                error = "没有该学生";
                return null;
            }
            else
            {
                error = "查找成功";
                return student;
            }
        }
        public static Model.Person[] RetrieveAllStudent()
        {
            return students.RetrieveAll();
        }
        #endregion

        #region 课程管理
        public static bool AddCourse(string courseid, string name, double points, out string error)
        {
            error = "";
            if (courses.RetrieveCourse(courseid) == null)
            {
                courses.AddNewCourse(new Model.Course(courseid, name, points));
                error = "添加课程成功";
                return true;
            }
            else
            {
                error = "添加课程失败";
                return false;
            }
        }

        public static bool DeleteCourse(string courseid, out string error)
        {
            error = "";
            if (courses.RetrieveCourse(courseid) == null)
            {
                error = "没有该课程";
                return false;
            }
            else
            {
                Model.TermCourse[] course = termCourses.RetrieveAll();
                for(int i=0;i<course.Length;i++)
                {
                    Model.TermCourse tc = course[i];
                    if(tc.CourseID==courseid)
                    {
                        error = "该课程无法删除";
                        return false;
                    }
                }
                courses.RemoveCourse(courseid);
                error = "删除课程记录成功";
                return true;
            }
        }

        public static Model.Course RetrieveCourse(string id, out string error)
        {
            error = "";
            if (courses.RetrieveCourse(id) == null)
            {
                error = "没有该课程记录";
                return null;
            }
            else
            {
                error = "查找成功";
                return courses.RetrieveCourse(id);
            }
        }

        public static Model.Course[] RetrieveAllCourse()
        {
            return courses.RetrieveAll();
        }
        #endregion

        #region 学期课程管理

        public static bool AddTermCourse(string courseID, string teacherID, out string error)
        {
            error = "";
            Model.Course course = courses.RetrieveCourse(courseID);
            if (course == null)
            {
                error = "不存在课程ID为" + courseID + "的课程";
                return false;
            }
            else
            {
                Model.Person teacher = teachers.Retrieve(teacherID);
                if (teacher == null)
                {
                    error = "不存在教师ID为" + teacherID + "的教师";
                    return false;
                }
                else
                {
                    if (termCourses.RetrieveTermCourse(courseID + teacherID) == null)
                    {
                        termCourses.AddNewTermCourse(new Model.TermCourse(courseID, teacherID));
                        error = "添加学期课程记录成功";
                        return true;
                    }
                    else
                    {
                        error = "添加学期课程记录失败";
                        return false;
                    }
                }
            }
        }

        public static bool DeleteTermCourse(string termcourseid, out string error)
        {
            error = "";
            if (termCourses.RetrieveTermCourse(termcourseid) == null)
            {
                error = "没有该学期课程记录";
                return false;
            }
            else
            {
                termCourses.RemoveTermCourse(termcourseid);
                error = "";
                return false;
            }
        }

        public static Model.TermCourse RetrieveTermCourse(string id, out string error)
        {
            error = "";
            if (termCourses.RetrieveTermCourse(id) == null)
            {
                error = "没有该学期课程记录";
                return null;
            }
            else
            {
                error = "查找成功";
                return termCourses.RetrieveTermCourse(id);
            }
        }

        public static Model.TermCourse[] RetrieveAllTermCourse()
        {
            return termCourses.RetrieveAll();
        }
        #endregion
    }
}

