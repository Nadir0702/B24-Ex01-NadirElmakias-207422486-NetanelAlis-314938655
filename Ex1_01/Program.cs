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
            int minDecimalNumber;
            int maxDecimalNumber;

            getInputFromUser(out firstNumberStr, out secondNumberStr, out thirdNumberStr);
            binaryToDecimal(out firstDecimal, firstNumberStr);
            binaryToDecimal(out secondDecimal, secondNumberStr);
            binaryToDecimal(out thirdDecimal, thirdNumberStr);
            getMax(firstDecimal, secondDecimal, thirdDecimal, out maxDecimalNumber);
            getMin(firstDecimal, secondDecimal, thirdDecimal, out minDecimalNumber);
            printConvertedDecimalsAscendingOrder(firstDecimal, secondDecimal, thirdDecimal,
                                                 maxDecimalNumber, minDecimalNumber);
            handleStatistics(firstNumberStr, secondNumberStr, thirdNumberStr,
                             firstDecimal, secondDecimal, thirdDecimal,
                             maxDecimalNumber, minDecimalNumber);
            System.Console.ReadLine();
        }

        private static void handleStatistics(string firstNumberStr, string secondNumberStr, string thirdNumberStr,
                                             int firstDecimal, int secondDecimal, int thirdDecimal,
                                             int maxDecimalNumber, int minDecimalNumber)
        {
            float avgNumOfZeros;
            float avgNumOfOnes;
            int numOfPowsOfTwo;
            int numOfAscendingDigitsNumbers;

            getAvgOccurrencesOfChar(firstNumberStr, secondNumberStr, thirdNumberStr, '0', out avgNumOfZeros);
            getAvgOccurrencesOfChar(firstNumberStr, secondNumberStr, thirdNumberStr, '1', out avgNumOfOnes);
            getNumOfPowsOfTwo(firstNumberStr, secondNumberStr, thirdNumberStr, out numOfPowsOfTwo);
            getNumOfAscendingDigitsNumbers(firstDecimal, secondDecimal, thirdDecimal,
                                           out numOfAscendingDigitsNumbers);
            printStatistics(avgNumOfZeros, avgNumOfOnes, numOfPowsOfTwo, numOfAscendingDigitsNumbers,
                            minDecimalNumber, maxDecimalNumber);
        }

        private static void printStatistics(float i_AvgNumOfZeros, float i_AvgNumOfOnes, int i_NumOfPowsOfTwo,
                                            int i_NumOfAscendingDigitsNumbers, int i_MinNum, int i_MaxNum)
        {
            string statisticsStr = string.Format(@"The average number of 0's is: {0}
The average number of 1's is: {1}
The number of powers of 2 is: {2}
The number of ascending digits numbers is: {3}
The max number is: {4}
The min number is: {5}",i_AvgNumOfZeros, i_AvgNumOfOnes, i_NumOfPowsOfTwo, i_NumOfAscendingDigitsNumbers,
                        i_MaxNum, i_MinNum);

            System.Console.WriteLine(statisticsStr);
        }

        private static void getMax(int i_FirstNum, int i_SecondNum, int i_ThirdNum, out int o_MaxNum)
        {
            o_MaxNum = System.Math.Max(System.Math.Max(i_FirstNum, i_SecondNum), i_ThirdNum);
        }

        private static void getMin(int i_FirstNum, int i_SecondNum, int i_ThirdNum, out int o_MinNum)
        {
            o_MinNum = System.Math.Min(System.Math.Min(i_FirstNum, i_SecondNum), i_ThirdNum);
        }

        private static void getNumOfAscendingDigitsNumbers(int i_FirstNum, int i_SecondNum, int i_ThirdNum,
            out int o_NumOfAscendingDigitsNumbers)
        {
            int numOfAscendingDigitsNumbers = 0;
            string resultStr;

            if (isAscendingDigits(i_FirstNum))
            {
                numOfAscendingDigitsNumbers++;
            }

            if (isAscendingDigits(i_SecondNum))
            {
                numOfAscendingDigitsNumbers++;
            }

            if (isAscendingDigits(i_ThirdNum))
            {
                numOfAscendingDigitsNumbers++;
            }

            o_NumOfAscendingDigitsNumbers = numOfAscendingDigitsNumbers;
        }

        private static bool isAscendingDigits(int i_number)
        {
            bool ascendingDigits = true;
            int currentOnesDigit = i_number % 10;
            int nextOnesDigit;

            if(i_number < 10)
            {
                ascendingDigits = false;
            }

            while(ascendingDigits && i_number > 0)
            {
                i_number /= 10;
                nextOnesDigit = i_number % 10;
                if(nextOnesDigit >= currentOnesDigit)
                {
                    ascendingDigits = false;
                }

                currentOnesDigit = nextOnesDigit;
            }

            return ascendingDigits;
        }

        private static void getNumOfPowsOfTwo(string i_FirstStr, string i_SecondStr, string i_ThirdStr,
                                                out int o_NumOfPowsOfTwo)
        {
            int numOfPowsOfTwo = 0;
            string resultStr;

            if (isPowOfTwo(i_FirstStr))
            {
                numOfPowsOfTwo++;
            }

            if (isPowOfTwo(i_SecondStr))
            {
                numOfPowsOfTwo++;
            }

            if (isPowOfTwo(i_ThirdStr))
            {
                numOfPowsOfTwo++;
            }

            o_NumOfPowsOfTwo = numOfPowsOfTwo;
        }

        private static bool isPowOfTwo(string i_strToCheck)
        {
            int numOfOnes = 0;
            int digit = 0;
            bool powOfTwo = true;

            if(i_strToCheck == "000000000")
            {
                powOfTwo = false;
            }

            while(powOfTwo && digit < 9)
            {
                if(i_strToCheck[digit] == '1')
                {
                    numOfOnes++;
                }
                
                if(numOfOnes > 1)
                {
                    powOfTwo = false;
                }

                digit++;
            }

            return powOfTwo;
        }

        private static void getAvgOccurrencesOfChar(string i_FirstStr, string i_SecondStr, string i_ThirdStr,
                                                 char i_Char, out float o_AvgNumOfCharOccurrences)
        {
            float numOfCharOccurrences = 0;

            for (int i = 0; i < 9; i++)
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

            o_AvgNumOfCharOccurrences = numOfCharOccurrences / 3;
        }

        private static void printConvertedDecimalsAscendingOrder(int i_FirstNum, int i_SecondNum, int i_ThirdNum,
                                                                 int i_maxNum, int i_minNum)
        {
            int middle;
            string resultStr;

            if(i_FirstNum != i_maxNum && i_FirstNum != i_minNum)
            {
                middle = i_FirstNum;
            }
            else if(i_SecondNum != i_maxNum && i_SecondNum != i_minNum)
            {
                middle = i_SecondNum;
            }
            else // if(i_ThirdNum <= max && i_ThirdNum >= min)
            {
                middle = i_ThirdNum;
            }

            resultStr = string.Format("The decimal numbers are: {0}, {1}, {2}", i_minNum, middle, i_maxNum);
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

            while(currCharIndexInStr < 9 && binaryValid)
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
