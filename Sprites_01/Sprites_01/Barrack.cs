using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprites_01
{
    class Barrack
    {
        float timer = 0f;
        float interval = 3000f;
        int currentColumn;
        int currentRow;
        int totalColumns = 3;
        int totalRows = 2;
        public Texture2D Texture;
        public Rectangle SourceRect;

        public Vector2 Position;
        public Vector2 Origin;

        int level = 3;
        bool isUpgrading = true;

        public Barrack(Texture2D Texture)
        {
            this.Texture = Texture;
        }

        public void Update(GameTime gameTime)
        {
            Origin = new Vector2(0, 0);
            int width = Texture.Width / totalColumns;
            int height = Texture.Height / totalRows;

            //currentRow = 0;
            SourceRect = new Rectangle((int)currentColumn * width, (int)currentRow * height, width, height);

            switch (level)
            {
                //case 1:
                //    currentColumn = 2;
                //    break;
                case 2:
                    currentColumn = 0;
                    break;
                case 3:
                    currentColumn = 1;
                    break;
                default:
                    currentColumn = 2;
                    break;
            }
            if (isUpgrading == true)
            {
                currentRow = 1;
                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (timer > interval)
                {
                    //level += 1;
                    currentRow = 0;
                    isUpgrading = false;
                    //currentColumn++;
                    //if (currentColumn > )
                    //{
                    //    currentColumn = 0;
                    //}
                    //timer = 0f;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, SourceRect, Color.White, 0f, Origin, 3.0f, SpriteEffects.None, 0);
        }
    }
}
