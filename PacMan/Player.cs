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
    public class Player : GameObject
    {
        Texture2D texPacman;
        private Direction direction;
        float timeBetweenFrames = 0.1f;
        int currentFrame = 0;
        float timeSinceLastFrame;
        int numberOfFrames = 4;
        float speed = 150f;
        SpriteEffects spriteEffects = SpriteEffects.None;
        float rotation = 0;
        public bool[] AllowedDirections { get; set; } = new bool[4];

        public Player(Texture2D texMain, Rectangle pos) : base(texMain,pos)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            source = new Rectangle(currentFrame * texMain.Width / numberOfFrames, 0, texMain.Width / numberOfFrames, texMain.Height);
            spriteBatch.Draw(texMain, Position, source ,Color.White,rotation,new Vector2(),spriteEffects,0);

        }

        public override void Update(GameTime gameTime)
        {
            Animate(gameTime);

            
            if(KeyMouseReader.KeyPressed(Keys.Left))
            {
                direction = Direction.Left;
            }
            else if(KeyMouseReader.KeyPressed(Keys.Up))
            {
                direction = Direction.Up;
            }
            else if(KeyMouseReader.KeyPressed(Keys.Right))
            {
                direction = Direction.Right;
            }
            else if(KeyMouseReader.KeyPressed(Keys.Down))
            {
                direction = Direction.Down;
            }
            Move(gameTime);
            
        }

        private void Move(GameTime gameTime)
        {
            switch(direction)
            {
                case Direction.Down:
                    {
                        if (AllowedDirections[2] == true)
                        {
                            Position.Y += (int)(speed * gameTime.ElapsedGameTime.TotalSeconds);
                            spriteEffects = SpriteEffects.None; 
                        }
                        break;
                    }
                case Direction.Up:
                    {
                        if (AllowedDirections[0] == true)
                        {
                            Position.Y -= (int)(speed * gameTime.ElapsedGameTime.TotalSeconds);
                            spriteEffects = SpriteEffects.FlipVertically; 
                        }
                        break;
                    }
                case Direction.Left:
                    {
                        if (AllowedDirections[3] == true)
                        {
                            Position.X -= (int)(speed * gameTime.ElapsedGameTime.TotalSeconds);
                            spriteEffects = SpriteEffects.FlipHorizontally; 
                        }
                        break;
                    }
                case Direction.Right:
                    {
                        if (AllowedDirections[1] == true)
                        {
                            Position.X += (int)(speed * gameTime.ElapsedGameTime.TotalSeconds);
                            spriteEffects = SpriteEffects.None; 
                        }
                        break;
                    }
            }
        }

        private void Animate(GameTime gameTime)
        {
            timeSinceLastFrame += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if(timeSinceLastFrame >= timeBetweenFrames)
            {
                timeSinceLastFrame = 0;
                currentFrame++;
                if(currentFrame >= numberOfFrames)
                {
                    currentFrame = 0;
                }
            }
        }
    }
}
