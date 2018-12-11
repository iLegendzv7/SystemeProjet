using MySql.Data.MySqlClient;
using System;

namespace SystemeProjet
{
    public class BDD
    {
        private static BDD instance = null;
        private static MySqlConnection connection;

        public BDD()
        {
            //Création de la chaine de connection
            string connString = "SERVER=localhost ;DATABASE=systeme_projet;UID=root;PASSWORD=sosodu64";
            connection = new MySqlConnection(connString);

            try
            {
                //Ouverture de la connection
                connection.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //Création d'une instance pour le Singleton
        public static BDD GetInstance()
        {
            if (instance == null)
            {
                instance = new BDD();
            }

            return instance;
        }
        //Mise en place des accesseurs GET et SET
        public MySqlConnection Connection
        {
            get { return connection; }
            set { connection = value; }
        }
    }
}
