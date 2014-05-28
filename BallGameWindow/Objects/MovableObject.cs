﻿namespace BallGameWindow.Objects
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework.Input;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class MovableObject : DrawableGameComponent
    {

        public Rectangle Box { get; set; }
        public Color Color { get; set; }
        public Texture2D Texture { get; set; }
        public new Game1 Game { get; set; }
        public SpriteBatch SpriteBatch { get; set; }
        public Vector2 Location { get; set; }
        public Vector2 TextPos { get; set; }
        public Dictionary<string, Keys> Controls;
        public string Name { get; set; }

        public MovableObject(Color col, Game game) : base(game)
        {
            Location = new Vector2(60, 60);
            Game = (Game1) game;
            Color = col;
            Box = new Rectangle((int) Location.X, (int) Location.Y, 20, 20);
            Controls = new Dictionary<string, Keys>();
            TextPos = new Vector2(10, 10);
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            Texture = new Texture2D(GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            Texture.SetData(new[] {Color});

            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();
            SpriteBatch.Draw(Texture, Box, Color);
            SpriteBatch.DrawString(Game.Fonts["DefaultFont"], Name + " pos: " + Location.X + " x " + Location.Y, TextPos,
                Color.Black);
            SpriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {

            Box = new Rectangle((int) Location.X, (int) Location.Y, 20, 20);

            if (Keyboard.GetState().IsKeyDown(Controls["Right"]))
            {
                var loc = Location;
                loc.X += 0.5f;
                Location = loc;
            }
            if (Keyboard.GetState().IsKeyDown(Controls["Left"]))
            {
                var loc = Location;
                loc.X -= 0.5f;
                Location = loc;
            }
            if (Keyboard.GetState().IsKeyDown(Controls["Up"]))
            {
                var loc = Location;
                loc.Y -= 0.5f;
                Location = loc;
            }
            if (Keyboard.GetState().IsKeyDown(Controls["Down"]))
            {
                var loc = Location;
                loc.Y += 0.5f;
                Location = loc;
            }

        }
    }
}
