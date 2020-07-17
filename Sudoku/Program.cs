using System;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Résolveur de Sudoku");
            Console.WriteLine(Environment.NewLine);
            ISudoku monSudoku = new Sudoku();

            /*Cellule maCellule = monSudoku.GetCellule(8, 8);
            if (maCellule != null)
            {
                Console.WriteLine(maCellule.ToString());
            }
            else
            {
                Console.WriteLine("Cellule null");
            }
            if (monSudoku.SetCellule(8, 8, 9))
             { 
                 Console.WriteLine(maCellule.ToString());
             }*/
            //monSudoku.ResoudreCellule(0, 0);
            monSudoku.ResoudreGrille();
        }
    }
}
