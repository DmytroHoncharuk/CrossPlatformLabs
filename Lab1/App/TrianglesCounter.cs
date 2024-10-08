namespace App
{
    public static class TrianglesCounter 
    { 
        public static int CountNumberOfTriangles(int numberOfLevels)
        {
            return ((numberOfLevels * (numberOfLevels + 2) * (numberOfLevels * 2 + 1)) / 8);
        }
    }
}
