using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PacMan.Ghosts
{
    public class Ghost2 : Ghost
    {
        public Ghost2(Texture2D texMain, Rectangle pos, Tile[,] tiles) : base(texMain, pos, tiles)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Animate(GameTime gameTime)
        {
            base.Animate(gameTime);
        }

        protected override void ChoosePath()
        {
            base.ChoosePath();
        }
    }
}
