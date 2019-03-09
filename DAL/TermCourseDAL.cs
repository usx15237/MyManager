using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// TermCourseDAL的摘要说明
    /// </summary>
    [Serializable]
    public class TermCourseDAL
    {
        private List<Model.TermCourse> termCourses;

        public TermCourseDAL()
        {
            this.termCourses = new List<Model.TermCourse>();
        }

        /// <summary>
        /// 增加学期新课程
        /// </summary>
        /// <param name="newTermCourse"></param>
        /// <returns></returns>
        public bool AddNewTermCourse(Model.TermCourse newTermCourse)
        {
            for (int i = 0; i < termCourses.Count; i++)
            {
                if (newTermCourse.ID == ((Model.TermCourse)termCourses[i]).ID)
                    return false;
            }
            termCourses.Add(newTermCourse);
            return true;
        }


        /// <summary>
        /// 根据学期开设课程的ID取消该课程
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool RemoveTermCourse(string ID)
        {
            for (int i = 0; i < termCourses.Count; i++)
            {
                if (ID == ((Model.TermCourse)termCourses[i]).ID)
                {
                    termCourses.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 根据学期开设课程的ID检索开设课程
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Model.TermCourse RetrieveTermCourse(string ID)
        {
            for (int i = 0; i < termCourses.Count; i++)
            {
                if (ID == termCourses[i].ID)
                {
                    return termCourses[i];
                }
            }
            return null;
        }

        /// <summary>
        /// 返回学期开设的所有课程
        /// </summary>
        /// <returns></returns>
        public Model.TermCourse[] RetrieveAll()
        {
            return termCourses.ToArray();
        }

        /// <summary>
        /// 根据教师ID检索任课信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Model.TermCourse[] TeachCourses(string teacherid)
        {
            List<Model.TermCourse> teachCourses = new List<Model.TermCourse>();
            for (int i = 0; i < termCourses.Count; i++)
            {
                if (teacherid == termCourses[i].TeacherID)
                {
                    teachCourses.Add(termCourses[i]);
                }
            }
            return teachCourses.ToArray();
        }
        public Model.TermCourse[] BeStudiedByCourses(string studentid)
        {
            List<Model.TermCourse> bestudiedbycourses = new List<Model.TermCourse>();
            for(int i=0;i<termCourses.Count;i++)
            {
                if(termCourses[i].JustifyStudent(studentid))
                {
                    bestudiedbycourses.Add(termCourses[i]);
                }
            }
            return bestudiedbycourses.ToArray();
        }
    }
}
