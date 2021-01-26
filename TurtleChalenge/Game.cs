using System;
using System.Collections.Generic;
using TurtleChallenge.Enums;
using TurtleChallenge.Models;

namespace TurtleChallenge.ConsoleApp
{
    /// <summary>
    /// The Game class
    /// </summary>
    public class Game
    {
        /// <summary>
        /// The game Board
        /// </summary>
        private readonly Board Board;

        /// <summary>
        /// The character Turtle
        /// </summary>
        private readonly Turtle Turtle;

        /// <summary>
        /// Initialize Game class
        /// </summary>
        /// <param name="board"></param>
        /// <param name="turtle"></param>
        public Game(Board board, Turtle turtle)
        {
            Board = board ?? throw new ArgumentNullException(nameof(board));
            Turtle = turtle ?? throw new ArgumentNullException(nameof(turtle));
        }

        /// <summary>
        /// The game play, it's responsible to process each set of actions and play them
        /// </summary>
        /// <param name="actions">List of actions</param>
        /// <returns>The list of results of each move</returns>
        public IEnumerable<string> Play(IEnumerable<EAction> actions)
        {
            if (actions == null) throw new ArgumentNullException(nameof(actions));

            var play = new List<string>();
            if (!Board.ValidatePosition(Turtle.Position))
                throw new Exception("Turtle is out of bounds!");

            try
            {
                foreach (var move in actions)
                {
                    if (move == EAction.Rotate)
                    {
                        Turtle.Rotate();
                        continue;
                    }

                    Turtle.Move(Board.BoardSize);
                    

                    var cell = Board.GameBoard[Turtle.Position.CoordinateX, Turtle.Position.CoordinateY];

                    if (cell.IsMine)
                    {
                        play.Add($"Mine hit! X:{Turtle.Position.CoordinateX} - Y:{Turtle.Position.CoordinateY}");
                    }

                    if (cell.IsExit)
                    {
                        play.Add($"Success! X:{Turtle.Position.CoordinateX} - Y:{Turtle.Position.CoordinateY}");
                    }
                }

                play.Add($"Still in danger! X:{Turtle.Position.CoordinateX} - Y:{Turtle.Position.CoordinateY}");

            }
            catch (Exception e)
            {
                throw e;
            }

            return play;
        }
    }
}