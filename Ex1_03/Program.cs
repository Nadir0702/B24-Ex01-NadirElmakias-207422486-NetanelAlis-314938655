namespace Ex1_03
{
    internal class Program
    {
        private static void Main()
        {
            uint diamondHeight;
            string startingStr;
            uint mostLeftStar;

            getInputFromUser(out diamondHeight);
            createStartingStr(diamondHeight, out startingStr, out mostLeftStar);
            Ex1_02.Program.printDiamondRecursive(startingStr, mostLeftStar);
            System.Console.ReadLine();
        }

        private static void createStartingStr(uint i_DiamondHeight, out string o_StartingStr, out uint o_StarIndex)
        {
            System.Text.StringBuilder SB = new System.Text.StringBuilder();
            uint numOfSpaces = 0;

            if(i_DiamondHeight % 2 == 0)
            {
                i_DiamondHeight--;
            }

            numOfSpaces = (i_DiamondHeight - 1) / 2;
            for (int i = 0; i < numOfSpaces; i++)
            {
                SB.Append(" ");
            }

            SB.Append("*");
            o_StartingStr = SB.ToString();
            o_StarIndex = numOfSpaces;
        }

        private static void getInputFromUser(out uint o_DiamondHeight)
        {
            string input;

            System.Console.WriteLine("Please enter Diamond height:");
            input = System.Console.ReadLine();
            while(!uint.TryParse(input, out o_DiamondHeight) || o_DiamondHeight == 0)
            {
                System.Console.WriteLine("The input you entered is invalid. Please try again.");
                input = System.Console.ReadLine();
            }
        }
    }
}
