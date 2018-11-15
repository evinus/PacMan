using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PacMan
{
    public class Ghost : MovingObject
    {
        public Vector2 startPosition { get; private set; }
        public Ghost(Texture2D texMain, Rectangle pos, Tile[,] tiles) : base(texMain, pos,tiles)
        {
            timeBetweenFrames = 0.3f;
            startPosition = new Vector2(pos.X, pos.Y);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Animate(GameTime gameTime)
        {
            base.Animate(gameTime);
        }

        protected virtual void ChoosePath()
        {
            newDirection = (Direction)GameManager.Random.Next(0, 4);
            Console.WriteLine(newDirection);
        }
    }
}
