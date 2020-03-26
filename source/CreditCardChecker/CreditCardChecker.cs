using System;

namespace CreditCardChecker
{
    public class CreditCardChecker
    {
        /// <summary>
        /// Diese Methode überprüft eine Kreditkartenummer, ob diese gültig ist.
        /// Regeln entsprechend der Angabe.
        /// </summary>
        public static bool IsCreditCardValid(string creditCardNumber)
        {
            bool isValid = false;
            int count = 0;
            int evenSum = 0;
            int oddSum = 0;
            int checkNumber = 0;
            if (creditCardNumber.Length == 16)
            {
                for (int i = 0; i < creditCardNumber.Length - 1; i++)
                {
                    int number = ConvertToInt(creditCardNumber[i]);

                    if (i % 2 == 0 || i == 0)
                    {

                        number = number * 2;

                        if (number >= 10)
                        {
                            number = CalculateDigitSum(number);
                        }

                        evenSum += number;
                    }
                    else if (i % 2 != 0)
                    {
                        oddSum += number;
                    }

                }
                count = creditCardNumber.Length - 1;
                checkNumber = CalculateCheckDigit(oddSum, evenSum);

                if (checkNumber == ConvertToInt(creditCardNumber[count]))
                {
                    isValid = true;
                }
            }
            return isValid;
        }

        /// <summary>
        /// Berechnet aus der Summe der geraden Stellen (bereits verdoppelt) und
        /// der Summe der ungeraden Stellen die Checkziffer.
        /// </summary>
        private static int CalculateCheckDigit(int oddSum, int evenSum)
        {
            int sum = oddSum + evenSum;
            int checkNumber;

            checkNumber = (((sum / 10) + 1) * 10) - sum;

            return checkNumber;
        }

        /// <summary>
        /// Berechnet die Ziffernsumme einer Zahl.
        /// </summary>
        private static int CalculateDigitSum(int number)
        {
            int digitSum;

            digitSum = (number % 10) + (number / 10);

            return digitSum;
        }

        private static int ConvertToInt(char ch)
        {
            int number;

            number = ch - '0';

            return number;
        }
    }
}
