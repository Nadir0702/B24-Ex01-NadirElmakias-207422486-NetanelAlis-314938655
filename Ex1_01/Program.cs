namespace Ex1_01
{
    public class Program
    {
        private static void Main()
        {
            getInputFromUser();
            System.Console.WriteLine("all inputs were valid!, please press enter");
            System.Console.ReadLine();

        }
        private static void getInputFromUser()
        {
            string firstNumberStr;
            string secondNumberStr;
            string thirdNumberStr;

            System.Console.WriteLine("Please enter 3 binary numbers with 9 digits each:");
            firstNumberStr = System.Console.ReadLine();
            checkIfInputValid(firstNumberStr);
            secondNumberStr = System.Console.ReadLine();
            checkIfInputValid(secondNumberStr);
            thirdNumberStr = System.Console.ReadLine();
            checkIfInputValid(thirdNumberStr);
        }

        private static void checkIfInputValid(string io_StrToCheck)
        {
            while(io_StrToCheck.Length != 9 ||
                  !isBinaryNumber(io_StrToCheck))
            {
                System.Console.WriteLine("The input you entered is invalid. Please try again.");
                io_StrToCheck = System.Console.ReadLine();
            }
        }

        private static bool isBinaryNumber(string i_StrToCheck)
        {
            bool binaryValid = true;
            int currCharIndexInStr = 0;

            while(currCharIndexInStr < 4 && binaryValid)
            {
                if (i_StrToCheck[currCharIndexInStr] != '1' &&
                    i_StrToCheck[currCharIndexInStr] != '0')
                {
                    binaryValid = false;
                }

                currCharIndexInStr++;
            }

            return binaryValid;
        }
    }
}
