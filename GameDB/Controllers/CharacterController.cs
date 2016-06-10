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
        CharacterRepository CharRepo = new CharacterRepository();

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Character());
        }

        [HttpPost]
        public ActionResult Create(Character character, HttpPostedFileBase image)
        {
                if (ModelState.IsValid)
                {
                    if (image != null)
                    {
                        character.ImageMimeType = image.ContentType;
                        character.ImageData = new byte[image.ContentLength];
                        image.InputStream.Read(character.ImageData, 0, image.ContentLength);
                    }
                int parentId = (int)Session["parentId"];
                character.ParentGameID = parentId;
                Session["parentId"] = null;
                CharRepo.InsertOrUpdate(character);
                return View("CreatedCharacter", character);
            }
            return View(character);
        }
       
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(CharRepo.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(Character character, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if(image != null)
                {
                    character.ImageMimeType = image.ContentType;
                    character.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(character.ImageData, 0, image.ContentLength);
                }
                CharRepo.InsertOrUpdate(character);
                int charID = character.CharacterID;
                return RedirectToAction("Details", new { id = charID });
            }
            return View(character);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
             
            CharRepo.Delete(id);
            return RedirectToAction("Details");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(CharRepo.Find(id));
        }

        public FileContentResult GetImage(int id)
        {
            Character character = CharRepo.Find(id);
           
            if (character != null)
            {
                return File(character.ImageData, character.ImageMimeType);
            }
            else
            {
                return null;
            }
          
        }
    }
}