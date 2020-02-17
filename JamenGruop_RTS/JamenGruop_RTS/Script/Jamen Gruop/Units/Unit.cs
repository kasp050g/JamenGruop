using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JamenGruop_RTS
{
    public class Unit : Character
    {
        protected bool isRange = false;
        protected float attackRange = 69;
        protected int damage = 0;
        protected float attackSpeed = 1;
        protected Vector2 myNewPosition;
        protected Vector2 myNewPosition01;
        protected Vector2 myNewPosition02;

        protected Unit myTarget;
        protected ETeam myTeam;

        private int foodCost;

        public int FoodCost { get => foodCost; set => foodCost = value; }

        public Unit(Vector2 position, ETeam team)
        {
            this.transform.Position = position;
            this.myTeam = team;
        }

        protected virtual void AttackTarget()
        {
            if (myTarget != null)
            {
                myTarget.TakeDamage(damage + (unitZone == eUnitZone.attakcer ? 1 : 0));
            }
        }

        public override void Awake()
        {
            base.Awake();
            myNewPosition01 = new Vector2(100, 100);
            myNewPosition02 = new Vector2(-100, -100);
            Thread myThread01 = new Thread(MoveToPosition);

            myThread01.Start();
        }

        public override void Start()
        {
            base.Start();

        }

        public override void Update()
        {
            base.Update();
            
            Move();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
        /// <summary>
        /// Defines how the object moves.
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Move()
        {
            // Calculates deltaTime based on the gameTime.
            float deltatime = Time.deltaTime;

            // Move the GameObject based on the result from HandleInput, speed and deltaTime.
            Transform.Position += ((velocity * moveSpeed) * deltatime);
        }
        public void MoveToPosition()
        {
            Console.WriteLine("start");
            int numberOfMove = 0;
            while (numberOfMove < 7)
            {
                if (Vector2.Distance(transform.Position, myNewPosition) < 5f)
                {
                    if (Vector2.Distance(transform.Position, myNewPosition01) > Vector2.Distance(transform.Position, myNewPosition02))
                    {
                        myNewPosition = myNewPosition01;
                    }
                    else
                    {
                        myNewPosition = myNewPosition02;

                    }
                    numberOfMove += 1;
                }


                if (transform.Position != myNewPosition)
                {
                    Vector2 newVelocity = new Vector2();
                    if (transform.Position.Y > myNewPosition.Y)
                    {
                        newVelocity += new Vector2(0, -1);
                    }
                    if (transform.Position.Y < myNewPosition.Y)
                    {
                        newVelocity += new Vector2(0, +1);
                    }
                    if (transform.Position.X > myNewPosition.X)
                    {
                        newVelocity += new Vector2(-1, 0);
                    }
                    if (transform.Position.X < myNewPosition.X)
                    {
                        newVelocity += new Vector2(+1, 0);
                    }
                    newVelocity.Normalize();

                    velocity = newVelocity;
                }
            }

            velocity = new Vector2(0, 0);
        }
    }
}
