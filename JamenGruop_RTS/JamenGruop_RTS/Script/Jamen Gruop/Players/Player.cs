using JamenGruop_RTS.Script.Jamen_Gruop.Enum;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamenGruop_RTS
{
	class Player : GameObject
	{
<<<<<<< Updated upstream
		private int playerGold = 0;
		private int playerWood = 0;
		private int playerCurrentFood = 0;
		private int playerMaxFood = 0;

		private ETeam team = new ETeam();

		private PlayerSelectionRegion playerSelectReg;

		public int PlayerGold { get { return playerGold; } set { playerGold = value; } }
		public int PlayerWood { get { return playerWood; } set { playerWood = value; } }
		public int PlayerCurrentFood { get { return playerCurrentFood; } set { playerCurrentFood = value; } }
		public int PlayerMaxFood { get { return playerMaxFood; } set { playerMaxFood = value; } }

		public Player(ETeam team)
		{
			this.team = team;
		}

		public override void Update()
		{
			HandleMouseInput();
		}

		private void HandleMouseInput()
		{
			MouseState mouseState = Mouse.GetState();

			if (mouseState.LeftButton == ButtonState.Pressed)
			{
				Vector2 xy = new Vector2(mouseState.Position.X, mouseState.Position.Y);
				playerSelectReg = new PlayerSelectionRegion(xy);
				playerSelectReg.isMouseDown = true;
			}
			
			if (mouseState.LeftButton == ButtonState.Released)
			{
				playerSelectReg = null;
			}
		}
=======
		public int PlayerGold = 0;
		public int PlayerWood = 0;
		public int PlayerCurrentFood = 0;
		public int PlayerMaxFood = 0;
		public ETeam PlayerTeam = new ETeam();
>>>>>>> Stashed changes
	}
}
