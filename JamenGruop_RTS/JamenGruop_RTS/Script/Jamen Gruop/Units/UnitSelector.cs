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

        public void Update()
        {
            UnitSelect();
            MoveSelected();
        }

        public void UnitSelect()
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
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

            if (Mouse.GetState().RightButton == ButtonState.Pressed)
            {
                var mousex = Mouse.GetState().Position.X;
                var mousey = Mouse.GetState().Position.Y;
                Vector2 newPosition = new Vector2(mousex, mousey);

                Vector2 worldPosition = Vector2.Transform(newPosition, Matrix.Invert(SceneController.Camera.Transform));

                foreach (Unit item in currentSelectedUnits)
                {

                item.NewMovementCommand(worldPosition);
                }
            }
        }
    }
}
