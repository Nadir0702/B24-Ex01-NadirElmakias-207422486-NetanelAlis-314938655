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
            System.Console.ReadLine();
        }

        private static void printNumOfDigitsSmallerThanOnes(uint i_number)
        {
            uint onesDigit = i_number % 10;
            uint currentDigit;
            uint numOfDigits = 0;
            
            for (int i = 0; i < 7; i++)
            {
                i_number /= 10;
                currentDigit = i_number % 10;
                if (currentDigit < onesDigit)
                {
                    numOfDigits++;
                }
            } 

            System.Console.WriteLine($"Number of digits smaller than {onesDigit}: {numOfDigits}");
        }

        private static uint getInputFromUser(out string o_numberStr)
        {
            uint o_Number = 0;

            System.Console.WriteLine("Please enter a 8 digits number:");
            o_numberStr = System.Console.ReadLine();
            while (o_numberStr.Length != 8 || !uint.TryParse(o_numberStr, out o_Number))
            {
                System.Console.WriteLine("The input you entered is invalid. Please try again.");
                o_numberStr = System.Console.ReadLine();
            }

            return o_Number;
        }
    }
}
