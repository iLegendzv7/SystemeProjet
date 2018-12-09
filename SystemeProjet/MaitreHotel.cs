using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SystemeProjet
{
    public class MaitreHotel
    {
        public static int nbTable = 50;
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

                Console.WriteLine("Client" + i + " : Nous sommes : " + Nombre);

                Nombre++;
                i++;

            }

            Table = 0;
            if (Table < 10)
            {
                Table++;
            }
            else
            {
                Console.WriteLine("Toutes les tables sont occupées");
            }



            


          
            Thread.Sleep(2000);



            

            Console.WriteLine("Ca marche :" + Nombre + "   " + Nom + "   " + Table);

        }
    }
}
