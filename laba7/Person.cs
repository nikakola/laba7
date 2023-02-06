using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba7
{
    class Person
    {
        public int id { get; set; }
        public String name { get; set; }
        public int age { get; set; }
        public String company { get; set; }

        public Person()
        {
            
        }

        public Person(int id, String name, int age, String company)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.company = company;
        }

    }
}
