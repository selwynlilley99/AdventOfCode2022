namespace Day6;

internal static class Day6
{
    public static void Main(string[] args)
    {
        var charsBeforeMarker = 0;
        using (StreamReader file = new StreamReader("/Users/selwynlilley/Projects/adventofcode22/Day6/test.txt"))
        {
            string line;
            while ((line = file.ReadLine()) != null)
            {
                var arrayOfChars = line.ToCharArray();
                var currentFour = new Queue<char>();

                foreach (var c in arrayOfChars)
                {
                    charsBeforeMarker++;
                    
                    if (currentFour.Count < 14)
                    {
                        currentFour.Enqueue(c);
                        if (currentFour.Count == 14) //Check if this was the fourth element which has now been added
                        {
                            if (Latest14AreUnique(currentFour))
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        currentFour.Enqueue(c);
                        currentFour.Dequeue(); //Add new char and remove oldest char
                        
                        //Check if queue has matching elements
                        if (Latest14AreUnique(currentFour))
                        {
                            break;
                        }
                    }
                }
            }
            
            file.Close();
        }
        
        Console.WriteLine();
        Console.WriteLine(charsBeforeMarker);
    }

    //Used for part 1
    private static bool Latest4AreUnique(Queue<char> recentFour)
    {
        var temp = recentFour.ToArray();
        
        if (temp[0] == temp[1] || temp[0] == temp[2] || temp[0] == temp[3])
        {
            return false;
        }
        else if (temp[1] == temp[2] || temp[1] == temp[3])
        {
            return false;
        }
        else if (temp[2] == temp[3])
        {
            return false;
        }
        
        return true;
    }

    private static bool Latest14AreUnique(Queue<char> recentFourteen)
    {
        var temp = recentFourteen.ToArray();

        for (var i = 0; i < temp.Length - 1; i++)
        {
            for (var j = i + 1; j < temp.Length; j++)
            {
                if (temp[i] == temp[j])
                {
                    return false;
                }
            }
        }
        
        return true;
    }
}