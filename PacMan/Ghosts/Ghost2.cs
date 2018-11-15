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
            numberOfFrames = 8;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            
            source = new Rectangle(currentFrame * (texMain.Width / numberOfFrames), 32, 16, 16);
            spriteBatch.Draw(texMain, position, source, Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Animate(gameTime);
            GetAllowedDirections();
            Move(gameTime);
        }

        private void Move(GameTime gameTime)
        {
            switch (direction)
            {
                case Direction.Down:
                    {
                        if (allowedDirections[2] == true)
                        {
                            position.Y += 2;
                        }
                        break;
                    }
                case Direction.Up:
                    {
                        if (allowedDirections[0] == true)
                        {
                            position.Y -= 2;
                        }
                        break;
                    }
                case Direction.Left:
                    {
                        if (allowedDirections[3] == true)
                        {
                            position.X -= 2;
                        }
                        break;
                    }
                case Direction.Right:
                    {
                        if (allowedDirections[1] == true)
                        {
                            position.X += 2;
                        }
                        break;
                    }
            }
        }

        //protected override void Animate(GameTime gameTime)
        //{
        //    base.Animate(gameTime);
        //}

        protected override void ChoosePath()
        {
            base.ChoosePath();
            if (newDirection == Direction.Up && allowedDirections[0])
            {
                direction = newDirection;
            }
            else if (newDirection == Direction.Right && allowedDirections[1])
            {
                direction = newDirection;
            }
            else if (newDirection == Direction.Down && allowedDirections[2])
            {
                direction = newDirection;
            }
            else if (newDirection == Direction.Left && allowedDirections[3])
            {
                direction = newDirection;
            }
            else
            {
                for (int i = 0; i < allowedDirections.Length; i++)
                {
                    if (allowedDirections[i])
                    {
                        direction = (Direction)i;
                        break;
                    }
                }
            }

        }

        private void GetAllowedDirections()
        {

            int x = position.X % 32;
            int y = position.Y % 32;

            if (x == 0 && y == 0)
            {
                x = (position.X / 32);
                y = (position.Y / 32);
                for (int i = 0; i < allowedDirections.Length; i++)
                {
                    allowedDirections[i] = false;
                }

                if (tiles[x, y - 1].Type == enumTile.Empty)
                {
                    allowedDirections[0] = true;
                }
                if (tiles[x + 1, y].Type == enumTile.Empty)
                {
                    allowedDirections[1] = true;
                }
                if (tiles[x, y + 1].Type == enumTile.Empty)
                {
                    allowedDirections[2] = true;
                }
                if (tiles[x - 1, y].Type == enumTile.Empty)
                {
                    allowedDirections[3] = true;
                }

                ChoosePath();
            }
            else return;
            // 0upp, 1höger, 2ner, 3vänster



        }

        private void CheckWallGetNewDir()
        {
            ChoosePath();

            if (direction == Direction.Up && allowedDirections[0] == false)
            {

            }
            else if (direction == Direction.Right && allowedDirections[1] == false)
            {

            }
            else if (direction == Direction.Down && allowedDirections[2] == false)
            {

            }
            else if (direction == Direction.Left && allowedDirections[3] == false)
            {

            }
        }
    }
}
