namespace Ex1_05
{
    internal class Program
    {
        private static void Main()
        {
            string numberStr;
            uint number = getInputFromUser(out numberStr);

            System.Console.WriteLine($"{number} is valid!");
            printNumOfDigitsSmallerThanOnes(number);
            printNumOfDigitsDivisableByThree(number);
            System.Console.ReadLine();
        }

        private static void printNumOfDigitsDivisableByThree(uint i_Number)
        {
            uint currentDigit = i_Number % 10; 
            uint numOfDigits = 0;

            for (int i = 0; i < 8; i++)
            {
                if (currentDigit % 3 == 0)
                {
                    numOfDigits++;
                }

                i_Number /= 10;
                currentDigit = i_Number % 10;
            }

            System.Console.WriteLine($"Number of digits divisable by 3: {numOfDigits}");
        }

        private static void printNumOfDigitsSmallerThanOnes(uint i_Number)
        {
            uint onesDigit = i_Number % 10;
            uint currentDigit;
            uint numOfDigits = 0;
            
            for (int i = 0; i < 7; i++)
            {
                i_Number /= 10;
                currentDigit = i_Number % 10;
                if (currentDigit < onesDigit)
                {
                    numOfDigits++;
                }
            } 

            System.Console.WriteLine($"Number of digits smaller than {onesDigit}: {numOfDigits}");
        }

        private static uint getInputFromUser(out string o_NumberStr)
        {
            uint number = 0;

            System.Console.WriteLine("Please enter a 8 digits number:");
            o_NumberStr = System.Console.ReadLine();
            while (o_NumberStr.Length != 8 || !uint.TryParse(o_NumberStr, out number))
            {
                System.Console.WriteLine("The input you entered is invalid. Please try again.");
                o_NumberStr = System.Console.ReadLine();
            }

            return number;
        }
    }
}
