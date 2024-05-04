namespace Ex1_01
{
    public class Program
    {
        private static void Main()
        {
            runProgram();
        }

        private static void runProgram()
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
        }

        private static void handleStatistics(string i_FirstNumberStr, string i_SecondNumberStr,
                                             string i_ThirdNumberStr, int i_FirstDecimal,
                                             int i_SecondDecimal, int i_ThirdDecimal,
                                             int i_MaxDecimalNumber, int i_MinDecimalNumber)
        {
            float avgNumOfZeros;
            float avgNumOfOnes;
            int numOfPowsOfTwo;
            int numOfAscendingDigitsNumbers;

            getAvgOccurrencesOfChar(i_FirstNumberStr, i_SecondNumberStr, i_ThirdNumberStr, '0',
                                    out avgNumOfZeros);
            getAvgOccurrencesOfChar(i_FirstNumberStr, i_SecondNumberStr, i_ThirdNumberStr, '1',
                                    out avgNumOfOnes);
            getNumOfPowsOfTwo(i_FirstNumberStr, i_SecondNumberStr, i_ThirdNumberStr, out numOfPowsOfTwo);
            getNumOfAscendingDigitsNumbers(i_FirstDecimal, i_SecondDecimal, i_ThirdDecimal,
                                           out numOfAscendingDigitsNumbers);
            printStatistics(avgNumOfZeros, avgNumOfOnes, numOfPowsOfTwo, numOfAscendingDigitsNumbers,
                            i_MinDecimalNumber, i_MaxDecimalNumber);
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

        private static bool isAscendingDigits(int i_Number)
        {
            bool ascendingDigits = true;
            int currentOnesDigit = i_Number % 10;
            int nextOnesDigit;

            if(i_Number < 10)
            {
                ascendingDigits = false;
            }

            while(ascendingDigits && i_Number > 0)
            {
                i_Number /= 10;
                nextOnesDigit = i_Number % 10;
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

        private static bool isPowOfTwo(string i_StrToCheck)
        {
            int numOfOnes = 0;
            int currentDigitToCheck = 0;
            bool powOfTwo = true;

            if(i_StrToCheck == "000000000")
            {
                powOfTwo = false;
            }

            while(powOfTwo && currentDigitToCheck < 9)
            {
                if(i_StrToCheck[currentDigitToCheck] == '1')
                {
                    numOfOnes++;
                }
                
                if(numOfOnes > 1)
                {
                    powOfTwo = false;
                }

                currentDigitToCheck++;
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
                                                                 int i_MaxNum, int i_MinNum)
        {
            int middleNumber;
            string resultStr;

            if(i_FirstNum != i_MaxNum && i_FirstNum != i_MinNum)
            {
                middleNumber = i_FirstNum;
            }
            else if(i_SecondNum != i_MaxNum && i_SecondNum != i_MinNum)
            {
                middleNumber = i_SecondNum;
            }
            else // if(i_ThirdNum <= max && i_ThirdNum >= min)
            {
                middleNumber = i_ThirdNum;
            }

            resultStr = string.Format("The decimal numbers are: {0}, {1}, {2}", i_MinNum, middleNumber, i_MaxNum);
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
            while(io_StrToCheck.Length != 9 || !isBinaryNumber(io_StrToCheck))
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
