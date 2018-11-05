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

        public GameManager()
        {
            Player = new Player(Game1.PacManSheet, new Rectangle(96, 96, 32, 32));
        }

        LevelManager levelManager = new LevelManager();

        public void Draw(SpriteBatch spriteBatch)
        {
            levelManager.Draw(spriteBatch);
            Player.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            Player.Update(gameTime);
            Player.allowedDirections = levelManager.CurrentMap.GetAllowedDirections(Player.position);
        }

        
    }
}
