using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace SystemeProjet
{
    class Horloge {

        public static int minu = 0;
        public static int heur = 0;

        public Horloge()
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

        private static void Minute_Elapsed(object sender, ElapsedEventArgs e)
        {


            minu++;

            if (minu == 60)
            {
                heur++;
                minu = 0;
            }
            //Console.WriteLine(heur + " heure(s) et " + minu + " minute(s)'écoule");
            //minute.Interval = 1000;

        }

        private static void Heure_Elapsed(object sender, ElapsedEventArgs e)
        {
            //heur++;
            if (heur == 24)
            {
                heur = 0;
                minu = 0;
            }
        }

    }
}
