#region Using Statements
using System;
using System.Collections.Generic;
using BallGameWindow.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace BallGameWindow
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        public List<MovableObject> Objects;

        public Dictionary<string, SpriteFont> Fonts;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {

            Fonts = new Dictionary<string, SpriteFont>();
            Objects = new List<MovableObject>();
            var Ball1 = new MovableObject(Color.Aqua, new Rectangle(60, 60, 10, 10), this);

            Objects.Add(Ball1);
            Components.Add(Ball1);
            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Fonts["DefaultFont"] = Content.Load<SpriteFont>("DefaultFont");

            //foreach (var movableObject in Objects)
            //{
            //    //movableObject.LoadContent();
            //}
            
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            

            // TODO: Add your update logic here
            foreach (var movableObject in Objects)
            {
                movableObject.Update(gameTime);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            foreach (var movableObject in Objects)
            {
                movableObject.Draw(gameTime);
            }


            spriteBatch.Begin();
            spriteBatch.DrawString(Fonts["DefaultFont"], "aw yee", new Vector2(32, 32), Color.Black);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
