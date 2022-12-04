namespace AdventOfCode2022.Task2
{
    class Task2 : AdventTask
    {
        private const int WIN_POINTS = 6;
        private const int DRAW_POINTS = 3;
        private const int LOSE_POINTS = 0;
        
        private const int ROCK_POINTS = 1;
        private const int PAPER_POINTS = 2;
        private const int SCISSORS_POINTS = 3;

        private int currentPoints;
        
        public override void Execute()
        {
            base.Execute();
            FindScoreBasedOnStrategyGuide();
        }

        
        // A - Rock, B - Paper, C - Scissors | X - Rock, Y - Paper, Z - Scissors
        private void FindScoreBasedOnStrategyGuide()
        {
            int i = 0;
            foreach (var line in File.ReadLines("./Task2/data.txt"))
            {

                int pointsForBattleOutcome = GetPointsForBattleOutcome(line[0], line[2]);
                int pointsForYourHandShape = GetPointsForHandShape(line[2]);
                int sum = pointsForBattleOutcome + pointsForYourHandShape;
                currentPoints += sum;
                
                Console.WriteLine($"{i}: Line: {line} -- Points for battle: {pointsForBattleOutcome}, points for hand shape: {pointsForYourHandShape}, CURRENT POINTS: {currentPoints}");
                i++;
            }
            Console.WriteLine($"Final score: {currentPoints}");
        }

        private int GetPointsForBattleOutcome(char enemyHandShape, char yourHandShape)
        {
            switch (enemyHandShape)
            {
                case 'A':
                {
                    if (yourHandShape == 'X') return DRAW_POINTS;
                    if (yourHandShape == 'Y') return WIN_POINTS;
                    if (yourHandShape == 'Z') return LOSE_POINTS;
                    break;
                }
                case 'B':
                {
                    if (yourHandShape == 'X') return LOSE_POINTS;
                    if (yourHandShape == 'Y') return DRAW_POINTS;
                    if (yourHandShape == 'Z') return WIN_POINTS;
                    break;
                }
                case 'C':
                {
                    if (yourHandShape == 'X') return WIN_POINTS;
                    if (yourHandShape == 'Y') return LOSE_POINTS;
                    if (yourHandShape == 'Z') return DRAW_POINTS;
                    break;
                }
            }

            throw new InvalidOperationException($"No possible outcome for {enemyHandShape} and {yourHandShape}");
        }

        private int GetPointsForHandShape(char yourHandShape)
        {
            switch (yourHandShape)
            {
                case 'X':
                {
                    return ROCK_POINTS;
                }
                case 'Y':
                {
                    return PAPER_POINTS;
                }
                case 'Z':
                {
                    return SCISSORS_POINTS;
                }
            }

            throw new InvalidOperationException($"No hand shape as {yourHandShape}");
        }
    }
}