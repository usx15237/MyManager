using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public abstract class Person
    {
        private string id;
        protected string name;
        protected string password;
        public string ID
        {
            get
            {
                return id;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
        }

        public string Password
        {
            set
            {
                this.password = value;
            }
            get
            {
                return this.password;
            }

        }
        public Person(string name, string password)
        {
            this.name = name;
            id = getID();
            this.password = password;
        }

        public Person(string id, string name, string password)
        {
            this.id = id;
            this.name = name;
            this.password = password;
        }

        public abstract string getID();

        public virtual string GetUserType()
        {
            return this.GetType().ToString();
        }

    }
}
