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
            string connString = "SERVER=localhost ;DATABASE=systeme_projet;UID=root;PASSWORD=";
            connection = new MySqlConnection(connString);

            try
            {
                connection.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static BDD GetInstance()
        {
            if (instance == null)
            {
                instance = new BDD();
            }

            return instance;
        }

        public void CloseConnection(MySqlConnection connection)
        {
            connection.Close();
        }

        public MySqlConnection Connection
        {
            get { return connection; }
            set { connection = value; }
        }
    }
}
