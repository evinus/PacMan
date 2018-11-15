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
    public class Player : MovingObject
    {
        Texture2D texPacman;
        GameManager gm;
        public int NumberOfFoodEaten { get; set; }
        
        float speed = 150f;
        SpriteEffects spriteEffects = SpriteEffects.None;
        

        public Player(Texture2D texMain, Rectangle pos, Tile[,] tiles, GameManager gm) : base(texMain,pos, tiles)
        {
            numberOfFrames = 4;
            this.gm = gm;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            source = new Rectangle(currentFrame * texMain.Width / numberOfFrames, 0, texMain.Width / numberOfFrames, texMain.Height);
            spriteBatch.Draw(texMain, drawPos, source ,Color.White,rotation,new Vector2(20,20),spriteEffects,0);

        }

        public override void Update(GameTime gameTime)
        {
            Animate(gameTime);
            GetAllowedDirections();
            base.Update(gameTime);
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

        private void GetAllowedDirections()
        {

            int x = position.X % 32;
            int y = position.Y % 32;

            if (x == 0 && y == 0)
            {
                x = (position.X / 32);
                y = (position.Y / 32);
                direction = newDirection;
                CheckFood(x, y, tiles);
            }
            else return;

            

            for (int i = 0; i < allowedDirections.Length; i++)
            {
                allowedDirections[i] = false;
            }

            if(tiles[x,y-1].Type == enumTile.Empty)
            {
                allowedDirections[0] = true;
            }
            if(tiles[x+1,y].Type == enumTile.Empty)
            {
                allowedDirections[1] = true;
            }
            if (tiles[x,y+1].Type == enumTile.Empty)
            {
                allowedDirections[2] = true;
            }
            if(tiles[x-1,y].Type == enumTile.Empty)
            {
                allowedDirections[3] = true;
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
                            position.Y += 2; 
                            rotation = MathHelper.ToRadians(90);
                            spriteEffects = SpriteEffects.None;
                        }
                        break;
                    }
                case Direction.Up:
                    {
                        if (allowedDirections[0] == true)
                        {
                            position.Y -= 2;
                            rotation = MathHelper.ToRadians(-90);
                            spriteEffects = SpriteEffects.None;
                        }
                        break;
                    }
                case Direction.Left:
                    {
                        if (allowedDirections[3] == true)
                        {
                            position.X -= 2;
                            rotation = MathHelper.ToRadians(0);
                            spriteEffects = SpriteEffects.FlipHorizontally;
                        }
                        break;
                    }
                case Direction.Right:
                    {
                        if (allowedDirections[1] == true)
                        {
                            position.X += 2;
                            rotation = MathHelper.ToRadians(0);
                            spriteEffects = SpriteEffects.None;
                        }
                        break;
                    }
            }
        }

        private void CheckFood(int x,int y, Tile[,] tiles)
        {
            if(tiles[x,y].Food == true)
            {
                tiles[x, y].Food = false;
                gm.GainScore(10);
                NumberOfFoodEaten++;
            }
        }

        
       
    }
}
