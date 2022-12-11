// See https://aka.ms/new-console-template for more information

int[] bestThree = {0, 0, 0};

using (StreamReader file = new StreamReader("/Users/selwynlilley/Projects/adventofcode22/Day1/test.txt"))
{
    string line;
    var currentElfSum = 0;
    while ((line = file.ReadLine()) != null)
    {
        if (line == "")
        {
            int indexOfLeast = 0;
            var valueOfLeast = bestThree[0];
            for (var i = 1; i < 3; i++)
            {
                if (valueOfLeast > bestThree[i])
                {
                    valueOfLeast = bestThree[i];
                    indexOfLeast = i;
                    //bestThree[i] = currentElfSum;
                    //break;
                }
            }

            if (currentElfSum > valueOfLeast)
            {
                bestThree[indexOfLeast] = currentElfSum;
            }

            currentElfSum = 0;
        }
        else
        {
            currentElfSum += Int32.Parse(line);
        }
    }
    
    //Check last elf as well
    for (var i = 0; i < 3; i++)
    {
        if (currentElfSum > bestThree[i])
        {
            bestThree[i] = currentElfSum;
            break;
        }
    }
    
    file.Close();
}

var bestTotal = 0;
for (var i = 0; i < 3; i++)
{
    Console.WriteLine(bestThree[i]);
    bestTotal += bestThree[i];
}

Console.WriteLine();
Console.WriteLine(bestTotal);
//return bestTotal;