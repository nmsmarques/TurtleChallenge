using System;

namespace TurtleChallenge.Models
{
    /// <summary>
    /// The cell class, that represents a single cell on the board
    /// </summary>
    public class Cell
    {
        /// <summary>
        /// If a cell is empty or not
        /// </summary>
        public bool IsEmpty { get; set; }

        /// <summary>
        /// If it is an exit or not
        /// </summary>
        public bool IsExit { get; set; }

        /// <summary>
        /// If it is a mine or not
        /// </summary>
        public bool IsMine { get; set; }

        /// <summary>
        /// If it is a turtle or not
        /// </summary>
        public bool IsTurtle { get; set; }

        /// <summary>
        /// Initialize the Cell class
        /// </summary>
        public Cell()
        {
            this.IsExit = false;
            this.IsMine = false;
            this.IsTurtle = false;
            this.IsEmpty = !IsExit && !IsMine && !IsTurtle;
        }

    }
}