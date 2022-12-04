namespace AdventOfCode2022.Task2;

public class Task2Part2 : AdventTask
{
    private const int WIN_POINTS = 6;
    private const int DRAW_POINTS = 3;
    private const int LOSE_POINTS = 0;
    
    private const int ROCK_POINTS = 1;
    private const int PAPER_POINTS = 2;
    private const int SCISSORS_POINTS = 3;

    private const char ROCK = 'A';
    private const char PAPER = 'B';
    private const char SCISSORS= 'C';
    
    private const char LOSE = 'X';
    private const char DRAW = 'Y';
    private const char WIN = 'Z';
    
    private int currentPoints;
    
    public override void Execute()
    {
        base.Execute();
        FindScoreBasedOnStrategyGuide();
    }

    
    // A - Rock, B - Paper, C - Scissors | X - Lose, Y - Draw, Z - Win
    private void FindScoreBasedOnStrategyGuide()
    {
        int i = 0;
        foreach (var line in File.ReadLines("./Task2/data.txt"))
        {
            char neededShapeOutcome = GetHandShapeAccordingToNeededOutcome(line[0], line[2]);
            int pointsForBattleOutcome = GetPointsForBattleOutcome(line[0], neededShapeOutcome);
            int pointsForYourHandShape = GetPointsForHandShape(neededShapeOutcome);
            
            int sum = pointsForBattleOutcome + pointsForYourHandShape;
            currentPoints += sum;
            
            Console.WriteLine($"{i}: Line: {line} -- Needed shape: {neededShapeOutcome}, points for battle: {pointsForBattleOutcome}, points for hand shape: {pointsForYourHandShape}, CURRENT POINTS: {currentPoints}");
            i++;
        }
        Console.WriteLine($"Final score: {currentPoints}");
    }

    private char GetHandShapeAccordingToNeededOutcome(char enemyHandShape, char outcome)
    {
        switch (enemyHandShape)
        {
            case ROCK:
            {
                if (outcome == LOSE) return SCISSORS;
                if (outcome == DRAW) return ROCK;
                if (outcome == WIN) return PAPER;
                break;
            }
            case PAPER:
            {
                if (outcome == LOSE) return ROCK;
                if (outcome == DRAW) return PAPER;
                if (outcome == WIN) return SCISSORS;
                break;
            }
            case SCISSORS:
            {
                if (outcome == LOSE) return PAPER;
                if (outcome == DRAW) return SCISSORS;
                if (outcome == WIN) return ROCK;
                break;
            }
        }
        throw new InvalidOperationException($"No possible outcome for {enemyHandShape} and {outcome}");
    }

    private int GetPointsForBattleOutcome(char enemyHandShape, char yourHandShape)
    {
        switch (enemyHandShape)
        {
            case ROCK:
            {
                if (yourHandShape == ROCK) return DRAW_POINTS;
                if (yourHandShape == PAPER) return WIN_POINTS;
                if (yourHandShape == SCISSORS) return LOSE_POINTS;
                break;
            }
            case PAPER:
            {
                if (yourHandShape == ROCK) return LOSE_POINTS;
                if (yourHandShape == PAPER) return DRAW_POINTS;
                if (yourHandShape == SCISSORS) return WIN_POINTS;
                break;
            }
            case SCISSORS:
            {
                if (yourHandShape == ROCK) return WIN_POINTS;
                if (yourHandShape == PAPER) return LOSE_POINTS;
                if (yourHandShape == SCISSORS) return DRAW_POINTS;
                break;
            }
        }

        throw new InvalidOperationException($"No possible outcome for {enemyHandShape} and {yourHandShape}");
    }

    private int GetPointsForHandShape(char yourHandShape)
    {
        switch (yourHandShape)
        {
            case ROCK:
            {
                return ROCK_POINTS;
            }
            case PAPER:
            {
                return PAPER_POINTS;
            }
            case SCISSORS:
            {
                return SCISSORS_POINTS;
            }
        }

        throw new InvalidOperationException($"No hand shape as {yourHandShape}");
    }
}