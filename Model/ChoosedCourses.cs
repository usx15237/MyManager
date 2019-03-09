using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class ChoosedCourses
    {
        private string courseID;
        private double grade;
        public string courseid
        {
            get
            {
                return courseID;
            }
        }
        public double Grade
        {
            set
            {
                this.grade = value;
            }
            get
            {
                return grade;
            }
        }
        public ChoosedCourses(string courseID,double grade)
        {
            this.courseID = courseID;
            this.grade = grade;
        }
        public ChoosedCourses(string courseID)
        {
            this.courseID = courseID;
            grade = -1;
        }
    }
}
