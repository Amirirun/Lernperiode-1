using System;
using System.Threading;

class Program
{
    static int birdPosition;
    static int obstaclePosition;
    static int obstacleHeight;
    static int score;
    static int fieldHeight = 20;
    static int fieldWidth = 50;
    static bool isGameRunning;

    static void Main(string[] args)
    {
        Console.CursorVisible = false;
        Console.SetWindowSize(fieldWidth, fieldHeight + 2);
        Console.SetBufferSize(fieldWidth, fieldHeight + 2);

        // Start the game
        LaunchGame();
    }

    static void LaunchGame()
    {
        birdPosition = fieldHeight / 2; // Bird starts in the middle
        obstaclePosition = fieldWidth - 1; // Obstacle starts at the right edge
        obstacleHeight = 5; // Initial height of the obstacle
        score = 0;
        isGameRunning = true;

        while (isGameRunning)
        {
            GameLogic();
            DrawField();
            ProcessInput();
            Thread.Sleep(100); // Game speed
        }

        // After Game Over, restart
        Console.Clear();
        Console.WriteLine("Game Over! Your score: " + score);
        Console.WriteLine("Press 'R' to restart...");

        // Wait for 'R' key to restart the game
        while (Console.ReadKey(true).Key != ConsoleKey.R)
        {
        }

        LaunchGame();
    }

    static void GameLogic()
    {
        obstaclePosition--;

        if (obstaclePosition < 0)
        {
            obstaclePosition = fieldWidth - 1;
            obstacleHeight = new Random().Next(3, fieldHeight - 3);
            score++;
        }

        birdPosition++;

        // Nested if for collision
        if (birdPosition >= fieldHeight)
        {
            isGameRunning = false;
        }
        else if (obstaclePosition == 5 && (birdPosition < obstacleHeight || birdPosition > obstacleHeight + 3))
        {
            isGameRunning = false;
        }
    }

    static void DrawField()
    {
        Console.Clear();

        if (birdPosition >= 0 && birdPosition < fieldHeight)
        {
            Console.SetCursorPosition(5, birdPosition);
            Console.Write("O"); // Bird is "O"
        }

        for (int i = 0; i < fieldHeight; i++)
        {
            if ((i < obstacleHeight || i > obstacleHeight + 3) && obstaclePosition >= 0 && obstaclePosition < fieldWidth)
            {
                Console.SetCursorPosition(obstaclePosition, i);
                Console.Write("|"); // Obstacle is "|"
            }
        }

        // Draw score in the top-right corner
        Console.SetCursorPosition(fieldWidth - 10, 0);
        Console.Write("Score: " + score);
    }

    static void ProcessInput()
    {
        // Process user input
        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Spacebar) // Bird flies up when the spacebar is pressed
            {
                birdPosition -= 3;
            }
        }
    }
}
