using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class TermCourse
    {
        private string id;
        private string courseID;
        private List<string> students;
        private string teacherID;
        public string ID
        {
            set
            {
                id = value;
            }
            get
            {
                return id;
            }
        }
        public string CourseID
        {
            set
            {
                courseID = value;
            }
            get
            {
                return courseID;
            }
        }
        public string TeacherID
        {
            set
            {
                teacherID = value;
            }
            get
            {
                return teacherID;
            }
        }
        public TermCourse(string courseID, string teacherID)
        {
            this.id = courseID+teacherID;
            this.courseID = courseID;
            this.teacherID = teacherID;
            students = new List<string>();
        }
        public bool AddStudent(string studentID)
        {
            int i, c=0;
            bool result=false;
            for(i=0;i<students.Count;i++)
            {
                if (studentID == students[i])
                {
                    result = false;
                    break;
                }
                else
                {
                    c++;
                }
            }
            if(c==students.Count)
            {
                students.Add(studentID);
                result = true;
            }
            return result;
        }
        public bool RemoveStudent(string studentID)
        {
            int i, c=0;
            bool result = false;
            for (i = 0; i < students.Count; i++)
            {
                if (studentID == students[i])
                {
                    students.RemoveAt(i);
                    result = true;
                    break;
                }
                else
                {
                    c++;
                }
            }
            if(c==students.Count)
            {
                result = true;
            }
            return result;
        }
        public string[] GetAllStudent()
        {
            return this.students.ToArray();
        }
        public bool JustifyStudent(string studentid)
        {
            int i;
            bool result = false;
            for (i = 0; i < students.Count; i++)
            {
                if (students[i] == studentid)
                {
                    result = true;
                    break;
                }
                else
                    result = false;
            }
            return result;
        }
    }
}
