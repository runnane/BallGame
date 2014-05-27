using Microsoft.Xna.Framework.Input;

namespace BallGameWindow.Objects
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class MovableObject : DrawableGameComponent
    {

        public Rectangle Position { get; set; }
        public Color Color { get; set; }
        public Texture2D Texture { get; set; }
        public new Game1 Game { get; set; }
        public SpriteBatch spriteBatch { get; set; }

        public MovableObject(Color _col, Rectangle _vec, Game _game)
            : base(_game)
        {
            Game = (Game1)_game;
            Color = _col;
            Position = _vec;
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
            spriteBatch.Draw(Texture, Position, Color);
            spriteBatch.DrawString(Game.Fonts["DefaultFont"], Position.X + " x " + Position.Y, new Vector2(200, 200), Color.Black);
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                Position.Offset(1, 0);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                Position.Offset(-1, 0);
            }

        }
    }
}
