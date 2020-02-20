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
    public class _ShowUI : GUI
    {
        bool doOneTime = true;
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
            transform.Scale = new Vector2(GraphicsSetting.ScreenSize.X,70);
            Color = Color.Gray;            
            base.Awake();            
        }

        public override void Start()
        {
            base.Start();
        }

        public override void Update()
        {
            base.Update();
            if (doOneTime)
            {
                doOneTime = false;
                MoreUI();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public void MoreUI()
        {
            // Gold Icon
            MakeNewImage(
                SpriteContainer.sprite["goldIcon"],
                new Vector2(605, 10),
                new Vector2(0.1f, 0.1f)
                );
            // Wood Icon
            MakeNewImage(
                SpriteContainer.sprite["woodIcon"],
                new Vector2(905, 10),
                new Vector2(0.1f, 0.1f)
                );
            // Food Icon
            MakeNewImage(
                SpriteContainer.sprite["foodIcon"],
                new Vector2(1205, 10),
                new Vector2(0.1f, 0.1f)
                );
        }

        public void MakeNewImage(Texture2D image,Vector2 posiston,Vector2 scale)
        {
            _Image_UI newImage = new _Image_UI(image);
            newImage.Transform.Position = posiston;
            newImage.Transform.Scale = scale;
            SceneController.CurrentScene.Instantiate(newImage);
        }
    }
}
