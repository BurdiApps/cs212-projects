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

        // Plan:
        // 1. Create a new array of doubles with size 'length'
        double[] result = new double[length];
        // 2. Use a loop to go through each position in the array (from 0 to length-1)
        for (int i = 0; i < length; i++)
        {
            // 3. For each position i, calculate the multiple: number * (i + 1)
            //    - Position 0 gets number * 1 (the first multiple)
            //    - Position 1 gets number * 2 (the second multiple)
            //    - Position 2 gets number * 3 (the third multiple), etc.
            // 4. Store the calculated multiple in the array at position i
            result[i] = number * (i + 1);
        }
        // 5. After the loop completes, return the array
        return result;
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

        // Plan (using list slicing approach):
        // 1. Calculate the split point: the last 'amount' elements need to move to the front
        //    - The split point is at index: data.Count - amount
        //    - Example: {1,2,3,4,5,6,7,8,9} with amount=3, split point is 9-3=6
        int splitPoint = data.Count - amount;

        // 2. Get the "right part" - the elements that will move to the front
        //    - Use GetRange to get the last 'amount' elements starting from the split point
        //    - Example: elements at index 6,7,8 which are {7,8,9}
        List<int> rightPart = data.GetRange(splitPoint, amount);

        // 3. Get the "left part" - the elements that will move to the back
        //    - Use GetRange to get elements from index 0 up to the split point
        //    - Example: elements from 0 to 6 which are {1,2,3,4,5,6}
        List<int> leftPart = data.GetRange(0, splitPoint);

        // 4. Clear the original list using Clear()
        data.Clear();

        // 5. Add the right part back first using AddRange()
        data.AddRange(rightPart);

        // 6. Add the left part back second using AddRange()
        data.AddRange(leftPart);
        // Result: {7,8,9,1,2,3,4,5,6}
    }
}
