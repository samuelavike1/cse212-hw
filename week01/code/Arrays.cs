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
        // 1. Create a new array of doubles with size 'length' to store our multiples
        // 2. Loop through each index from 0 to length-1
        // 3. For each index i, calculate the multiple as: number * (i + 1)
        //    - At index 0, we want the 1st multiple (number * 1)
        //    - At index 1, we want the 2nd multiple (number * 2)
        //    - And so on...
        // 4. Store each calculated multiple in the array at the corresponding index
        // 5. Return the completed array

        // Step 1: Create the result array with the specified length
        double[] multiples = new double[length];

        // Step 2-4: Loop and calculate each multiple
        for (int i = 0; i < length; i++)
        {
            // The (i+1)th multiple of number is number * (i+1)
            multiples[i] = number * (i + 1);
        }

        // Step 5: Return the array of multiples
        return multiples;
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
        // "Rotate right by amount" means the last 'amount' elements move to the front.
        // For example, with {1,2,3,4,5,6,7,8,9} and amount=3:
        //   - The last 3 elements {7,8,9} should move to the front
        //   - Result: {7,8,9,1,2,3,4,5,6}
        //
        // Steps:
        // 1. Calculate the split index: this is where we divide the list
        //    - Split index = data.Count - amount
        //    - Elements from split index to end will move to front
        // 2. Get the "right part" (last 'amount' elements) using GetRange
        // 3. Get the "left part" (first elements up to split index) using GetRange
        // 4. Clear the original list
        // 5. Add the right part first (these move to the front)
        // 6. Add the left part second (these move to the back)

        // Step 1: Calculate where to split the list
        int splitIndex = data.Count - amount;

        // Step 2: Get the last 'amount' elements (these will go to the front)
        List<int> rightPart = data.GetRange(splitIndex, amount);

        // Step 3: Get the first elements (these will go to the back)
        List<int> leftPart = data.GetRange(0, splitIndex);

        // Step 4: Clear the original list
        data.Clear();

        // Step 5: Add the right part first (now at the front)
        data.AddRange(rightPart);

        // Step 6: Add the left part second (now at the back)
        data.AddRange(leftPart);
    }
}
