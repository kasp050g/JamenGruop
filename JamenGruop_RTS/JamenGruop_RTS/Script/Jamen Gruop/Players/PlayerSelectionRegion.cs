using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamenGruop_RTS.Script.Jamen_Gruop.Players
{
	class PlayerSelectionRegion : GameObject
	{
		public bool isMouseDown = false;

		private Vector2 xyStart = new Vector2();
		private Vector2 xyEnd = new Vector2();

		private Rectangle selectionArea;

		public PlayerSelectionRegion()
		{ }

		public PlayerSelectionRegion(Vector2 xy)
		{
			xyStart = xy;
		}

		public override void Update()
		{
			if (xyStart != null)
			{
				SelectionRegion();
			}
		}

		private void SelectionRegion()
		{
			MouseState mouseState = Mouse.GetState();

			xyEnd = new Vector2(mouseState.Position.X, mouseState.Position.Y);

			selectionArea = new Rectangle(
				(int)xyStart.X,
				(int)xyStart.Y,
				(int)(xyEnd.X - xyStart.X),
				(int)(xyEnd.Y - xyStart.Y)
				);
		}
	}
}
