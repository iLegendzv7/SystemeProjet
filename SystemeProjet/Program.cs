﻿using System;

namespace SystemeProjet
{
    class Program
    {
        static void Main(string[] args)
        {
            Horloge jalo = new Horloge();


            MaitreHotel NbTest = MaitreHotel.GetInstance();
            NbTest.AccueillirClient();
            NbTest.PacerClient();

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
