using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamenGruop_RTS
{
	public class Camera
	{
		private bool isFirstUpdate = true;
		public Matrix Transform { get; private set; }
		public Vector2 Position { get; set; }
		public Vector2 Destination { get; set; }
		public GameObject Target { get; set; }
		public float MovementWeight { get; set; }

		public Camera()
		{
			this.Transform = Matrix.CreateTranslation(0, 0, 0);
			this.MovementWeight = 0.90f;
		}

		public void Update()
		{
			if (this.Target != null)
			{
				this.Destination = this.Target.Transform.Position;
			}

			if (this.isFirstUpdate == true)
			{
				// On the first update (after each scene switch) the camera should instantly move to destination
				// (meaning that the weight will not have an effect on the movement)

				this.Position = this.Destination;
				this.isFirstUpdate = false;
			}

			this.Position = this.Position * (this.MovementWeight) + (1 - this.MovementWeight) * this.Destination;

            Matrix position = Matrix.CreateTranslation(
				-this.Position.X,
				-this.Position.Y,
				0);

            Matrix offset = Matrix.CreateTranslation(
				GraphicsSetting.ScreenSize.X / 2,
				GraphicsSetting.ScreenSize.Y / 2,
				0);

			this.Transform = position * offset;
		}

		public void OnSwitchScene()
		{
			this.isFirstUpdate = true;
		}
	}
}
