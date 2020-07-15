using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku
{
    public class Cellule
    {
        public int Valeur { get; set; }
        public bool EstTrouve { get; set; }
        public bool EstValeurInitiale { get; set; }
    }
}
