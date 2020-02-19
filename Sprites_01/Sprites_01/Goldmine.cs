using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprites_01
{
    class Goldmine
    {
        float timer = 0f;
        float interval = 3000f;
        int currentColumn;
        int currentRow;
        int totalColumns = 1;
        int totalRows = 2;
        public Texture2D Texture;
        public Rectangle SourceRect;

        public Vector2 Position;
        public Vector2 Origin;

        //KeyboardState currentKBState;
        //KeyboardState previousKBState;

        public bool inUse = true;

        public Goldmine(Texture2D Texture)
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
            currentColumn = 0;
            if (inUse == true)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (timer > interval)
                {
                    currentRow++;
                    if (currentRow > 1)
                    {
                        currentRow = 0;
                    }
                    timer = 0f;
                }
            }
            else
            {
                currentRow = 0;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, SourceRect, Color.White, 0f, Origin, 3.0f, SpriteEffects.None, 0);
        }
    }
}
