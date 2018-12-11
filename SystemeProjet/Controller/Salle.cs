using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace SystemeProjet
{
    public class Salle
    {

        public Salle()
        {

                Timer gon = new Timer(30000);
                gon.Elapsed += Gon_Elapsed;
                gon.Enabled = true;
                gon.AutoReset = true;
                gon.Start();
                
         
        }

        private void Gon_Elapsed(object sender, ElapsedEventArgs e)
        {
     
            MaitreHotel NbTest = MaitreHotel.GetInstance();
            NbTest.AccueillirClient();
            NbTest.PacerClient();

            ChefDeRang commanderun = new ChefDeRang();
            commanderun.PrendreCommande();

            ChefDeRang commanderdeux = new ChefDeRang();
            commanderdeux.DistribuerPlat(commanderun.Cmdd);

            ChefDeRang commandertrois = new ChefDeRang();
            commandertrois.DebarrasserTable();
        }
        //public void Pololo()

        // {
        //     int pp = 0;
        //     while (pp < 10)
        //     {
        //         MaitreHotel NbTest = MaitreHotel.GetInstance();
        //         NbTest.AccueillirClient();
        //         NbTest.PacerClient();

        //         ChefDeRang commanderun = new ChefDeRang();
        //         commanderun.PrendreCommande();

        //         ChefDeRang commanderdeux = new ChefDeRang();
        //         commanderdeux.DistribuerPlat(commanderun.Cmdd);

        //         ChefDeRang commandertrois = new ChefDeRang();
        //         commandertrois.DebarrasserTable();

        //         pp++;
        //     }


   // }


    }
}