using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using MySql.Data.MySqlClient;

namespace SystemeProjet
{
    public class MaitreHotel
    {
        private static MaitreHotel instance = null;

        public int Nom { get; set; }
        public int Nombre { get; set; }
        public int Table { get; set; }


        private MaitreHotel()
        {
        }

        public static MaitreHotel GetInstance()
        {
            if (instance == null)
            {
                instance = new MaitreHotel();
            }
            return instance;
        }





        //MaitreHotel ecrire = new MaitreHotel(nom, nombre, MaitreHotel.nbTable);

        public void AccueillirClient()
        {

            Random aleatoire = new Random();
            int i = 0;
            int nombre = aleatoire.Next(1, 9);

            Nom = 0;
            Nom++;


            //MaitreHotel clt = new MaitreHotel(i, _nbclient, );

            Console.WriteLine(i);


            while (i < nombre)
            {

                //Console.WriteLine("[" + Horloge.heur + "h" + Horloge.minu + "min]   Client" + i + " : Nous sommes : " + Nombre);

                Nombre++;
                i++;

            }
            Console.WriteLine("[" + Horloge.heur + "h" + Horloge.minu + "min]   Maitre d'hôtel : Bonjour messieurs dames, combien êtes-vous? ");
            Console.WriteLine("[" + Horloge.heur + "h" + Horloge.minu + "min]   Client(s) : Bonjour, nous sommes " + Nombre);



            //Table = 0;
            //if (Table < 10)
            //{
            //    Table++;
            //    Console.WriteLine("[" + Horloge.heur + "h" + Horloge.minu + "min]   Bien, le Chef de Rang va venir vous placer à la table " + Table);
            //    Console.WriteLine("[" + Horloge.heur + "h" + Horloge.minu + "min]   *** Le chef de rang place les clients ***");
            //    Thread.Sleep(6000);     //Temps d'attente durant lequel les clients se placent à la table et regardent ce qu'ils vont prendre commme menu
            //}
            //else
            //{
            //    Console.WriteLine("[" + Horloge.heur + "h" + Horloge.minu + "min]   Toutes les tables sont occupées");
            //}







            Thread.Sleep(2000);





            //Console.WriteLine("Ca marche :" + Nombre + "   " + Nom + "   " + Table);

        }

        public void PacerClient()
        {
            try
            {
                BDD connexion = new BDD();

                string tableDispo = "SELECT * FROM tables WHERE disponible = 0";

                MySqlCommand cmd = new MySqlCommand(tableDispo, connexion.Connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                reader.Read();
                Table = reader.GetInt32("numero");
                Console.WriteLine("[" + Horloge.heur + "h" + Horloge.minu + "min]   Bien, le Chef de Rang va venir vous placer à la table " + Table);
                Console.WriteLine("[" + Horloge.heur + "h" + Horloge.minu + "min]   *** Le chef de rang place les clients ***");
                Thread.Sleep(6000);     //Temps d'attente durant lequel les clients se placent à la table et regardent ce qu'ils vont prendre commme menu
                reader.Close();

                //string majTable = "UPDATE tables SET numero = 4,disponible = 1 WHERE numero = 4";
                //MySqlCommand test = new MySqlCommand(majTable, connexion.Connection);
                //test.ExecuteNonQuery();


            }
            catch
            {
                Console.WriteLine("[" + Horloge.heur + "h" + Horloge.minu + "min]   Toutes les tables sont occupées");
            }
        }

    }
}
