using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Course
    {
        string cid;
        string name;
        double point;
        public string CourseID
        {
            set
            {
                cid = value;
            }
            get
            {
                return cid;
            }
        }
        public string Name
        {
            set
            {
                name = value;
            }
            get
            {
                return name;
            }
        }
        public double Point
        {
            set
            {
                point = value;
            }
            get
            {
                return point;
            }
        }
        public Course(string cid, string name, double point)
        {
            this.cid = cid;
            this.name = name;
            this.point = point;
        }

    }
}
