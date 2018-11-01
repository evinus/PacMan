using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PacMan
{
    public abstract class GameObject : IGame
    {

        protected Texture2D texMain;

        public abstract void Draw(SpriteBatch spriteBatch);
        

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
