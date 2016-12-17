using System;
using System.Collections;

namespace Taquin
{
	class Taquin
	{
		//--- Variables d'instance
		private int ligneVide;
		private int colonneVide;
		private int[,] plateau;
        private int[,] plateauGagnant;
	
		//--- Constructeurs
		public Taquin()
		{
            plateau = new int[3, 3];
		}     

		public override string ToString()	
        // développer l'objet comme s'il était destiné à quelqu'un d'autre, 
		{
            // rendre indépendant de l'interface utilisateur (console,Windows Form, Web).
            // chaque méthode doit rendre un service et un seul.
            // cette méthode retourne une chaine de caractère présentant sous la forme d'un tableau 
            // le taquin
			string plateauTaquin="";
            for (int ligne = 0; ligne < 3; ligne++)
            {
                for (int colonne = 0; colonne < 3; colonne++)
                {
                   plateauTaquin = plateauTaquin + plateau[ligne, colonne] +"                      ";
                }
                plateauTaquin = plateauTaquin + "\n\n\n\n\n\n\n\n\n\n";
            }
			// à coder
			return plateauTaquin;
		}

        // Cette méthod permet de jouer un et un seul coup de taquin
        // retourn false si unCoup ne prend pas une des valeurs suivantes : 2,4,6,8
		public bool Jouer(int unCoup)
		{
			bool coupJoué = true;
            // A compléter

			if (unCoup==2) 
			{
                if (ligneVide  > 0 )
                {
                    int vb1;
                    vb1 = plateau[ligneVide - 1, colonneVide];
                    plateau[ligneVide - 1, colonneVide] = plateau[ligneVide, colonneVide];
                    plateau[ligneVide, colonneVide] = vb1;

                    ligneVide = ligneVide - 1;
                }
                
			}
			else
			{
				if (unCoup==4)
				{
                    if (colonneVide < 2)
                    {
                        int vb1;
                        vb1 = plateau[ligneVide, colonneVide + 1];
                        plateau[ligneVide, colonneVide + 1] = plateau[ligneVide, colonneVide];
                        plateau[ligneVide, colonneVide] = vb1;

                        colonneVide = colonneVide + 1;
                    }                  
				}
				else
				{
					if (unCoup==6)
					{
                        if (colonneVide > 0)
                        {
                            int vb1;
                            vb1 = plateau[ligneVide, colonneVide - 1];
                            plateau[ligneVide, colonneVide - 1] = plateau[ligneVide, colonneVide];
                            plateau[ligneVide, colonneVide] = vb1;

                            colonneVide = colonneVide - 1;
                        }    
					}
					else
					{
						if(unCoup==8)
						{
                            if (ligneVide < 2 )
                            {
                                int vb1;
                                vb1 = plateau[ligneVide + 1, colonneVide];
                                plateau[ligneVide + 1, colonneVide] = plateau[ligneVide, colonneVide];
                                plateau[ligneVide, colonneVide] = vb1;

                                ligneVide = ligneVide + 1;    
                            }   
						}
						else
						{
                            // le joueur n'a pas choisi 2,4,6 ou 8, il n'a pas joué
							coupJoué=false;
						}
					}

				}
			}
			return coupJoué;
		}
		public bool Gagné()
		{
            bool Gagne = false;
            bool sameTableau = true;
            plateauGagnant = new int [,]{{1,2,3},{4,5,6},{7,8,0}};
            // à vous de déterminer si la situation du taquin est gagnante ou non

            for (int ligne = 0; ligne < 3; ligne++)
            {
                for (int colonne = 0; colonne < 3; colonne++)
                {
                    if (plateau[ligne, colonne] != plateauGagnant[ligne, colonne])
                    {
                        sameTableau = false;
                    }
                } 
            }
            if (sameTableau == true)
            {
                Gagne = true;
            }
			return Gagne;
		}

        // pourrait être une méthode privée si on l'utilise uniquement dans 
        // un constructeur, ou faire partie du code du constructeur.
        // initialise le taquin aléatoirement 
        public void NouveauJeu()
        {
            ArrayList valeurs = new ArrayList();
            Random r = new Random();
            int nbRandom;
            for (int i = 0; i < 9; i++)
            {
                valeurs.Add(i);
            }
            for (int ligneTableau = 0; ligneTableau < 3; ligneTableau++)
            {
                for (int colonneTableau = 0; colonneTableau < 3; colonneTableau++)
                {
                    nbRandom = r.Next(0, valeurs.Count);               
                    plateau[ligneTableau, colonneTableau] = (int)valeurs[nbRandom];
                    if ((int)valeurs[nbRandom] == 0)
                    {
                        ligneVide = ligneTableau;
                        colonneVide = colonneTableau;
                    }
                    valeurs.RemoveAt(nbRandom);
                   
                }
            }





            // tous les postes du tableau sont initialisés avec une valeur comprise entre 0 et 9
            // attention pas de doublons...
        }


        public void tableauTest()
        {
            plateau = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 0, 8 } };
            ligneVide = 2;
            colonneVide = 1;

        }
        // Accesseurs
        public int GetLigneVide
        {
            get { return this.ligneVide; }
        }
        public int GetColonneVide
        {
            get { return this.colonneVide; }
        }


        // Indexeur 
        int this[int ligne, int colonne]
        {
            get { return plateau[ligne, colonne]; }
        }

	}

}
