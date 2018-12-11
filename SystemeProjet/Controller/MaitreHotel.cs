using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using MySql.Data.MySqlClient;

namespace SystemeProjet
{
    public class MaitreHotel
    {
        //Mise en place du Singleton
        private static MaitreHotel instance = null;

        public int Nom { get; set; }
        public int Nombre { get; set; }
        public int Table { get; set; }

        public int TableAServir { get; set; }

        public int TableADebarrasser { get; set; }

        //Création d'une instance pour Singleton
        public static MaitreHotel GetInstance()
        {
            if (instance == null)
            {
                instance = new MaitreHotel();
            }
            return instance;
        }
        //Méthode pour la génération de client
        public void AccueillirClient()
        {
            //Appelle de Random pour créer un nombre aléatoire entre 2 et 9
            Random aleatoire = new Random();
            Nombre = aleatoire.Next(2, 9);

            Nom = 0;
            Nom++;

            Console.WriteLine("_______________________________________Un nouveau groupe de clients arrive______________________________________________");
            Console.WriteLine("[" + Horloge.heur + "h" + Horloge.minu + "min]   Maitre d'hôtel : Bonjour messieurs dames, combien êtes-vous? ");
            Console.WriteLine("[" + Horloge.heur + "h" + Horloge.minu + "min]   Client(s) : Bonjour, nous sommes " + Nombre);

            Thread.Sleep(2000);
        }
        //Méthode pour l'attribution de table
        public void PlacerClient()
        {
            try
            {
                //Instancie la connexion
                BDD connexion = new BDD();
                //Requête de selection de table
                string tableDispo = "SELECT * FROM tables WHERE disponible = 0";
                //Appel et execution
                MySqlCommand cmd = new MySqlCommand(tableDispo, connexion.Connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                reader.Read();
                Table = reader.GetInt32("numero");
                Console.WriteLine("[" + Horloge.heur + "h" + Horloge.minu + "min]   Bien, le Chef de Rang va venir vous placer à la table " + Table);
                Console.WriteLine("[" + Horloge.heur + "h" + Horloge.minu + "min]   *** Le chef de rang place les clients ***");
                Thread.Sleep(6000);     //Temps d'attente durant lequel les clients se placent à la table et regardent ce qu'ils vont prendre commme menu
                reader.Close();
                //Requête pour rendre la table indisponible
                string majTable = "UPDATE tables SET numero = " + Table + ",disponible = 1 WHERE numero =" + Table;
                MySqlCommand test = new MySqlCommand(majTable, connexion.Connection);
                test.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("[" + Horloge.heur + "h" + Horloge.minu + "min]   Toutes les tables sont occupées");
            }
        }

    }
}
