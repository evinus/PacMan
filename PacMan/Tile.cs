using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PacMan
{
     public class Tile
    {
        public Rectangle pos;

        public enumTile Type { get; set; } = enumTile.Empty;

        public bool Food { get; set; }
        public bool SuperFood { get; set; }



    }
}
