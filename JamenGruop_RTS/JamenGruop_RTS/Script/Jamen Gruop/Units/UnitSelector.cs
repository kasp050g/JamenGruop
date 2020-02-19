using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamenGruop_RTS
{
	public class UnitSelector
	{
		List<Unit> currentSelectedUnits = new List<Unit>();
		List<_KasperTestbuild> currentSelectedBuild = new List<_KasperTestbuild>();

		public ShowUnitSelect showUnit = new ShowUnitSelect();

		public bool unitZoneSelectReleased;

		public Vector2 unitZoneSelectReleasedPosition;

		public void Start()
		{

		}

		public void Update()
		{
			UnitSelect();
			UnitZoneSelect();
			MoveSelected();
			BuildSelect();
		}
		public void BuildSelect()
		{
			if (Input.MouseButtonJustPressed(Input.MyMouseButtonsEnum.LeftButton))
			{
				currentSelectedUnits.Clear();

				var mousex = Mouse.GetState().Position.X;
				var mousey = Mouse.GetState().Position.Y;
				Vector2 newPosition = new Vector2(mousex, mousey);

				Vector2 worldPosition = Vector2.Transform(newPosition, Matrix.Invert(SceneController.Camera.Transform));
				var mouseRectangle = new Rectangle((int)worldPosition.X, (int)worldPosition.Y, 1, 1);

				foreach (Component item in SceneController.CurrentScene.Components)
				{
					if (item is _KasperTestbuild)
					{
						if (mouseRectangle.Intersects((item as _KasperTestbuild).BuildCollider))
						{
							Console.Write("Got Build");
							currentSelectedBuild.Add((item as _KasperTestbuild));
						}
					}
				}
			}
		}

		public void UnitSelect()
		{
			if (Input.MouseButtonJustPressed(Input.MyMouseButtonsEnum.LeftButton))
			{
				currentSelectedUnits.Clear();

				var mousex = Mouse.GetState().Position.X;
				var mousey = Mouse.GetState().Position.Y;
				Vector2 newPosition = new Vector2(mousex, mousey);

				Vector2 worldPosition = Vector2.Transform(newPosition, Matrix.Invert(SceneController.Camera.Transform));
				var mouseRectangle = new Rectangle((int)worldPosition.X, (int)worldPosition.Y, 1, 1);

				foreach (Component item in SceneController.CurrentScene.Components)
				{
					if (item is Unit)
					{
						if (mouseRectangle.Intersects((item as Unit).UnitCollider))
						{
							Console.Write("howdy");
							currentSelectedUnits.Add((item as Unit));
						}
					}
				}
			}
		}
		public void MoveSelected()
		{
			if (Input.MouseButtonJustPressed(Input.MyMouseButtonsEnum.RightButton))
			{
				var mousex = Mouse.GetState().Position.X;
				var mousey = Mouse.GetState().Position.Y;
				Vector2 newPosition = new Vector2(mousex, mousey);

				Vector2 worldPosition = Vector2.Transform(newPosition, Matrix.Invert(SceneController.Camera.Transform));

				foreach (Unit item in currentSelectedUnits)
				{
					item.NewMovementCommand(worldPosition);
					worldPosition += new Vector2(100, 0);
				}
			}
		}

		public void UnitZoneSelect()
		{
			if (Input.MouseButtonDown(Input.MyMouseButtonsEnum.LeftButton))
			{
				var mousex = Mouse.GetState().Position.X;
				var mousey = Mouse.GetState().Position.Y;
				Vector2 newPosition = new Vector2(mousex, mousey);

				Vector2 worldPosition = Vector2.Transform(newPosition, Matrix.Invert(SceneController.Camera.Transform));

				if (unitZoneSelectReleased == false)
				{
					currentSelectedUnits.Clear();
					unitZoneSelectReleased = true;

					unitZoneSelectReleasedPosition = worldPosition;

					showUnit.IsActive = true;
					showUnit.Transform.Position = unitZoneSelectReleasedPosition;
				}

				showUnit.Transform.Scale = worldPosition - unitZoneSelectReleasedPosition;
			}
			if (Input.MouseButtonJustReleased(Input.MyMouseButtonsEnum.LeftButton) && unitZoneSelectReleased == true)
			{
				foreach (Component item in SceneController.CurrentScene.Components)
				{
					if (item is Unit)
					{
						if (showUnit.ShowUnitSelectCollider.Intersects((item as Unit).UnitCollider))
						{
							currentSelectedUnits.Add((item as Unit));
						}
					}
				}

				unitZoneSelectReleased = false;
				Console.WriteLine("LeftButton Released");
				showUnit.IsActive = false;
			}
		}
	}
}
