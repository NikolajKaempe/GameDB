using GameDB.Models;
using GameDB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameDB.Controllers
{
    public class GameController : Controller
    {
        GameRepository gameRepo = new GameRepository();

        public ActionResult Index()
        {
            return View(gameRepo.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Game game)
        {
            if (ModelState.IsValid)
            {
                gameRepo.InsertOrUpdate(game);
                return View("CreatedGame",game);
            }
            return View();
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(gameRepo.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(Game game)
        {
            if(ModelState.IsValid)
            {
                gameRepo.InsertOrUpdate(game);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            gameRepo.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(gameRepo.Find(id));
        }
    }
}