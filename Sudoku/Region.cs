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

        internal List<int> RecupererValeurs()
        {
            List<int> valeurs = new List<int>();
            for(int x = 0; x < Cellules.Length; x++)
            {
                if (Cellules[x] != null)
                {
                    for (int y = 0; y < Cellules[x].Length; y++)
                    {
                        if (Cellules[x][y] != null)
                            if (Cellules[x][y].Valeur != 0)
                                valeurs.Add(Cellules[x][y].Valeur);
                    }
                }
            }
            return valeurs;
        }
    }
}
