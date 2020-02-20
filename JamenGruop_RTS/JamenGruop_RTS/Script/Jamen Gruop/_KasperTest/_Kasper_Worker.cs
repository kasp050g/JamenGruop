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
    public class _Kasper_Worker : Unit
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
        public _Kasper_eMove_LeftAndRigth eMove_LeftAndRigth;
        public _Kasper_eMove_UpAndDown eMove_UpAndDown;

        //protected Vector2 velocity = new Vector2();
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

        public _Kasper_Worker(Vector2 position, ETeam team) : base(position, team)
        {

        }

        public override void Awake()
        {
            sprite = SpriteContainer.sprite["Peasant"];
            transform.Scale = new Vector2(5, 5);
            layerDepth = 0.8f;
            base.Awake();

        }

        public override void Start()
        {
            base.Start();

        }

        public override void Update()
        {
            base.Update();

            Animate();
            TestMove();
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
            if(velocity.Y > 0)
            {
                eMove_UpAndDown = _Kasper_eMove_UpAndDown.Down;
            }
            else if(velocity.Y < 0)
            {
                eMove_UpAndDown = _Kasper_eMove_UpAndDown.Up;
            }
            else
            {
                eMove_UpAndDown = _Kasper_eMove_UpAndDown.None;
            }

            if (velocity.X > 0)
            {
                eMove_LeftAndRigth = _Kasper_eMove_LeftAndRigth.Rigth;
            }
            else if (velocity.X < 0)
            {
                eMove_LeftAndRigth = _Kasper_eMove_LeftAndRigth.Left;                
            }
            else
            {
                eMove_LeftAndRigth = _Kasper_eMove_LeftAndRigth.None;                
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
                if (eMove_LeftAndRigth == _Kasper_eMove_LeftAndRigth.Left)
                {
                    _spriteEffects = SpriteEffects.FlipHorizontally;
                }
                else
                {
                    _spriteEffects = SpriteEffects.None;
                }



                //Right
                if (eMove_LeftAndRigth == _Kasper_eMove_LeftAndRigth./**/Rigth/**/ /*&&*/&&/*&&*/ eMove_UpAndDown == _Kasper_eMove_UpAndDown./**/None/**/)
                {
                    currentColumn = 2;
                }
                //Left
                else if (eMove_LeftAndRigth == _Kasper_eMove_LeftAndRigth./**/Rigth/**/ /*&&*/&&/*&&*/ eMove_UpAndDown == _Kasper_eMove_UpAndDown./**/None/**/)
                {
                    currentColumn = 2;                    
                }
                //Down
                else if (eMove_LeftAndRigth == _Kasper_eMove_LeftAndRigth./**/None/**/ /*&&*/&&/*&&*/ eMove_UpAndDown == _Kasper_eMove_UpAndDown./**/Down/**/)
                {
                    currentColumn = 4;
                }
                //Up
                else if (eMove_LeftAndRigth == _Kasper_eMove_LeftAndRigth./**/None/**/ /*&&*/&&/*&&*/ eMove_UpAndDown == _Kasper_eMove_UpAndDown./**/Up/**/)
                {
                    currentColumn = 0;
                }
                //Up + Right
                else if (eMove_LeftAndRigth == _Kasper_eMove_LeftAndRigth./**/Rigth/**/ /*&&*/&&/*&&*/ eMove_UpAndDown == _Kasper_eMove_UpAndDown./**/Up/**/)
                {
                    currentColumn = 1;
                }
                //Down + Right
                else if (eMove_LeftAndRigth == _Kasper_eMove_LeftAndRigth./**/Rigth/**/ /*&&*/&&/*&&*/ eMove_UpAndDown == _Kasper_eMove_UpAndDown./**/Down/**/)
                {
                    currentColumn = 3;
                }
                //Up + Left
                else if (eMove_LeftAndRigth == _Kasper_eMove_LeftAndRigth./**/Left/**/ /*&&*/&&/*&&*/ eMove_UpAndDown == _Kasper_eMove_UpAndDown./**/Up/**/)
                {
                    currentColumn = 1;
                }
                //Down + Left
                else if (eMove_LeftAndRigth == _Kasper_eMove_LeftAndRigth./**/Left/**/ /*&&*/&&/*&&*/ eMove_UpAndDown == _Kasper_eMove_UpAndDown./**/Down/**/)
                {
                    currentColumn = 3;
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
