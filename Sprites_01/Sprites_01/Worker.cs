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
    class Worker
    {
        int MoveSpeed = 2;

        float timer = 0f;
        float interval = 200f;
        int currentColumn;
        int currentRow;
        int totalColumns = 5;
        int totalRows = 22;
        public Texture2D Texture;
        public Rectangle SourceRect;
		public SpriteEffects spriteEffects = SpriteEffects.None;


		public Vector2 Position;
        public Vector2 Origin;

        KeyboardState currentKBState;
        KeyboardState previousKBState;

        bool carryGold = false;
        bool carryWood = false;

        public Worker(Texture2D Texture)
        {
            this.Texture = Texture;
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

            if (currentKBState.GetPressedKeys().Length == 0)
            {
                if (carryGold == false && carryWood == false)
                {
                    currentRow = 0;
                }
                if (carryGold == true && carryWood == false)
                {
                    currentRow = 10;
                }
                if (carryGold == false && carryWood == true)
                {
                    currentRow = 15;
                }
            }
            //Right
            if (currentKBState.IsKeyDown(Keys.Right) == true)
            {
                currentColumn = 2;
                AnimatedWalk(gameTime);
                Position.X += MoveSpeed;
				spriteEffects = SpriteEffects.None;

			}
            //Left
            if (currentKBState.IsKeyDown(Keys.Left) == true)
            {
                currentColumn = 2;
                AnimatedWalk(gameTime);
                Position.X -= MoveSpeed;
				spriteEffects = SpriteEffects.FlipHorizontally;

			}
            //Down
            if (currentKBState.IsKeyDown(Keys.Down) == true)
            {
                currentColumn = 4;
                AnimatedWalk(gameTime);
                Position.Y += MoveSpeed;
            }
            //Up
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
            if (carryGold == false && carryWood == false)
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
            if (carryGold == true && carryWood == false)
            {
                if (currentKBState != previousKBState)
                {
                    currentRow = 10;
                }
                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (timer > interval)
                {
                    currentRow++;
                    if (currentRow > 14)
                    {
                        currentRow = 10;
                    }
                    timer = 0f;
                }
            }
            if (carryGold == false && carryWood == true)
            {
                if (currentKBState != previousKBState)
                {
                    currentRow = 15;
                }
                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (timer > interval)
                {
                    currentRow++;
                    if (currentRow > 19)
                    {
                        currentRow = 15;
                    }
                    timer = 0f;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, SourceRect, Color.White, 0f, Origin, 3.0f, spriteEffects, 0);
        }
    }
}
