using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Student : Person
    {
        private string sid;
        private List<ChoosedCourses> courses;
        static int cnt = 0;
        public Student(string name, string password) : base(name, password)
        {
            courses = new List<ChoosedCourses>();
        }
        public Student(string id, string name, string password) : base(id, name, password)
        {
            courses = new List<ChoosedCourses>();
        }
        public override string getID()
        {
            cnt++;
            return "S" + "0115" + cnt.ToString().PadLeft(3, '0');
        }
        public override string GetUserType()
        {
            return "学生";
        }
        public bool AddCourse(ChoosedCourses course)
        {
            int i;
            bool result = false;
            if (courses.Count == 0)
            {
                courses.Add(course);
                result = true;
            }
            int c = 0;
            for (i = 0; i < courses.Count; i++)
            {
                if (course.courseid == courses[i].courseid)
                    result = false;
                else
                    c++;
            }
            if (c == courses.Count)
            {
                courses.Add(course);
                result = true;
            }
            return result;
        }
        public bool RemoveCourse(string courseID)
        {
            int i;
            bool result = false;
            for (i = 0; i < courses.Count; i++)
            {
                if (courseID == courses[i].courseid)
                {
                    courses.RemoveAt(i);
                    result = true;
                    break;
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }
        public ChoosedCourses[] GetCourseGrade()
        {
            return this.courses.ToArray();
        }
        public bool BeMarked(string courseid,double grade)
        {
            int c = 0;
            bool result=false;
            for(int i=0;i<courses.Count;i++)
            {
                if (courseid == courses[i].courseid)
                {
                    courses[i].Grade = grade;
                    result = true;
                    break;
                }
                else
                {
                    c++;
                    result = false;
                }
            }
            if (c == courses.Count)
                result = false;
            return result;
        }
    }
}
