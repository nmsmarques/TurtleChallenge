using TurtleChallenge.Enums;

namespace TurtleChallenge.Models
{
    /// <summary>
    /// The turtle class
    /// </summary>
    public class Turtle
    {
        /// <summary>
        /// The direction enum
        /// </summary>
        public EDirections Direction { get; set; }

        /// <summary>
        /// The position based in two axis x & y
        /// </summary>
        public Coordinates Position { get; set; }

        /// <summary>
        /// Initialize Turtle class
        /// </summary>
        /// <param name="position"></param>
        /// <param name="direction"></param>
        public Turtle(Coordinates position, EDirections direction)
        {
            this.Position = position;
            this.Direction = direction;
        }

        /// <summary>
        /// Set the right direction, rotating 90 degrees right from actual position
        /// </summary>
        public void Rotate()
        {
            switch (this.Direction)
            {
                case EDirections.North:
                    Direction = EDirections.East;
                    break;
                case EDirections.East:
                    Direction = EDirections.South;
                    break;
                case EDirections.South:
                    Direction = EDirections.West;
                    break;
                case EDirections.West:
                    Direction = EDirections.North;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Increase or decrease position based on direction
        /// </summary>
        /// <param name="boardMaxSize">Actual board size</param>
        public void Move(BoardSize boardMaxSize)
        {
            switch (Direction)
            {
                case EDirections.North:
                    if((Position.CoordinateX - 1) >= 0) { Position.CoordinateX--; }
                    break;
                case EDirections.South:
                    if((Position.CoordinateX + 1) < boardMaxSize.Height){ Position.CoordinateX++; }
                    break;
                case EDirections.East:
                    if((Position.CoordinateY + 1) < boardMaxSize.Width){ Position.CoordinateY++; }
                    break;
                case EDirections.West:
                    if (Position.CoordinateY - 1 >= 0) { Position.CoordinateY--; }
                    break;
                default:
                    break;
            }
        }
    }
}