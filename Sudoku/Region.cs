using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku
{
    public class Region
    {
        /// <summary>
        /// Position de la région dans la grille de 0 à 8
        /// </summary>
        public int Indice { get; set; }
        public Cellule[][] Cellules { get; set; }
    }
}
