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
        protected float rotation = 0;

        protected Direction direction, newDirection;
        protected bool[] allowedDirections = new bool[] { false, false, false, false };

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
            drawPos.X = position.X +17 ;//(texMain.Width / 2);
            drawPos.Y = position.Y +17;
        }
    }
}
