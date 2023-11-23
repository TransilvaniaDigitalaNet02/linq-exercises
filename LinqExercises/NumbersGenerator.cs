namespace LinqExercises
{
    public static class NumbersGenerator
    {
        public static IEnumerable<int> AllNumbers()
        {
            int currentNumber = 0;
            while (true)
            {
                yield return currentNumber;
                currentNumber++;
            }
        }
    }
}
