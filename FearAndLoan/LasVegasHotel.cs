using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FearAndLoan
{
    public class LasVegasHotel
    {
        //constructor without properties - will run when new LasVegasHotel() is called
        public LasVegasHotel(List<string> heroNames)
        {
            var gluckNames = new List<string>() { "Bat", "Reptile", "Shark Girl", "Deja Vu", "Self" };
            Heroes = new List<Hero>();
            var rnd = new Random();
            foreach (var name in heroNames)
            {
                Heroes.Add(new Hero(name, rnd.Next(100, 200), (decimal)(rnd.Next(70, 100) * 0.1)));
            }
            AvailableDrugs = new List<Drug>();
            decimal currentDrugDoze = 0;
            foreach (var drugName in DrugNames)
            {
                currentDrugDoze += (decimal)(rnd.Next(20, 100) * 0.1);

                var drug = new Drug()
                {
                    Name = drugName, //look here its comma
                    Doze = currentDrugDoze
                };

                AvailableDrugs.Add(drug);
            }
            IncomingGlucks = new List<Gluck>();
            decimal currentStr = 5;
            decimal currentReq = 3;
            foreach (var gluckName in gluckNames)
            {
                currentStr += 5;
                currentReq += (decimal) (rnd.Next(100, 200) * 0.1);
                IncomingGlucks.Add(new Gluck()
                {
                    Name = gluckName,
                    DrugRequirement = currentReq,
                    GluckStrength = currentStr
                });
            }
        }

        //this adds to the beginning of constructor.
        public List<string> DrugNames => new List<string>() { "Cannabis", "Heroin", "Cocaine", "Efir", "LSD", "Mushrooms" };
        public List<Hero> Heroes { get; set; }
        public List<Drug> AvailableDrugs { get; set; }
        public List<Gluck> IncomingGlucks { get; set; }

        public void DoDich()
        {
            var rnd = new Random();
            for (int i = 0; i < 6; i++)
            {
                foreach (var hero in Heroes)
                {
                    //var drug = AvailableDrugs[rnd.Next(AvailableDrugs.Count)];
                    //hero.TakeDrug(drug);
                    if (hero.Health > 0)
                    {
                        hero.TakeDrug(AvailableDrugs[rnd.Next(AvailableDrugs.Count)]);
                    }
                }
                foreach (var hero in Heroes)
                {
                    var correspondingGlucks = new List<Gluck>();
                    //correspondingGlucks = IncomingGlucks.Where(x => x.DrugRequirement < hero.CurrentDoze).ToList();
                    foreach (var gluck in IncomingGlucks)
                    {
                        if (gluck.DrugRequirement < hero.CurrentDoze)
                        {
                            correspondingGlucks.Add(gluck);
                        }
                    }


                    foreach (var gluck in correspondingGlucks)
                    {
                        if(hero.Health>0)
                        {
                            hero.HaveATrip(gluck);
                        }
                    }
                }
                Console.WriteLine();
                
            }
            foreach (var hero in Heroes)
            {
                hero.Report();
            }
        }
    }
}
