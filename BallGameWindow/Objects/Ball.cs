using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace BallGameWindow.Objects
{
    class Ball : MovableObject
    {
        public Ball(Color col, Game game) : base(col, game)
        {
        }

        public override void Update(GameTime gameTime)
        {
            float ret = 0.98f;
            Velocity *= ret;
            base.Update(gameTime);
        }
    }
}
