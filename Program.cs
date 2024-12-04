const int numberOfRegions = 5;
int[,] adjacencyMatrix = new int[numberOfRegions, numberOfRegions]
{
    //A  B  C  D  E
    { 0, 1, 1, 1, 0 }, // A
    { 1, 0, 1, 0, 0 }, // B
    { 1, 1, 0, 1, 0 }, // C
    { 1, 0, 1, 0, 1 }, // D
    { 0, 0, 0, 1, 0 }  // E
};

// int[,] adjacencyMatrix2 = new int[numberOfRegions, numberOfRegions]
// {
//     //A  B  C  D  E
//     { 0, 1, 1, 0, 0 }, // A
//     { 1, 0, 1, 1, 0 }, // B
//     { 1, 1, 0, 0, 1 }, // C
//     { 0, 1, 0, 0, 1 }, // D
//     { 0, 0, 1, 1, 0 }  // E
// };

// TODO: implement your code

bool isValid(int region, int[] coloredRegions, int color)
{
  // Check if the given color can be assigned to the region
  for (int r = 0; r < numberOfRegions; r++)
  {
    // If the region is adjacent and has the same color, return false
    if (adjacencyMatrix[region, r] == 1 && coloredRegions[r] == color)
    {
      return false;
    }
  }
  // If no adjacent region has the same color, return true
  return true;
}

bool colorRegion(int region, int[] coloredRegions, int maxColors)
{
  // If all regions are colored, return true
  if (region == numberOfRegions)
  {
    return true;
  }

  // Try different colors for the current region
  for (int c = 1; c <= maxColors; c++)
  {
    // Check if the color can be assigned to the region
    if (isValid(region, coloredRegions, c))
    {
      // Assign correct color to the region
      coloredRegions[region] = c;

      // Recursively color the next region
      if (colorRegion(region + 1, coloredRegions, maxColors))
      {
        return true;
      }
    }
  }

  // If no color can be assigned, return false
  return false;
}

void Solution()
{
  int maxColors = 4;
  int[] coloredRegions = new int[numberOfRegions];

  bool isValidSolution = colorRegion(0, coloredRegions, maxColors);

  // Start coloring from the first region
  if (!isValidSolution)
  {
    // If no valid coloring is found, print a message and return
    Console.WriteLine("Solution does not exist.");
    return;
  }

  // Print the result
  for (int i = 0; i < numberOfRegions; i++)
  {
    Console.WriteLine($"Region {i}: Color {coloredRegions[i]}");
  }
}

Solution();

var expected = new int[numberOfRegions] { 1, 2, 3, 2, 1 };
