using System;

namespace lab0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // int lowNumber = 0;
            // int highNumber = 0;

            // Creating an array that will contain the two numbers inputted by the user. We use "new double[2]" because we only need to set the 
            // size of the array, because the contents will be determined within the for loop later.
            double[] highLow = new double[2];
            
            
            // Main for loop
            for (double i = 0; i < highLow.Length; i++)
            {
                // The if and else if statements check to see which index position we are performing an operation on. highLow[0] is our low number,
                // and highLow[1] is our high number.
                
                if (i == 0)
                {
                    // This loop takes input from the user for a low number and checks for errors. The while loop is to ensure we continue to ask for the low
                    // number while we still need it. We use a string called userInput for the actual Console.ReadLine command so that we can check to see if
                    // the users input is actually a number. If the input can be parsed as a double, the operation continues. If it can't, the loop begins from
                    // the start again and tells the user to input a number. Unfortunately I couldn't think of a more elegant solution than to call the variable
                    // twice in both while loops; I couldn't figure out how to check to see if the input was a string with double.TryParse(Console.ReadLine()).
                    // When we ask for input and the user inputs 0 or a negative number, we use the out keyword to set the current "i" to the value taken by
                    // userInput AND check to see if that number is positive. If it is, we can break the loop and continue to the next index position in our
                    // highLow array. My understanding of the 'out' keyword is that we can include it when we're declaring an operation to store the 
                    // information in another, extra variable. When we declare 'out' in a statement like this, we are telling the code that we want it to perform
                    // the Console.ReadLine operation and use that same input to change the current value of 'i'. 
                    Console.WriteLine("Please input a low number: ");
                    while (true)
                    {
                        string userInput = Console.ReadLine();
                        if (double.TryParse(userInput, out highLow[(int) i]) && highLow[(int) i] > 0)
                            break;
  
                        else
                        {
                            if (!double.TryParse(userInput, out _))
                                Console.WriteLine("Please input a number.");
                            else
                                Console.WriteLine("Please input a positive number.");
                        }
                            
                    }
                }
               
                else if (i == 1)
                {
                    Console.WriteLine("Please input a high number: ");
                    while (true)
                    {
                        string userInput = Console.ReadLine();
                        if (double.TryParse(userInput, out highLow[(int)i]) && highLow[(int)i] > highLow[(int)i - 1])
                            break;

                        // The else statement here contains messages for 3 different possible errors. I'm not entirely sure why, but I had to sequence
                        // these so that it checks to see if the user input is a string before checking for anything else, otherwise it returned the 
                        // the "positive number" error message, presumably because a string has no int value? 
                        else
                        {
                            if (!double.TryParse(userInput, out _))
                                Console.WriteLine("Please input a number.");
                            else if (highLow[(int)i] <= 0)
                                Console.WriteLine("Please input a positive number.");
                            else if (highLow[(int)i] < highLow[(int)i - 1])
                                Console.WriteLine("Please input a number higher than the low number.");
                        }
                    }
                }
            }

            // highNum and lowNum help clarify which number is which for our calculations. difference subtracts the low number from the high number.
            // Finally, we print the difference.
            double highNum = highLow[1];
            double lowNum = highLow[0];
            double difference = highNum - lowNum;
            Console.WriteLine($"The difference between the two is {difference}");

            
            // Creating the array that will hold the numbers between the low number and the high number. We use the difference variable because it
            // already has the correct number of spaces between the two and cuts back on creating more variables. 
            double[] differenceArray = new double[(int)difference];

            // This for loop takes the size of the difference between high and low and goes through each object in the array. It edits the contents of 
            // differenceArray by taking the value of the low number and adding the index value to it, i.e. taking a low value of 6 counting up to 
            // 9 by putting 6 + 0 in the first position, 6 + 1 in the second, 6 + 2 in the third and so on. That way our array is always populated by
            // the correct numbers.
            for (double i = 0;i < difference;i++) 
            {
                differenceArray[(int)i] = lowNum + i;
            }

            // Finally, we have one last foreach loop that prints a new line for every number between the low number and the high number. It also checks
            // to make sure we don't print the low and high numbers themselves, though if we wanted to print those too we could remove this and add a
            // variable like 'sizeOfDifference = difference + 1' and change differenceArray to 'differenceArray = new double[(int)sizeOfDifference];'.
            // That way when we print the numbers between the low and high number we also include them in the list. 
            Console.WriteLine($"The numbers between {highNum} and {lowNum} are: ");
            foreach (double num in  differenceArray)
            {
                if (num < highNum && num > lowNum)
                    Console.WriteLine(num);
            }


            
            

            // This was my initial code for step one. 

            //Console.WriteLine("Please input a low number");
            //int lowNumber = Convert.ToInt32((Console.ReadLine()));
            //Console.WriteLine("Please input a high number");
            //int highNumber = Convert.ToInt32((Console.ReadLine()));
            //int difference = (highNumber - lowNumber);
            //string numberDifference = Convert.ToString(difference);
            //Console.WriteLine("The difference between the two is " + numberDifference);
        }
    }
}