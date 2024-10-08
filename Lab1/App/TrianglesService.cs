namespace App
{
    public static class TrianglesService
    {
        public static int GetNumberOfTriangles(int numberOfLevels)
        {
            CheckNumberOfLevels(numberOfLevels, nameof(numberOfLevels));

            int countedTriangles = TrianglesCounter.CountNumberOfTriangles(numberOfLevels);

            return countedTriangles;
        }


        private static void CheckNumberOfLevels(int numberOfLevels, string variableName)
        {
            if (numberOfLevels <= 0 || numberOfLevels >= 106)
            {
                throw new ArgumentOutOfRangeException(variableName, $"{variableName} має бути в межах 1 та 105.");
            }

        }
    }
}