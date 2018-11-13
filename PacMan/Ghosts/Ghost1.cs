using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PacMan.Ghosts
{
    class Ghost1 :Ghost
    {
        public Ghost1(Texture2D texMain,Rectangle pos): base(texMain,pos)
        {

        }

        protected override void ChoosePath(Tile[,] tiles)
        {
            base.ChoosePath(tiles);

        }

    }
}
