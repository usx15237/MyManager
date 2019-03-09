using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class HasStudents
    {
        private string studentID;
        private double grade;
        public string StudentID
        {
            get
            {
                return studentID;
            }
        }
        public double Grade
        {
            set
            {
                grade = value;
            }
            get
            {
                return grade;
            }
        }
        public HasStudents(string studentID,double grade)
        {
            this.studentID = studentID;
            this.grade = grade;
        }
    }
}
