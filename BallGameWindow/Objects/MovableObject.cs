using Microsoft.Xna.Framework.Input;

namespace BallGameWindow.Objects
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class MovableObject : DrawableGameComponent
    {

        public Rectangle Box { get; set; }
        public Color Color { get; set; }
        public Texture2D Texture { get; set; }
        public new Game1 Game { get; set; }
        public SpriteBatch spriteBatch { get; set; }
        public Vector2 Location { get; set; }
        public MovableObject(Color _col, Game _game)
            : base(_game)
        {
            Location = new Vector2(60, 60);
            Game = (Game1)_game;
            Color = _col;
            Box = new Rectangle((int)Location.X, (int)Location.Y, 20, 20);
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture = new Texture2D(GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            Texture.SetData(new[] {Color});

            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, Box, Color);
            spriteBatch.DrawString(Game.Fonts["DefaultFont"], "Square pos: " + Location.X + " x " + Location.Y, new Vector2(200, 200), Color.Black);
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
           
            Box = new Rectangle((int)Location.X, (int)Location.Y, 20, 20);
           
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                var loc = Location;
                loc.X += 0.5f;
                Location = loc;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                var loc = Location;
                loc.X -= 0.5f;
                Location = loc;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                var loc = Location;
                loc.Y -= 0.5f;
                Location = loc;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                var loc = Location;
                loc.Y += 0.5f;
                Location = loc;
            }

        }
    }
}
