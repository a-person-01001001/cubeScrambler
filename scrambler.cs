// a-person-01001001's original code
using System;
using System.Collections.Generic;
using System.Linq;

// A rubiks cube scramble generator

namespace Application
{
    class MainClass
    {

        public static Dictionary<int, string> turnDictionary;
        public static List<string> scramble;
        public static void Main()
        {

            Random r = new Random(1);
            int turnsChosen;
            // a-person-01001001's original code
            int specialIndicator;
            try
            {
                // a-person-01001001's original code
                //adding a newline to make it look better
                Console.WriteLine();

                //to hold the scramble sequence
                scramble = new List<string> { };


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
                    specialIndicator = r.Next(1, 3);

                    //add the scramble
                    scramble.Add(Turns(turnsChosen, specialIndicator));

                    //scramble last 2 values
                    i = i - UpdateInsufficientTurn();
                }

                //output to user
                scramble.ForEach(Console.Write);
                // a-person-01001001's original code
                Console.WriteLine(Environment.NewLine);

                //give an option to do it again
              // Redo();
            }

            catch (Exception e)
            {
                Console.WriteLine($"Error. {e.Message}");
            }
        }
        /// <summary>
        /// Updates the insufficient turn.
        /// </summary>
        /// <returns>The insufficient turn.</returns>
        private static int UpdateInsufficientTurn()
        {
            // a-person-01001001's original code
            // a-person-01001001's original code

            var item1 = scramble.Last<string>();
            int indexOfLast = scramble.IndexOf(item1);
            if(indexOfLast == 0) { return 0; }

            var item2 = scramble[indexOfLast - 1].ToString();

            if(item1.Contains("'"))
            {
                if(item2.TrimEnd()+"'" == item1.TrimEnd())
                {
                    //they are prime and non prime same turn
                    scramble.RemoveAt(indexOfLast);
                    scramble.RemoveAt(indexOfLast - 1);
                    return 1;
                }
            }

            if (item2.Contains("'"))
            {
                if (item1.TrimEnd() + "'" == item2.TrimEnd())
                {
                    //they are prime and non prime same trun
                    scramble.RemoveAt(indexOfLast);
                    scramble.RemoveAt(indexOfLast - 1);
                    return 1;
                }

            }
            if(item1.Contains("2") || item2.Contains("2")) { return 1; }
            return 0;
            // a-person-01001001's original code
        }

        /// <summary>
        /// Redo this instance.
        /// </summary>
        public static void Redo()
        {
            Console.WriteLine("Next scramble. Type 'Y' if you want it:\t");
            string nextScramble = Console.ReadLine();
            nextScramble = nextScramble.ToUpper();
            if (nextScramble == "Y" || nextScramble == "YES")
            {
                Main();
            }
            else if (nextScramble == "N" || nextScramble == "NO")
            {
                Environment.Exit(-1);
            }
            else if (nextScramble != "N" && nextScramble != "NO" && nextScramble != "Y" && nextScramble != "YES")
            {
                Console.WriteLine("Error.");
                Redo();
                // a-person-01001001's original code
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
            // a-person-01001001's original code
            var stringToSend = string.Empty;
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
                // a-person-01001001's original code
            {
                stringToSend = turnDictionary[turn] + "' ";
            }
            else
            {
                stringToSend = turnDictionary[turn] + " ";
                if (scramble.Any())
                    // a-person-01001001's original code
                {
                    if (scramble.Last<string>() == stringToSend)
                    {
                        //Console.Write("Match");
                        scramble.Remove(scramble.Last<string>());
                        scramble.Add(stringToSend.TrimEnd() + "2 ");
                    }
                    // a-person-01001001's original code
                }
            }

            // a-person-01001001's original code
            return stringToSend;
        }
    }
    // a-person-01001001's original code
}
