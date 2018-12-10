using System;
using System.Threading;

namespace SystemeProjet
{
    class Program
    {
        static void Main(string[] args)
        {
            Horloge jalo = new Horloge();


            MaitreHotel NbTest = MaitreHotel.GetInstance();
            NbTest.AccueillirClient();

            ChefDeRang commanderun = new ChefDeRang();
            commanderun.PrendreCommande();

            ChefDeRang commanderdeux = new ChefDeRang();
            commanderdeux.DistribuerPlat(commanderun.Cmdd);

            ChefDeRang commandertrois = new ChefDeRang();
            commandertrois.DebarrasserTable();
            

   
            

            
            Console.Read();
        }
    }
}
