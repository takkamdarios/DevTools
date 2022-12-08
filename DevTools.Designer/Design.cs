using System;
using System.Collections.Generic;

namespace DevTools.Designer
{
    public static partial class Design
    {

        // assemblage de tte les methodes pour effectuer le design
        public static void Show<T>(T entity)
        {
            IEnumerable<T> list = new List<T>{ entity};

            Show(GetMultiDimArrayFrom<T>(list));
        }

        // assemblage de tte les methodes pour effectuer le design
        public static void Show(string[,] tab)
        {
            int rowSize = tab.GetLength(0);

            int[] maxWords = MaxWords(tab);

            Console.WriteLine("\n\n\n\n");
            for (int i = 0; i < rowSize; i++)
            {
                DesignLine(maxWords);
                string[] lineWords = GetLineWords(tab, i);
                DesignLine(maxWords, lineWords);
            }
            DesignLine(maxWords);
        }

        // design en pointille fait avec '-' et '+'
        private static void DesignLine(int[] maxWords)
        {
            string line = "";
            foreach (int i in maxWords)
            {
                line += "+";
                for (int j = 0; j < i + 2; j++)
                    line += "-";
            }
            line += "+";

            Console.WriteLine("             " + line);
        }

        // design par ligne, caractere + espace 
        private static void DesignLine(int[] maxWords, string[] lineWords)
        {
            string line = "";
            string space = "";
            int index = -1;
            foreach (string i in lineWords)
            {
                index++;
                int leftSpace = (maxWords[index] - i.Length) / 2;
                int rightSpace = maxWords[index] - i.Length - leftSpace;

                for (int j = 0; j < rightSpace + 1; j++)
                    space += " ";
                // PadLeft complete le mot avec des espace a gauche, afin d'atteindre la taille specifier en param
                line += "| " + i.PadLeft(i.Length + leftSpace, ' ') + space;
                // reinitialisation d la variable d'espacement a droite
                space = "";
            }
            line += "|";
            Console.WriteLine("             " + line);
        }

        // calcul la taille du caractere le plus long de chaque colone du tableau
        private static int[] MaxWords(string[,] tab)
        {
            int index = -1;
            // nombre de ligne du tableau multidimentionnelle
            int rowSize = tab.GetLength(0);
            // nombre de column du tableau multidimentionnelle
            int columnSize = tab.GetLength(1);

            int[] maxLenghts = new int[columnSize];
            int max = 0;

            for (int i = 0; i < columnSize; i++)
            {
                for (int j = 0; j < rowSize; j++)
                {
                    max = (tab[j, i].Length < max) ? max : tab[j, i].Length;
                }
                index++;
                maxLenghts[index] = max;
                max = 0;
            }
            return maxLenghts;
        }

        // renvoi un tableau contenant les mots des differentes colone d'une ligne
        private static string[] GetLineWords(string[,] tab, int line)
        {
            int columnSize = tab.GetLength(1);
            int index = -1;
            string[] lineWords = new string[columnSize];

            for (int i = 0; i < columnSize; i++)
            {
                index++;
                lineWords[index] = tab[line, i];
            }
            return lineWords;
        }
    }
}
