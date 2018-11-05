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

        public enumTile[,] Tiles { get; set; }
        public Rectangle[,] TilePos { get; set; }
        
        List<Rectangle> tilesSourcePos  = new List<Rectangle>();

        public Map(int width,int height)
        {
            

            Tiles = new enumTile[width, height];
            //CreateMap();
            GetTexTiles();
        }

        private void CreateMap()
        {
            Tiles[0, 0] = enumTile.TurnRightBottom;
            Tiles[1, 0] = enumTile.WallTopBottom;
            Tiles[2, 0] = enumTile.WallTopBottom;
            Tiles[3, 0] = enumTile.WallTopBottom;
            Tiles[4, 0] = enumTile.TurnLeftBottom;

            Tiles[0, 1] = enumTile.WallRightLeft;
            Tiles[1, 1] = enumTile.Empty;
            Tiles[2, 1] = enumTile.Empty;
            Tiles[3, 1] = enumTile.Empty;
            Tiles[4, 1] = enumTile.WallRightLeft;

            Tiles[0, 2] = enumTile.WallRightLeft;
            Tiles[1, 2] = enumTile.Empty;
            Tiles[2, 2] = enumTile.OnlyWalls;
            Tiles[3, 2] = enumTile.Empty;
            Tiles[4, 2] = enumTile.WallRightLeft;

            Tiles[0, 3] = enumTile.WallRightLeft;
            Tiles[1, 3] = enumTile.Empty;
            Tiles[2, 3] = enumTile.Empty;
            Tiles[3, 3] = enumTile.Empty;
            Tiles[4, 3] = enumTile.WallRightLeft;

            Tiles[0, 4] = enumTile.TurnTopLeft;
            Tiles[1, 4] = enumTile.WallTopBottom;
            Tiles[2, 4] = enumTile.WallTopBottom;
            Tiles[3, 4] = enumTile.WallTopBottom;
            Tiles[4, 4] = enumTile.TurnTopRight;


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
                    if (Tiles[x, y] == 0)
                    {
                        spriteBatch.Draw(Game1.TileEmpty, new Vector2((x * 32), (y * 32)), Color.White);
                    }
                    else
                    {
                        spriteBatch.Draw(Game1.TileSetSheet, new Rectangle((x * 32), (y * 32), 32, 32), getTile((int)Tiles[x, y] -1), Color.White);
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
