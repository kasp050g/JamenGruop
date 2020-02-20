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
	public class _Barracks : GameObject
	{
		Resource gold;
		Resource wood;
		Resource food;
		public AllBuildings allBuildings;
		public _Barracks(Resource gold, Resource wood, Resource food)
		{
			this.gold = gold;
			this.wood = wood;
			this.food = food;
		}
		public Rectangle Collider
		{
			get
			{
				return new Rectangle(
					(int)transform.Position.X - (int)(transform.Origin.X * transform.Scale.X),
					(int)transform.Position.Y - (int)(transform.Origin.Y * transform.Scale.Y),
					(int)(sprite.Width * transform.Scale.X),
					(int)(sprite.Height * transform.Scale.Y)
					);
			}
		}
		public override void Awake()
		{
			Sprite = SpriteContainer.sprite["Barracks"];
			originPositionEnum = OriginPositionEnum.BottomMid;
			base.Awake();
            transform.Origin += new Vector2(30, -20);			
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

		public void GiveResource(_Kasper_Worker worker)
		{
			eMoveToSpot eMoveTo = WhereToRetrunTo(worker);

			gold.ResourceNumber += worker.currentGold;
			wood.ResourceNumber += worker.currentWood;
			food.ResourceNumber += worker.currentFood;

			Console.WriteLine(gold.ResourceNumber);

			worker.currentGold = 0;
			worker.currentWood = 0;
			worker.currentFood = 0;

			switch (eMoveTo)
			{
				case eMoveToSpot.None:
					break;
				case eMoveToSpot.Barracks:					
					break;
				case eMoveToSpot.LumberMilk:
					worker.NewMovementCommand(allBuildings.lumberMilk.Transform.Position, eMoveToSpot.LumberMilk);
					break;
				case eMoveToSpot.Fram:
					worker.NewMovementCommand(allBuildings.fram.Transform.Position, eMoveToSpot.Fram);
					break;
				case eMoveToSpot.GoldMine:
					worker.NewMovementCommand(allBuildings.goldMine.Transform.Position, eMoveToSpot.GoldMine);
					break;
				default:
					break;
			}
		}

		public eMoveToSpot WhereToRetrunTo(_Kasper_Worker worker)
		{
			eMoveToSpot eMoveTo = eMoveToSpot.None;

			if(worker.currentGold > 0)
			{
				eMoveTo = eMoveToSpot.GoldMine;
			}
			else if(worker.currentWood > 0)
			{
				eMoveTo = eMoveToSpot.LumberMilk;
			}
			else if(worker.currentFood > 0)
			{
				eMoveTo = eMoveToSpot.Fram;
			}

			return eMoveTo;
		}
	}
}
