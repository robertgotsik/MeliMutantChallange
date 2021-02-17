using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeliMutantChallange.Models
{
    public class Adn
    {
        public int Id { get; set; }
        
        [NotMapped]
        public string[] dna { get; set; }
        public string dnaPersisted { get; set; }
        public short? type { get; set; }


        public static bool isMutant(string[] dna)
        {
            if (checkLeftToRight(dna) || checkLeftBottomToTop(dna) || checkObliqueTopToRight(dna) || checkObliqueBottomToTop(dna) || checkObliqueLeftBottomToRight(dna)) 
                return true; 
            else return false;
        }
        public static bool isValid(string[] dna)
        {
            if (calculateLenght(dna) && allowedLetters(dna)) return true;
            else return false;
        }

        //Verifico si el largo es NxN
        public static bool calculateLenght(string[] dna)
        {
            for (int i = 0; i < dna.Length; i++)
            {
                for (int j = 0; j < dna[i].Length; j++)
                {
                    if (dna[i].Length == dna[j].Length)
                    {
                        continue;
                    }
                    else return false;
                }
            }
            return true;
        }

        //Verifico si la cadena esta compuesta por las letras permitidas
        public static bool allowedLetters(string[] dna)
        {
            List<string> allowed = new List<string>() { "A", "C", "T", "G" };

            for (int i = 0; i < dna.Length; i++)
            {
                var current = dna[i];
                var validLetters =  current.ToList().All(x => allowed.Contains(x.ToString()));

                if (!validLetters) return false;
            }
            return true;
        }

        public static bool checkLeftToRight(string[] dna)
        {
            for (int i = 0; i < dna.Length; i++)
            {
                int letterPosition = 0, letterAproach = 1;

                for (int b = 1; b < dna[i].Length; b++)
                {
                    if ((dna[i][letterPosition] == dna[i][b]))
                    {
                        letterPosition++;
                        letterAproach++;
                        if (letterAproach == 4) { return true; }
                    }
                    else
                    {
                        if (letterAproach > 1) { letterAproach = 1; }
                        letterPosition++;
                        continue;
                    }
                }
            }
            return false;
        }

        public static bool checkLeftBottomToTop(string[] dna)
        {
            List<string> reorder = new List<string>();
            int letterPosition = 0;
            int arrayLenght = dna.Length;

            while (arrayLenght > reorder.Count)
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
            if (checkLeftToRight(array)) return true;
            else return false;
        }

        public static bool checkObliqueTopToRight(string[] dna)
        {
            List<string> reorder = new List<string>();
            int letterPosition = 0;
            int letterHorizontalPosition = 0;
            int arrayLenght = dna.Length;
            int lettersLeft = dna.Length;

            //No loopeo si mi posicion va a ser inferior a los ultimo 4 casilleros.
            for (int j = 0; (arrayLenght - 3) > j; j++)
            {
                while (1 > reorder.Count)
                {
                    string newString = "";

                    for (int i = 0; i < lettersLeft; i++)
                    {
                        for (int b = letterPosition; b < letterPosition + 1; b++)
                        {
                            newString = newString + dna[i][b];
                        }
                        letterPosition++;
                    }
                    reorder.Add(newString);
                    lettersLeft--;
                }
                letterHorizontalPosition++;
                /*Conversion de la lista a array para utilizar la funcion checkRight()*/
                string[] array = reorder.ConvertAll(x => x.ToString()).ToArray();
                if (checkLeftToRight(array)) return true;
                else
                {
                    letterPosition = letterHorizontalPosition;
                    reorder.Clear();
                }
            }
            return false;
        }

        public static bool checkObliqueBottomToTop(string[] dna)
        {
            List<string> reorder = new List<string>();
            int letterPosition = 0;
            int letterVerticalPosition = 0;
            int arrayLenght = dna.Length;
            int arrayPosition = dna.Length -1;

            for (int j = 0; (arrayLenght - 3) > j; j++)
            {
                while (1 > reorder.Count)
                {
                    string newString = "";

                    for (int i = (arrayPosition); i > -1; i--)
                    {
                        for (int b = letterPosition; b < letterPosition +1; b++)
                        {
                            newString = newString + dna[i][b];
                        }
                        letterPosition++;
                    }
                    reorder.Add(newString);
                    arrayPosition--;
                }
                letterVerticalPosition = 0;
                /*Conversion de la lista a array para utilizar la funcion checkRight()*/
                string[] array = reorder.ConvertAll(x => x.ToString()).ToArray();
                if (checkLeftToRight(array)) return true;
                else
                {
                    letterPosition = letterVerticalPosition;
                    reorder.Clear();
                }
            }
            return false;
        }

        public static bool checkObliqueLeftBottomToRight(string[] dna)
        {
            List<string> reorder = new List<string>();
            int letterPosition = 1;
            int letterVerticalPosition = 1;
            int arrayLenght = dna.Length;
            int arrayPosition = dna.Length - 1;

            for (int j = 0; (arrayLenght - 4) > j; j++)
            {
                while (1 > reorder.Count)
                {
                    string newString = "";

                    for (int i = (arrayPosition); i > 1; i--)
                    {
                        for (int b = letterPosition; b < letterPosition + 1; b++)
                        {
                            newString = newString + dna[i][b];
                        }
                        letterPosition++;
                    }
                    reorder.Add(newString);
                }
                letterVerticalPosition++;
                /*Conversion de la lista a array para utilizar la funcion checkRight()*/
                string[] array = reorder.ConvertAll(x => x.ToString()).ToArray();
                if (checkLeftToRight(array)) return true;
                else
                {
                    letterPosition = letterVerticalPosition;
                    reorder.Clear();
                }
            }
            return false;
        }
    }
}
