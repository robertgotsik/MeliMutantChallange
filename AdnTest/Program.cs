using System;
using System.Collections.Generic;

namespace AdnTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] adnTest = { "AAGCGA", "CACCTA", "TGATGT", "AGAAGG", "CGGTGC", "TGACTG" };

            Console.WriteLine(isMutant(adnTest));
            Console.ReadKey();
        }
        public static bool isMutant(string[] dna)
        {
            if (allowedLetters(dna))
            {
                //if (
                //checkRight(dna) || 
                //checkBottom(dna); 
                //checkOblique(dna);
                checkReverseOblique(dna);
                //    ) { return true; }
                //else 
                return true;

            }
            else return false;
        }

        public static bool allowedLetters(string[] dna)
        {
            char[] allowed = { 'B', 'D', 'E', 'F', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'Ñ', 'O', 'P', 'Q', 'R', 'S', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            int letter = 0;

            for (int i = 0; i < dna.Length; i++)
            {
                for (int b = 0; b < allowed.Length; b++)
                {
                    if (dna[i].ToUpper().Contains(allowed[letter]))
                    { return false; }
                    else
                    { letter++; }
                }
                letter = 0;
            }
            return true;
        }

        public static bool checkRight(string[] dna)
        {
            /*char firstLetter, secondLetter, thirdLetter, fourthLetter, fifthLetter, sixthLetter; (dna[i])[0];*/

            for (int i = 0; i < dna.Length; i++)
            {
                int letterPosition = 0, letterAproach = 1;

                for (int b = 1; b < dna[i].Length; b++)
                {
                    if ((dna[i][letterPosition] == dna[i][b]) )
                    {
                        letterPosition++;
                        letterAproach++;
                        if (letterAproach == 4) { return true; }
                    }
                    else 
                    {
                        if(letterAproach > 1) { letterAproach = 1; }
                        letterPosition++;
                        continue;
                    }
                }
            }
            return false;
        }

        public static void checkBottom(string[] dna)
        {
            List<string> reorder = new List<string>();
            int letterPosition = 0;

            while (6 > reorder.Count)
            {
                string newString = "";

                for (int i = 0; i < dna.Length; i++)
                {
                    for (int b = letterPosition; b < letterPosition + 1; b++)
                    {
                        newString = newString + dna[i][b];
                    }
                }
                
                reorder.Add(newString);
                letterPosition++;
            }
            /*Conversion de la lista a array para utilizar la funcion checkRight()*/
            string[] array = reorder.ConvertAll(x => x.ToString()).ToArray();
            checkRight(array);
        }

        public static void checkOblique(string[] dna)
        {
            List<string> reorder = new List<string>();
            int letterPosition = 0;

            while (1 > reorder.Count)
            {
                string newString = "";

                for (int i = 0; i < dna.Length; i++)
                {
                    for (int b = letterPosition; b < letterPosition + 1; b++)
                    {
                        newString = newString + dna[i][b];
                    }
                    letterPosition++;
                }
                reorder.Add(newString);
            }
            /*Conversion de la lista a array para utilizar la funcion checkRight()*/
            string[] array = reorder.ConvertAll(x => x.ToString()).ToArray();
            checkRight(array);
        }

        public static void checkReverseOblique(string[] dna)
        {
            List<string> reorder = new List<string>();
            int letterPosition = 5;

            while (1 > reorder.Count)
            {
                string newString = "";

                for (int i = 5; i > -1; i--)
                {
                    for (int b = letterPosition; b > letterPosition - 1; b--)
                    {
                        newString = newString + dna[i][b];
                    }
                    letterPosition--;
                }
                reorder.Add(newString);
            }
            /*Conversion de la lista a array para utilizar la funcion checkRight()*/
            string[] array = reorder.ConvertAll(x => x.ToString()).ToArray();
            checkRight(array);
        }
    }
}
