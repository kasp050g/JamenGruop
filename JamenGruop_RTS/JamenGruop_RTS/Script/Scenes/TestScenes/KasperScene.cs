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

		public override void Initialize()
		{
			base.Initialize();
            SceneController.eCurrentTest = eCurrentTestScene.Kasper;
            //Instantiate(unitSelector.showUnit);


            //Footman footman01 = new Footman(new Vector2(0, 0), ETeam.Team01);
            //footman01.Color = Color.Blue;
            //Instantiate(footman01);

            //Footman footman02 = new Footman(new Vector2(5, 0), ETeam.Team01);
            //footman02.Color = Color.Blue;
            //Instantiate(footman02);

            //Footman footman03 = new Footman(new Vector2(5, 0), ETeam.Team01);
            //footman03.Color = Color.Blue;
            //Instantiate(footman03);

            //_Zone zone01 = new _Zone();
            //zone01.Transform.Position = new Vector2(-790, -230);
            //zone01.units.Add(footman01);
            //zone01.units.Add(footman03);
            //zone01.units.Add(footman02);
            //Instantiate(zone01);

            //// Zone 02
            //Footman footman04 = new Footman(new Vector2(0, 0), ETeam.Team01);
            //footman04.Color = Color.Red;
            //Instantiate(footman04);

            //Footman footman05 = new Footman(new Vector2(5, 0), ETeam.Team01);
            //footman05.Color = Color.Red;
            //Instantiate(footman05);

            //Footman footman06 = new Footman(new Vector2(5, 0), ETeam.Team01);
            //footman06.Color = Color.Red;
            //Instantiate(footman06);

            //_Zone zone02 = new _Zone();
            //zone02.Transform.Position = new Vector2(90, -230);
            //zone02.units.Add(footman04);
            //zone02.units.Add(footman05);
            //zone02.units.Add(footman06);
            //Instantiate(zone02);			

            //zone01.enemyZone = zone02;

            // - - - - - - - - - - - - - - - //
            _Kasper_Worker kasper_Worker = new _Kasper_Worker();
            Instantiate(kasper_Worker);
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
	}
}
