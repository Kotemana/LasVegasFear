using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FearAndLoan
{
    class Program
    {
        static void Main(string[] args)
        {
            var nameList = new List<string> { "Raul Duke", "Dr Gonzo", "Dextor", "Assassin" };
            var hotel = new LasVegasHotel(nameList);
            hotel.DoDich();
            Console.ReadLine();
        }
    }
}
