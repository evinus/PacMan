using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace PacMan
{
    public class MovingObject : GameObject
    {
        protected Rectangle drawPos;
        public MovingObject(Texture2D texMain, Rectangle pos) : base(texMain, pos)
        {
            drawPos = new Rectangle(0, 0, pos.Width, pos.Height);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            drawPos.X = position.X + (texMain.Width / 2);
            drawPos.Y = position.Y + texMain.Height / 2;
        }
    }
}
