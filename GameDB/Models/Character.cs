using GameDB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameDB.Models
{
    public class Character
    {
        public int CharacterID { get; set; }
        public int ParentGameID { get; set; }
        public string CharacterName { get; set; }
        public string CharacterDescription { get; set; }

        public string ImageMimeType { get; set; }
        public byte[] ImageData { get; set; }

    }
}