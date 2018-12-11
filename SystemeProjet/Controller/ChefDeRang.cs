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


        public void PrendreCommande()           // M�thode permettant de donner un plat pour chaque client en fonction du client.
        {
            Random aleatoire = new Random();
            int i = 0;

            int client = MaitreHotel.GetInstance().Nombre;
            Plat[] plats = new Plat[] { new Plat { NomPlat = "Hamburger", TempsPlat = 5 }, new Plat { NomPlat = "Couscous", TempsPlat = 15 }, new Plat { NomPlat = "Entrec�te Frites", TempsPlat = 10 } };
            Console.WriteLine("[" + Horloge.heur + "h" + Horloge.minu + "min]   Chef De Rang : Bonjour, avez-vous choisi vos menus?");

            while (i < client)
            {
                int g = aleatoire.Next(3);      //Permet de r�cup�rer un plar al�atoirement dans notre tableau d'objet Plat.
                Console.WriteLine("[" + Horloge.heur + "h" + Horloge.minu + "min]   Client" + i + " : Je voudrais un " + plats[g].NomPlat);
                Plat listecommande = plats[g];
                cmdd.Add(listecommande);        //Ajoute le plat � la liste des plats command�s sur le moment.
                i++;

                try
                {
                    //Instancie la connexion
                    BDD connect = new BDD();
                    //Requete pour enlever la quantit� de plats command�
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
        public void DistribuerPlat(List<Plat> cmdd)     // M�thode permettant de d�finir le temps d'attente puis de servir les clients
        {
            cmdd.ForEach(x =>                               //Cherche le plat le plus long � pr�parer
            {
                if (tempsmax < x.TempsPlat)
                {
                    tempsmax = x.TempsPlat;
                }
            });
            Thread.Sleep(1000 * MaitreHotel.GetInstance().Nombre);                  //Temps de prise de commande en fonction du nombre de clients
            Console.WriteLine("[" + Horloge.heur + "h" + Horloge.minu + "min]   Chef De Rang : J'ai bien not� vos commandes. Le temps d'attente est de " + tempsmax + " minutes");
            MaitreHotel.GetInstance().TableAServir = MaitreHotel.GetInstance().Table;
            Thread.Sleep(tempsmax * 1000);                                      //Temps d'attente pour la pr�paration du repas
            Console.WriteLine("[" + Horloge.heur + "h" + Horloge.minu + "min]   ***Les clients de la table " + MaitreHotel.GetInstance().TableAServir + " sont servis!***");
            MaitreHotel.GetInstance().TableADebarrasser = MaitreHotel.GetInstance().TableAServir;
            Thread.Sleep(15 * 1000);                                            //Temps durant lequel les clients mangent
        }

        public void DebarrasserTable()                                         // M�thode permettant de lib�rer la table occup�e et de signaler que le groupe de clients est parti
        {
            Console.WriteLine("[" + Horloge.heur + "h" + Horloge.minu + "min]   ***Les clients de la table " + MaitreHotel.GetInstance().TableADebarrasser + " ont finit de manger***");
            cmdd.Clear();
            Thread.Sleep(500 * MaitreHotel.GetInstance().Nombre);               //Temps durant lequel le Chef de Rang d�barasse la table
            Console.WriteLine("[" + Horloge.heur + "h" + Horloge.minu + "min]   *** Le Chef de Rang a finit de d�barrasser ! ***");
            MaitreHotel.GetInstance().Nombre = 0;

            try
            {
                //Instancie la connexion
                BDD connect = new BDD();
                //Requ�te pour rendre une table disponible
                string majTable = "UPDATE tables SET numero = " + MaitreHotel.GetInstance().TableADebarrasser + ",disponible = 0 WHERE numero =" + MaitreHotel.GetInstance().TableADebarrasser;
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

