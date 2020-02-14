using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamenGruop_RTS
{
	public class GUI : Component
	{
        private bool showGUI = true;
        private GUI parentGUI;

        /// <summary>
        /// This is use to show or hide this GUI.
        /// </summary>
        public bool ShowGUI { get { return showGUI; } set { showGUI = value; } }
        public GUI ParentGUI { get { return parentGUI; } set { parentGUI = value; } }

        /// <summary>
        /// Use to check if you hold your mouse over GUI.
        /// </summary>
        public virtual Rectangle GUImouseBlockCollision
        {
            get
            {
                // returns a new rectangle based on the position, scale, sprite width and height.
                return new Rectangle(
                    (int)this.Transform.Position.X - (int)(this.Transform.Origin.X * this.Transform.Scale.X),
                    (int)this.Transform.Position.Y - (int)(this.Transform.Origin.Y * this.Transform.Scale.Y),
                    (int)(this.sprite.Width * this.Transform.Scale.X),
                    (int)(this.sprite.Height * this.Transform.Scale.Y)
                    );
            }
        }

        public override void Awake()
		{
            this.sprite = SpriteContainer.sprite["Test"];
			base.Awake();
		}

		public override void Start()
		{
			base.Start();
		}

		public override void Update()
		{
			base.Update();
            UpdateParentGUI();
        }

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
		}

        public void UpdateParentGUI()
        {
            if (ParentGUI != null)
            {
                if (ShowGUI != ParentGUI.ShowGUI)
                {
                    ShowGUI = ParentGUI.ShowGUI;
                }
            }
        }
    }
}
