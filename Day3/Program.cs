// See https://aka.ms/new-console-template for more information

class Day3
{
    public static void Main(string[] args)
    {
        var allCommonItems = new List<char>();
        Console.WriteLine();
        
        using (StreamReader file = new StreamReader("/Users/selwynlilley/Projects/adventofcode22/Day3/test.txt"))
        {
            string currentLine;
            var counter = 1;

            var line1 = "";
            var line2 = "";
            var line3 = "";
            
            while ((currentLine = file.ReadLine()) != null)
            {
                /*
                 First part:
                    var firstHalf = line.Substring(0, line.Length / 2);
                    var secondHalf = line.Substring(line.Length / 2);

                    var currentItems = GetCommonItems(firstHalf, secondHalf);
                    currentItems.ForEach(x => Console.Write(x));
                    Console.Write(" ");
                    currentItems.ForEach(x => allCommonItems.Add(x));
                */
                if (counter % 3 == 1) //first elf of elf triplet
                {
                    line1 = currentLine;
                }
                else if (counter % 3 == 2) //second elf of elf triplet
                {
                    line2 = currentLine;
                }
                else //third elf of elf triplet
                {
                    line3 = currentLine;
                    var badgeChar = GetElfBadge(line1, line2, line3);
                    Console.Write(badgeChar + " ");
                    allCommonItems.Add(badgeChar);
                }

                counter++;
            }
            
            file.Close();
        }

        var score = GetScore(allCommonItems);
        Console.WriteLine();
        Console.WriteLine(score);
    }

    private static char GetElfBadge(string firstLine, string secondLine, string thirdLine)
    {
        var commonCharsForFirstAndSecond = new List<char>();
        firstLine.ToList().ForEach(x =>
        {
            if (secondLine.Contains(x))
            {
                commonCharsForFirstAndSecond.Add(x);
            }
        });
        commonCharsForFirstAndSecond = commonCharsForFirstAndSecond.Distinct().ToList();

        var commonBadge = '!'; //dummy value should always be overwritten
        foreach (var x in commonCharsForFirstAndSecond)
        {
            if (thirdLine.Contains(x))
            {
                commonBadge = x;
                break;
            }
        }

        return commonBadge;
    }
    
    private static List<char> GetCommonItems(string firstHalf, string secondHalf)
    {
        var commonChars = new List<char>();
        firstHalf.ToList().ForEach(x =>
        {
            if (secondHalf.Contains(x))
            {
                commonChars.Add(x);
            }
        });
        
        //var unionString = firstHalf.Union(secondHalf);
        return commonChars.Distinct().ToList(); //Remove duplicate common chars
    }

    private static int GetScore(List<char> items)
    {
        Console.WriteLine();
        var totalScore = 0;

        items.ForEach(x =>
        {
            //Using https://web.alfredstate.edu/faculty/weimandn/miscellaneous/ascii/ascii_index.html for ASCII table conversions
            int charValue = x;
            if (97 <= charValue && charValue <= 122) //must be lower case
            {
                var itemScore = charValue - 96; // - 96 to get 'a' to start at 1
                Console.Write(itemScore + " ");
                totalScore += itemScore;
            }
            else //must be upper case
            {
                var itemScore = charValue - 64 + 26; // -64 to preset the letters then + 26 to start the capital letters after lowercase
                Console.Write(itemScore + " ");
                totalScore += itemScore;
            }
        });

        return totalScore;
    }
}