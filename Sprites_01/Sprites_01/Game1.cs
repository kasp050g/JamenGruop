using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sprites_01
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private List<Worker> workers;
        private List<Footman> footmen;
        private List<Knight> knights;
        private List<Ballista> ballistas;

        private List<Goldmine> goldmines;
        private List<Barrack> barracks;

        private List<Barrack02> barracks02;
        private List<Goldmine02> goldmines02;
        private List<Worker02> workers02;
        private List<Footman02> footmen02;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 1800;
            graphics.PreferredBackBufferHeight = 1000;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            workers = new List<Worker>()
            {
                new Worker(Content.Load<Texture2D>("Worker02")){Position = new Vector2(100, 100) },
             };
            footmen = new List<Footman>()
            {
                new Footman(Content.Load<Texture2D>("Footman02")){Position = new Vector2(300, 100) },
             };
            knights = new List<Knight>()
            {
                new Knight(Content.Load<Texture2D>("Knight01")){Position = new Vector2(500, 100) },
             };
            ballistas = new List<Ballista>()
            {
                new Ballista(Content.Load<Texture2D>("Ballista01")){Position = new Vector2(700, 100) },
             };
            goldmines = new List<Goldmine>()
            {
                new Goldmine(Content.Load<Texture2D>("Goldmine05")){Position = new Vector2(900, 100) },
             };
            barracks = new List<Barrack>()
            {
                new Barrack(Content.Load<Texture2D>("Buildings14")){Position = new Vector2(1100, 500) },
             };
            // Updated versions
            barracks02 = new List<Barrack02>()
            {
                new Barrack02(Content.Load<Texture2D>("Buildings14"),
                              Content.Load<Texture2D>("Loadbar02"),
                              Content.Load<Texture2D>("Icons02"),
                              Content.Load<Texture2D>("Selected04.1"))
                             { Position = new Vector2(200, 500) },
             };
            goldmines02 = new List<Goldmine02>()
            {
                new Goldmine02(Content.Load<Texture2D>("Goldmine05"),
                Content.Load<Texture2D>("Selected04.1"))
                { Position = new Vector2(1200, 300) },
             };
            workers02 = new List<Worker02>()
            {
                new Worker02(Content.Load<Texture2D>("Worker02"),
                Content.Load<Texture2D>("Selected04.1"))
                {Position = new Vector2(500, 500) },
             };
            footmen02 = new List<Footman02>()
            {
                new Footman02(Content.Load<Texture2D>("Footman02"),
                Content.Load<Texture2D>("Selected04.1"))
                { Position = new Vector2(600, 500) },
             };
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (Worker worker in workers)
            {
                worker.Controls(gameTime);
            }
            foreach (Footman footman in footmen)
            {
                footman.Controls(gameTime);
            }
            //foreach (Knight knight in knights)
            //{
            //    knight.Controls(gameTime);
            //}
            //foreach (Ballista ballista in ballistas)
            //{
            //    ballista.Controls(gameTime);
            //}
            foreach (Goldmine goldmine in goldmines)
            {
                goldmine.Update(gameTime);
            }
            foreach (Barrack barrack in barracks)
            {
                barrack.Update(gameTime);
            }
            //Updated versions
            foreach (Barrack02 barrack02 in barracks02)
            {
                barrack02.Update(gameTime);
            }
            foreach (Goldmine02 goldmine02 in goldmines02)
            {
                goldmine02.Update(gameTime);
            }
            foreach (Worker02 worker02 in workers02)
            {
                worker02.Controls(gameTime);
            }
            foreach (Footman02 footman02 in footmen02)
            {
                footman02.Controls(gameTime);
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Green);

            spriteBatch.Begin();
            foreach (Worker worker in workers)
            {
                worker.Draw(spriteBatch);
            }
            foreach (Footman footman in footmen)
            {
                footman.Draw(spriteBatch);
            }
            //foreach (Knight knight in knights)
            //{
            //    knight.Draw(spriteBatch);
            //}
            //foreach (Ballista ballista in ballistas)
            //{
            //    ballista.Draw(spriteBatch);
            //}
            foreach (Goldmine goldmine in goldmines)
            {
                goldmine.Draw(spriteBatch);
            }
            foreach (Barrack barrack in barracks)
            {
                barrack.Draw(spriteBatch);
            }
            //Updated version
            foreach (Barrack02 barrack02 in barracks02)
            {
                barrack02.Draw(spriteBatch);
            }
            foreach (Goldmine02 goldmine02 in goldmines02)
            {
                goldmine02.Draw(spriteBatch);
            }
            foreach (Worker02 worker02 in workers02)
            {
                worker02.Draw(spriteBatch);
            }
            foreach (Footman02 footman02 in footmen02)
            {
                footman02.Draw(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
