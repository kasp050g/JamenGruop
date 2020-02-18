using JamenGruop_RTS.Script.Jamen_Gruop.Enum;
using JamenGruop_RTS.Script.Jamen_Gruop.Units;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JamenGruop_RTS.Script.Jamen_Gruop.Players;

namespace JamenGruop_RTS.Script.Jamen_Gruop.Buildings
{
	class Barracks : GameObject
	{
		public List<Unit> createdUnits = new List<Unit>();
		public ETeam BarracksTeam = new ETeam();
		public int recruitBonus = 0;

		private Vector2 creationPoint = new Vector2();
		private float recruitTimer = 10f;
		private Player owner = new Player();
		private Unit tmp;

		public Barracks(int positionX, int positionY, ETeam team, Player owner)
		{
			Transform.Position = new Vector2(positionX, positionY);
			BarracksTeam = team;
			this.owner = owner;
			owner.PlayerMaxFood += 25;
		}

		public override void Update()
		{
			RecruitmentTimer();
		}

		private void RecruitmentTimer()
		{
			//while(recruitTimer != 0f &&
			//	owner.PlayerMaxFood > owner.PlayerCurrentFood + tmp.FoodCost)
			//{
			//	recruitTimer -= Time.deltaTime;
			//	switch(recruitTimer)
			//	{
			//		case 0f:
			//			RecruitUnit();
			//			recruitTimer = 10f - (1 * recruitBonus);
			//			break;
			//	}
			//}
		}

		//private void RecruitUnit()
		//{
		//	tmp = new Unit(
		//		(int)creationPoint.X,
		//		(int)creationPoint.Y,
		//		BarracksTeam
		//		);

		//	createdUnits.Add(tmp);

		//	SceneController.CurrentScene.Instantiate(tmp);
		//}
	}
}
