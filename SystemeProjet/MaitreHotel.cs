using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SystemeProjet
{
    public class MaitreHotel
    {
        public int Nom { get; set; }
        public int Nombre { get; set; }
        public int Table { get; set; }

        public MaitreHotel(int nom, int nombre, int table)
        {
            Nom = nom;
            Nombre = nombre;
            Table = table;
        }

        public MaitreHotel()
        {
        }

        private List<MaitreHotel> cmd = new List<MaitreHotel>();
        public static int nbTable = 50;


        public void AccueillirClient()
        {





            Random aleatoire = new Random();
            int i = 0;
            int _nbclient = aleatoire.Next(1, 9);




            //MaitreHotel clt = new MaitreHotel(i, _nbclient, );

            Console.WriteLine(i);


            while (i < _nbclient)
            {

                Console.WriteLine("Client" + i + " : Nous sommes : " + _nbclient);


                i++;

            }
            int nb = _nbclient;

            MaitreHotel.nbTable = nbTable - 1;

            Console.WriteLine(i);
            Thread.Sleep(2000);



            MaitreHotel ecrire = new MaitreHotel(i, nb, MaitreHotel.nbTable);

            Console.WriteLine("Ca marche :" + ecrire.Nombre + "   " + ecrire.Nom + "   " + MaitreHotel.nbTable);
        }

        void PlacerClient()
        {
            throw new NotImplementedException();
        }
    }
}
