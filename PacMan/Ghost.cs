using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PacMan
{
    class Ghost : MovingObject
    {
        public Ghost(Texture2D texMain, Rectangle pos) : base(texMain, pos)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        virtual protected void Animate()
        {

        }

        virtual protected void ChoosePath(Tile[,] tiles)
        {

        }
    }
}
