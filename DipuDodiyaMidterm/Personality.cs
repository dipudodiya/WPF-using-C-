using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DipuDodiyaMidterm
{
    //inheritance from person class

    public class Personality : Person
    {
        //To define varibles
        public int Id { get; set; }
        public int ShoeSize { get; set; }
        public string FavouriteMovie { get; set; }
        public string FavouriteActor { get; set; }

        //Argument Constructor
        public Personality(int PersonId, string name, string address, string email, int age,  string birthday, int id, int shoeSize, string favouriteMovie, string favouriteActor) : base(id, name, address, email, age, birthday)
        {
            Id = id;
            ShoeSize = shoeSize;
            FavouriteMovie = favouriteMovie;
            FavouriteActor = favouriteActor;

        }
    }
}
