using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace StartPage
{
    public class Pokemon
    {
        [Key]
        public int PokeDexID { get; set; }
        public string PokemonName { get; set; }

        //Added HP levels and pcitures
        public string ImageURL_Front { get; set; }
        public string ImageURL_Back { get; set; }
        public int Health { get; set; }



        public int TypeID { get; set; }

        public virtual Types Types { get; set; }
        public virtual List<Moves> Moves { get; set; }

    }
    public class Types
    {
        [Key]
        public int TypeID { get; set; }
        public string PokeType { get; set; }
        public string Weakness { get; set; }
        public string Effective { get; set; }

        public virtual List<Pokemon> Pokemons { get; set; }
    }

    public class Moves
    {
        [Key]
        public int MoveID { get; set; }
        public string MoveName { get; set; }
        public Types Types { get; set; }
        public int AttackDamage { get; set; }
        public int Accuracy { get; set; }

        public virtual List<Pokemon> Pokemons{ get; set; }
    }

    public class PokeData : DbContext   
    {
        public PokeData() : base("PokeDex") { }

        public DbSet<Pokemon> Pokemon { get; set; }
        public DbSet<Types> Types { get; set; }

        public DbSet<Moves> Moves { get; set; }
    }
}
