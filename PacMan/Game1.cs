using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;

namespace PacMan
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public static GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameManager gameManager;

        public static Texture2D TileSetSheet { get; private set; }
        public static Texture2D TileEmpty { get; private set; }
        public static Texture2D PacManSheet { get; private set; }
        public static Texture2D SpriteSheet { get; private set; }


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

       
        protected override void Initialize()
        {
            //using (LevelEditor form = new LevelEditor())
            //{

            //    if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK) ;

            //}
            //IsMouseVisible = true;
            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            TileSetSheet = Content.Load<Texture2D>("Tileset");
            TileEmpty = Content.Load<Texture2D>("emptyTile");
            PacManSheet = Content.Load<Texture2D>("pacman");
            SpriteSheet = Content.Load<Texture2D>("SpriteSheet");
            gameManager = new GameManager();
            // 52 3 2 2
            
        }

        
        protected override void UnloadContent()
        {
            
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            gameManager.Update(gameTime);
            KeyMouseReader.Update();
            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkBlue);
            
            spriteBatch.Begin();
            gameManager.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
