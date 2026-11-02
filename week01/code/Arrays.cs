using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'count' where each element is a multiple of 'number'.
    /// The first multiple is 'number' itself (1 * number).
    /// </summary>
    public static double[] MultiplesOf(double number, int count)
    {
        // === 1. Plan ===
        // Step 1: Create an array of doubles named 'multiples' allocated with the size of 'count'.
        // Step 2: Set up a for-loop that iterates 'count' times, using an index variable 'i' starting at 0.
        // Step 3: Inside the loop, calculate each multiple by multiplying 'number' by (i + 1).
        // Step 4: Assign the calculated multiple to the current index 'multiples[i]'.
        // Step 5: Return the fully populated 'multiples' array.

        // === 2. Code ===
        double[] multiples = new double[count];

        for (int i = 0; i < count; i++)
        {
            multiples[i] = number * (i + 1);
        }

        return multiples;
    }

    /// <summary>
    /// Rotate the list to the right by the specified amount.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // === 3. Plan ===
        // Step 1: Guard against edge cases. If the list is null, empty, has 1 element, or amount is 0, return immediately.
        // Step 2: Use the modulo operator (%) to normalize the rotation 'amount' against 'data.Count'. 
        //         This handles cases cleanly if 'amount' equals or exceeds the total size.
        // Step 3: Check if the normalized amount is 0. If it is, no shift is required; return immediately.
        // Step 4: Calculate the index where the list should split. The items to move begin at 'data.Count - amount'.
        // Step 5: Extract the moving segment using 'data.GetRange(startIndex, amount)' and store it in a temporary list.
        // Step 6: Delete that same segment from its original location at the back using 'data.RemoveRange(startIndex, amount)'.
        // Step 7: Insert the saved temporary list back at the very beginning using 'data.InsertRange(0, savedList)'.

        // === 4. Code ===
        if (data == null || data.Count <= 1 || amount == 0)
        {
            return;
        }

        // Normalize amount to wrap around cleanly if amount >= data.Count
        int actualRotation = amount % data.Count;

        if (actualRotation == 0)
        {
            return;
        }

        int splitIndex = data.Count - actualRotation;

        // Slice out the trailing items, remove them from the back, and insert them at the front
        List<int> wrappedElements = data.GetRange(splitIndex, actualRotation);
        data.RemoveRange(splitIndex, actualRotation);
        data.InsertRange(0, wrappedElements);
    }
}
