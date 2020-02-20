using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprites_01
{
    class Barrack02
    {
        //barrack stuff
        float timer = 0f;
        float interval = 3000f; //How fast the animation is from start to finish
        int currentColumn;
        int currentRow;
        int totalColumns = 3;
        int totalRows = 2;
        public Texture2D Texture;
        public Rectangle SourceRect;

        public Vector2 Position;
        public Vector2 Origin;

        //1 = barrack lvl 1
        //2 = barrack lvl 2
        //3 = barrack lvl 3
        //4 = Worker
        //5 = Footman
        int BuildOrder = 1;

        //Select thing
        bool isSelected = true;
        public Texture2D SelectTexture;
        public Vector2 SelectPosition;
        public Rectangle SelectRect;

        //Load bar animation
        int Loading = 0;
        int LoadRows = 25;
        public Vector2 LoadPosition;
        public Texture2D LoadTexture;
        public Rectangle LoadSourceRect;
        float timer2 = 0f;

        //Icon thing
        int IconRows = 5;
        public Vector2 IconPosition;
        public Texture2D IconTexture;
        public Rectangle IconSourceRect;


        public Barrack02(Texture2D Texture, Texture2D LoadTexture, Texture2D IconTexture, Texture2D SelectTexture)
        {
            this.Texture = Texture;
            this.LoadTexture = LoadTexture;
            this.IconTexture = IconTexture;
            this.SelectTexture = SelectTexture;
        }

        public void Update(GameTime gameTime)
        {
            Origin = new Vector2(0, 0);

            //Building stuff
            int width = Texture.Width / totalColumns;
            int height = Texture.Height / totalRows;
            SourceRect = new Rectangle((int)currentColumn * width, (int)currentRow * height, width, height);

            //Loadbar stuff
            int LoadWidth = LoadTexture.Width;
            int Loadheight = LoadTexture.Height / LoadRows;
            //LoadSourceRect = new Rectangle((int)Health * LoadWidth, 1, LoadWidth, Loadheight);
            LoadSourceRect = new Rectangle(1, (int)Loading * Loadheight, LoadWidth, Loadheight);

            LoadPosition.X = Position.X + 56; //Load bar posistion i forhold til Barrack på X aksen
            LoadPosition.Y = Position.Y + 245; //Load bar posistion i forhold til Barrack på Y aksen

            //Icon Stuff
            int IconWidth = IconTexture.Width;
            int Iconheight = IconTexture.Height / IconRows;
            IconSourceRect = new Rectangle(1, ((int)BuildOrder - 1) * Iconheight, IconWidth, Iconheight);

            IconPosition.X = Position.X + 8; //Icon posistion i forhold til Barrack på X aksen
            IconPosition.Y = Position.Y + 238; //Icon posistion i forhold til Barrack på Y aksen

            //Select stuff
            SelectPosition.X = Position.X ; //Select posistion i forhold til Barrack på X aksen
            SelectPosition.Y = Position.Y ; //Select posistion i forhold til Barrack på Y aksen
            int selectWidth = SelectTexture.Width;
            int selectHeigth = SelectTexture.Height;
            SelectRect = new Rectangle(0, 0, selectWidth, selectHeigth);

            switch (BuildOrder)
            {
                case 1:
                    //build lvl 1
                    LoadBar(gameTime);
                    currentColumn = 2;
                    currentRow = 1;
                    timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                    if (timer > interval)
                    {
                        currentRow = 0;
                        BuildOrder = 0;
                    }
                    break;
                case 2:
                    //build lvl 2
                    LoadBar(gameTime);
                    currentColumn = 0;
                    currentRow = 1;
                    timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                    if (timer > interval)
                    {
                        currentRow = 0;
                        BuildOrder = 0;
                    }
                    break;
                case 3:
                    //build lvl 3
                    LoadBar(gameTime);
                    currentColumn = 1;
                    currentRow = 1;
                    timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                    if (timer > interval)
                    {
                        currentRow = 0;
                        BuildOrder = 0;
                    }
                    break;
                case 4:
                    //build worker
                    LoadBar(gameTime);
                    timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                    if (timer > interval)
                    {
                        BuildOrder = 0;
                    }
                    break;
                case 5:
                    //build footman
                    LoadBar(gameTime);
                    timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                    if (timer > interval)
                    {
                        BuildOrder = 0;
                    }
                    break;
                default:
                    //build nothing
                    break;
            }
        }

        public void LoadBar(GameTime gameTime)
        {
            timer2 += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (timer2 > (interval / 26))
            {
                Loading++;
                timer2 = 0f;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isSelected == true)
            {
                spriteBatch.Draw(SelectTexture, SelectPosition, SelectRect, Color.White, 0f, Origin, 0.66f, SpriteEffects.None, 0);
            }
            spriteBatch.Draw(Texture, Position, SourceRect, Color.White, 0f, Origin, 2.0f, SpriteEffects.None, 0);
            if (BuildOrder > 0)
            {
                spriteBatch.Draw(LoadTexture, LoadPosition, LoadSourceRect, Color.White, 0f, Origin, 4.0f, SpriteEffects.None, 0);
                spriteBatch.Draw(IconTexture, IconPosition, IconSourceRect, Color.White, 0f, Origin, 1.0f, SpriteEffects.None, 0);
            }
        }
    }
}
