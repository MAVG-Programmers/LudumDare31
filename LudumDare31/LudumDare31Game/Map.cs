using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudumDare31Game
{
    public class Map
    {
        public Tile[][] Tiles { get; set; }
        public List<Entity> Entities { get; set; }
    }
}
