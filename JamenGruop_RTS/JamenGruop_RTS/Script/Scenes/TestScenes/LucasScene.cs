using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamenGruop_RTS
{
    public class LucasScene : Scene
    {
        //UnitSelector unitSelector = new UnitSelector();

        public static List<Component> GameObjects = new List<Component>();
        private static List<Component> newGameObjects = new List<Component>();
        private static List<Component> gameObjectsToBeDeleted = new List<Component>();

        public static List<Player> PlayerList = new List<Player>();
        Player playerA = new Player();

        public override void Initialize()
        {
            SceneController.eCurrentTest = eCurrentTestScene.Lucas;
            PlayerList.Add(playerA);
            GameObjects.Add(new Barracks(new Vector2(700, 200)));
            GameObjects.Add(new Goldmine(new Vector2(500, 600)));
            GameObjects.Add(new Farm(new Vector2(800, 600)));
            GameObjects.Add(new Lumbermill(new Vector2(1000, 300)));
            GameObjects.Add(new Worker(playerA, new Vector2(200, 200)));
            GameObjects.Add(new Worker(playerA, new Vector2(150, 200)));
            GameObjects.Add(new Worker(playerA, new Vector2(100, 200)));
            GameObjects.Add(new Worker(playerA, new Vector2(50, 200)));
            GameObjects.Add(new Worker(playerA, new Vector2(0, 200)));
            GameObjects.Add(new Worker(playerA, new Vector2(-50, 200)));
            GameObjects.Add(new Worker(playerA, new Vector2(-100, 200)));
            //GameObjects.Add(unitSelector.showUnit);
            base.Initialize();
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
            foreach (Component component in GameObjects)
            {
                foreach (Component componentOther in GameObjects)
                    component.IsColliding(componentOther);
            }

            foreach (Component comp in GameObjects)
            {
                if (comp is Worker)
                    (comp as Worker).Move();
            }

            base.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (Component component in GameObjects)
            {
                component.Draw(spriteBatch);
            }

            spriteBatch.End();
            base.Draw(spriteBatch);
        }
    }
}
