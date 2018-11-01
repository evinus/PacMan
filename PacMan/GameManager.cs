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

        LevelManager levelManager = new LevelManager();

        public void Draw(SpriteBatch spriteBatch)
        {
            levelManager.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        
    }
}
