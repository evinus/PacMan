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
    public class LevelManager : IGame
    {
        public Map CurrentMap { get; set; }
        

        public LevelManager()
        {
            
            

            
        }

        

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            CurrentMap.Draw(spriteBatch);
        }

        private void SaveMapFile()
        {
            using (FileStream filestream = new FileStream("TimeMap", FileMode.OpenOrCreate, FileAccess.Write))
            {
                BinaryWriter writer = new BinaryWriter(filestream);
                int width = CurrentMap.Tiles.GetLength(0);
                int height = CurrentMap.Tiles.GetLength(1);
                writer.Write(width);
                writer.Write(height);

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        writer.Write((int)CurrentMap.Tiles[x, y].Type);
                    }
                }
                
                writer.Dispose();
            }
        }

        
    }
}
