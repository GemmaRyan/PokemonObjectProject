using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StartPage;

namespace DataManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PokeData db = new PokeData();

            using (db)
            {
                //declare all types, attack, defence and specials before initalising the pokemon 
                // because we need everything initalised before we state the pokemon 
                //Types t1 = new Types() { TypeID = 1, PokeType = "Fire" , Effective = "Grass" , Weakness = "Water"};
                //Types t2 = new Types() { TypeID = 2, PokeType = "Water", Effective = "Fire", Weakness = "Electric" };       //temporarily change to test
                //Types t3 = new Types() { TypeID = 3, PokeType = "Grass", Effective = "Fighing", Weakness = "Fire" };

                //tester data
                Types t1 = new Types() { TypeID = 1, PokeType = "Fire", Effective = "Grass", Weakness = "Water" };
                Types t2 = new Types() { TypeID = 2, PokeType = "Water", Effective = "Fire", Weakness = "Grass" };       //delete after
                Types t3 = new Types() { TypeID = 3, PokeType = "Grass", Effective = "Water", Weakness = "Fire" };



                //Types t4 = new Types() { TypeID = 4, PokeType = "Psycic", Effective = "Fighting", Weakness = "Dark" };  //not effective against anything give extra hp / stronger moves
                //Types t5 = new Types() { TypeID = 5, PokeType = "Electric", Effective = "Water", Weakness = "Fighting" };
                //Types t6 = new Types() { TypeID = 6, PokeType = "Dark", Effective = "Psycic", Weakness = "Normal" };  
                //Types t7 = new Types() { TypeID = 7, PokeType = "Normal", Effective = "Normal", Weakness = "Fighting" };
                //Types t8 = new Types() { TypeID = 8, PokeType = "Fighting", Effective = "Electric", Weakness = "Grass" };   // strong against loads of types but alos weak against loads

                Pokemon p1 = new Pokemon() { PokeDexID = 1, PokemonName = "Charizard", Types = t1, ImageURL_Back = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/back/6.png", ImageURL_Front = $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/6.png", Health = 280 };
                Pokemon p2 = new Pokemon() { PokeDexID = 2, PokemonName = "Venusaur", Types = t3, ImageURL_Back = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/back/3.png", ImageURL_Front = $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/3.png", Health = 350 };
                Pokemon p3 = new Pokemon() { PokeDexID = 3, PokemonName = "Blastoise", Types = t2, ImageURL_Back = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/back/9.png", ImageURL_Front = $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/9.png", Health = 300 };

                //Pokemon p4 = new Pokemon() { PokeDexID = 1, PokemonName = "Charizard", Types = t1 };


                Moves m1 = new Moves() { MoveID = 1, MoveName = "Ember", Types = t1, Accuracy = 90, AttackDamage = 20, Pokemons = new List<Pokemon> { p1 } };
                Moves m2 = new Moves() { MoveID = 2, MoveName = "Raging Fury", Types = t1, Accuracy = 60, AttackDamage = 40, Pokemons = new List<Pokemon> { p1, p3 } };
                Moves m3 = new Moves() { MoveID = 3, MoveName = "Overheat", Types = t1, Accuracy = 35, AttackDamage = 60, Pokemons = new List<Pokemon> { p1, p3 } };
                Moves m4 = new Moves() { MoveID = 4, MoveName = "Inferno", Types = t1, Accuracy = 75, AttackDamage = 30, Pokemons = new List<Pokemon> { p1 } };
                Moves m5 = new Moves() { MoveID = 5, MoveName = "Vine Whip", Types = t3, Accuracy = 90, AttackDamage = 20, Pokemons = new List<Pokemon> { p2 } };
                Moves m6 = new Moves() { MoveID = 6, MoveName = "Hydro Blast", Types = t2, Accuracy = 50, AttackDamage = 50, Pokemons = new List<Pokemon> { p3 } };
                Moves m7 = new Moves() { MoveID = 7, MoveName = "Spore Blast", Types = t3, Accuracy = 30, AttackDamage = 60, Pokemons = new List<Pokemon> { p2 } };
                Moves m8 = new Moves() { MoveID = 5, MoveName = "Leaf Storm", Types = t3, Accuracy = 90, AttackDamage = 30, Pokemons = new List<Pokemon> { p2 } };


                //adding moves
                db.Moves.Add(m1);
                db.Moves.Add(m2);
                db.Moves.Add(m3);
                db.Moves.Add(m4);
                db.Moves.Add(m5);
                db.Moves.Add(m6);
                db.Moves.Add(m7);
                db.Moves.Add(m8);
                Console.WriteLine("Adding moves");


                //adding types
                db.Types.Add(t1);
                db.Types.Add(t2);
                db.Types.Add(t3);
                Console.WriteLine("Added three Types");

                //adding them all 
                //adding pokemon
                db.Pokemon.Add(p1);
                db.Pokemon.Add(p2);
                db.Pokemon.Add(p3);

                Console.WriteLine("Added three pokemon");

                db.SaveChanges();

                Console.WriteLine("Saved changes!");
            }
        }
    }
}
