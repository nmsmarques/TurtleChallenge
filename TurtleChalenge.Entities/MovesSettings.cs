using System.Collections.Generic;
using System.Transactions;
using TurtleChallenge.Enums;
using TurtleChallenge.Models.Interfaces;

namespace TurtleChallenge.Models
{
    /// <summary>
    /// The moves settings class
    /// </summary>
    public class MovesSettings : ISettings
    {
        /// <summary>
        /// List with a list of moves
        /// </summary>
        public IEnumerable<IEnumerable<EAction>> Moves { get; set; }
    }
}