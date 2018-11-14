using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PacMan
{
    public class Map : IGame
    {

        public Tile[,] Tiles { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public int numberFood { get; set; } = 0;

        List<Rectangle> tilesSourcePos  = new List<Rectangle>();
        Rectangle foodSource = new Rectangle(52, 3, 2, 2);
        public Map(int width,int height)
        {
            Width = width;
            Height = height;

            Tiles = new Tile[width, height];
            
            //CreateMap();
            GetTexTiles();
        }

      
        public Rectangle getTile(int tile)
        {
            return tilesSourcePos[tile];
        }

        private void GetTexTiles()
        {
            Rectangle rectangle;
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    if(x== 0 && y ==0)
                    {
                        rectangle = new Rectangle(0, 0, 32, 32);
                    }
                    else if(x==0)
                    {
                        rectangle = new Rectangle(x, (y * 32) + y, 32, 32);
                    }
                    else if(y==0)
                    {
                        rectangle = new Rectangle((x * 32) + x, y, 32, 32);
                    }
                    else
                    {
                        rectangle = new Rectangle((x * 32) + x, (y * 32) +y, 32, 32);
                    }
                    tilesSourcePos.Add(rectangle);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            for (int y = 0; y < Tiles.GetLength(1); y++)
            {
                for (int x = 0; x < Tiles.GetLength(0); x++)
                {
                    if (Tiles[x, y].Type == 0)
                    {
                        spriteBatch.Draw(Game1.TileEmpty, new Vector2((x * 32), (y * 32)), Color.White);
                        if(Tiles[x, y].Food == true)
                        {
                            spriteBatch.Draw(Game1.SpriteSheet, new Rectangle((x * 32) +16, (y * 32)+16,5,5), foodSource, Color.White);
                        }
                    }
                    else if(Tiles[x, y].Type >= (enumTile)1 && Tiles[x, y].Type <= (enumTile)17)
                    {
                        spriteBatch.Draw(Game1.TileSetSheet, new Rectangle((x * 32), (y * 32), 32, 32), getTile((int)Tiles[x, y].Type -1), Color.White);
                    }
                } 
            }
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
        
    }
}
