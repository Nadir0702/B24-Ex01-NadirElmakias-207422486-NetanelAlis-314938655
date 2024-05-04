namespace Ex1_04
{
    internal class Program
    {
        private static void Main()
        {
            string str;

            getInputFromUser(out str);
            System.Console.WriteLine($"{str} is {(isPalindrome(str) ? "" : "Not ")}a Palindrome!");

            System.Console.ReadLine();
        }

        private static bool isPalindrome(string i_StrToCheck)
        {
            bool palindrome;
            string tempStr;

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
                    tempStr = i_StrToCheck.Remove(0, 1);
                    tempStr = tempStr.Remove(tempStr.Length - 1, 1);
                    palindrome = isPalindrome(tempStr);
                }
            }

            return palindrome;
        }

        private static bool isValidStr(string i_StrToCheck)
        {
            bool valid = true;
            int strindex = 0;

            if(i_StrToCheck.Length != 10)
            {
                valid = false;
            }
            else if (char.IsLetter(i_StrToCheck[0]))
            {
                while(valid && strindex < 10)
                {
                    if(!char.IsLetter(i_StrToCheck[strindex]))
                    {
                        valid = false;
                    }

                    strindex++;
                }
            }
            else if (char.IsDigit(i_StrToCheck[0]))
            {
                while (valid && strindex < 10)
                {
                    if (!char.IsDigit(i_StrToCheck[strindex]))
                    {
                        valid = false;
                    }

                    strindex++;
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
