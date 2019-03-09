using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// BaseDAL的摘要说明
    /// </summary>
    [Serializable]
    public class BaseDAL
    {
        private List<Model.Person> persons;

        public BaseDAL()
        {
            this.persons = new List<Model.Person>();
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public bool Add(Model.Person person)
        {
            for (int i = 0; i < persons.Count; i++)
            {
                if (person.ID == persons[i].ID)
                {
                    return false;
                }
            }
            persons.Add(person);
            return true;
        }

        /// <summary>
        /// 根据ID删除
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool Remove(string ID)
        {
            for (int i = 0; i < persons.Count; i++)
            {
                if (ID == persons[i].ID)
                {
                    persons.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 根据ID查询
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Model.Person Retrieve(string ID)
        {
            for (int i = 0; i < persons.Count; i++)
            {
                if (ID == persons[i].ID)
                {
                    return persons[i];
                }
            }
            return null;
        }
        public bool ChangPW(Model.Person p, string newPw)
        {
            Model.Person thePerson = Retrieve(p.ID);
            if (thePerson != null)
            {
                thePerson.Password = newPw;
                return true;
            }
            return false;

        }
        public bool ChangPW(string pid, string newPw)
        {
            Model.Person thePerson = Retrieve(pid);
            if (thePerson != null)
            {
                thePerson.Password = newPw;
                return true;
            }
            return false;

        }
        public Model.Person[] RetrieveAll()
        {
            return persons.ToArray();
        }


    }
}
