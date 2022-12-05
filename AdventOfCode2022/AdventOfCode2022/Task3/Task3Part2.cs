namespace AdventOfCode2022.Task3;

public class Task3Part2 : AdventTask
{
    private int finalSumOfPriorities = 0;

    private Dictionary<char, int> symbolPriorities = new Dictionary<char, int>();

    private const int LOWER_A_IN_ASCII = 97;
    private const int LOWER_Z_IN_ASCII = 122;
    private const int UPPER_A_IN_ASCII = 65;
    private const int UPPER_Z_IN_ASCII = 90;
    public override void Execute()
    {
        base.Execute();
        InitializePriorityDictionaries();
        FindBadgesPriorities();
        Console.WriteLine($"Final sum of compartment: {finalSumOfPriorities}");
    }

    private void InitializePriorityDictionaries()
    {
        int priority = 1;
        for (int i = LOWER_A_IN_ASCII; i <= LOWER_Z_IN_ASCII; i++)
        {
            symbolPriorities.Add((char)i, priority);
            priority++;
        }
        for (int i = UPPER_A_IN_ASCII; i <= UPPER_Z_IN_ASCII; i++)
        {
            symbolPriorities.Add((char)i, priority);
            priority++;
        }
    }

    private void FindBadgesPriorities()
    {
        var lines = File.ReadAllLines("./Task3/data.txt");

        for (int i = 0; i < lines.Length; i += 3)
        {
            int badgePriority = FindTheBadgeAndGetPriority(lines[i], lines[i+1], lines[i+2]);
            finalSumOfPriorities += badgePriority;
        }
    }

    private int FindTheBadgeAndGetPriority(string bag1, string bag2, string bag3)
    {
        foreach (var itemInBag in bag1)
        {
            if (FindIfTheItemIsTheBadge(itemInBag, bag2, bag3))
            {
                Console.WriteLine($"Found item: {itemInBag}");
                return symbolPriorities[itemInBag];
            }
        }
        
        throw new InvalidOperationException($"No possible outcome for {bag1}");
    }
    
    private bool FindIfTheItemIsTheBadge(char item, string bag2, string bag3)
    {
        if (bag2.Contains(item) && bag3.Contains(item)) return true;
        return false;
    }
    
}
