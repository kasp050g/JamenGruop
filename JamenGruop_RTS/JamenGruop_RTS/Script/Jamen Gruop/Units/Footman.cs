using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamenGruop_RTS 
{
	public class Footman : Unit
	{
        public override void Awake()
        {
            layerDepth = 0.8f;
            sprite = SpriteContainer.sprite["UnitTest"];
            OriginPositionEnum = OriginPositionEnum.Mid;

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
