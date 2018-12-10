using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace ConsoleApp1
{
    public class BDD
    {

        public MySqlConnection connect;
        private static BDD instance = null;
        public static BDD Instance()
        {
            {
                if (instance == null)
                {
                    instance = new BDD();
                }
                return instance;
            }
        }
        public void bdd()
        {
            if (connect == null)
            {
                try
                {
                    connect = new MySqlConnection("SERVER=178.62.4.64;DATABASE=Groupe1_Pau;UID=Groupe1Pau;PASSWORD=grp1");
                    connect.Open();
                    Console.WriteLine("sys : INSTANCIATION CONNEXION SQL");
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                }
            }
        }
        public void CloseConnection()
        {
            connect.Close();
        }
    }
}


