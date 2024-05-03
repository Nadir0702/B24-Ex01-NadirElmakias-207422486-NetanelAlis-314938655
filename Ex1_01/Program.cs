namespace Ex1_01 // change 4 to 9 , check how to print
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
            printNumOfPowsOfTwo(firstNumberStr,secondNumberStr, thirdNumberStr);
            printNumOfAscendingsDigitNumber(firstDecimal, secondDecimal, thirdDecimal); 
        }

        private static void printNumOfAscendingsDigitNumber(int i_FirstNum, int i_SecondNum, int i_ThirdNum)
        {

            int numPowersOfTwo = 0;
            string strToPrint;

            if (isAcendingDigits(i_FirstNum))
            {
                numPowersOfTwo++;
            }

            if (isAcendingDigits(i_SecondNum))
            {
                numPowersOfTwo++;
            }

            if (isAcendingDigits(i_ThirdNum))
            {
                numPowersOfTwo++;
            }

            strToPrint = string.Format("The number of ascendingsDigits is:{0}", numPowersOfTwo);
            System.Console.WriteLine(strToPrint);
        }
        private static bool isAcendingDigits(int i_Number)
        {
            bool acendingDigits = true;
            int currentOnesDigit = i_Number % 10;
            int nextOnesDigit;

            if(i_Number > 10)
            {
                acendingDigits = false;
            }

            while (acendingDigits && i_Number > 0)
            {
                i_Number /= 10;
                nextOnesDigit = i_Number % 10;
                if(nextOnesDigit >= currentOnesDigit)
                {
                    acendingDigits = false;
                }
            }

            return acendingDigits;
        }

        private static void printNumOfPowsOfTwo(string i_FirstStr, string i_SecondStr, string i_ThirdStr)
        {
            int numPowersOfTwo = 0;
            string strToPrint;

            if(isPowOfTwo(i_FirstStr))
            {
                numPowersOfTwo++;
            }

            if (isPowOfTwo(i_SecondStr))
            {
                numPowersOfTwo++;
            }

            if (isPowOfTwo(i_ThirdStr))
            {
                numPowersOfTwo++;
            }

            strToPrint = string.Format("The number of powers of two is:{0}", numPowersOfTwo);
            System.Console.WriteLine(strToPrint);
        }
        private static bool isPowOfTwo(string i_StrToCheck)
        {
            int numOfOnes = 0;
            int digits = 0;
            bool powOfTwo = true;

            if(i_StrToCheck == "0000") // change to 9 zeroes
            {
                powOfTwo = false;
            }

            while(powOfTwo && digits < 4)
            {
                if (i_StrToCheck[digits]  == '1')
                {
                    numOfOnes++;
                }

                if(numOfOnes > 1)
                {
                    powOfTwo = false;
                }

                digits++;
            }
            
            return powOfTwo;
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
