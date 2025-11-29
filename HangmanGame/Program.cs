using System;

namespace HangmanGame
{
    class Game
    {
        private static readonly Random _random = new Random();
        private readonly string[] _words = { "apple", "lion", "doctor", "cat", "pen" };
        private readonly string _name;
        private string _guessed;
        private int _currentLives = 6;
        private readonly int _totalLives = 6;

        public Game()
        {
            _name = _words[_random.Next(_words.Length)];
            _guessed = new string('_', _name.Length);
        }

        public void Start()
        {
            while (true)
            {
                Console.Clear();
                DrawHangman();

                Console.WriteLine($"Word: {_guessed}");
                Console.WriteLine($"Lives: {_currentLives}/{_totalLives}");
                Console.WriteLine("Guess a letter:");

                string? input = Console.ReadLine();
                input = input?.Trim().ToLower();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Invalid input. Try again.\n");
                    continue;
                }

                char userInput = input[0];

                if (!IsValidChoice(userInput))
                {
                    Console.WriteLine("Please enter a valid letter (a-z).\n");
                    continue;
                }

                if (_name.Contains(userInput))
                {
                    for (int i = 0; i < _name.Length; i++)
                    {
                        if (_name[i] == userInput)
                        {
                            _guessed = _guessed.Remove(i, 1).Insert(i, userInput.ToString());
                        }
                    }
                }
                else
                {
                    _currentLives--;
                }

                if (_currentLives <= 0)
                {
                    Console.Clear();
                    DrawHangman();
                    Console.WriteLine($"You lost! The word was '{_name}'.");
                    return;
                }

                if (_guessed == _name)
                {
                    Console.Clear();
                    Console.WriteLine($"Word: {_guessed}");
                    Console.WriteLine("Congratulations! You've guessed the word!");
                    return;
                }
            }
        }

        private bool IsValidChoice(char? choice)
        {
            return choice is >= 'a' and <= 'z';
        }

        private void DrawHangman()
        {
            int stage = _totalLives - _currentLives;

            string[] hangman = new string[]
            {
                // Stage 0
                @"
  +---+
  |   |
      |
      |
      |
      |
=========",
                // Stage 1
                @"
  +---+
  |   |
  O   |
      |
      |
      |
=========",
                // Stage 2
                @"
  +---+
  |   |
  O   |
  |   |
      |
      |
=========",
                // Stage 3
                @"
  +---+
  |   |
  O   |
 /|   |
      |
      |
=========",
                // Stage 4
                @"
  +---+
  |   |
  O   |
 /|\  |
      |
      |
=========",
                // Stage 5
                @"
  +---+
  |   |
  O   |
 /|\  |
 /    |
      |
=========",
                // Stage 6
                @"
  +---+
  |   |
  O   |
 /|\  |
 / \  |
      |
========="
            };

            Console.WriteLine(hangman[Math.Min(stage, hangman.Length - 1)]);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
        }
    }
}
