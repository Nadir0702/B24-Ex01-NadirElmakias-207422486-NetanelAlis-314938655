﻿
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

            getInputFromUser(out firstNumberStr, out secondNumberStr, out thirdNumberStr);
            binaryToDecimal(out firstDecimal, firstNumberStr);
            binaryToDecimal(out secondDecimal, secondNumberStr);
            binaryToDecimal(out thirdDecimal, thirdNumberStr);
            printConvertedDecimalsAscendingOrder(firstDecimal, secondDecimal, thirdDecimal);

            System.Console.ReadLine();
        }

        private static void printConvertedDecimalsAscendingOrder(int i_FirstNum, int i_SecondNum, int i_ThirdNum)
        {
            int max;
            int middle;
            int min;
            string resultStr;

            max = System.Math.Max(System.Math.Max(i_FirstNum, i_SecondNum), i_ThirdNum);
            min = System.Math.Min(System.Math.Min(i_FirstNum, i_SecondNum), i_ThirdNum);
            if(i_FirstNum != max && i_FirstNum != min)
            {
                middle = i_FirstNum;
            }
            else if(i_SecondNum != max && i_SecondNum != min)
            {
                middle = i_SecondNum;
            }
            else // if(i_ThirdNum <= max && i_ThirdNum >= min)
            {
                middle = i_ThirdNum;
            }

            resultStr = string.Format("The decimal numbers are: {0}, {1}, {2}", min, middle, max);

            System.Console.WriteLine(resultStr);
        }

        private static void binaryToDecimal(out int o_DecimalNumber, string i_BinaryStr)
        {
            int binaryNumber = int.Parse(i_BinaryStr);
            int decimalNumber = 0;
            int binaryDigit = 0;
            int currentBinaryMSB;
            
            while(binaryNumber > 0)
            {
                currentBinaryMSB = binaryNumber % 10;
                currentBinaryMSB *= (int)System.Math.Pow(2, binaryDigit);
                decimalNumber += currentBinaryMSB;
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

        private static void checkIfInputValid(ref string io_StrToCheck)
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
