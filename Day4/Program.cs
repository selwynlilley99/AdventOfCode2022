// See https://aka.ms/new-console-template for more information

namespace Day4;

internal static class Day4
{
    public static void Main(string[] args)
    {
        var numOfIneffectivePairs = 0; //part 1
        var numOfOverlappingPairs = 0; //part 2
        using (StreamReader file = new StreamReader("/Users/selwynlilley/Projects/adventofcode22/Day4/test.txt"))
        {
            string line;
            while ((line = file.ReadLine()) != null)
            {
                var elfPair = line.Split(',');
                var firstElfRange = elfPair[0].Split('-');
                var secondElfRange = elfPair[1].Split('-');

                var firstElfStart = Int32.Parse(firstElfRange[0]);
                var firstElfFinish = Int32.Parse(firstElfRange[1]);
                var secondElfStart = Int32.Parse(secondElfRange[0]);
                var secondElfFinish = Int32.Parse(secondElfRange[1]);

                if (PairIsFullyContained(firstElfStart, firstElfFinish, secondElfStart,
                        secondElfFinish, elfPair)) //Returns 1 if pair are containing each other, 0 otherwise
                {
                    numOfIneffectivePairs++;
                    numOfOverlappingPairs++;
                }
                else if (PairIsOverlapping(firstElfStart, firstElfFinish, secondElfStart,
                             secondElfFinish, elfPair))
                {
                    numOfOverlappingPairs++;
                }
                /*
                if (secondElfStart >= firstElfStart && secondElfFinish <= firstElfFinish) //First elf encompasses second
                {
                    Console.WriteLine($"{elfPair[0]} encompasses {elfPair[1]}");
                    numOfIneffectivePairs++;
                }
                else if (firstElfStart >= secondElfStart && firstElfFinish <= secondElfFinish) //Second elf encompasses first
                {
                    Console.WriteLine($"{elfPair[1]} encompasses {elfPair[0]}");
                    numOfIneffectivePairs++;
                }
                */
            }
            
            file.Close();
        }
        
        Console.WriteLine();
        Console.WriteLine("Part 1. Number of ineffective pairs: " + numOfIneffectivePairs);
        Console.WriteLine("Part 2. Number of overlapping pairs: " + numOfOverlappingPairs);
    }

    private static bool PairIsFullyContained(int firstElfStart, int firstElfFinish, int secondElfStart, int secondElfFinish, string[] elfPair)
    {
        if (secondElfStart >= firstElfStart && secondElfFinish <= firstElfFinish) //First elf encompasses second
        {
            Console.WriteLine($"{elfPair[0]} encompasses {elfPair[1]}");
            return true;
        }
        else if (firstElfStart >= secondElfStart && firstElfFinish <= secondElfFinish) //Second elf encompasses first
        {
            Console.WriteLine($"{elfPair[1]} encompasses {elfPair[0]}");
            return true;
        }

        return false;
    }

    private static bool PairIsOverlapping(int firstElfStart, int firstElfFinish, int secondElfStart, int secondElfFinish,
        string[] elfPair)
    {
        if (secondElfStart >= firstElfStart && secondElfStart <= firstElfFinish) //Second elf starts somewhere in the first elf range so overlaps
        {
            Console.WriteLine($"{elfPair[0]} overlaps {elfPair[1]}");
            return true;
        }
        else if (secondElfFinish >= firstElfStart && secondElfFinish <= firstElfFinish) //Second elf encompasses first
        {
            Console.WriteLine($"{elfPair[1]} overlaps {elfPair[0]}");
            return true;
        }

        return false;
    }
}