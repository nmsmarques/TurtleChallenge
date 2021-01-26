using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TurtleChallenge.Models.Interfaces;

namespace TurtleChallenge.Models
{
    /// <summary>
    /// The Board class that inherit from IBoard
    /// </summary>
    public class Board : IBoard
    {
        /// <summary>
        /// The Cell bidimensional array that represents the game board
        /// </summary>
        public Cell[,] GameBoard { get; set; }

        /// <summary>
        /// The board size
        /// </summary>
        public BoardSize BoardSize { get; set; }

        /// <summary>
        /// Initialize Board class
        /// </summary>
        /// <param name="boardSize">The board size</param>
        /// <param name="mines">List with coordinates of Mines location</param>
        /// <param name="exit">Coordinates with Exit location</param>
        /// <param name="turtle">Coordinates with Turtle location</param>
        public Board(BoardSize boardSize, IEnumerable<Coordinates> mines, Coordinates exit, Coordinates turtle)
        {
            this.BoardSize = boardSize;
            this.Validate(boardSize);
            this.Create(boardSize, mines, exit, turtle);
        }

        ///<inheritdoc cref="IBoard"/>
        public void Create(BoardSize boardSize, IEnumerable<Coordinates> mines, Coordinates exit, Coordinates turtle)
        {
            var cell = new Cell[boardSize.Width, boardSize.Height];

            for (var i = 0; i <= boardSize.Width-1; i++)
            {
                for (var j = 0; j <= boardSize.Height-1; j++)
                {
                    cell[i, j] = new Cell();
                    var actualCoordinates = new Coordinates {CoordinateX = i, CoordinateY = j};
                    if (mines.Any(m => m.CoordinateX == i && m.CoordinateY == j) && ValidatePosition(actualCoordinates))
                    {
                        cell[i, j].IsMine = true;
                    }
                    else
                    {
                        cell[i, j].IsEmpty = true;
                    }
                }
            }

            if (ValidatePosition(exit))
            {
                cell[exit.CoordinateX, exit.CoordinateY].IsExit = true;
            }

            if (ValidatePosition(turtle))
            {
                cell[turtle.CoordinateX, turtle.CoordinateY].IsTurtle = true;
            }

            this.GameBoard = cell;
        }

        ///<inheritdoc cref="IBoard"/>
        public bool Validate(BoardSize boardSize)
        {
            if (boardSize.Width <= 0 || boardSize.Height <= 0)
            {
                throw new Exception("The provided board size should be bigger than zero!");
            }

            return true;
        }
        
        ///<inheritdoc cref="IBoard"/>
        public bool ValidatePosition(Coordinates position)
        {
            return position.CoordinateX >= 0 && position.CoordinateX < this.BoardSize.Width &&
                   position.CoordinateY >= 0 && position.CoordinateY < this.BoardSize.Height;
        }
    }
}