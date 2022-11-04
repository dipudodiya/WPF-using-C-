using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DipuDodiyaMidterm
{
    //inheritance from person class
    public class SportsTeam : Person
    {
        //To define varibles
        public int Id { get; set; }
        public string SportTeam { get; set; }
        public string City { get; set; }

        //Argument Constructor
        public SportsTeam(int PersonId, string name, string address, string email,int age, string birthday, int id, string sportTeam, string city) : base(id, name, address, email,age,  birthday)
        {
            Id = id;
            SportTeam = sportTeam;
            City = city;

        }
    }
}
