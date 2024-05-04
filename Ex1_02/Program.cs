namespace Ex1_02
{
    public class Program
    {
        private static void Main()
        {
            printDiamondRecursive("    *", 4);
            System.Console.ReadLine();  
        }

        public static void printDiamondRecursive(string i_StarsStr, uint i_MostLeftStar)
        {
            string newStarsStr;

            if(i_MostLeftStar == 0)
            {
                System.Console.WriteLine(i_StarsStr);
            }
            else
            {
                System.Console.WriteLine(i_StarsStr);
                newStarsStr = string.Format("{0}**", i_StarsStr);
                newStarsStr = newStarsStr.Remove((int)i_MostLeftStar - 1, 1);
                printDiamondRecursive(newStarsStr, i_MostLeftStar - 1);
                System.Console.WriteLine(i_StarsStr);
            }
        }
    }
}
