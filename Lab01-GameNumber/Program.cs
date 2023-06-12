using System;

namespace Lab01Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Welcome to my game");
                StartSequence();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Program is complete.");
            }

        }

        public static void StartSequence()
        {
            try
            {
                Console.WriteLine(" Enter a number greater than zero");
              
                int sizeNumbers = Convert.ToInt32(Console.ReadLine());
                int[] numbers = new int[sizeNumbers];
                numbers = Populate(numbers);
                int sum = GetSum(numbers);
                int product = GetProduct(numbers, sum);
                decimal quotient = GetQuotient(product);

                Console.WriteLine($"Your array is size: {sizeNumbers}");
                Console.Write("The numbers in the array are ");
                foreach (int item in numbers) { 
                    Console.Write(item+",");
                }
                Console.WriteLine();
                Console.WriteLine($"The sum of the array is {sum}");
                int chosenNumber = product / sum;
                Console.WriteLine($"{sum} * {chosenNumber} = {product}");
                decimal mystery = product / quotient;
                Console.WriteLine($"{product} / {mystery} =  {quotient}");
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public static int[] Populate(int[] Numbers)
        {
            for (int i = 0; i < Numbers.Length; i++)
            {
                Console.WriteLine($"Please enter the number {i + 1} of {Numbers.Length}");
                Numbers[i] = Convert.ToInt32(Console.ReadLine());

            }
            return Numbers;
        }

        static int GetSum(int[] numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }

            if (sum < 20)
            {
                throw new Exception($"Value of {sum} is too low");
            }

            return sum;
        }

        public static int GetProduct(int[] numbers, int sum)
        {
            try
            {
                Console.WriteLine($"Please select a random number between 1 and {numbers.Length}");
                int random = Convert.ToInt32(Console.ReadLine());
                int product = numbers[random - 1] * sum;
                return product;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }




        }

        public static decimal GetQuotient(int product)
        {
            try
            {
                Console.WriteLine($"Please enter a number to divide your product {product} by");
                int number = Convert.ToInt32(Console.ReadLine());

                decimal temp = decimal.Divide(product, number);

                return temp;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }

            return 0;
        }
    }
}