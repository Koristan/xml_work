using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz08._11
{
    class Person
    {
        public string Name { get; }
        public int Age { get; set; }
        public string Company { get; set; }
        public Person(string name, int age, string company)
        {
            Name = name;
            Age = age;
            Company = company;
        }
    }
}
