using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters;
using Newtonsoft.Json;
using TurtleChallenge.ConsoleApp.Services;
using TurtleChallenge.Enums;
using TurtleChallenge.Models;

namespace TurtleChallenge.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Startup();
        }

        /// <summary>
        /// Startup method will initialize the game
        /// </summary>
        private static void Startup()
        {
            var gameSettings = (GameSettings)SettingsFactory.Instance.GetGameSettings(ESettingType.Game);
            var moves = (MovesSettings)SettingsFactory.Instance.GetGameSettings(ESettingType.Moves);

            var board = new Board(gameSettings.BoardSize, gameSettings.MinesLocation, gameSettings.ExitPoint, gameSettings.StartingCoordinates);
            var turtle = new Turtle(gameSettings.StartingCoordinates, gameSettings.Direction);
            var rSeed = new Random();
            //PrintBoard(board);

            foreach (var move in moves.Moves)
            {
                var game = new Game(board, turtle);
                var results = game.Play(move);
                PrintResult(results);

                turtle.Position.CoordinateX = rSeed.Next(0, board.BoardSize.Width);
                turtle.Position.CoordinateY = rSeed.Next(0, board.BoardSize.Height);
                board.Create(gameSettings.BoardSize, gameSettings.MinesLocation, gameSettings.ExitPoint, turtle.Position);
            }
        }

        /// <summary>
        /// Print Results that came from game
        /// </summary>
        /// <param name="results">All results from one iteration</param>
        private static void PrintResult(IEnumerable<string> results)
        {
            //Base 1, no need to be zero base it's only for presentation purposes
            int counter = 1;

            foreach (string result in results)
            {
                Console.WriteLine($"Sequence {counter}: {result}");
                counter++;
            }
        }
    }
}
