namespace Day8;

internal static class Day8
{
    public static void Main(string[] args)
    {
        var visibleTrees = 0;
        int[,] grid;
        List<List<int>> inputAsInt = new List<List<int>>();
        int numRows = 0;
        int numColumns = 0;

        //First read in grid (as list of lists of ints)
        using (StreamReader file = new StreamReader("/Users/selwynlilley/Projects/adventofcode22/Day8/test.txt"))
        {
            string line;
            while ((line = file.ReadLine()) != null)
            {
                if (numRows == 0) //set numColumns with first line
                {
                    numColumns = line.Length;
                }

                var lineAsInts = new List<int>();
                foreach (var num in line)
                {
                    lineAsInts.Add(Int32.Parse(num.ToString()));
                }

                inputAsInt.Add(lineAsInts);
                numRows++;
            }

            file.Close();
        }

        //Create grid from list of lists
        grid = new int[numRows, numColumns];
        grid = FillGrid(grid, inputAsInt);

        //Get number of visible trees (part 1)
        visibleTrees = GetVisibleTrees(grid);

        //Get best scenic score (part 2)
        var scenicScore = GetHighestScenicScore(grid);

        Console.WriteLine();
        Console.WriteLine($"Number of visible trees: {visibleTrees}");
        Console.WriteLine($"Highest scenic score is: {scenicScore}");
    }

    private static int[,] FillGrid(int[,] emptyGrid, List<List<int>> listOfInts)
    {
        for (var i = 0; i < listOfInts.Count; i++)
        {
            for (var j = 0; j < listOfInts[0].Count; j++)
            {
                emptyGrid[i, j] = listOfInts[i][j];
            }
        }

        return emptyGrid;
    }

    //Part 1
    private static int GetVisibleTrees(int[,] grid)
    {
        var visibleTrees = 0;

        for (var i = 1; i < grid.GetLength(0) - 1; i++)
        {
            for (var j = 1; j < grid.GetLength(1) - 1; j++)
            {
                var visibleToLeft = true;
                var visibleToRight = true;
                var visibleToTop = true;
                var visibleToBottom = true;

                //Check each middle tree in 4 directions for bigger/same height trees
                for (var l = 0; l < i; l++) //Check left
                {
                    if (grid[l, j] >= grid[i, j]) //At least one tree greater or equal to tree height so not visible
                    {
                        visibleToLeft = false;
                        break;
                    }
                }

                for (var r = i + 1; r < grid.GetLength(0); r++) //Check right
                {
                    if (grid[r, j] >= grid[i, j])
                    {
                        visibleToRight = false;
                        break;
                    }
                }

                for (var t = 0; t < j; t++) //Check top
                {
                    if (grid[i, t] >= grid[i, j])
                    {
                        visibleToTop = false;
                        break;
                    }
                }

                for (var b = j + 1; b < grid.GetLength(1); b++) //Check bottom
                {
                    if (grid[i, b] >= grid[i, j])
                    {
                        visibleToBottom = false;
                        break;
                    }
                }

                if (visibleToLeft || visibleToRight || visibleToTop || visibleToBottom)
                {
                    Console.WriteLine($"Visible tree at [{i}, {j}]. With height {grid[i, j]}");
                    visibleTrees++;
                }
            }
        }

        //4 corners being double accounted for by adding both dimensions twice (top and bottom rows, left and right columns)
        var edgeTrees = (grid.GetLength(0) * 2) + (grid.GetLength(1) * 2) - 4;

        visibleTrees += edgeTrees;

        return visibleTrees;
    }

    private static int GetHighestScenicScore(int[,] grid)
    {
        var highestScore = 0;

        //Do not need to check edge of the grid
        for (var i = 1; i < grid.GetLength(0) - 1; i++)
        {
            for (var j = 1; j < grid.GetLength(1) - 1; j++)
            {
                var distanceToLeft = 0;
                var distanceToRight = 0;
                var distanceToTop = 0;
                var distanceToBottom = 0;
                
                //Check each middle tree in 4 directions for bigger/same height trees
                for (var l = i - 1; l >= 0; l--) //Check left
                {
                    distanceToLeft++;
                    
                    if (grid[l, j] >= grid[i, j]) //Tree greater or equal to tree height so ends view
                    {
                        break;
                    }
                }

                for (var r = i + 1; r < grid.GetLength(0); r++) //Check right
                {
                    distanceToRight++;
                    
                    if (grid[r, j] >= grid[i, j])
                    {
                        break;
                    }
                }

                for (var t = j - 1; t >= 0; t--) //Check top
                {
                    distanceToTop++;
                    
                    if (grid[i, t] >= grid[i, j])
                    {
                        break;
                    }
                }

                for (var b = j + 1; b < grid.GetLength(1); b++) //Check bottom
                {
                    distanceToBottom++;
                    
                    if (grid[i, b] >= grid[i, j])
                    {
                        break;
                    }
                }

                var scenicScoreForCurrent = distanceToLeft * distanceToRight * distanceToTop * distanceToBottom;

                if (scenicScoreForCurrent > highestScore)
                {
                    Console.WriteLine($"New highest scenic score of {scenicScoreForCurrent} found. At position: [{i}],[{j}]");
                    highestScore = scenicScoreForCurrent;
                }
            }
        }

        return highestScore;
    }
}