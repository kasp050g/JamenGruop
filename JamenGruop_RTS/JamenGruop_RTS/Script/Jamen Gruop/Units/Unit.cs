using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamenGruop_RTS.Script.Jamen_Gruop.Units
{
	public class Unit : Character
	{
		protected bool isRange = false;
		protected int damage = 0;
		protected float attackSpeed = 1;

		protected Unit myTarget;

		

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
	}

	public enum UnitZone
	{
		defender,
		attakcer
	}
}
