using System;

namespace Assignment1_Spring2020
    /*n Self Reflection: 
     * I thought the assignment was quite challenging that used programming skills and creativity to solve each question. 
     * I liked that an example program.cs was provided which had a clean layout to insert code for each question. 
     * Each question was unique on its own and there wasn't much overlap between them.
     * The Palindrome problem was interesting and was the most difficult for me to think about. The question
     * took me the longest to work on and I was lucky to found a .reverse array function otherwise I would have 
     * had to code something similar to the reverse function manually. This would have added additional work.
     * Looking back on it, I feel like there is better way to code the answer for question 4, instead of stating
     * each case. I also feel the same for question 6. I was able to get a solution if the game had 5 turns or less. I
     * was not able to figure out how to have the whole program loop through additional loops if required. So my code below
     * could not answer a higher number of n stones like n=14 (I did not want to write additional loops). Although I know as
     * n increases, the number of solutions would grow faster. I enjoyed trying to solve question 3 as I learned how to convert
     * dates to strings. 
    */
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1
            int n = 5;
            PrintPattern(n);

            //Question 2
            Console.WriteLine();
            int n2 = 6;
            PrintSeries(n2);

            //Question 3
            Console.WriteLine();
            string s = "09:15:35PM";
            string t = UsfTime(s);
            Console.WriteLine(t);

            //Question 4
            int n3 = 110;
            int k = 11;
            UsfNumbers(n3, k);

            //Question 5
            Console.WriteLine();
            string[] words = new string[] { "abcd", "dcba", "lls", "s", "sssll" };
            PalindromePairs(words);
            Console.WriteLine();

            //Question 6
            Console.WriteLine();
            int n4 = 5;
            Stones(n4);
        }


        private static void PrintPattern(int n) // Question 1
        {
            try
            {
                int i = n; //Declare starting integer for number of total rows
                while (i > 0) //loop for adding rows
                {
                    Console.WriteLine();
                    int j = i; //Declare starting integer for descending numbers
                    while (j > 0) //loop for descending numbers in a single row
                    {
                        Console.Write(j); //print number 
                        j--;
                    } // end 2nd loop

                    i--;
                } // end 1st loop

            }
            catch
            {
                Console.WriteLine("Exception Occured while computing printPattern");
            }
        }


        private static void PrintSeries(int n2)
        {
            try
            {
                int j = 0;
                int x = 0;
                Console.WriteLine();
                for (j = 1; j <= n2 ; j++) // loop through n2 number of times
                {
                    x = j + x; //adding on to variable through each interation
                    
                    if (j < n2) //if statement to have no commas at end of print
                    {
                        Console.Write(x + ","); //print variable through each iteration
                    }
                    else
                    {
                        Console.Write(x);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception Occured while computing printSeries");
            }
        }


        public static string UsfTime(string s)
        {
            try
            {
                Console.WriteLine();
                //Read in Earth Time to hours, minutes, seconds, and am or pm
                int hours = Convert.ToInt32(s.Substring(0, 2));
                int minutes = Convert.ToInt32(s.Substring(3, 2));
                int seconds = Convert.ToInt32(s.Substring(6, 2));
                string ampm = s.Substring(8, 2);
                
                //Convert AM/PM to military time by increasing hours by 12 if PM
                if (ampm == "PM")
                {
                    hours = hours + 12;
                }

                //Derive the total number of seconds
                int total = hours * 3600 + minutes * 60 + seconds;

                //Convert to other USF time
                int U = total / (60 * 45);
                int S = (total % (60 * 45)) / 45;
                int F = (total % (60 * 45)) % 45;

                //Format to string output
                string output = U + ":" + S + ":" + F;
                return output;
            }
            catch
            {
                Console.WriteLine("Exception Occured while computing UsfTime");
            }
            return null;
        }


        public static void UsfNumbers(int n3, int k)
        {
            try
            {
                Console.WriteLine();
                // Loop through n3
                int i = 1;
                while (i <= n3)
                {
                    //if a number if divisible by 3,5 and 7 print USF instead of number
                    if (i % 3 == 0 && i % 5 == 0 && i % 7 == 0)

                    {
                        Console.Write("USF ");
                    }

                    //if a number if divisible by 3 and 5 print US instead of number
                    else if (i % 3 == 0 && i % 5 == 0)

                    {
                        Console.Write("US ");
                    }

                    //if a number if divisible by 5 and 7 print SF instead of number
                    else if (i % 5 == 0 && i % 7 == 0)

                    {
                        Console.Write("SF ");
                    }

                    //if a number if divisible by 3 print U instead of number
                    else if (i % 3 == 0)

                    {
                        Console.Write("U ");
                    }
                    //if a number if divisible by 5 print S instead of number
                    else if (i % 5 == 0)

                    {
                        Console.Write("S ");
                    }
                    //if a number if divisible by 7 print S instead of number
                    else if (i % 7 == 0)

                    {
                        Console.Write("F ");
                    }
                    
                    else Console.Write(i + " "); // if not divisible by 3, 5 or 7 then print the number
                   
                    if (i % k == 0) //writes a new line at every k numbers
                    {
                        Console.WriteLine();
                    }
                    
                    i++; //increments main number
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing UsfNumbers()");
            }
        }


        public static void PalindromePairs(string[] words)
        {
            try
            {
                for (int i = 0;i < words.Length; i++)
                {
                    for (int j = 0; j < words.Length; j++) // run two loops to get all combos for word i and word j
                    {
                        string wordcombo = words[i] + words[j]; //concatenation of word i and word j

                        if (i != j) // dont want the same word twice because that would be a palindrome
                        {
                            int wordlength = wordcombo.Length;
                            char[] chararray = wordcombo.ToCharArray(); //Create an array of the wordcombo
                            Array.Reverse(chararray); //Create a new array by reversing the letters
                          
                            // if the original equals to the reverse word then print the original
                            if(wordcombo == new string(chararray))
                            {
                                Console.Write("["+ i +","+j+"]"); //Print out the array elements that satisfy
                            }
                        }
                    }
                }
            }
            catch
            {

                Console.WriteLine("Exception occured while computing     PalindromePairs()");
            }
        }

        public static void Stones(int n4)
        {
            try
            {
                //Player one turn
                for (int i = 1; i < 4; i++)
                {
                    int stonecountturn1 = n4;
                    stonecountturn1 = stonecountturn1 - i;
                    if (stonecountturn1 < 4)
                    {
                        //Player one loses
                    }
                    else
                    {
                        //Player two turn
                        for (int j = 1; j < 4; j++)
                        {
                            int stonecountturn2 = stonecountturn1;
                            stonecountturn2 = stonecountturn2 - j;
                            if (stonecountturn2 < 4)
                            {
                                //Player one wins
                                Console.WriteLine(i + "," + j + "," + stonecountturn2);
                            }
                            else
                            {
                                //Player one turn
                                for(int k = 1; k<4; k++)
                                {
                                    int stonecountturn3 = stonecountturn2;
                                    stonecountturn3 = stonecountturn3 - k;
                                    if (stonecountturn3 < 4)
                                    {
                                        // Player one loses
                                    }
                                    else
                                    {

                                        //Player two turn
                                        for (int h = 1; h < 4; h++)
                                        {
                                            int stonecountturn4 = stonecountturn3;
                                            stonecountturn4 = stonecountturn4 - h;
                                            if (stonecountturn4 < 4)
                                            {
                                                //Player one wins
                                                Console.WriteLine(i + "," + j + "," + k + "," + h + "," + stonecountturn4);
                                            }
                                        }
                                    }
                                }
                            }

                        }
                    }
                }
                
            }
            catch
            {
                Console.WriteLine("Exception occured while computing Stones()");
            }
        }


    }
}
