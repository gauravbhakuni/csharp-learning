using System;

namespace RockPaperScissor
{
    class Game
    {
        private readonly Random _random = new Random();

        public void Start()
        {
            int userwins = 0;
            int computerwins = 0;

            while (true)
            {
                Console.Write("Select rock (r), paper (p), scissor (s) or type exit: ");
                string? input = Console.ReadLine();
                string userInput = input?.Trim().ToLower() ?? "";

                if (userInput == "exit")
                {
                    Console.WriteLine("Game ended.");
                    return;
                }

                if (!IsValidChoice(userInput))
                {
                    Console.WriteLine("Invalid choice. Try again.\n");
                    continue;
                }

                string computerInput = GenerateComputerChoice();
                Console.WriteLine($"Computer selected: {computerInput}");

                string result = DetermineWinner(userInput, computerInput);
                Console.WriteLine(result + "\n");
                if (result == "You win!")
                    userwins++;
                else if (result == "Computer wins!")
                    computerwins++;
                Console.WriteLine($"Score => You: {userwins}, Computer: {computerwins}\n");
            }
        }

        private bool IsValidChoice(string? choice)
        {
            return choice is "r" or "p" or "s";
        }

        private string GenerateComputerChoice()
        {
            return _random.Next(1, 4) switch
            {
                1 => "r",
                2 => "p",
                _ => "s"
            };
        }

        private string DetermineWinner(string user, string computer)
        {
            if (user == computer)
                return "It's a tie!";
            if ((user == "r" && computer == "s") ||
                (user == "p" && computer == "r") ||
                (user == "s" && computer == "p"))
                return "You win!";
            return "Computer wins!";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Game().Start();
        }
    }
}
