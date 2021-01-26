using System.Collections.Generic;

namespace TurtleChallenge.Models.Interfaces
{
    /// <summary>
    /// IBoard interface
    /// </summary>
    public interface IBoard
    {
        /// <summary>
        /// Create a new game board
        /// </summary>
        /// <param name="boardSize">The board size</param>
        /// <param name="mines">List with coordinates of Mines location</param>
        /// <param name="exit">Coordinates with Exit location</param>
        /// <param name="turtle">Coordinates with Turtle location</param>
        void Create(BoardSize boardSize, IEnumerable<Coordinates> mines, Coordinates exit, Coordinates turtle);

        /// <summary>
        /// Validate if the board size is allowed
        /// </summary>
        /// <param name="boardSize">Actual board size</param>
        /// <returns>True if the board size its ok, otherwise throw an exception</returns>
        bool Validate(BoardSize boardSize);

        /// <summary>
        /// Validate if the given coordinate is valid
        /// </summary>
        /// <param name="position">Coordinates X & Y</param>
        /// <returns>True all coordinates are ok, otherwise false</returns>
        bool ValidatePosition(Coordinates position);
    }
}