using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameDB.Models
{
    public class Game
    {
        public int GameID { get; set; }
        public String Name { get; set; }
        public double Rating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public String Author { get; set; }
        public List<Platform> PlatformList { get; set; }
        public List<Character> CharList { get; set; }

        public String ImageMimeType { get; set; }
        public byte[] ImageData { get; set; }
    }
}