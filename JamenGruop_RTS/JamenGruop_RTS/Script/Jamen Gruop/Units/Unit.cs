using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

		protected Unit myTarget;

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
		}

		public override void Start()
		{
			base.Start();
		}

		public override void Update()
		{
			base.Update();
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
		}

        public void MoveToPosition()
        {
            if (transform.Position != myNewPosition)
            {
                Vector2 newVelocity = new Vector2();
                if (transform.Position.Y > myNewPosition.Y)
                {
                    newVelocity += new Vector2(0, -1);
                }
            }
        }
	}
}
