using System;

namespace CoinCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalCents;
            int remainingCents;

            totalCents = GetInputFromUserAsCents();

            var numQuarters = totalCents / 25;
            remainingCents = totalCents - (numQuarters * 25);

            var numDims = remainingCents / 10;
            remainingCents = remainingCents - (numDims * 10);

            var numNickels = remainingCents / 5;
            remainingCents = remainingCents - (numNickels * 5);

            var numPennies = remainingCents;

            Console.WriteLine();
            Console.WriteLine($"Coins breakdown for ${totalCents / 100.0}: ");

            if (numQuarters > 0)
                Console.WriteLine($"{numQuarters} quarter{(numQuarters > 1 ? "s" : "")}");

            if (numDims > 0)
                Console.WriteLine($"{numDims} dime{(numDims > 1 ? "s" : "")}");

            if (numNickels > 0)
                Console.WriteLine($"{numNickels} nickel{(numNickels > 1 ? "s" : "")}");

            if (numPennies > 0)
                Console.WriteLine($"{numPennies} {(numPennies > 1 ? "pennies" : "penny")}");

            Console.ReadLine();
        }

        /// <summary>
        /// Encapsulates logic to loop until received valid input
        /// </summary>
        /// <returns>int</returns>
        static int GetInputFromUserAsCents()
        {            
            string textInput;
            decimal valDollars;
        
            //loop until we get valid input
            do
            {            
                Console.Write("Please input amount (example: $0.46): ");

                textInput = Console.ReadLine();

                //this could be enhanced for better validation
                //for example culture aware code
                //or only allow two decimal places
                //add specific error messages for better user experience
                textInput = textInput.Replace("$", "");

            } while (!decimal.TryParse(textInput, out valDollars));

            //truncates fractional pennies so validate that before getting here if that matters
            return (int)(valDollars * 100);

        }


    }
}
