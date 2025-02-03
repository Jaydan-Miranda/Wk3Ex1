using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wk3Ex1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Start of the program and displays the title of the program and what it does
            Console.WriteLine("Currency Converter: ");
            Console.WriteLine("Convert currency to USD, EUR, JPY");

            // calls the method to GetAmount to convert input to a double
            double amount = GetAmount();

            // Writes line for user to input the currency they want to convert from and calls the GetCurrency method to store input in fromCurrency
            string fromCurrency = GetCurrency("Enter the currency to convert from (USD, EUR, JPY): ");

            // Writes line for user to input the currency they want to convert to and calls the GetCurrency method to store input in toCurrency
            string toCurrency = GetCurrency("Enter the currency to convert to (USD, EUR, JPY): ");

            // Calls the ConvertCurrency method to convert the amount from one currency to another
            double convertedAmount = ConvertCurrency(amount, fromCurrency, toCurrency);

            // Display the result for the user
            Console.WriteLine($"Converted amount: {convertedAmount:0.00} {toCurrency}");

            // stops code for user to view output
            Console.ReadLine();
        }

        // Method to collect user input and covert to double
        static double GetAmount()
        {
            Console.Write("Enter the amount: ");
            string input = Console.ReadLine();

            double result = 0;
            bool isDecimal = false; // checks if the input has a decimal point
            double decimalPlace = 0.1;

            foreach (char d in input)
            {
                if (d == '.' && !isDecimal) // statement reads the decimal point to convert it correctly
                {
                    isDecimal = true;
                    continue;
                }

                if (isDecimal)    
                {
                    result += (d - '0') * decimalPlace; // converts the string to a double
                    decimalPlace /= 10; // moves the decimal place
                }
                else
                {
                    result = result * 10 + (d - '0'); // converts the string to a double
                }
            }

            return result;
        }

        // Method to collect what currency the user wants to convert
        static string GetCurrency(string prompt)
        {
            string currency;

            while (true) // loop to ask the user for the currency
            {
                Console.Write(prompt);
                currency = Console.ReadLine();

                if (currency == "USD" || currency == "EUR" || currency == "JPY")
                {
                    return currency;
                }
                else
                {
                    Console.WriteLine("Please try again");
                }
            }
        }

        // Method to convert currency 
        static double ConvertCurrency(double amount, string fromCurrency, string toCurrency)
        {
            // Simulated exchange rates
            double usdToEur = 0.97, usdToJpy = 155.63;
            double eurToUsd = 1.02, eurToJpy = 159.14;
            double jpyToUsd = 0.0064, jpyToEur = 0.0062;

            // If the currency is the same, no conversion is needed
            if (fromCurrency == toCurrency)
            {
                return amount; // No conversion needed
            }

            //if statements to convert the currency from one to another
            if (fromCurrency == "USD" && toCurrency == "EUR")
            {
                return amount * usdToEur; //return the amount converted to the new currency by multiplying the amount by the exchange rate
            }
            else if (fromCurrency == "USD" && toCurrency == "JPY")
            {
                return amount * usdToJpy;
            }
            else if (fromCurrency == "EUR" && toCurrency == "USD")
            {
                return amount * eurToUsd;
            }
            else if (fromCurrency == "EUR" && toCurrency == "JPY")
            {
                return amount * eurToJpy;
            }
            else if (fromCurrency == "JPY" && toCurrency == "USD")
            {
                return amount * jpyToUsd;
            }
            else if (fromCurrency == "JPY" && toCurrency == "EUR")
            {
                return amount * jpyToEur;
            }
            else
            {
                return 0; // If the conversion leads to an error or messes up along the way
            }
        }
    }
}

