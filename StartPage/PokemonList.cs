using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace StartPage
{
    public class Pokemon
    {
        public int PokeDexID { get; set; }
        public string PokemonName { get; set; }

        //Added HP levels and pcitures
        public string ImageURL_Front { get; set; }
        public string ImageURL_Back { get; set; }
        public int Health { get; set; }

        public Types Types { get; set; }
        

    }
    public class Types
    {
        public int TypeID { get; set; }
        public string PokeType { get; set; }
        public string Weakness { get; set; }
        public string Effective { get; set; }

    }

    public class Moves
    {
        public int MoveID { get; set; }
        public string MoveName { get; set; }
        public Types Types { get; set; }
        public string AttackName { get; set; }
        public int AttackDamage { get; set; }
        public int Accuracy { get; set; }


    }

    public class PokeData : DbContext   
    {
        public PokeData() : base("PokeDex") { }

        public DbSet<Pokemon> Pokemon { get; set; }
        public DbSet<Types> Types { get; set; }

    }
}
