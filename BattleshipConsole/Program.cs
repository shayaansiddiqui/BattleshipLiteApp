using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleshipLiteLibrary;
using BattleshipLiteLibrary.Models;

namespace BattleshipConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WelcomeMessage();
            PlayerInfoModel player = new PlayerInfoModel() {UserName = "Shayaan", ShipLocations = new List<GridSpotModel>(), ShotGrid = new List<GridSpotModel>()};
        }

        private static void WelcomeMessage()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Welcome to Battleship Lite");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("created by Shayaan Siddiqui");
            Console.WriteLine();
        }

        private static PlayerInfoModel CreatePlayer()
        {
            PlayerInfoModel output = new PlayerInfoModel();
            // Ask User for their name
            output.UserName = AskForUserName();
            // Load up the shot grid
            GameLogic.InitializeGrid(output);
            // Ask user to place 5 ships

            // Clear
            return output;
        }

        private static string AskForUserName()
        {
            Console.Write("What is your name:\t");
            string output = Console.ReadLine();
            return output;
        }

        private static void PlaceShip(PlayerInfoModel model)
        {
            do
            {
                Console.Write($"Please place ship number {model.ShipLocations.Count + 1}: ");
                string location = Console.ReadLine();
                bool isValidLocation = GameLogic.StoreShot(model, location);
            }while(model.ShipLocations.Count < 5);
        }
    }
}
