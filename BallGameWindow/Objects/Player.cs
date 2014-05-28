


namespace BallGameWindow.Objects
{

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    internal class Player : MovableObject
    {
        public Player(Color col, Game game) : base(col, game)
        {
        }

        public void CheckKeys()
        {
            string[] k = {"Right", "Left", "Up", "Down"};
            foreach (var s in k)
            {
                Keys[s] = Keyboard.GetState().IsKeyDown(Controls[s]);
            }
        }

        public override void Update(GameTime gameTime)
        {
            float ret = 0.95f;
            float acc = 0.1f;
            CheckKeys();
            Box = new Rectangle((int) Location.X, (int) Location.Y, 20, 20);



            if (Keys["Right"])
            {
                Velocity += new Vector2(acc, 0f);
            }
            else if (Keys["Left"])
            {
                Velocity -= new Vector2(acc, 0f);
            }
            else
            {
                Velocity *= new Vector2(ret, 1);
            }

            if (Keys["Up"])
            {
                Velocity -= new Vector2(0f, acc);
            }
            else if (Keys["Down"])
            {
                Velocity += new Vector2(0f, acc);
            }
            else
            {
                Velocity *= new Vector2(1, ret);
            }

            base.Update(gameTime);

        }

    }
}