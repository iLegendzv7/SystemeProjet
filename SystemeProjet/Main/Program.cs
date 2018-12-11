using System;
using System.Timers;

namespace SystemeProjet
{
    class Program
    {
        static void Main(string[] args)
        {

            Horloge horloge = new Horloge();        //Execute l'horloge

            Salle salle = new Salle();      //Execute le reste du code ainsi que les répétitions

            Console.Read();         //Garde la console affiché
        }


    }
}
