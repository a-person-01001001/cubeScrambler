using System;
using System.Collections.Generic;
using System.Linq;

// A rubiks cube scramble generator

namespace Application
{
    class MainClass
    {

        public static Dictionary<int, string> turnDictionary;

        public static void Main()
        {

            Random r = new Random(1);
            int turnsChosen;
            int specialIndicator;
            try
            {
                //adding a newline to make it look better
                Console.WriteLine();

                //to hold the scramble sequence
                var scramble = new List<string> {};


                //message to user
                Console.WriteLine("Scramble Length:\t");

                //reading input from user
                int length = Convert.ToInt32(Console.ReadLine());

                //depending on user input we will go through each one of them
                for (int i = 0; i <= length; i++)
                {
                    //randomly chooose a turn
                    turnsChosen = r.Next(1, 7); 

                    //randomly choose if it is anti-clockwise (prime) or not, or a double move
                    specialIndicator = r.Next(1, 4);

                    //add the scramble
                    scramble.Add(Turns(turnsChosen, specialIndicator));

                }

                //output to user
                scramble.ForEach(Console.Write);
                Console.WriteLine(Environment.NewLine);

                //give an option to do it again
                Redo();
            }

            catch (Exception)
            {
                Console.WriteLine($"Error.");
            }
        }

        /// <summary>
        /// Redo this instance.
        /// </summary>
        public static void Redo()
        {
            Console.WriteLine("Next scramble. Type 'Y' if you want it:\t");
            string nextScramble = Console.ReadLine();
            nextScramble = nextScramble.ToUpper();
            if(nextScramble == "Y" || nextScramble == "YES")
            {
                Main();
            }
            else if(nextScramble == "N" || nextScramble == "NO")
            {
                Environment.Exit(-1);
            }
            else if(nextScramble != "N" && nextScramble != "NO" && nextScramble != "Y" && nextScramble != "YES")
            {
                Console.WriteLine("Error.");
                Redo();
            }
        }

        /// <summary>
        /// Turns the specified turn and prime.
        /// </summary>
        /// <returns>The turns.</returns>
        /// <param name="turn">Turn.</param>
        /// <param name="prime">Prime.</param>
        // my dad helped with this part. Hes much more advanced than me :P
        private static string Turns(int turn, int prime)
        {
            turnDictionary = new Dictionary<int, string>
            {
                { 1, "F" },
                { 2, "R" },
                { 3, "U" },
                { 4, "L" },
                { 5, "D" },
                { 6, "B" }
            };

            //if it is 2, it indicates it is prime
            if (prime == 2)
            {
                return turnDictionary[turn]+"' ";
            }
            else if (prime == 3)
            {
                return turnDictionary[turn] + "2 ";
            }
            return turnDictionary[turn] + " ";
        }
    }
} 
