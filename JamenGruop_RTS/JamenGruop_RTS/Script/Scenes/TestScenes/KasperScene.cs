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
            Instantiate(unitSelector.showUnit);


            _Kasper_Worker _Kasper_Worker01 = new _Kasper_Worker(new Vector2(0, 0), ETeam.Team01);
            //_Kasper_Worker01.Color = Color.Blue;
            Instantiate(_Kasper_Worker01);

            _Kasper_Worker _Kasper_Worker02 = new _Kasper_Worker(new Vector2(5, 0), ETeam.Team01);
            //_Kasper_Worker02.Color = Color.Blue;
            Instantiate(_Kasper_Worker02);

            _Kasper_Worker _Kasper_Worker03 = new _Kasper_Worker(new Vector2(5, 0), ETeam.Team01);
            //_Kasper_Worker03.Color = Color.Blue;
            Instantiate(_Kasper_Worker03);

            _Zone zone01 = new _Zone();
            zone01.Transform.Position = new Vector2(-790, -230);
            zone01.units.Add(_Kasper_Worker01);
            zone01.units.Add(_Kasper_Worker03);
            zone01.units.Add(_Kasper_Worker02);
            Instantiate(zone01);

            // Zone 02
            _Kasper_Worker _Kasper_Worker04 = new _Kasper_Worker(new Vector2(0, 0), ETeam.Team01);
            _Kasper_Worker04.Color = Color.Red;
            Instantiate(_Kasper_Worker04);

            _Kasper_Worker _Kasper_Worker05 = new _Kasper_Worker(new Vector2(5, 0), ETeam.Team01);
            _Kasper_Worker05.Color = Color.Red;
            Instantiate(_Kasper_Worker05);

            _Kasper_Worker _Kasper_Worker06 = new _Kasper_Worker(new Vector2(5, 0), ETeam.Team01);
            _Kasper_Worker06.Color = Color.Red;
            Instantiate(_Kasper_Worker06);

            _Zone zone02 = new _Zone();
            zone02.Transform.Position = new Vector2(90, -230);
            zone02.units.Add(_Kasper_Worker04);
            zone02.units.Add(_Kasper_Worker05);
            zone02.units.Add(_Kasper_Worker06);
            Instantiate(zone02);

            zone01.enemyZone = zone02;


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
