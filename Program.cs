using System;

namespace Summer_Assignment
{
    class Program
    {

        static void Main(string[] args)
        {  //Question 1
            Console.WriteLine("Q1 : Enter the Moves of Robot:");
            string moves = Console.ReadLine();
            bool pos = JudgeCircle(moves);
            if (pos)
            {
                Console.WriteLine("The Robot returns to the initial position (0,0)");
            }
            else
            {
                Console.WriteLine("The Robot does not return to the initial postion (0,0)");
            }
            // Question 2
            Console.WriteLine("Q2 : Enter the string to check for pangram:");
            string s = Console.ReadLine();
            bool flag = CheckIfPangram(s);
            if (flag)
            {
                Console.WriteLine("Yes, the given string is a pangram");
            }
            else
            {
                Console.WriteLine("No, the given string is not a pangram");
            }
            // Question 3 
            Console.WriteLine("Q3: Enter array length");
            int len = int.Parse(Console.ReadLine());
            int[] arr = new int[len];
            Console.WriteLine("Enter the array of numbers");
            for (int i = 0; i < len; i++)
                arr[i] = int.Parse(Console.ReadLine());

            int result = NumIdenticalPairs(arr);
            Console.WriteLine("The number of IdenticalPairs in the array are:{0}", result);
            //Question 4
            Console.WriteLine("Q4: Enter the array length");
            int len1 = int.Parse(Console.ReadLine());
            int[] arr1 = new int[len1];
            Console.WriteLine("Enter the array of numbers");
            for (int i = 0; i < len1; i++)
                arr1[i] = int.Parse(Console.ReadLine());
            int pivot = PivotIndex(arr1);
            if (pivot > 0)
            {
                Console.WriteLine("The Pivot index for the given array is {0}", pivot);
            }
            else
            {
                Console.WriteLine("The given array has no Pivot index");
            }
            //Question 5
            Console.WriteLine("Q5:");
            Console.WriteLine("Enter the First Word:");
            String word1 = Console.ReadLine();
            Console.WriteLine("Enter the Second Word:");
            String word2 = Console.ReadLine();
            String merged = MergeAlternately(word1, word2);
            Console.WriteLine("The Merged Sentence fromed by both words is {0}", merged);
            //Quesiton 6:
            Console.WriteLine("Q6: Enter the sentence to convert:");
            string sentence = Console.ReadLine();
            string goatLatin = ToGoatLatin(sentence);
            Console.WriteLine("Goat Latin for the Given Sentence is {0}", goatLatin);
            Console.WriteLine();

            static bool JudgeCircle(string moves)
            {
                try          // implementation of try and catch block
                {

                    int x = 0;                                     //Initialize x and y to 0
                    int y = 0;
                    char[] pos = moves.ToCharArray(); 

                    for (int move = 0; move < pos.Length; move++)
                    {
                        if (move == 'U') y = y + 1;//y++;         // if input is U increase y by 1               
                        else if (move == 'D') y = y - 1; //y--;   // if input is D increase y by 1     
                        else if (move == 'L') x = x + 1; //x++;   // if input is L increase y by 1     
                        else if (move == 'R') x = x - 1; //x--;   // if input is R increase y by 1     
                    }
                    if (x == 0 && y == 0)                         // if x and y both remain unchanged then robot is back to the origional position.
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }


                catch (Exception e)
                {

                    Console.WriteLine("Error: " + e.Message);
                    throw;
                }
            }

        }



        /* Self reflection Question 1
         * 
         * Time Complexity: O(N)O(N), where NN is the length of moves. We iterate through the string. 
         * Space complexity is O(1)
         * I learned implemetation of the loop concept and bool value concept */


        static public bool CheckIfPangram(string s)
        {
            try
            {
                string expression = "abcdefghijklmnopqrstuvwxyz";
                int count = 0;

                foreach (char i in expression)                     // loop one for checking characters in expression
                {
                    foreach (char j in s)                          // loop two to count the characters 
                    {
                        if (i == j)                               // if character is matched; break from the loop
                        {
                            count++;
                            break;
                        }
                    }
                }
                if (count == 26)                               // condition for checking the count
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                throw;
            }

        }

