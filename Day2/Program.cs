// See https://aka.ms/new-console-template for more information
class Day2
{
    static void Main(string[] args)
    {
        int totalScore = 0;

        using (StreamReader file = new StreamReader("/Users/selwynlilley/Projects/adventofcode22/Day2/test.txt"))
        {
            string line;
            while ((line = file.ReadLine()) != null)
            {
                var roundScore = GetPointsFromRoundKnowingResult(line[0], line[2]);
                //totalScore += GetPointsFromRound(line[0], line[2]);
                Console.WriteLine(roundScore);
                totalScore += roundScore;
            }

            file.Close();
        }

        Console.WriteLine();
        Console.WriteLine(totalScore);
    }

    static int GetPointsFromRound(char opponent, char you)
    {
        int pointsObtained = 0;
        switch (you)
        {
            case 'X': //you pick rock
                pointsObtained += 1;
                if (opponent == 'A') //Opponent picks rock
                {
                    pointsObtained += 3;
                }
                else if (opponent == 'B') //Opponent picks paper
                {
                    pointsObtained += 0;
                }
                else //Opponent picks scissors
                {
                    pointsObtained += 6;
                }
                break;
            
            case 'Y': //you pick paper
                pointsObtained += 2;
                if (opponent == 'A') //Opponent picks rock
                {
                    pointsObtained += 6;
                }
                else if (opponent == 'B') //Opponent picks paper
                {
                    pointsObtained += 3;
                }
                else //Opponent picks scissors
                {
                    pointsObtained += 0;
                }
                break;
            
            case 'Z': //you pick scissors
                pointsObtained += 3;
                if (opponent == 'A') //Opponent picks rock
                {
                    pointsObtained += 0;
                }
                else if (opponent == 'B') //Opponent picks paper
                {
                    pointsObtained += 6;
                }
                else //Opponent picks scissors
                {
                    pointsObtained += 3;
                }
                break;
        }

        return pointsObtained;
    }

    static int GetPointsFromRoundKnowingResult(char opponent, char result)
    {
        int roundScore = 0;
        switch (result)
        {
            case 'X': //you loose
                roundScore += 0;
                
                if (opponent == 'A') //opponent picks rock
                {
                    roundScore += 3;
                }
                else if (opponent == 'B') //opponent picks paper
                {
                    roundScore += 1;
                }
                else //opponent picks scissors
                {
                    roundScore += 2;
                }
                break;
            
            case 'Y': //you draw
                roundScore += 3;
                
                if (opponent == 'A') //opponent picks rock
                {
                    roundScore += 1;
                }
                else if (opponent == 'B') //opponent picks paper
                {
                    roundScore += 2;
                }
                else //opponent picks scissors
                {
                    roundScore += 3;
                }
                break;
            
            case 'Z': //you win
                roundScore += 6;
                
                if (opponent == 'A') //opponent picks rock
                {
                    roundScore += 2;
                }
                else if (opponent == 'B') //opponent picks paper
                {
                    roundScore += 3;
                }
                else //opponent picks scissors
                {
                    roundScore += 1;
                }
                break;
        }

        return roundScore;
    }
}
/*
int totalScore = 0;

using (StreamReader file = new StreamReader("/Users/selwynlilley/Projects/adventofcode22/Day1/test.txt"))
{
    string line;
    var roundScore = 0;
    while ((line = file.ReadLine()) != null)
    {

    }

    file.Close();
}

return totalScore;
*/