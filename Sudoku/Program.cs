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

            monSudoku.ResoudreGrille();
        }
    }
}
