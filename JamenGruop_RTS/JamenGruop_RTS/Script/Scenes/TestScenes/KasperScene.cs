using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamenGruop_RTS
{
	public class KasperScene : Scene
	{
		UnitSelector unitSelector = new UnitSelector();

		Resource gold = new Resource("gold");
		Resource wood = new Resource("wood");
		Resource food = new Resource("food");

		public AllBuildings allBuildings = new AllBuildings();

		public override void Initialize()
		{
			base.Initialize();
            SceneController.eCurrentTest = eCurrentTestScene.Kasper;
			MakeNewObject();
		}

		public override void OnSwitchToThisScene()
		{
			base.OnSwitchToThisScene();
		}

		public override void OnSwitchAwayFromThisScene()
		{
			base.OnSwitchAwayFromThisScene();
		}

		public override void Update()
		{
			base.Update();
			unitSelector.Update();
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
		}

		public void MakeNewObject()
		{
			Instantiate(unitSelector.showUnit);

			// - - - Show UI To Resourece - - - //
			ShowResource showResourceGold = new ShowResource(gold);
			showResourceGold.Transform.Position = new Vector2(400, 10);
			Instantiate(showResourceGold);

			ShowResource showResourceWood = new ShowResource(wood);
			showResourceWood.Transform.Position = new Vector2(700, 10);
			Instantiate(showResourceWood);

			ShowResource showResourceFood = new ShowResource(food);
			showResourceFood.Transform.Position = new Vector2(1000, 10);
			Instantiate(showResourceFood);

            _ShowUI showUI = new _ShowUI();
            Instantiate(showUI);

            // - - - Buildings - - - //
            _Barracks barracks = new _Barracks(gold,wood,food);
			barracks.Transform.Position = new Vector2(-50, 0);
			barracks.Transform.Scale = new Vector2(2, 2);
			Instantiate(barracks);

			_Fram fram = new _Fram();
			fram.Transform.Position = new Vector2(350, -300);
			fram.Transform.Scale = new Vector2(2, 2);
			Instantiate(fram);

			_LumberMilk lumberMilk = new _LumberMilk();
			lumberMilk.Transform.Position = new Vector2(-450, 350);
			lumberMilk.Transform.Scale = new Vector2(2, 2);
			Instantiate(lumberMilk);

			_GoldMine goldMine = new _GoldMine();
			goldMine.Transform.Position = new Vector2(350, 350);
			goldMine.Transform.Scale = new Vector2(2, 2);
			Instantiate(goldMine);

			allBuildings.barracks = barracks;
			allBuildings.fram = fram;
			allBuildings.lumberMilk = lumberMilk;
			allBuildings.goldMine = goldMine;

			barracks.allBuildings = allBuildings;
			fram.allBuildings = allBuildings;
			lumberMilk.allBuildings = allBuildings;
			goldMine.allBuildings = allBuildings;

            // - - - Workers - - - //
            for (int i = 0; i < 6; i++)
            {
                _Kasper_Worker _Kasper_Worker01 = new _Kasper_Worker(new Vector2(0, 0), ETeam.Team01);
                _Kasper_Worker01.allBuildings = allBuildings;
                Instantiate(_Kasper_Worker01);
            }

        }
	}
}