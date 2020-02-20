using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JamenGruop_RTS
{
    public class _Image_UI : GUI
    {
        public _Image_UI(Texture2D image)
        {
            this.sprite = image;
        }
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle(
                    (int)Transform.Position.X - (int)(Transform.Origin.X * Transform.Scale.X),
                    (int)Transform.Position.Y - (int)(Transform.Origin.Y * Transform.Scale.Y),
                    (int)(sprite.Width * Transform.Scale.X),
                    (int)(sprite.Height * Transform.Scale.Y));
            }
        }
        public override void Awake()
        {
            layerDepth = 0.95f;
            base.Awake();
        }

        public override void Start()
        {
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
