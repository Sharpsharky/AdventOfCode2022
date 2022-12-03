namespace AdventOfCode2022.Task1
{
    class Task1 : AdventTask
    {
        private List<int> elvesCalories = new List<int>();
        
        public void Execute()
        {
            Console.WriteLine($"Hello World {this}");
            ReadElvesCalories();
        }
        
        private void ReadElvesCalories()
        {
            int accumulator = 0;
            var lines =  File.ReadAllLines("./Task1/data.txt");
            foreach (var line in lines)
            {
                if (String.IsNullOrEmpty(line))
                {
                    elvesCalories.Add(accumulator);
                    accumulator = 0;
                    continue;
                } 
                
                int numberToAdd = 0;
                Int32.TryParse(line, out numberToAdd);
                accumulator += numberToAdd;
            }
            if (accumulator != 0) elvesCalories.Add(accumulator);

            int mostCalories = elvesCalories.Max();
            int mostCaloriesCheck = elvesCalories.OrderDescending().Take(1).Sum();
            int top3ElvesCalories = elvesCalories.OrderDescending().Take(3).Sum();
            
            Console.WriteLine($"Most calories: {mostCalories}, {mostCaloriesCheck}");
            Console.WriteLine($"Top3 calories: {top3ElvesCalories}");

        }
        
    }
}