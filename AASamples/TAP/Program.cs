namespace TAP
{
    using System;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            // 179426549
            Console.WriteLine("Please enter a valid number:");
            var numberIn = Console.ReadLine();
            long number;

            while (!Int64.TryParse(numberIn, out number))
            {
                Console.WriteLine("Not a valid number - please enter again:");
                numberIn = Console.ReadLine();
            }
            
            var program = new Program();
            program.DetermineIfIsPrimeNumberAsync(number);

            Console.WriteLine("Calculating if is prime number...{0}", Environment.NewLine);
            Console.ReadKey();
        }

        private async void DetermineIfIsPrimeNumberAsync(long number)
        {
            var result = await Task.Run(() =>
                {
                    var i = 2;

                    if (number == 2)
                    {
                        return true;
                    }

                    while (i < number)
                    {
                        if (number % i == 0)
                        {
                            return false;
                        }
                   
                        i++;
                    }

                    return true;
                });

            Console.WriteLine("{0} is prime: {1}", number, result);
        }
    }
}
