using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Teacher : Person
    {
        private string TID;
        static int cnt = 0;
        public Teacher(string name, string password) : base(name, password)
        {
            TID = getID();
        }
        public override string getID()
        {
            cnt++;
            return "T" +"2010"+ cnt.ToString().PadLeft(3, '0');
        }
    }
}
