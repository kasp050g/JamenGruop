using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

		public void UnSelecte()
		{
            foreach (Unit item in currentSelectedUnits)
            {
                (item as _Kasper_Worker).IsSelected = false;
            }
			SelectBuild(false);
			currentSelectedBuild.Clear();
			currentSelectedUnits.Clear();
		}

		public void BuildSelect()
		{
			if (Input.MouseButtonJustPressed(Input.MyMouseButtonsEnum.LeftButton))
			{				
				UnSelecte();

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
				SelectBuild(true);
			}
		}

		public void SelectBuild(bool showBuild)
		{
			foreach (_KasperTestbuild item in currentSelectedBuild)
			{
				item.IsSelect(showBuild);
			}
		}

		public void UnitSelect()
		{
			if (Input.MouseButtonJustPressed(Input.MyMouseButtonsEnum.LeftButton))
			{
				UnSelecte();

				var mousex = Mouse.GetState().Position.X;
				var mousey = Mouse.GetState().Position.Y;
				Vector2 newPosition = new Vector2(mousex, mousey);

				Vector2 worldPosition = Vector2.Transform(newPosition, Matrix.Invert(SceneController.Camera.Transform));
				var mouseRectangle = new Rectangle((int)worldPosition.X, (int)worldPosition.Y, 1, 1);

				foreach (Component item in SceneController.CurrentScene.Components)
				{
					if (item is _Kasper_Worker)
					{
						if (mouseRectangle.Intersects((item as _Kasper_Worker).UnitCollider))
						{
                            if((item as _Kasper_Worker).isWorking == false)
                            {
                                Console.Write("howdy");
                                currentSelectedUnits.Add((item as _Kasper_Worker));
                                (item as _Kasper_Worker).IsSelected = true;
                            }
						}
					}
				}
			}
		}
		public void MoveSelected()
		{
			if (Input.MouseButtonJustPressed(Input.MyMouseButtonsEnum.RightButton))
			{
				bool hitBuild = false;
				var mousex = Mouse.GetState().Position.X;
				var mousey = Mouse.GetState().Position.Y;
				Vector2 newPosition = new Vector2(mousex, mousey);

				Vector2 worldPosition = Vector2.Transform(newPosition, Matrix.Invert(SceneController.Camera.Transform));
				var mouseRectangle = new Rectangle((int)worldPosition.X, (int)worldPosition.Y, 1, 1);

				foreach (Component item in SceneController.CurrentScene.Components)
				{
					if (item is _Barracks)
					{
						if (mouseRectangle.Intersects((item as _Barracks).Collider))
						{
							Console.Write("Hit _Barracks");
							hitBuild = true;
							//currentSelectedUnits.Add((item as _Kasper_Worker));
							foreach (_Kasper_Worker worker in currentSelectedUnits)
							{
								worker.NewMovementCommand(item.Transform.Position, eMoveToSpot.Barracks);
							}
						}
					}
					if (item is _GoldMine)
					{
						if (mouseRectangle.Intersects((item as _GoldMine).Collider))
						{
							Console.Write("Hit _GoldMine");
							hitBuild = true;

							foreach (_Kasper_Worker worker in currentSelectedUnits)
							{
								worker.NewMovementCommand(item.Transform.Position, eMoveToSpot.GoldMine);
							}
						}
					}
					if (item is _LumberMilk)
					{
						if (mouseRectangle.Intersects((item as _LumberMilk).Collider))
						{
							Console.Write("Hit _LumberMilk");
							hitBuild = true;
							//currentSelectedUnits.Add((item as _Kasper_Worker));
							foreach (_Kasper_Worker worker in currentSelectedUnits)
							{
								worker.NewMovementCommand(item.Transform.Position, eMoveToSpot.LumberMilk);
							}
						}
					}
					if (item is _Fram)
					{
						if (mouseRectangle.Intersects((item as _Fram).Collider))
						{
							Console.Write("Hit _Fram");
							hitBuild = true;
							//currentSelectedUnits.Add((item as _Kasper_Worker));
							foreach (_Kasper_Worker worker in currentSelectedUnits)
							{
								worker.NewMovementCommand(item.Transform.Position, eMoveToSpot.Fram);
							}
						}
					}
				}

				if(hitBuild == false)
				{
					foreach (_Kasper_Worker item in currentSelectedUnits)
					{
						item.NewMovementCommand(worldPosition,eMoveToSpot.None);
						worldPosition += new Vector2(50, 0);
					}
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
                UnSelecte();
                foreach (Component item in SceneController.CurrentScene.Components)
				{
					if (item is _Kasper_Worker)
					{
						if (showUnit.ShowUnitSelectCollider.Intersects((item as _Kasper_Worker).UnitCollider))
						{
                            if ((item as _Kasper_Worker).isWorking == false)
                            {
                                currentSelectedUnits.Add((item as _Kasper_Worker));
                                (item as _Kasper_Worker).IsSelected = true;
                            }
						}
					}
				}

				unitZoneSelectReleased = false;
				Console.WriteLine("LeftButton Released");
				showUnit.IsActive = false;
			}
		}



		//public void AttackArrowSelect()
		//{
		//	if (Input.MouseButtonJustPressed(Input.MyMouseButtonsEnum.LeftButton))
		//	{
		//		var mousex = Mouse.GetState().Position.X;
		//		var mousey = Mouse.GetState().Position.Y;
		//		Vector2 newPosition = new Vector2(mousex, mousey);

		//		Vector2 worldPosition = Vector2.Transform(newPosition, Matrix.Invert(SceneController.Camera.Transform));
		//		var mouseRectangle = new Rectangle((int)worldPosition.X, (int)worldPosition.Y, 1, 1);

		//		foreach (Component item in SceneController.CurrentScene.Components)
		//		{
		//			if (item is AttackArrow)
		//			{
		//				if (mouseRectangle.Intersects((item as AttackArrow).Collider))
		//				{
		//					Console.WriteLine("Atttack!");
		//					(item as AttackArrow).AttackZone();
		//				}
		//			}
		//		}

		//		UnSelecte();
		//	}
		//}
	}
}
