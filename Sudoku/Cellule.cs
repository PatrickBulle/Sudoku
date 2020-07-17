using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku
{
    public class Cellule
    {
        public int Valeur { get; set; }
        public bool EstTrouve { get; set; }
        public bool EstValeurInitiale { get; set; }
        public List<int> Propositions { get; set; }

        public Cellule()
        {
            EstTrouve = false;
            EstValeurInitiale = false;
            Propositions = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        }

        public Cellule(int valeur)
        {
            Valeur = valeur;
            if (valeur != 0)
            {
                EstTrouve = true;
                EstValeurInitiale = true;
                Propositions = new List<int>();
            }
            else
            {
                Propositions = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            }
        }


        public override string ToString()
        {
            return $"Valeur : {Valeur} - Initiale : {EstValeurInitiale} - Trouve : {EstTrouve}- Propositions : {string.Join(",", Propositions)}";
        }

        internal void Maj(List<int> valeurs)
        {
            MajPossibilites(valeurs);
            if (Propositions.Count() == 1)
            {
                EstTrouve = true;
                Valeur = Propositions[0];
                Propositions = new List<int>();
            }
        }

        internal void MajPossibilites(List<int> valeurs)
        {
            foreach (int valeur in valeurs)
            {
                int index = Propositions.FindIndex(x => x .Equals(valeur));
                if (index >= 0)
                    Propositions.RemoveAt(index);
            }
        }

        internal int? ComparaisonValeurs(List<List<int>> propositionsAutresCellulesDeRegion)
        {
            bool estTrouve;
            if (propositionsAutresCellulesDeRegion.Count > 0)
            {
                foreach (int proposition in Propositions)
                {
                    estTrouve = false;
                    int numListe = 0;
                    while (numListe < propositionsAutresCellulesDeRegion.Count && !estTrouve)
                    {
                        if (propositionsAutresCellulesDeRegion[numListe].Contains(proposition))
                            estTrouve = true;
                        numListe++;
                    }
                    if (!estTrouve)
                        return proposition;
                }
            }
            return null;


            /*
            for (int compteur = 0; compteur < valeurs.Count; compteur++)
            {
                foreach (int valeur in valeurs[compteur])
                {
                    estTrouve = false;
                    int comparer = 0;
                    while (comparer < valeurs.Count && !estTrouve)
                    {
                        if (comparer != compteur)
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
            */
            //return null;

        }
       
    }
}