        /* Self reflection 
        * 
        * Time Complexity is O(N^2) as we need to loop through the string twice.
        * Space complexity is O(1)
        * I learned about another solution using hash tables that will reduce the complexity. By using hash table complexity can be reduced to O(n)*/
        public static int NumIdenticalPairs(int[] nums)
        {
            try
            {
                {
                    int count = 0;
 
                    for (int i = 0; i < nums.Length; i++)                  //initialize loop for array elements
                    {
                        for (int j = i + 1; j < nums.Length; j++)         //compare each element to the outer loop values if values match then keep a count.
                        {
                            if (nums[i] == nums[j])
                            {
                                count++;
                            }
                        }
                    }

                    return count;


                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Error: " + e.Message);
                throw;
            }
        }

        /* Self reflection 
        * 
        * Time Complexity is O(N^2) as we need to go through two loops.
        * Space complexity is O(1)
        * Another way to solve this problem could be implementing dictionary that will reduce the time complexity to O(n)
        * whearas space complexity will change to O(N)*/

        private static int PivotIndex(int[] nums)
        {
            try
            {

                int sum = 0;
                foreach (int i in nums)
                {
                    sum = sum + i;
                }
   
                int leftsum = 0;                                //Initialize leftsum to 0


                for (int j = 0; j < nums.Length; j++)            
                {
                    if (leftsum == (sum - leftsum - nums[j]))   //if leftside sum is eaual to sum - leftsum - element, then return the position of element
                    {
                        return j;
                    }
                    leftsum = leftsum + nums[j];

                }

                return -1;



            }
            catch (Exception e)
            {

                Console.WriteLine("Error: " + e.Message);
                throw;
            }

        }

        /* Self refelection
           Time complexity is O(N) as we loop once through array
           space complexity is O(1) 
           leraned to use array */


        public static string MergeAlternately(string word1, string word2)
        {
            try
            {
                int maxLength = 0;
                string result = "";
                maxLength = (word1.Length > word2.Length) ? word1.Length : word2.Length;  // take the maximum length from both the words
                for (int i = 0; i < maxLength; i++)                       //for each element print the letter alternatively till the max length is reached
                {
                    if (i < word1.Length)
                        result += word1[i].ToString();
                    if (i < word2.Length)
                        result += word2[i].ToString();
                }
                return result;

            }
            catch (Exception e)
            {

                Console.WriteLine("Error: " + e.Message);
                throw;
            }

        }



            /* Self refelection
              Time complexity is O(N) as we loop once through array
              space complexity is O(1) 
              learned the use of conditional statements and used built in functions like length */


            public static string ToGoatLatin(string S)
            {
                try
                {

                    string res = "";
                    int numOfWordsSeen = 0;
                    string vowels = "aeiouAEIOU";
                    string cons = "bcdfghiklmnjpqrstvwxyzBCDFGHIKLMNPJQRSTVWXYZ";
                    string temp = "";

                    int i = 0;

                    while (i < S.Length)
                    {
                        while (i < S.Length && S[i] != ' ')
                        {
                            temp += S[i];
                            i++;
                        }
                        numOfWordsSeen++;
                        i++;

                        if (vowels.IndexOf(temp[0]) != -1)        // append ma if it's vowels 
                        {
                            temp += "ma";
                        }

                        else if (cons.IndexOf(temp[0]) != -1)     //append first letter to end and add ma if its constant
                        {
                            char firstLetter = temp[0];
                            temp = temp.Substring(1);
                            temp += firstLetter + "ma";
                        }

                        for (int j = 0; j < numOfWordsSeen; j++)   //append a to the end of words according to its index in sentence 
                        {
                            temp += 'a';
                        }

                        if (numOfWordsSeen == 1)
                        {
                            res += temp;
                        }

                        else
                        {
                            res += ' ' + temp;
                        }

                        temp = "";
                    }
                    return res;
                }
                catch (Exception e)
                {

                    Console.WriteLine("Error: " + e.Message);
                    throw;
                }
            }
        }
    } 
/* Self reflection 
        * 
        * Time Complexity is more for this program which can be reduced by using function like string builder 
        * Space complexity is O(1)
        * I learned implemetation of nested while loop*/
