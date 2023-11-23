namespace LinqExercises
{
    public static class NumbersExtensions
    {
        public static IEnumerable<int> WhereIsEven(this IEnumerable<int> allNumbers)
        {
            if (allNumbers is not null)
            {
                foreach (int number in allNumbers)
                {
                    bool isEven = number % 2 == 0;

                    if (isEven)
                    {
                        yield return number;
                    }
                }
            }
        }
    }
}
