using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Threading;

namespace SystemeProjet
{
    public class ChefDeRang
    {
        private List<Plat> cmdd = new List<Plat>();
        int tempsmax = 0;


        public void PrendreCommande()
        {
            Random aleatoire = new Random();
            int i = 0;

            int client = MaitreHotel.GetInstance().Nombre;
            Plat[] plats = new Plat[] { new Plat { NomPlat = "Hamburger", TempsPlat = 10 }, new Plat { NomPlat = "Couscous", TempsPlat = 25 }, new Plat { NomPlat = "Entrec�te Frites", TempsPlat = 15 } };
            Console.WriteLine("[" + Horloge.heur + "h" + Horloge.minu + "min]   Chef De Rang : Bonjour, avez-vous choisi vos menus?");

            while (i < client)
            {
                int g = aleatoire.Next(3);
                Console.WriteLine("[" + Horloge.heur + "h" + Horloge.minu + "min]   Client" + i + " : Je voudrais un " + plats[g].NomPlat);
                Plat pouloulou = plats[g];
                cmdd.Add(pouloulou);
                i++;

                try
                {
                    BDD connect = new BDD();
                    string majTable = "UPDATE plats SET nomPlat = '" + plats[g].NomPlat + "', quantit�Plat = quantit�Plat - 1 WHERE nomPlat ='" + plats[g].NomPlat + "'";
                    MySqlCommand test = new MySqlCommand(majTable, connect.Connection);
                    test.ExecuteNonQuery();
                }
                catch
                {
                    Console.WriteLine("Erreur");
                }
            }
        }
        public void DistribuerPlat(List<Plat> cmdd)
        {
            cmdd.ForEach(x =>
            {
                if (tempsmax < x.TempsPlat)
                {
                    tempsmax = x.TempsPlat;
                }
            });
            Thread.Sleep(1000 * MaitreHotel.GetInstance().Nombre);                  //Temps de prise de commande en fonction du nombre de clients
            Console.WriteLine("[" + Horloge.heur + "h" + Horloge.minu + "min]   Chef De Rang : J'ai bien not� vos commandes. Le temps d'attente est de " + tempsmax + " minutes");
            Thread.Sleep(tempsmax * 1000);                                      //Temps d'attente pour la pr�paration du repas
            Console.WriteLine("[" + Horloge.heur + "h" + Horloge.minu + "min]   ***Les clients de la table " + MaitreHotel.GetInstance().Table + " sont servis!***");
            Thread.Sleep(30 * 1000);                                            //Temps durant lequel les clients mangent
        }

        public void DebarrasserTable()
        {
            Console.WriteLine("[" + Horloge.heur + "h" + Horloge.minu + "min]   ***Les clients de la table " + MaitreHotel.GetInstance().Table + " ont finit de manger***");
            cmdd.Clear();
            Thread.Sleep(500 * MaitreHotel.GetInstance().Nombre);               //Temps durant lequel le Chef de Rang d�barasse la table
            Console.WriteLine("[" + Horloge.heur + "h" + Horloge.minu + "min]   *** Le Chef de Rang a finit de d�barrasser ! ***");
            MaitreHotel.GetInstance().Nombre = 0;

            try
            {
                BDD connect = new BDD();
                string majTable = "UPDATE tables SET numero = " + MaitreHotel.GetInstance().Table + ",disponible = 0 WHERE numero =" + MaitreHotel.GetInstance().Table;
                MySqlCommand test = new MySqlCommand(majTable, connect.Connection);
                test.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erreur");
            }
        }
        public List<Plat> Cmdd
        {
            get { return cmdd; }
            set { cmdd = value; }

        }
    }
}
