﻿
using MyFirstProgram.Models;

namespace MyFirstProgram
{
    internal class Helpers
    {
        internal static List<Game> games = new(){              };

        internal static int[] GetDivisionNumbers()
        {
            var random = new Random();
            var firstNumber = random.Next(0, 99);
            var secondNumber = random.Next(0, 99);

            var result = new int[2];

            while (firstNumber % secondNumber != 0)
            {
                firstNumber = random.Next(1, 99);
                secondNumber = random.Next(1, 99);
            }

            result[0] = firstNumber;
            result[1] = secondNumber;

            return result;
        }

        internal static void PrintGames()
        {
            //var gamesToPrint = games.Where(x => x.Date > new DateTime(2022, 08, 09));

            Console.Clear();
            Console.WriteLine("Games History");
            Console.WriteLine("--------------------->");
            foreach (var game in games)
            {
                Console.WriteLine($"{game.Date}- {game.Type}: {game.Score} pts");
            }
            Console.WriteLine("--------------------->\n");
            Console.WriteLine("Press any key to return to Main Menu");
            Console.ReadLine();
        }

        internal static void AddToHistory(int gameScore, GameType gameType)
        {
            games.Add(new Game
            {
                Date = DateTime.Now,
                Score = gameScore,
                Type = gameType

            });
        }

        internal static string? ValidateResult(string result)
        {
            while (string.IsNullOrEmpty(result) || !Int32.TryParse(result, out _))
            {
                Console.WriteLine("Your answer must be an integer. Please try again!");
                result = Console.ReadLine();
            }
            return result;
        }

        internal static string GetName()
        {
            Console.WriteLine("Please type your name");
            var name = Console.ReadLine();

            while (string.IsNullOrEmpty(name)) 
            { 
                Console.WriteLine("Name can't be empty");
                name = Console.ReadLine();
            }

            return name;
        }

        public void SelectDifficult(GameEngine gameEngine)
        {
        
            Console.WriteLine($@"Please select the difficult of this game:
                E - Easy
                M - Medium
                H - Hard
            
                ");

            Console.WriteLine("--------------------->");
            var difficultSelected = Console.ReadLine();


            var random = new Random();

            switch (difficultSelected.Trim().ToLower())
            {
                case "e":
                    gameEngine.firstNumber = random.Next(1, 10);
                    gameEngine.secondNumber = random.Next(1, 10);
                    break;

                case "m":
                    gameEngine.firstNumber = random.Next(1, 50);
                    gameEngine.secondNumber  = random.Next(1, 50);
                    break;

                case "h":
                    gameEngine.firstNumber = random.Next(1, 100);
                    gameEngine.secondNumber = random.Next(1, 100);
                    break;

                default:
                    Console.WriteLine("Opción no válida. Seleccionando dificultad por defecto.");
                    gameEngine.firstNumber = random.Next(1, 10); ; // Dificultad por defecto
                    gameEngine.secondNumber = random.Next(1, 10); ; // Rango por defecto
                    break;
            }

        }
    }

        

       


