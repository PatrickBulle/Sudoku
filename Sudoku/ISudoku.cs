using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku
{
    public interface ISudoku
    {
        /// <summary>
        /// Retourne la grille avec les valeurs initiales et les valeurs renseignées par après
        /// </summary>
        /// <returns>Retourne un tableau à deux dimensions de Cellules</returns>
        Cellule[][] GetGrille();

        /// <summary>
        /// Retourne la valeur d'une cellule aux coordonnées passés en paramètres
        /// </summary>
        /// <param name="posX">Position X</param>
        /// <param name="posY">Position Y</param>
        /// <returns>Retourne une cellule</returns>
        Cellule GetCellule(int posX, int posY);

        /// <summary>
        /// Positionne la valeur d'une cellule aux coordonnées passés en paramètres
        /// </summary>
        /// <param name="posX">Position X</param>
        /// <param name="posY">Position Y</param>
        /// <param name="valeur"></param>
        /// <returns>Retourne vrai si la valeur est plausible, faux dans les autres cas</returns>
        bool SetCellule(int posX, int posY, int valeur);

        /// <summary>
        /// Initialise la grille
        /// </summary>
        /// <returns>Retourne vrai si la grille est valide, faux dans les autres cas</returns>
        bool InitGrille(Cellule[][] valeurs);

        /// <summary>
        /// Restaurer la grille
        /// </summary>
        /// <returns>Restaure les valeurs initiales d'une grille</returns>
        public void RestaurerGrille();


        /// <summary>
        /// Vider la grille
        /// </summary>
        /// <returns>Vide toutes les cellules d'une grille</returns>
        public void ViderGrille();

        /// <summary>
        /// Lance la résolution de la cellule
        /// </summary>
        /// <param name="posX">Position X</param>
        /// <param name="posX">Position Y</param>
        /// <returns>Retourne une cellule si elle est résolue, null dans le cas contraire</returns>
        Cellule ResoudreCellule(int posX, int posY);

        /// <summary>
        /// Lance la résolution de la grille
        /// </summary>
        /// <returns>Retourne la grille si elle est résolue, null dans le cas contraire</returns>
        Cellule[][] ResoudreGrille(bool parEtape = false);
    }
}
