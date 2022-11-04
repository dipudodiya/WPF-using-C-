using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DipuDodiyaMidterm
{
    public class Person
    {
        //To define varibles
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
       public int Age { get; set; }
        public string Birthday { get; set; }

        //Argument Constructor
        public Person(int id, string name, string address, string email, int age,  String birthday)
        {
            PersonId = id;
            Name = name;
            Address = address;
            Email = email;
           Age = age;
            Birthday = birthday;

        }
    }
}
