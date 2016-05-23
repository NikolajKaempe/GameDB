using GameDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Web.Mvc;

namespace GameDB.Repositories
{
    public class GameRepository : IRepository<Game>
    {

        ApplicationDbContext db = new ApplicationDbContext();

        public void Delete(int id)
        {
            db.Games.Remove(db.Games.Find(id));
            db.SaveChanges();
        }

        public Game Find(int id)
        {
            return db.Games.Find(id);
        }

        public List<Game> GetAll()
        {


            return db.Games.ToList();
        }

        public void InsertOrUpdate(Game game)
        {
            if (game.GameID == 0)
            {
                db.Games.Add(game);
            }
            else
            {
                db.Entry(game).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
        }

    }
}