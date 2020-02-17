using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamenGruop_RTS
{
	public class SceneContainer
	{
		private List<Scene> scenes = new List<Scene>();
		public List<Scene> Scenes { get => scenes; set => scenes = value; }



		public void Initialize()
		{
			Test();
		}

		public void Test()
		{
			TestScene01 Test01 = new TestScene01
			{
				Name = "Test01"
			};
			Scenes.Add(Test01);

            JonasScene jonasScene = new JonasScene
            {
				Name = "jonasScene"
            };
            jonasScene.Initialize();
            Scenes.Add(jonasScene);

            NicolaScene nicolaScene = new NicolaScene
            {
                Name = "nicolaScene"
            };
            nicolaScene.Initialize();
            Scenes.Add(nicolaScene);

            KasperScene kasperScene = new KasperScene
            {
                Name = "kasperScene"
            };
            kasperScene.Initialize();
            Scenes.Add(kasperScene);

            LucasScene lucasScene = new LucasScene
            {
                Name = "lucasScene"
            };
            lucasScene.Initialize();
            Scenes.Add(lucasScene);

        }
	}
}
