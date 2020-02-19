using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mouse_Select_01
{
    class Spaceship
    {
        Texture2D ssTexture;
        Vector2 ssPosition;
        public Spaceship(Texture2D)
        {

        }

        public Player_2(Texture2D Texture, Texture2D HpTexture, Keys Left, Keys Right, Keys Up, Keys Down, Keys Shoot, Keys Jump, int Health)
        {
            this.Texture = Texture;
            this.HpTexture = HpTexture;
            this.Left = Left;
            this.Right = Right;
            this.Up = Up;
            this.Down = Down;
            this.Shoot = Shoot;
            this.Jump = Jump;
            // Health er til at teste HP bar
            this.Health = Health;
        }

    }
}
