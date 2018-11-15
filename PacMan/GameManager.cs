using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        int life;
        HUD hud;
        int hudPositionY;
        string map;

        public GameManager(string map)
        {
            this.map = map;
            levelManager = new LevelManager();
            ReadMapFile();
            setScreenSize();
            Player = new Player(Game1.PacManSheet, new Rectangle(32, 32, texSize, texSize),levelManager.CurrentMap.Tiles, this);
            life = 3;
            
            hud = new HUD(new Vector2 (5,hudPositionY));
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
                        hud.Draw(spriteBatch);
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
                            if( Player.position.Intersects(ghost.position))
                            {
                                LostLife();
                            }
                        }
                        if(Player.NumberOfFoodEaten >= levelManager.CurrentMap.numberFood)
                        {
                            gamestate = Gamestate.End;
                        }
                        break;
                    }
            }  
        }

        private void ReadMapFile()
        {
            try
            {
                using (FileStream filestream = new FileStream(map, FileMode.OpenOrCreate, FileAccess.Read))
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
                                Ghosts.Ghost1 ghost1 = new Ghosts.Ghost1(Game1.SpriteSheet, new Rectangle(x * 32, y * 32, texSize, texSize), levelManager.CurrentMap.Tiles);
                                ghosts.Add(ghost1);
                                levelManager.CurrentMap.Tiles[x, y].Type = enumTile.Empty;
                            }
                            else if (levelManager.CurrentMap.Tiles[x, y].Type == enumTile.Ghost2)
                            {
                                Ghosts.Ghost2 ghost2 = new Ghosts.Ghost2(Game1.SpriteSheet, new Rectangle(x * 32, y * 32, texSize, texSize), levelManager.CurrentMap.Tiles);
                                ghosts.Add(ghost2);
                                levelManager.CurrentMap.Tiles[x, y].Type = enumTile.Empty;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Du skrev fel namn på kartan.","",MessageBoxButtons.OK);
                Application.Restart();
                
            }
        }
        private void LostLife()
        {
            hud.Life--;

            if(hud.Life <= 0)
            {
                gamestate = Gamestate.End;
            }
            Player.position.X = 32;
            Player.position.Y = 32;

            foreach(Ghost ghost in ghosts)
            {
                ghost.position.X = (int)ghost.startPosition.X;
                ghost.position.Y = (int)ghost.startPosition.Y;
            }
        }
        public void GainScore(int score)
        {
            hud.Score += score;
        }
        private void setScreenSize()
        {
            Game1.graphics.PreferredBackBufferWidth = levelManager.CurrentMap.Width * 32;
            Game1.graphics.PreferredBackBufferHeight = levelManager.CurrentMap.Height * 32 + 100;
            hudPositionY = levelManager.CurrentMap.Height * 32 + 20;
            Game1.graphics.ApplyChanges();
        }
    }
}
