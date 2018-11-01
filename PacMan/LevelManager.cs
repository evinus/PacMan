using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PacMan
{
    class LevelManager : IGame
    {
        Map map = new Map(3, 1);




        public void Draw(SpriteBatch spriteBatch)
        {
            map.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        private void SaveMapFile()
        {
            using (FileStream filestream = new FileStream("TileMap", FileMode.OpenOrCreate, FileAccess.Write))
            {
                BinaryWriter writer = new BinaryWriter(filestream);
                int width = map.Tiles.GetLength(0);
                int height = map.Tiles.GetLength(1);
                writer.Write(width);
                writer.Write(height);

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        writer.Write((int)map.Tiles[x, y]);
                    }
                }
                
                writer.Dispose();
            }
        }

        private void ReadMapFile()
        {
            
        }
    }
}
