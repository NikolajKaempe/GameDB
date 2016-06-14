using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameDB.Repositories;
using Moq;
using GameDB.Controllers;
using GameDB.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetAllGames()
        {
            // Arrange
            Mock<GameRepository> MockRepo = new Mock<GameRepository>();
            GameController Controller = new GameController(MockRepo.Object);

            var Game1 = new Game
            {
                Name = "LeagueOfLesbians",
                Rating = 4.1,
                ReleaseDate = new DateTime(),
                Author = "Emil",
                PlatformList = new List<Platform>(),
                CharList = new List<Character>(),
            };

            var Game2 = new Game
            {
                Name = "HoTS",
                Rating = 3.1,
                ReleaseDate = new DateTime(),
                Author = "Peter",
                PlatformList = new List<Platform>(),
                CharList = new List<Character>(),
            };

            List<Game> Games = new List<Game>();
            Games.Add(Game1);
            Games.Add(Game2);

            // Act
            MockRepo.Setup(x => x.GetAll()).Returns(() => Games);

            // Assert
            MockRepo.Verify(x => x.GetAll());

        }

    [TestMethod]
    public void CreateGame()
    {
        // Arrange
        Mock<GameRepository> MockRepo = new Mock<GameRepository>();
        GameController Controller = new GameController(MockRepo.Object);

        var Game1 = new Game
        {
            Name = "LeagueOfLesbians",
            Rating = 4.1,
            ReleaseDate = new DateTime(),
            Author = "Emil",
            PlatformList = new List<Platform>(),
            CharList = new List<Character>(),
        };

        var Result = Controller.Create(Game1, null) as ViewResult;

    }
}
}
