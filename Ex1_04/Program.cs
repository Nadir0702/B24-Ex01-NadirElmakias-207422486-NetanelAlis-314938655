namespace Ex1_04
{
    internal class Program
    {
        private static void Main()
        {
            runProgram();
        }

        private static void runProgram()
        {
            string str;

            getInputFromUser(out str);
            System.Console.WriteLine($"{str} is {(isPalindrome(str) ? "" : "Not ")}a Palindrome!");
            System.Console.WriteLine($"{str} is {(isDivisableByFour(str) ? "" : "Not ")}divisable by 4");
            printNumberOfLowercaseChars(str);
        }

        private static void printNumberOfLowercaseChars(string i_Str)
        {
            int numOfLowercaseChars = 0;

            if(char.IsLetter(i_Str[0]))
            {
                for (int i = 0; i < 10; i++)
                {
                    if (char.IsLower(i_Str[i]))
                    {
                        numOfLowercaseChars++;
                    }
                }

                System.Console.WriteLine($"Number of lowercase letters in {i_Str}: {numOfLowercaseChars}");
            }
            else
            {
                System.Console.WriteLine($"{i_Str} is a number, it has no lowercase letters");
            }
        }

        private static bool isDivisableByFour(string i_StrToCheck)
        {
            bool divisable = true;
            ulong numberToCheck;

            if(!ulong.TryParse(i_StrToCheck, out numberToCheck))
            {
                divisable = false;
            }
            else if (numberToCheck % 4 != 0)
            {
                divisable = false;
            }

            return divisable;
        }

        private static bool isPalindrome(string i_StrToCheck)
        {
            bool palindrome;

            if(i_StrToCheck.Length == 0)
            {
                palindrome = true;
            }
            else
            {
                if(i_StrToCheck[0] != i_StrToCheck[i_StrToCheck.Length - 1])
                {
                    palindrome = false; 
                }
                else
                {
                    i_StrToCheck = i_StrToCheck.Remove(i_StrToCheck.Length - 1, 1);
                    i_StrToCheck = i_StrToCheck.Remove(0, 1);
                    palindrome = isPalindrome(i_StrToCheck);
                }
            }

            return palindrome;
        }

        private static bool isValidStr(string i_StrToCheck)
        {
            bool valid = true;
            int strIndex = 0;

            if(i_StrToCheck.Length != 10)
            {
                valid = false;
            }
            else if (char.IsLetter(i_StrToCheck[0]))
            {
                while(valid && strIndex < 10)
                {
                    if(!char.IsLetter(i_StrToCheck[strIndex]))
                    {
                        valid = false;
                    }

                    strIndex++;
                }
            }
            else if (char.IsDigit(i_StrToCheck[0]))
            {
                while (valid && strIndex < 10)
                {
                    if (!char.IsDigit(i_StrToCheck[strIndex]))
                    {
                        valid = false;
                    }

                    strIndex++;
                }
            }
            else
            {
                valid = false;
            }

            return valid;
        }

        private static void getInputFromUser(out string o_Str)
        {
            System.Console.WriteLine("Please enter a 10 characters string:");
            o_Str = System.Console.ReadLine();
            while(!isValidStr(o_Str))
            {
                System.Console.WriteLine("The input you entered is invalid. Please try again.");
                o_Str = System.Console.ReadLine();
            }
        }
    }
}
