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
            var player1 = new MovableObject(Color.Aqua, this);
            var player2 = new MovableObject(Color.Pink, this);

            player1.Name = "Player1";
            player1.TextPos = new Vector2(10,450);
            player1.Controls["Up"] = Keys.W;
            player1.Controls["Down"] = Keys.S;
            player1.Controls["Left"] = Keys.A;
            player1.Controls["Right"] = Keys.D;

            player2.Name = "Player2";
            player2.TextPos = new Vector2(500, 450);
            player2.Controls["Up"] = Keys.Up;
            player2.Controls["Down"] = Keys.Down;
            player2.Controls["Left"] = Keys.Left;
            player2.Controls["Right"] = Keys.Right;

            Objects.Add(player1);
            Components.Add(player1);

            Objects.Add(player2);
            Components.Add(player2);
            
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
            //foreach (var movableObject in Objects)
            //{
            //    movableObject.Update(gameTime);
            //}

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            //foreach (var movableObject in Objects)
            //{
            //    movableObject.Draw(gameTime);
            //}


            spriteBatch.Begin();
            spriteBatch.DrawString(Fonts["DefaultFont"], "The mighty ballgame!", new Vector2(10, 10), Color.Black);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
