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
        private Direction direction, newDirection;
        float timeBetweenFrames = 0.1f;
        int currentFrame = 0;
        float timeSinceLastFrame;
        int numberOfFrames = 4;
        float speed = 150f;
        SpriteEffects spriteEffects = SpriteEffects.None;
        float rotation = 0;
        bool[] allowedDirections = new bool[] { false, false, false, false };
        bool moving;

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


            if (KeyMouseReader.KeyPressed(Keys.Left))
            {
                newDirection = Direction.Left;
            }
            else if(KeyMouseReader.KeyPressed(Keys.Up))
            {
                newDirection = Direction.Up;
            }
            else if(KeyMouseReader.KeyPressed(Keys.Right))
            {
                newDirection = Direction.Right;
            }
            else if(KeyMouseReader.KeyPressed(Keys.Down))
            {
                newDirection = Direction.Down;
            }
            Move(gameTime);
            
        }

        public void GetAllowedDirections(enumTile[,] tiles)
        {

            int x = position.X % 32;
            int y = position.Y % 32;

            if (x == 0 && y == 0)
            {
                x = (position.X / 32);
                y = (position.Y / 32);
                direction = newDirection;
                moving = false;
            }
            else return;

            //beronde på vilket håll man åker så ska man kolla på olika sätt
            //int tileX1 = (int)Math.Floor(position.X / 32d);
            //int tileY1 = (int)Math.Floor(position.Y / 32d);

            //int tileX2 = (int)Math.Ceiling(position.X / 32d);
            //int tileY2 = (int)Math.Ceiling(position.Y / 32d);

            //int tileX3 = (int)Math.Ceiling((position.X + 32) / 32d);
            //int tileY3 = (int)Math.Ceiling((position.Y + 32) / 32d);

            for (int i = 0; i < allowedDirections.Length; i++)
            {
                allowedDirections[i] = false;
            }

            if(tiles[x,y-1] == enumTile.Empty)
            {
                allowedDirections[0] = true;
            }
            if(tiles[x+1,y] == enumTile.Empty)
            {
                allowedDirections[1] = true;
            }
            if (tiles[x,y+1] == enumTile.Empty)
            {
                allowedDirections[2] = true;
            }
            if(tiles[x-1,y]== enumTile.Empty)
            {
                allowedDirections[3] = true;
            }

            ////0 upp,1höger,2 ner,3vänster
            //if (direction == Direction.Down)
            //{
                
            //    allowedDirections[0] = true;
                
            //    if (tiles[tileX1 + 1, tileY1] == enumTile.Empty)
            //    {
            //        allowedDirections[1] = true;
            //    }

            //    if (tiles[tileX1,tileY1 +1] == enumTile.Empty)
            //    {
            //        allowedDirections[2] = true; 
            //    }
  
            //    if (tiles[tileX1 - 1, tileY1] == enumTile.Empty)
            //    {
            //        allowedDirections[3] = true;
            //    } 
            //}
            //if(direction == Direction.Left)
            //{
            //    if()
            //}
            
        }

        private void Move(GameTime gameTime)
        {
            switch(direction)
            {
                case Direction.Down:
                    {
                        if (allowedDirections[2] == true)
                        {
                            position.Y += 2; //(int)(speed * gameTime.ElapsedGameTime.TotalSeconds);
                            spriteEffects = SpriteEffects.None;
                            allowedDirections[0] = false;
                            allowedDirections[1] = false;
                            allowedDirections[3] = false;
                        }
                        break;
                    }
                case Direction.Up:
                    {
                        if (allowedDirections[0] == true)
                        {
                            position.Y -= 2;//(int)(speed * gameTime.ElapsedGameTime.TotalSeconds);
                            spriteEffects = SpriteEffects.FlipVertically;
                            allowedDirections[2] = false;
                            allowedDirections[1] = false;
                            allowedDirections[3] = false;
                        }
                        break;
                    }
                case Direction.Left:
                    {
                        if (allowedDirections[3] == true)
                        {
                            position.X -= 2; //(int)(speed * gameTime.ElapsedGameTime.TotalSeconds);
                            spriteEffects = SpriteEffects.FlipHorizontally;
                            allowedDirections[0] = false;
                            allowedDirections[1] = false;
                            allowedDirections[2] = false;
                        }
                        break;
                    }
                case Direction.Right:
                    {
                        if (allowedDirections[1] == true)
                        {
                            position.X += 2; //(int)(speed * gameTime.ElapsedGameTime.TotalSeconds);
                            spriteEffects = SpriteEffects.None;
                            allowedDirections[0] = false;
                            allowedDirections[2] = false;
                            allowedDirections[3] = false;
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
