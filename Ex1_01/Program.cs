namespace Ex1_01
{
    public class Program
    {
        private static void Main()
        {
            string firstNumberStr;
            string secondNumberStr;
            string thirdNumberStr;
            int firstDecimal;
            int secondDecimal;
            int thirdDecimal;

            getInputFromUser(out firstNumberStr,out secondNumberStr,out thirdNumberStr);
            System.Console.WriteLine("all inputs were valid!, please press enter");
            System.Console.ReadLine();
            binaryToDecimal(out firstDecimal,firstNumberStr);
            binaryToDecimal(out secondDecimal, secondNumberStr);
            binaryToDecimal(out thirdDecimal, thirdNumberStr);
            printDecimalAscendingOrder(firstDecimal, secondDecimal, thirdDecimal);
            printAvgNumberOfChar(firstNumberStr, secondNumberStr, thirdNumberStr, '0');
            printAvgNumberOfChar(firstNumberStr, secondNumberStr, thirdNumberStr, '1');
        }
        private static void printAvgNumberOfChar (string i_FirstStr, string i_SecondStr, string i_ThirdStr,char i_Char)
        {
            float numOfCharOccurrences = 0;
            string strToPrint;
            float avgNumberOfOccurrences;

            for (int i = 0; i < 4; i++) 
            {
                if (i_FirstStr[i] == i_Char)
                {
                    numOfCharOccurrences++;
                }
                if (i_SecondStr[i] == i_Char)
                {
                    numOfCharOccurrences++;
                }
                if (i_ThirdStr[i] == i_Char)
                {
                    numOfCharOccurrences++;
                }
            }
            avgNumberOfOccurrences = numOfCharOccurrences / 3;
            strToPrint = string.Format("The avg number of {0} is: {1}", i_Char, avgNumberOfOccurrences);
            System.Console.WriteLine(strToPrint);
        }
        private static void printDecimalAscendingOrder (int i_firstNum, int i_SecondNum, int i_ThirdNum)
        {
            int maxNumber;
            int middleNumber;
            int minNumber;
            string resultStr;

            maxNumber = System.Math.Max(i_ThirdNum, System.Math.Max(i_firstNum, i_SecondNum));
            minNumber = System.Math.Min(i_ThirdNum, System.Math.Min(i_firstNum, i_SecondNum));
            if(i_firstNum != maxNumber && i_firstNum != minNumber)
            {
                middleNumber = i_firstNum;
            }
            else if(i_SecondNum != maxNumber && i_SecondNum != minNumber)
            {
                middleNumber = i_SecondNum;
            }
            else
            {
                middleNumber = i_ThirdNum;
            }

          resultStr = string.Format("The Decimals numbers are: {0}, {1}, {2}",minNumber,middleNumber,maxNumber);

          System.Console.WriteLine(resultStr);
        }
        private static void binaryToDecimal(out int o_DecimalNumber, string i_binaryStr)
        {
            int decimalNumber = 0;
            int binaryNumber = int.Parse(i_binaryStr);
            int binaryDigit = 0;
            int currentBinaryMsb;

            while (binaryNumber > 0)
            {
                currentBinaryMsb = binaryNumber % 10;
                currentBinaryMsb *= (int)System.Math.Pow(2, binaryDigit);
                decimalNumber += currentBinaryMsb;
                binaryDigit++;
                binaryNumber /= 10;
            }

            o_DecimalNumber = decimalNumber;
        }
        private static void getInputFromUser(out string o_FirstNumberStr,
            out string o_SecondNumberStr,
            out string o_ThirdNumberStr)
        {
            System.Console.WriteLine("Please enter 3 binary numbers with 9 digits each:");
            o_FirstNumberStr = System.Console.ReadLine();
            checkIfInputValid(ref o_FirstNumberStr);
            o_SecondNumberStr = System.Console.ReadLine();
            checkIfInputValid(ref o_SecondNumberStr);
            o_ThirdNumberStr = System.Console.ReadLine();
            checkIfInputValid(ref o_ThirdNumberStr);
        }

        private static void checkIfInputValid(ref string io_StrToCheck)// change 4 to 9
        {
            while(io_StrToCheck.Length != 4 ||
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
