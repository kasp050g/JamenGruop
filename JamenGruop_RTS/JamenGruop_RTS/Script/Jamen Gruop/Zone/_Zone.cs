using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamenGruop_RTS
{
	public class _Zone : GameObject
	{
		public List<Unit> units = new List<Unit>();
		public List<Unit> enemyUnits = new List<Unit>();

		public _Zone enemyZone = null;

		public _DefeZone defeZone;
		public _AttackZone attackZone;

		public _KasperTestbuild kasperTestbuild;

		public AttackArrow attackArrow;

		public override void Awake()
		{
			defeZone = new _DefeZone(this);
			attackZone = new _AttackZone(this);
			kasperTestbuild = new _KasperTestbuild(this);
			attackArrow = new AttackArrow(this);
			attackArrow.Transform.Position = this.transform.Position + new Vector2(750, 200);

			Sprite = SpriteContainer.sprite["Test"];
			transform.Scale = new Vector2(700, 450);
			Color = Color.Green;
			layerDepth = 0;

			base.Awake();
		}

		public override void Start()
		{
			SceneController.CurrentScene.Instantiate(defeZone);
			SceneController.CurrentScene.Instantiate(attackZone);
			SceneController.CurrentScene.Instantiate(kasperTestbuild);
			SceneController.CurrentScene.Instantiate(attackArrow);
			defeZone.units = units;

			attackArrow.EnemyZone = enemyZone;

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
}
