namespace AdventOfCode2022.Task3;

public class Task3 : AdventTask
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
        FindIncorrectlyArrangedItems();
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

    private void FindIncorrectlyArrangedItems()
    {
        int compartmentIndex = 0;
        foreach (var line in File.ReadLines("./Task3/data.txt"))
        {
            int lineLength = line.Length;
            string firstCompartment = line.Substring(0, lineLength / 2);
            string secondCompartment = line.Substring(lineLength / 2,lineLength / 2);

            int compartmentPriority = CompareBothCompartmentsAndGetPriority(firstCompartment, secondCompartment);
            finalSumOfPriorities += compartmentPriority;
            
            //Console.WriteLine($"Compartment {compartmentIndex} priority: {compartmentPriority}");
            compartmentIndex++;
        }
    }

    private int CompareBothCompartmentsAndGetPriority(string firstCompartment, string secondCompartment)
    {
        int compartmentPriority = 0;
        HashSet<char> alreadyUsedItems = new HashSet<char>();
        foreach (var character in firstCompartment)
        {
            if (!alreadyUsedItems.Contains(character) && secondCompartment.Contains(character))
            {
                compartmentPriority += symbolPriorities[character];
                //Console.WriteLine($"Character {character} adds priority: {symbolPriorities[character]}");

                if (!alreadyUsedItems.Contains(character)) alreadyUsedItems.Add(character);
            }
        }

        return compartmentPriority;
    }
    
}
