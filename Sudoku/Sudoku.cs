using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku
{
    public class Sudoku : ISudoku
    {
        private Cellule[][] TabCellules;

        public Sudoku()
        {
            TabCellules = new Cellule[9][];

            TabCellules[0] = new Cellule[] { new Cellule(), new Cellule(), new Cellule(6), new Cellule(2), new Cellule(), new Cellule(), new Cellule(), new Cellule(8), new Cellule() };
            TabCellules[1] = new Cellule[] { new Cellule(), new Cellule(), new Cellule(8), new Cellule(9), new Cellule(7), new Cellule(), new Cellule(), new Cellule(), new Cellule() };
            TabCellules[2] = new Cellule[] { new Cellule(), new Cellule(), new Cellule(4), new Cellule(8), new Cellule(1), new Cellule(), new Cellule(5), new Cellule(), new Cellule() };
            TabCellules[3] = new Cellule[] { new Cellule(), new Cellule(), new Cellule(), new Cellule(), new Cellule(6), new Cellule(), new Cellule(), new Cellule(), new Cellule(2) };
            TabCellules[4] = new Cellule[] { new Cellule(), new Cellule(7), new Cellule(), new Cellule(), new Cellule(), new Cellule(), new Cellule(), new Cellule(3), new Cellule() };
            TabCellules[5] = new Cellule[] { new Cellule(6), new Cellule(), new Cellule(), new Cellule(), new Cellule(5), new Cellule(), new Cellule(), new Cellule(), new Cellule() };
            TabCellules[6] = new Cellule[] { new Cellule(), new Cellule(), new Cellule(2), new Cellule(), new Cellule(4), new Cellule(7), new Cellule(1), new Cellule(), new Cellule() };
            TabCellules[7] = new Cellule[] { new Cellule(), new Cellule(), new Cellule(3), new Cellule(), new Cellule(2), new Cellule(8), new Cellule(4), new Cellule(), new Cellule() };
            TabCellules[8] = new Cellule[] { new Cellule(), new Cellule(5), new Cellule(), new Cellule(), new Cellule(), new Cellule(1), new Cellule(2), new Cellule(), new Cellule() };
           /* for (int x = 0; x <= 8; x++)
            {
                TabCellules[x] = new Cellule[9];
                for (int y = 0; y <= 8; y++)
                {
                    TabCellules[x][y] = new Cellule
                    {
                        EstTrouve = false,
                        EstValeurInitiale = false,
                        Valeur = x * 10 + (y + 1)
                    };
                        
                }
            }*/
        }

        //Commentaire
        public Cellule GetCellule(int posX, int posY)
        {
            if (Enumerable.Range(0, 9).Contains(posX) && Enumerable.Range(0, 9).Contains(posY))
            {
                return TabCellules[posX][posY];
            }
            return null;
        }

        public Cellule[][] GetGrille()
        {
            return TabCellules;
        }

        public bool InitGrille(Cellule[][] valeurs)
        {
            try
            {
                TabCellules = valeurs;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void RestaurerGrille()
        {
            for (int ligne = 0; ligne < TabCellules.Length; ligne++)
            {
                for (int colonne = 0; colonne < TabCellules[ligne].Length; colonne++)
                {
                    TabCellules[ligne][colonne].EstTrouve = false;
                    if (TabCellules[ligne][colonne].EstValeurInitiale == false) {
                        TabCellules[ligne][colonne].Valeur = 0;
                    }
                }
            }
        }

        public Cellule ResoudreCellule(int posX, int posY)
        {
            Cellule maCellule; 
            Region regionCellule;
            if (PositionXYEstValide(posX, posY))
            {
                if (!TabCellules[posX][posY].EstValeurInitiale && !TabCellules[posX][posY].EstTrouve)
                {
                    regionCellule = GetRegion(posX, posY);
                    if (regionCellule != null)
                    {
                        maCellule = GetCellule(posX, posY);
                        //Console.WriteLine($"X : {posX+1} - Y : {posY+1}");
                        //Console.WriteLine(maCellule.ToString());
                        List<int> valeurs = new List<int>();
                        valeurs.AddRange(regionCellule.RecupererValeurs());
                        valeurs.AddRange(RecupererValeursLigne(posX, posY));
                        valeurs.AddRange(RecupererValeursColonne(posX, posY));
                        maCellule.Maj(valeurs);
                        if (maCellule.EstTrouve)
                        {
                            Console.WriteLine($"Ligne : {posX+1} - Colonne : {posY+1}");
                            Console.WriteLine(maCellule.ToString());
                            Console.WriteLine(Environment.NewLine);
                        }
                        else
                        {
                            int? testComparaison = regionCellule.ComparaisonValeurs(maCellule.Propositions);
                            if (testComparaison != null)
                            {
                                maCellule.EstTrouve = true;
                                maCellule.Valeur = (int)testComparaison;
                                maCellule.Propositions = new List<int> { (int)testComparaison };
                            }
                        }
                        return maCellule;
                    }
                }
            }
            return null;
        }

        public Cellule[][] ResoudreGrille()
        {       
            for (int ligne = 0; ligne < TabCellules.Length; ligne++)
            {
                for (int colonne = 0; colonne < TabCellules[ligne].Length; colonne++)
                {
                    if (!TabCellules[ligne][colonne].EstValeurInitiale && !TabCellules[ligne][colonne].EstTrouve)
                    {
                        ResoudreCellule(ligne, colonne);
                        if (TabCellules[ligne][colonne].EstTrouve)
                            TabCellules = ResoudreGrille();
                    }
                }
            }
            return TabCellules;
        }

        public bool SetCellule(int posX, int posY, int valeur)
        {
            if (PositionXYEstValide(posX, posY))
            {
                if (TabCellules[posX][posY].EstValeurInitiale == false && Enumerable.Range(1, 9).Contains(valeur))
                {
                    TabCellules[posX][posY].Valeur = valeur;
                    // EstTrouve à gérer ?
                    return true;
                }
            }
            return false;   
        }

        private bool PositionXYEstValide(int posX, int posY)
        {
            return (Enumerable.Range(0, TabCellules.Length).Contains(posX) && Enumerable.Range(0, TabCellules[posX].Length).Contains(posY));
        }

        private Region GetRegion(int posX, int posY)
        {
            if (PositionXYEstValide(posX, posY))
            {
                int? numRegion = GetNumRegion(posX, posY);
                if (numRegion != null)
                {
                    Region maRegion = new Region();
                    maRegion.Indice = (int)numRegion;
                    maRegion.Cellules = GetCelluleDeRegion((int)numRegion);
                    return maRegion;
                }
                else
                    return null;
            }
            return null;
        }

        private int? GetNumRegion(int posX, int posY)
        {
            if (PositionXYEstValide(posX, posY))
            {
                return (int)(Math.Floor(posX/3.0)+1) + (int)(Math.Floor(posY/3.0))*3 - 1;
            }
            return null;
        }

        private Cellule[][] GetCelluleDeRegion(int indiceRegion)
        {
            Cellule[][] mesCellules = new Cellule[9][];
            int posXMini, posXMaxi, posYMini, posYMaxi;

            posXMini = (indiceRegion % 3) * 3;
            posXMaxi = posXMini + 2;

            posYMini = (int)(Math.Floor(indiceRegion / 3.0)) * 3;
            posYMaxi = posYMini + 2;

           //int xCompteur = 0;
            for (int ligne = posXMini; ligne <= posXMaxi; ligne++)
            {
                mesCellules[ligne] = new Cellule[9];
                    //int yCompteur = 0;
                for (int colonne = posYMini; colonne <= posYMaxi; colonne++)
                {
                    mesCellules[ligne][colonne] = TabCellules[ligne][colonne];
                }
                //xCompteur++;
            }
            return mesCellules;
        }

        private List<int> RecupererValeursLigne(int posX, int posY)
        {
            List<int> valeurs = new List<int>();
            for (int x = 0; x < TabCellules.Length; x++)
            {
                if (x != posX && TabCellules[x][posY].Valeur != 0)
                    valeurs.Add(TabCellules[x][posY].Valeur);
            }
            return valeurs;
        }

        private List<int> RecupererValeursColonne(int posX, int posY)
        {
            List<int> valeurs = new List<int>();
            for (int y = 0; y < TabCellules[posX].Length; y++)
            {
                if (y != posY && TabCellules[posX][y].Valeur != 0)
                    valeurs.Add(TabCellules[posX][y].Valeur);
            }
            return valeurs;
        }

        public void ViderGrille()
        {
            for (int ligne = 0; ligne < TabCellules.Length; ligne++)
            {
                for (int colonne = 0; colonne < TabCellules[ligne].Length; colonne++)
                {
                    TabCellules[ligne][colonne].Valeur = 0;
                    TabCellules[ligne][colonne].EstValeurInitiale = false;
                    TabCellules[ligne][colonne].EstTrouve = false;
                }
            }
        }
    }
}
