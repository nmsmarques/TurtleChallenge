using System.Collections.Generic;
using TurtleChallenge.Enums;
using TurtleChallenge.Models.Interfaces;

namespace TurtleChallenge.Models
{
    /// <summary>
    /// The game settings class
    /// </summary>
    public class GameSettings : ISettings
    {
        /// <summary>
        /// The board size configuration
        /// </summary>
        public BoardSize BoardSize { get; set; }

        /// <summary>
        /// Turtle starting coordinates
        /// </summary>
        public Coordinates StartingCoordinates { get; set; }

        public EDirections Direction { get; set; }

        /// <summary>
        /// The exit point coordinates
        /// </summary>
        public Coordinates ExitPoint { get; set; }

        /// <summary>
        /// List of mines location
        /// </summary>
        public IEnumerable<Coordinates> MinesLocation { get; set; }
    }
}