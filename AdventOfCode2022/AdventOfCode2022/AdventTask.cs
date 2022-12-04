namespace AdventOfCode2022
{
    public abstract class AdventTask
    {
        public virtual void Execute()
        {
            Console.WriteLine($"Execute Task {this}");
        }
    }
}