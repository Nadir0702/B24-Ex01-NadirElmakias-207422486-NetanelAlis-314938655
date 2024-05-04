namespace Ex1_05
{
    internal class Program
    {
        private static void Main()
        {
            string numberStr;
            uint number = getInputFromUser(out numberStr);
            System.Console.WriteLine($"{number} is valid!");

            System.Console.ReadLine();
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
