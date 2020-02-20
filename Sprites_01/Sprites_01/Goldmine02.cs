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
    class Goldmine02
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

        //Select thing
        bool isSelected = true;
        public Texture2D SelectTexture;
        public Vector2 SelectPosition;
        public Rectangle SelectRect;

        public Goldmine02(Texture2D Texture, Texture2D SelectTexture)
        {
            this.Texture = Texture;
            this.SelectTexture = SelectTexture;
        }

        public void Update(GameTime gameTime)
        {
            Origin = new Vector2(0, 0);
            int width = Texture.Width / totalColumns;
            int height = Texture.Height / totalRows;
            SourceRect = new Rectangle((int)currentColumn * width, (int)currentRow * height, width, height);

            //Select stuff
            SelectPosition.X = Position.X - 12; //Select posistion i forhold til Goldmine på X aksen
            SelectPosition.Y = Position.Y - 10; //Select posistion i forhold til Goldmine på Y aksen
            int selectWidth = SelectTexture.Width;
            int selectHeigth = SelectTexture.Height;
            SelectRect = new Rectangle(0, 0, selectWidth, selectHeigth);

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
            if (isSelected == true)
            {
                spriteBatch.Draw(SelectTexture, SelectPosition, SelectRect, Color.White, 0f, Origin, 0.55f, SpriteEffects.None, 0);
            }
            spriteBatch.Draw(Texture, Position, SourceRect, Color.White, 0f, Origin, 2.0f, SpriteEffects.None, 0);
        }
    }
}
