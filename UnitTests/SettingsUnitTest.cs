using System.IO;
using Newtonsoft.Json;
using TurtleChallenge.ConsoleApp.Services;
using TurtleChallenge.Enums;
using TurtleChallenge.Models;
using Xunit;

namespace TurtleChallenge.UnitTests
{
    public class SettingsUnitTest
    {
        [Fact]
        public void ItShouldGetAllGameSettingsFromFile()
        {
            var gameSettings = (GameSettings)SettingsFactory.Instance.GetGameSettings(ESettingType.Game);

            Assert.Equal(5, gameSettings.BoardSize.Height);
            Assert.Equal(5, gameSettings.BoardSize.Width);
            Assert.Equal(0, gameSettings.StartingCoordinates.CoordinateX);
            Assert.Equal(0, gameSettings.StartingCoordinates.CoordinateY);
            Assert.Equal(EDirections.North, gameSettings.Direction);
            Assert.Equal(4, gameSettings.ExitPoint.CoordinateX);
            Assert.Equal(4, gameSettings.ExitPoint.CoordinateY);
            foreach (var mines in gameSettings.MinesLocation)
            {
                Assert.InRange(mines.CoordinateX, 0, gameSettings.BoardSize.Width);
                Assert.InRange(mines.CoordinateY, 0, gameSettings.BoardSize.Height);
            }
        }
    }
}