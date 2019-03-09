using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// CourseDAL的摘要说明
    /// </summary>
    [Serializable]
    public class CourseDAL
    {
        private List<Model.Course> courses;

        public CourseDAL()
        {
            this.courses = new List<Model.Course>();
        }

        /// <summary>
        /// 增加新课程
        /// </summary>
        /// <param name="newCourse"></param>
        /// <returns></returns>
        public bool AddNewCourse(Model.Course course)
        {
            for (int i = 0; i < courses.Count; i++)
            {
                if (course.CourseID == courses[i].CourseID)
                {
                    return false;
                }
            }
            this.courses.Add(course);
            return true;
        }


        /// <summary>
        /// 根据课程编号检索课程
        /// </summary>
        /// <param name="courseID"></param>
        /// <returns></returns>
        public Model.Course RetrieveCourse(string courseID)
        {
            for (int i = 0; i < courses.Count; i++)
            {
                if (courseID == courses[i].CourseID)
                {
                    return courses[i];
                }
            }
            return null;
        }

        /// <summary>
        /// 检索所有课程
        /// </summary>
        /// <returns></returns>
        public Model.Course[] RetrieveAll()
        {
            return courses.ToArray();

        }

        /// <summary>
        /// 根据课程ID删除课程
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool RemoveCourse(string courseID)
        {
            for (int i = 0; i < courses.Count; i++)
            {
                if (courseID == courses[i].CourseID)
                {
                    courses.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
    }
}
