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
    class Footman02
    {
        int MoveSpeed = 2;

        float timer = 0f;
        float interval = 200f;
        int currentColumn;
        int currentRow;
        int totalColumns = 5;
        int totalRows = 11;
        public Texture2D Texture;
        public Rectangle SourceRect;

        public Vector2 Position;
        public Vector2 Origin;

        KeyboardState currentKBState;
        KeyboardState previousKBState;

        bool isAttacking = true;

        //Select thing
        bool isSelected = true;
        public Texture2D SelectTexture;
        public Vector2 SelectPosition;
        public Rectangle SelectRect;

        public Footman02(Texture2D Texture, Texture2D SelectTexture)
        {
            this.Texture = Texture;
            this.SelectTexture = SelectTexture;
        }

        public void Controls(GameTime gameTime)
        {
            previousKBState = currentKBState;
            currentKBState = Keyboard.GetState();

            //Player animation del
            int width = Texture.Width / totalColumns;
            int height = Texture.Height / totalRows;
            SourceRect = new Rectangle((int)currentColumn * width, (int)currentRow * height, width, height);
            Origin = new Vector2(0, 0);

            //Select stuff
            SelectPosition.X = Position.X + 32; //Select posistion i forhold til Worker på X aksen
            SelectPosition.Y = Position.Y + 50; //Select posistion i forhold til Worker på Y aksen
            int selectWidth = SelectTexture.Width;
            int selectHeigth = SelectTexture.Height;
            SelectRect = new Rectangle(0, 0, selectWidth, selectHeigth);

            if (currentKBState.GetPressedKeys().Length == 0)
            {
                if (isAttacking == true)
                {
                    currentRow = 0;
                }
                else
                {
                    currentRow = 0;
                }
            }
            if (currentKBState.IsKeyDown(Keys.Right) == true)
            {
                currentColumn = 2;
                AnimatedWalk(gameTime);
                Position.X += MoveSpeed;
            }
            if (currentKBState.IsKeyDown(Keys.Left) == true)
            {
                currentColumn = 2;
                AnimatedWalk(gameTime);
                Position.X -= MoveSpeed;
            }
            if (currentKBState.IsKeyDown(Keys.Down) == true)
            {
                currentColumn = 4;
                AnimatedWalk(gameTime);
                Position.Y += MoveSpeed;
            }
            if (currentKBState.IsKeyDown(Keys.Up) == true)
            {
                currentColumn = 0;
                AnimatedWalk(gameTime);
                Position.Y -= MoveSpeed;
            }
            //Up + Right
            if (currentKBState.IsKeyDown(Keys.Up) == true && currentKBState.IsKeyDown(Keys.Right) == true)
            {
                currentColumn = 1;
            }
            //Down + Right
            if (currentKBState.IsKeyDown(Keys.Down) == true && currentKBState.IsKeyDown(Keys.Right) == true)
            {
                currentColumn = 3;
            }
            //Up + Left
            if (currentKBState.IsKeyDown(Keys.Up) == true && currentKBState.IsKeyDown(Keys.Left) == true)
            {
                currentColumn = 1;
            }
            //Down + Left
            if (currentKBState.IsKeyDown(Keys.Down) == true && currentKBState.IsKeyDown(Keys.Left) == true)
            {
                currentColumn = 3;
            }
        }
        public void AnimatedWalk(GameTime gameTime)
        {
            if (isAttacking == false)
            {
                if (currentKBState != previousKBState)
                {
                    currentRow = 1;
                }
                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (timer > interval)
                {
                    currentRow++;
                    if (currentRow > 4)
                    {
                        currentRow = 1;
                    }
                    timer = 0f;
                }
            }
            if (isAttacking == true)
            {
                if (currentKBState != previousKBState)
                {
                    currentRow = 5;
                }
                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (timer > interval)
                {
                    currentRow++;
                    if (currentRow > 8)
                    {
                        currentRow = 5;
                    }
                    timer = 0f;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (isSelected == true)
            {
                spriteBatch.Draw(SelectTexture, SelectPosition, SelectRect, Color.White, 0f, Origin, 0.2f, SpriteEffects.None, 0);
            }
            spriteBatch.Draw(Texture, Position, SourceRect, Color.White, 0f, Origin, 2.0f, SpriteEffects.None, 0);
        }
    }
}
