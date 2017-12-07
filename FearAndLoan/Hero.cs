using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FearAndLoan
{
    public class Hero
    {
        public Hero(string name, decimal health, decimal resistance)
        {
            Name = name;
            Health = health;
            Resistance = resistance;
        }
        public string Name { get; set; }
        public decimal Health { get; set; }

        private decimal currentDoze;

        public decimal CurrentDoze
        {
            get { return currentDoze; }
            set
            {
                if (value < 0)
                {
                    currentDoze = 0;
                }
                else currentDoze = value;
            }
        }
                
        public decimal Resistance { get; set; }

        public void TakeDrug(Drug drug)
        {
            CurrentDoze += drug.Doze-Resistance;
            Console.WriteLine($"{Name} took {drug.Name}. Now his doze is {CurrentDoze}.");
        }

        public void HaveATrip(Gluck gluck)
        {
            if(Health>0)
            {
                Health -= gluck.GluckStrength;
                Console.WriteLine($"{Name} faces {gluck.Name}. His health is {Health}");
            }
            else
            {
                Console.WriteLine($"{Name} is fucking dead!");
            }
        }

        public void Report()
        {
            if (Health > 0)
            {
                Console.WriteLine($"{Name} is Alive! His {Health} health and current doze is {CurrentDoze}");
            }
            else if (Health>-10)
            {
                Console.WriteLine($"{Name} Lies unconcious! His {Health} health and current doze is {CurrentDoze}");
            }
            else
            {
                Console.WriteLine($"{Name} is fucking dead! His {Health} health and current doze is {CurrentDoze}");
            }
        }
        //public void SayHello()
        //{
        //    Console.WriteLine("Hello");
        //}

        //public void SayHello(string name)
        //{
        //    Console.WriteLine("Pruved "+name);
        //}
        //public void SayHello(int count)
        //{
        //    for (int i = 0; i < count; i++)
        //    {
        //        Console.WriteLine("Halllo");
        //    }

        //}
    }
}
