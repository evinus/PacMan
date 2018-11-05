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
        bool[] allowedDirections = new bool[] { false, false, false, false };

        public Player(Texture2D texMain, Rectangle pos) : base(texMain,pos)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            source = new Rectangle(currentFrame * texMain.Width / numberOfFrames, 0, texMain.Width / numberOfFrames, texMain.Height);
            spriteBatch.Draw(texMain, position, source ,Color.White,rotation,new Vector2(),spriteEffects,0);

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

        public void GetAllowedDirections(enumTile[,] tiles)
        {
            //beronde på vilket håll man åker så ska man kolla på olika sätt
            int tileX1 = (int)Math.Floor(position.X / 32d);
            int tileY1 = (int)Math.Floor(position.Y / 32d);

            int tileX2 = (int)Math.Ceiling(position.X / 32d);
            int tileY2 = (int)Math.Ceiling(position.Y / 32d);

            int tileX3 = (int)Math.Ceiling((position.X + 32) / 32d);
            int tileY3 = (int)Math.Ceiling((position.Y + 32) / 32d);

            for (int i = 0; i < allowedDirections.Length; i++)
            {
                allowedDirections[i] = false;
            }


            if (direction == Direction.Down)
            {
                if (tiles[tileX2, tileY2 - 1] == enumTile.Empty)
                {
                    allowedDirections[0] = true;
                }
                if (tiles[tileX1 + 1, tileY1] == enumTile.Empty)
                {
                    allowedDirections[1] = true;
                }
                if (tiles[tileX1, tileY1 + 1] == enumTile.Empty)
                {
                    allowedDirections[2] = true;
                }
                if (tiles[tileX2 - 1, tileY3] == enumTile.Empty)
                {
                    allowedDirections[3] = true;
                } 
            }
            
        }

        private void Move(GameTime gameTime)
        {
            switch(direction)
            {
                case Direction.Down:
                    {
                        if (allowedDirections[2] == true)
                        {
                            position.Y += (int)(speed * gameTime.ElapsedGameTime.TotalSeconds);
                            spriteEffects = SpriteEffects.None; 
                        }
                        break;
                    }
                case Direction.Up:
                    {
                        if (allowedDirections[0] == true)
                        {
                            position.Y -= (int)(speed * gameTime.ElapsedGameTime.TotalSeconds);
                            spriteEffects = SpriteEffects.FlipVertically; 
                        }
                        break;
                    }
                case Direction.Left:
                    {
                        if (allowedDirections[3] == true)
                        {
                            position.X -= (int)(speed * gameTime.ElapsedGameTime.TotalSeconds);
                            spriteEffects = SpriteEffects.FlipHorizontally; 
                        }
                        break;
                    }
                case Direction.Right:
                    {
                        if (allowedDirections[1] == true)
                        {
                            position.X += (int)(speed * gameTime.ElapsedGameTime.TotalSeconds);
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
