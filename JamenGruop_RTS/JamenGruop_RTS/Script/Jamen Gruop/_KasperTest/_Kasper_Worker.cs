using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamenGruop_RTS
{
    public class _Kasper_Worker : GameObject
    {
        float timer = 0f;
        float interval = 200f;
        int currentColumn;
        int currentRow;
        int totalColumns = 5;
        int totalRows = 22;
        //public Texture2D Texture;
        public Rectangle SourceRect;
        public SpriteEffects _spriteEffects = SpriteEffects.None;

        protected Vector2 velocity = new Vector2();
        protected Vector2 velocityPrevious = new Vector2();
        protected Vector2 currentPrevious = new Vector2();

        bool carryGold = false;
        bool carryWood = false;

        public virtual Rectangle Collider
        {
            get
            {
                return new Rectangle(
                    (int)transform.Position.X - (int)(transform.Origin.X * transform.Scale.X),
                    (int)transform.Position.Y - (int)(transform.Origin.Y * transform.Scale.Y),
                    (int)(sprite.Width / totalColumns * transform.Scale.X),
                    (int)(sprite.Height / totalRows * transform.Scale.Y)
                    );
            }
        }

        public override void Awake()
        {
            sprite = SpriteContainer.sprite["Peasant"];
            transform.Scale = new Vector2(5, 5);
            base.Awake();

        }

        public override void Start()
        {
            base.Start();

        }

        public override void Update()
        {
            base.Update();
            TestMove();
            Animate();

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                // Texture2D
                this.sprite,
                // Postion
                this.transform.Position,
                // Source Rectangle
                SourceRect,
                // Color
                this.color,
                // Rotation
                MathHelper.ToRadians(this.transform.Rotation),
                // Origin
                this.transform.Origin,
                // Scale
                this.transform.Scale,
                // SpriteEffects
                _spriteEffects,
                // LayerDepth
                this.layerDepth
            );
        }

        public void TestMove()
        {
            velocity = new Vector2(0,0);
            if (Input.GetKey(Keys.W))
            {
                velocity += new Vector2(0, -1);
            }
            if (Input.GetKey(Keys.S))
            {
                velocity += new Vector2(0, 1);
            }

            if (Input.GetKey(Keys.A))
            {
                velocity += new Vector2(-1, 0);
            }
            if (Input.GetKey(Keys.D))
            {
                velocity += new Vector2(1, 0);
            }
        }

        public void Animate()
        {
            velocityPrevious = currentPrevious;
            currentPrevious = velocity;
            //Player animation del
            int width = sprite.Width / totalColumns;
            int height = sprite.Height / totalRows;
            SourceRect = new Rectangle((int)currentColumn * width, (int)currentRow * height, width, height);

            if (velocity == new Vector2(0,0))
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

            if (velocity != new Vector2(0, 0))
            {
                //Right
                if (velocity == new Vector2(1, 0))
                {
                    currentColumn = 2;
                    _spriteEffects = SpriteEffects.None;
                }
                //Left
                else if (velocity == new Vector2(-1, 0))
                {
                    currentColumn = 2;
                    _spriteEffects = SpriteEffects.FlipHorizontally;
                }

                //Down
                if (velocity == new Vector2(0, 1))
                {
                    currentColumn = 4;
                }
                //Up
                else if (velocity == new Vector2(0, -1))
                {
                    currentColumn = 0;
                }

                //Up + Right
                else if (velocity == new Vector2(1, -1))
                {
                    currentColumn = 1;
                    _spriteEffects = SpriteEffects.None;
                }
                //Down + Right
                else if (velocity == new Vector2(1, 1))
                {
                    currentColumn = 3;
                    _spriteEffects = SpriteEffects.None;
                }
                //Up + Left
                else if (velocity == new Vector2(-1, -1))
                {
                    currentColumn = 1;
                    _spriteEffects = SpriteEffects.FlipHorizontally;
                }
                //Down + Left
                else if (velocity == new Vector2(-1, 1))
                {
                    currentColumn = 3;
                    _spriteEffects = SpriteEffects.FlipHorizontally;
                }

                AnimateWalk();
            }
        }

        public void AnimateWalk()
        {
            if (carryGold == false && carryWood == false)
            {
                if (currentPrevious != velocityPrevious)
                {
                    currentRow = 1;
                }
                timer += Time.totalMilliseconds;
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
                if (currentPrevious != velocityPrevious)
                {
                    currentRow = 10;
                }
                timer += Time.totalMilliseconds;
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
                if (currentPrevious != velocityPrevious)
                {
                    currentRow = 15;
                }
                timer += Time.totalMilliseconds;
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
    }
}
