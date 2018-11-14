using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PacMan
{
    public class GameManager : IGame
    {
        public static Player Player { get; private set; }
        public static Random Random = new Random();
        LevelManager levelManager;
        List<Ghost> ghosts = new List<Ghost>();
        int texSize = 32;
        Gamestate gamestate = Gamestate.Game;
        

        public GameManager()
        {
            levelManager = new LevelManager();
            ReadMapFile();
            setScreenSize();
            Player = new Player(Game1.PacManSheet, new Rectangle(32, 32, texSize, texSize),levelManager.CurrentMap.Tiles);
        }

        

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (gamestate)
            {
                case Gamestate.Game:
                    {
                        levelManager.Draw(spriteBatch);
                        Player.Draw(spriteBatch);

                        foreach (Ghost ghost in ghosts)
                        {
                            ghost.Draw(spriteBatch);
                        }
                        break;
                    }
                    
            }
        }

        public void Update(GameTime gameTime)
        {
            switch(gamestate)
            {
                case Gamestate.Game:
                    {
                        Player.Update(gameTime);
                        foreach(Ghost ghost in ghosts)
                        {
                            ghost.Update(gameTime);
                        }
                        if( Player.position.Intersects(ghosts[0].position))
                        {
                            Console.WriteLine("träff");
                        }
                        break;
                    }
            }

            
        }

        private void ReadMapFile()
        {
            using (FileStream filestream = new FileStream("mapv2", FileMode.OpenOrCreate, FileAccess.Read))
            {
                BinaryReader reader = new BinaryReader(filestream);
                int width = reader.ReadInt32();
                int height = reader.ReadInt32();
                levelManager.CurrentMap = new Map(width, height);

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        levelManager.CurrentMap.Tiles[x, y] = new Tile
                        {
                            Type = (enumTile)reader.ReadInt32()
                        };
                        if (levelManager.CurrentMap.Tiles[x, y].Type == enumTile.Empty)
                        {
                            levelManager.CurrentMap.Tiles[x, y].Food = true;
                            levelManager.CurrentMap.numberFood++;
                        }
                        else if (levelManager.CurrentMap.Tiles[x, y].Type == enumTile.Ghost1)
                        {
                            Ghosts.Ghost1 ghost1 = new Ghosts.Ghost1(Game1.SpriteSheet, new Rectangle(x * 32, y * 32, texSize, texSize),levelManager.CurrentMap.Tiles);
                            ghosts.Add(ghost1);
                            levelManager.CurrentMap.Tiles[x, y].Type = enumTile.Empty;
                        }
                    }
                }
            }
        }
        private void setScreenSize()
        {
            Game1.graphics.PreferredBackBufferWidth = levelManager.CurrentMap.Width * 32;
            Game1.graphics.PreferredBackBufferHeight = levelManager.CurrentMap.Height * 32 + 100;

            Game1.graphics.ApplyChanges();
        }
    }
}
