using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using TurtleChallenge.Enums;
using TurtleChallenge.Models;
using TurtleChallenge.Models.Interfaces;

namespace TurtleChallenge.ConsoleApp.Services
{
    /// <summary>
    /// The Settings factory class
    /// </summary>
    public class SettingsFactory
    {
        /// <summary>
        /// The instance of SettingsFactory
        /// </summary>
        private static SettingsFactory instance = null;

        /// <summary>
        /// Empty SettingsFactory constructor
        /// </summary>
        public SettingsFactory()
        {
        }

        /// <summary>
        /// Singleton, get an instance of SettingsFactory
        /// </summary>
        public static SettingsFactory Instance => instance ?? (instance = new SettingsFactory());

        /// <summary>
        /// Loads the settings from the config json files
        /// </summary>
        /// <param name="settingsType">The settings type to load</param>
        /// <returns>ISettings with the settings load</returns>
        public ISettings GetGameSettings(ESettingType settingsType)
        {
            string filePath = String.Empty;
            ISettings settings;
            switch (settingsType)
            {
                case ESettingType.Game:
                    settings = JsonConvert.DeserializeObject<GameSettings>(File.ReadAllText("GameSettings.json"));
                    break;
                case ESettingType.Moves:
                    settings = JsonConvert.DeserializeObject<MovesSettings>(File.ReadAllText("MovesSettings.json"));
                    break;
                default:
                    throw new Exception("The provided type doesn't exist!");
            }

            return settings;
        }
    }
}