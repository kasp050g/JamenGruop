using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamenGruop_RTS
{
	public class Character : GameObject
	{
		/// <summary>
		/// Character speed.
		/// </summary>
		protected float moveSpeed = 250;

		protected Vector2 velocity = new Vector2();

		/// <summary>
		/// Check if the character is alive.
		/// </summary>
		public bool IsAlive { get; set; } = true;

		/// <summary>
		/// Character's health.
		/// </summary>
		public Stat Health { get; set; } = new Stat();
		public Stat Armor { get; set; } = new Stat();

		protected eUnitZone unitZone;

		/// <summary>
		/// Blood color.
		/// </summary>
		protected Color bloodColor = Color.White;



		/// <summary>
		/// Makes the object take a specific damage.
		/// </summary>
		/// <param name="damage"></param>
		public virtual void TakeDamage(int damage)
		{
			if(unitZone == eUnitZone.defender)
			{
				damage -= (int)Armor.currentValue + 1;
			}
			else
			{
				damage -= (int)Armor.currentValue;
			}

			if(damage < 0)
			{
				damage = 0;
			}

			// If  the object is alive, then we can proceed.
			if (IsAlive)
			{
				// We use the object we checked IsAlive on, to reduce it's health. Then a blood effect is created and a sound is played.
				IsAlive = Health.LowerValueBool(damage);


				// if the object is the player and the player is not alive, and the attacker is an enemy, then the Player dies.
				if (IsAlive == false)
				{
					
				}
			}
		}
	}
}
