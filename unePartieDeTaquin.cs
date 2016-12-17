using System;
using System.Collections.Generic;
using System.Text;

namespace Taquin
{
    class unePartieDeTaquin
    {
        static public void Main(string[] args)
        {
            ConsoleKeyInfo toucheAppuyé;
            int i = 0;
            bool gagné = false;
            Taquin unTaquin = new Taquin();

            //unTaquin.tableauTest();
            unTaquin.NouveauJeu();
            Console.WriteLine(unTaquin.ToString());
            while (gagné == false)
            {
                // petit programme qui permet de tester le taquin
                
                toucheAppuyé = Console.ReadKey();
                if (toucheAppuyé.Key == ConsoleKey.DownArrow)
                {
                    i = 2;
                }
                if (toucheAppuyé.Key == ConsoleKey.LeftArrow)
                {
                    i = 4;
                }
                if (toucheAppuyé.Key == ConsoleKey.RightArrow)
                {
                    i = 6;
                }
                if (toucheAppuyé.Key == ConsoleKey.UpArrow)
                {
                    i = 8;
                }

                unTaquin.Jouer(i);
                Console.Clear();
                Console.WriteLine(unTaquin.ToString());
                gagné = unTaquin.Gagné();

            }
            Console.WriteLine("Vous avez gagné !");
            Console.ReadLine();
        }
    }
}