using Sudoku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace SudokuSolver.Models
{
    public class SudokuTest : ISudoku
    {
        public Cellule GetCellule(int posX, int posY)
        {
            throw new NotImplementedException();
        }

        public Cellule[][] GetGrille()
        {
            throw new NotImplementedException();
        }

        public bool InitGrille(Cellule[][] valeurs)
        {
            return true;
        }

        public void RestaurerGrille()
        {

        }
        public void ViderGrille()
        {

        }

        public Cellule ResoudreCellule(int posX, int posY)
        {
            Cellule maCellule = new Cellule()
            {
                Valeur = 8,
                EstTrouve = true,
                EstValeurInitiale = false
            };
            return maCellule;
        }

        public Cellule[][] ResoudreGrille()
        {
            Cellule[][] mesCellules = new Cellule[9][];
            for(int row = 0; row < 9; row++)
            {
                mesCellules[row] = new Cellule[9];
                for (int column = 0; column < 9; column++)
                {
                    mesCellules[row][column] = new Cellule()
                    {
                        Valeur = (1 + new Random().Next(8)),
                        EstTrouve = true,
                        EstValeurInitiale = false
                        
                    };

                }
            }
            return mesCellules;
        }

        public bool SetCellule(int posX, int posY, int valeur)
        {
            return true;
        }
    }
}
