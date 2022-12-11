namespace Day5;

internal static class Day5
{
    public static void Main(string[] args)
    {
        //var topCrates = new List<char>();
        var stacks = new List<Stack<char>>();
        
        using (StreamReader file = new StreamReader("/Users/selwynlilley/Projects/adventofcode22/Day5/test.txt"))
        {
            string line;
            var initialPhase = true;
            var initialLine = true;
            var wrongOrderStacks = new List<Stack<char>>();
            var tempQueues = new List<Queue<char>>();
            
            while ((line = file.ReadLine()) != null)
            {
                if (line == "") //break line between the two phases
                {
                    initialPhase = false;
                    
                    //Need to rearrange stacks to be in the correct order (as input went from top to bottom rather than bottom to top)
                    //Used resource https://iq.opengenus.org/reverse-stack-using-queue/ for helping with pseudo-code
                    for (var i = 0; i < wrongOrderStacks.Count; i++)
                    {
                        var wrongOrderStack = wrongOrderStacks[i];
                        while (wrongOrderStack.Count != 0)
                        {
                            tempQueues[i].Enqueue(wrongOrderStack.Pop());
                        }

                        while (tempQueues[i].Count != 0)
                        {
                            stacks[i].Push(tempQueues[i].Dequeue());
                        }

                        Console.WriteLine();
                        foreach (var c in stacks[i])
                        {
                            Console.Write(c);
                        }
                        Console.WriteLine();
                    }
                    
                    continue;
                }

                if (initialPhase) //Initial phase setting up the stacks
                {
                    if (initialLine) //use first line to get number of required stacks (only executed once)
                    {
                        //Each stack (plus space inbetween) takes 4 chars of input, last stack will always be an extra 3 chars
                        //So numOfStacks is the quotient of line length divided by 4 plus the extra stack at the end.
                        var numOfStacks = Math.DivRem(line.Length, 4).Quotient + 1;

                        for (var i = 0; i < numOfStacks; i++)
                        {
                            stacks.Add(new Stack<char>());
                            wrongOrderStacks.Add(new Stack<char>());
                            tempQueues.Add(new Queue<char>());
                        }

                        initialLine = false;
                        Console.WriteLine($"Number of stacks: {numOfStacks}");
                    }

                    if (line[1] == '1') //End of input, next line will be line break
                    {
                        continue;
                    }

                    var stackIndex = 0;
                    for (var charIndex = 1; charIndex < line.Length; charIndex += 4)
                    {
                        if (line[charIndex] != ' ') //Not space so must be crate in this stack
                        {
                            wrongOrderStacks[stackIndex].Push(line[charIndex]);
                        }
                        stackIndex++;
                    }
                }
                else //Second phase - moving instructions
                {
                    var lineParts = line.Split(' ');
                    var numToMove = Int32.Parse(lineParts[1]);
                    var sourceStack = Int32.Parse(lineParts[3]);
                    var destinationStack = Int32.Parse(lineParts[5]);

                    /* Part 1 logic
                    for (var numPopped = 1; numPopped <= numToMove; numPopped++)
                    {
                        stacks[destinationStack - 1].Push(stacks[sourceStack - 1].Pop());
                    }
                    */
                    
                    // Part 2 logic
                    var tempStack = new Stack<char>();
                    for (var numPopped = 1; numPopped <= numToMove; numPopped++)
                    {
                        tempStack.Push(stacks[sourceStack - 1].Pop());
                    }

                    foreach (var c in tempStack)
                    {
                        stacks[destinationStack - 1].Push(c);
                    }
                }
            }
            
            file.Close();
        }
        
        Console.WriteLine();
        foreach (var stack in stacks)
        {
            Console.Write(stack.Peek());
        }
        //Console.WriteLine(topCrates);
    }
}