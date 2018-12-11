using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace SystemeProjet
{
    class Horloge {

        public static int minu = 0;
        public static int heur = 0;
        

        public Horloge()        //Constructeur initialisant les Timers de minute et d'heure
        {
            Timer minute = new Timer(1000);
            minute.Elapsed += Minute_Elapsed;
            minute.Enabled = true;
            minute.AutoReset = true;
            minute.Start();

            Timer heure = new Timer(60000);
            heure.Elapsed += Heure_Elapsed;
            heure.Enabled = true;
            heure.AutoReset = true;
            heure.Start();

        }

        private static void Minute_Elapsed(object sender, ElapsedEventArgs e)       //Configuration des minutes
        {


            minu++;

            if (minu == 60)
            {
                heur++;
                minu = 0;
            }


        }

        private static void Heure_Elapsed(object sender, ElapsedEventArgs e)        //Configuration des heures
        {
            if (heur == 24)
            {
                heur = 0;
                minu = 0;
            }
        }

    }
}
