using GameDB.Models;
using GameDB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameDB.Controllers
{
    public class CharacterController : Controller
    {
        CharacterRepository charRepo = new CharacterRepository();
        Game currentGame;

        [HttpGet]
        public ActionResult Create(Game game)
        {
            currentGame = game;
            return View(game);
        }

        [HttpPost]
        public ActionResult Create(Game game, Character character)
        {
            if (ModelState.IsValid)
            {
                
            }
            return View(game);
        }
       
    }
}