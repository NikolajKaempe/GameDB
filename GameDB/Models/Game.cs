using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameDB.Models
{
    public class Game
    {
        public int GameID { get; set; }
        public String name { get; set; }
        public double rating { get; set; }
        public DateTime releaseDate { get; set; }
        public String author { get; set; }
        public String imagePath { get; set; }
        public List<Platform> platformList { get; set; }
        public List<Character> charList { get; set; }
    }
}