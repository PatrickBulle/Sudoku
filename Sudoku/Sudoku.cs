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
            for(int x = 0; x <= 8; x++)
            {
                TabCellules[x] = new Cellule[9];
                for (int y = 0; y <= 8; y++)
                {
                    TabCellules[x][y] = new Cellule
                    {
                        EstTrouve = false,
                        EstValeurInitiale = true,
                        Valeur = x * 10 + (y + 1)
                    };
                        
                }
            }
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
            catch (Exception e)
            {
                return false;
            }
        }

        public void RestaurerGrille()
        {
            for (int ligne = 0; ligne < TabCellules.GetLength(0); ligne++)
            {
                for (int colonne = 0; colonne < TabCellules.GetLength(1); colonne++)
                {
                    if (TabCellules[ligne][colonne].EstValeurInitiale == false)
                        TabCellules[ligne][colonne].Valeur = 0;
                }
            }
        }

        public Cellule ResoudreCellule(int posX, int posY)
        {
            throw new NotImplementedException();
        }

        public Cellule[][] ResoudreGrille()
        {
            throw new NotImplementedException();
        }

        public bool SetCellule(int posX, int posY, int valeur)
        {
            if (Enumerable.Range(0, 9).Contains(posX) && Enumerable.Range(0, 9).Contains(posY))
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

        public void ViderGrille()
        {
            throw new NotImplementedException();
        }
    }
}
