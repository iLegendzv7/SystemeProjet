﻿using System;

namespace SystemeProjet
{
    class Program
    {
        static void Main(string[] args)
        {
            ChefDeRang commanderun = new ChefDeRang();
            commanderun.PrendreCommande();

            ChefDeRang commanderdeux = new ChefDeRang();
            commanderdeux.DistribuerPlat(commanderun.Cmd);

            ChefDeRang commandertrois = new ChefDeRang();
            commandertrois.DebarrasserTable();

            Console.Read();
        }
    }
}
