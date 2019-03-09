using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Admin : Person
    {
        private string adminID;
        static int cnt = 0;
        public Admin(string name, string password) : base(name, password)
        {
        }

        public Admin(string id, string name, string password) : base(name, password)
        {
        }
        public override string getID()
        {
            cnt++;
            return "A" + cnt.ToString().PadLeft(3, '0');
        }

        public override string GetUserType()
        {
            return "管理员";
        }
    }
}
