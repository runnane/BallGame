namespace BallGameWindow.Objects
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
        public Vector2 Velocity { get; set; }
        public string Name { get; set; }
        public Dictionary<string, bool> Keys { get; set; } 


        public MovableObject(Color col, Game game) : base(game)
        {
            Location = new Vector2(60, 60);
            Game = (Game1) game;
            Color = col;
            Box = new Rectangle((int) Location.X, (int) Location.Y, 20, 20);
            Controls = new Dictionary<string, Keys>();
            Keys = new Dictionary<string, bool>();
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
            SpriteBatch.DrawString(Game.Fonts["DefaultFont"], Name + " pos: " + (int)Location.X + " x " + (int)Location.Y + " v="+Velocity.Length(), TextPos,
                Color.Black);
            SpriteBatch.End();
        }

        public virtual void Move(float x, float y)
        {
            Move(new Vector2(x, y));
        }

        public virtual void Move(Vector2 vec)
        {
            Location = vec;
        }
       

        public override void Update(GameTime gameTime)
        {

            const float maxVelocity = 5f;
          
            

            if (Velocity.Length() > maxVelocity)
            {
                Velocity = Vector2.Normalize(Velocity) * maxVelocity;
            }
            if (Velocity.Length() < 0.1)
            {
                Velocity = new Vector2(0, 0);
            }
           
            // Move
            Location += Velocity;


            // Boundingbox
            if (Location.X > 800)
            {
                Location = new Vector2(1, Location.Y);

            }
            if (Location.X < 1)
            {
                Location = new Vector2(800, Location.Y);

            }
            if (Location.Y > 480)
            {
                Location = new Vector2(Location.X, 1);

            }
            if (Location.Y < 1)
            {
                Location = new Vector2(Location.X, 480);
            }

            Box = new Rectangle((int)Location.X, (int)Location.Y, 20, 20);
        }
    }
}
