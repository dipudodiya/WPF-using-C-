using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DipuDodiyaMidterm
{

    //inheritance from person class
    public class Education : Person
    {
        //To define varibles
        public int Id { get; set; }
        public string CourseName { get; set; }
        public double CourseGrade { get; set; }

        public string Comments { get; set; }

        //Argument Constructor
        public Education(int PersonId, string name, string address, string email, int age, string birthday, int id, string courseName, double grade,  string comments) : base(id, name, address, email,age, birthday)
        {
            Id = id;
            CourseGrade = grade;
            Comments = comments;
            CourseName = courseName;

        }
    }
}
