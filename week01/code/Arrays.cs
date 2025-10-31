public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        //Solution
        //Create a new array of length "length"
        var multiples = new double[length];
        
        //The loop should run for "length number of times"
        for (int i = 1; i <= length; i++)
        {
        //Each iteration of the loop will add to a variable that starts from one (i), increases by one and multiplies the starting number by whatever the variable is at that point. 
        //The resulting number is added to the new array at one less than index (i). 
            double numberMultiplies = number * i;
            multiples[i - 1] = numberMultiplies;
        }

        return multiples; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {

        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        //First, we get all the "amount" items ((data.Count - amount)) from the end of the list as save it in a new list using GetRange
        var newList = data.GetRange(data.Count - amount, amount);
        //Next we remove all matching items from the end of the list using RemoveRange starting from the index where the amount of items can be removed and ending at the end (data.Count - amount)
        data.RemoveRange(data.Count - amount, amount);
        //Finally, we append the new list to the old list using InsertRange starting from index 0, effectively rotating the list right
        data.InsertRange(0, newList);
    }
}
