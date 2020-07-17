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
            for (int x = 0; x < Cellules.Length; x++)
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

        internal List<List<int>> RecupererAutresPropositionDeLaRegion(Cellule[][] autresCellulesDelaRegion)
        {
            List <List<int>> autresPropositionDeLaRegion = new List<List<int>>();

            for (int x = 0; x < autresCellulesDelaRegion.Length; x++)
            {
                if (autresCellulesDelaRegion[x] != null)
                {
                    for (int y = 0; y < autresCellulesDelaRegion[x].Length; y++)
                    {
                        if (autresCellulesDelaRegion[x][y] != null)//&& x != posX && y != posY)
                            if(autresCellulesDelaRegion[x][y].Propositions.Count != 0)
                                autresPropositionDeLaRegion.Add(autresCellulesDelaRegion[x][y].Propositions);
                            //if (Cellules[x][y].Propositions != 0)
                                //valeurs.Add(Cellules[x][y].Valeur);
                    }
                }
            }
            return autresPropositionDeLaRegion;
        }

        /*internal int? ComparaisonValeurs(List<int> propositions)
        {
            List <List<int>> valeurs = new List<List<int>>();
            for (int x = 0; x < Cellules.Length; x++)
            {
                if (Cellules[x] != null)
                {
                    for (int y = 0; y < Cellules[x].Length; y++)
                    {
                        if (Cellules[x][y] != null)
                            if (Cellules[x][y].Propositions.Count >1)
                                valeurs.Add(Cellules[x][y].Propositions);
                    }
                }
            }

            bool estTrouve;
            for(int compteur = 0; compteur < valeurs.Count; compteur++)
            {
                foreach(int valeur in valeurs[compteur])
                {
                    estTrouve = false;
                    int comparer = 0;
                    while (comparer < valeurs.Count && !estTrouve)
                    {
                        if(comparer != compteur)
                        {
                            if (propositions.Contains(valeur) && valeurs[comparer].Contains(valeur))
                                estTrouve = true;
                        }
                        comparer++;
                    }
                    if (estTrouve)
                        return valeur;
                }
            }
            return null;

        }
       */
    }
}
