using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PacMan
{
    public class HUD : IGame
    {
        public int Life { get; set; } = 3;
        public int Score { get; set; }
        Vector2 pos;

        public HUD(Vector2 pos)
        {
            this.pos = pos;  
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Game1.Font, $"Life: {Life}  Score: {Score}", pos, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        
    }
}
