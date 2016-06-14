using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameDB.Repositories;
using Moq;
using GameDB.Controllers;
using GameDB.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetAllGames()
        {
            // Arrange            
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

            Mock<GameRepository> MockRepo = new Mock<GameRepository>();
            MockRepo.Setup(mr => mr.GetAll()).Returns(Games);
            GameController Controller = new GameController(MockRepo.Object);

            // Act
            var Result = Controller.Index() as ViewResult;

            // Assert

            var Model = (List<Game>)Result.Model;
            CollectionAssert.Contains(Model, Game1);
            CollectionAssert.Contains(Model, Game2);

        }

        [TestMethod]
        public void GetGame()
        {
            //Arrange

            //Act

            //Assert

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

            // Act
            var Result = Controller.Create(Game1, null) as ViewResult;

            // Arrange
            Assert.AreEqual("Create", Result.ViewName);

            //TODO MAKE BETTER TEST.. Evt get List og se om item er added.
        }
    }
}
