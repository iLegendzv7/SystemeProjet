using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SystemeProjet
{
    public class ChefDeRang
    {
        private List<Plat> cmd = new List<Plat>();
        int tempsmax = 0;
        public void PrendreCommande()
        {
            Random aleatoire = new Random();
            int i = 0;
            int client = aleatoire.Next(1, 9);
            Plat[] plats = new Plat[] { new Plat { NomPlat = "hamburger", TempsPlat = 10 }, new Plat { NomPlat = "pizza", TempsPlat = 25 }, new Plat { NomPlat = "couscous", TempsPlat = 15 } };


            while (i < client)
            {
                // int y = aleatoire.Next(client);
                int g = aleatoire.Next(3);
                Console.WriteLine("Client" + i + " : Je voudrais ceci : " + plats[g].NomPlat);
                Plat pouloulou = plats[g];
                cmd.Add(pouloulou);
                i++;
            }
        }
        public void DistribuerPlat(List<Plat> cmd)
        {
            cmd.ForEach(x =>
            {
                if (tempsmax < x.TempsPlat)
                {
                    tempsmax = x.TempsPlat;
                }
            });
            //Thread.Sleep(3000);
            Console.WriteLine("Le temps d'attente est de " + tempsmax + " minutes");
            //Thread.Sleep(tempsmax * 1000);
            Console.WriteLine("Les clients de la table sont servis!");
            //Thread.Sleep(30000); 
        }

        public void DebarrasserTable()
        {
            Console.WriteLine("***Les clients ont finit de manger***");
            cmd.Clear();
            Thread.Sleep(2000);
            Console.WriteLine("*** Le Chef de Rang a finit de débarrasser ! ***");
        }
        public List<Plat> Cmd
        {
            get { return cmd; }
            set { cmd = value; }

        }
    }
}

