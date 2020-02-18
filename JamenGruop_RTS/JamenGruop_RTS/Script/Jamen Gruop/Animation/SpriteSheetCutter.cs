using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamenGruop_RTS.Script.Jamen_Gruop.Animation
{
    class SpriteSheetCutter
    {
        private Texture2D sprite;

        private int spriteSheetRows,
                    spriteSheetCollumns;

        public SpriteSheetCutter(Texture2D sprite, int x, int y)
        {
            this.sprite = sprite;
            spriteSheetRows = x;
            spriteSheetCollumns = y;
        }
    }
}
