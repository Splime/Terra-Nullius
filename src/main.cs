using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace TerraNullius
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class main : Microsoft.Xna.Framework.Game
    {
        public int[,] displayArray = new int[40,50];

        private Texture2D grassTile;
        private Texture2D lPlayer;

        private Vector2 playerPosition = new Vector2(0, 0);

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        bool pJustJumped = false;
        bool pInAir = false;
        private float pPixelVelocity = -0;
        private double gameTimeChange;
        private float floatGameTimeChange;

        private float pInitialJump = -5;

        private float playerMaxVelocity = 10; //pixels per second
        private float playerAcceleration = 10; //pixels per second per second

        private PhysicsHelper playerPhysics;

        private KeyboardState oldState;

        public main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            this.IsMouseVisible = true;

            graphics.PreferredBackBufferHeight = 640;
            graphics.PreferredBackBufferWidth = 800;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            playerPosition.X = 0;
            playerPosition.Y = (37 * 16);

            playerPhysics = new PhysicsHelper(playerMaxVelocity, playerAcceleration);

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

            grassTile = Content.Load<Texture2D>("GrassTile");
            lPlayer = Content.Load<Texture2D>("Player");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            KeyboardState keyState = Keyboard.GetState();
            KeyboardState newState = keyState; //for first pressed functions

            if (keyState.IsKeyDown(Keys.D))
            {
                playerPosition.X += 2;
            }

            if (keyState.IsKeyDown(Keys.A))
            {
                playerPosition.X -= 2;
            }

            if (oldState.IsKeyUp(Keys.W) && newState.IsKeyDown(Keys.W))
            {
                //collision check
                //if no collision, and on solid ground
                pPixelVelocity = pInitialJump;
                pInAir = true;
                pJustJumped = true;
            }

            if (pInAir == true)
            {
                //collision double check
                //send velocity change(collision) to stop clipping
                //if pass
                //ONLY first pass
                if (pJustJumped == true)
                {
                    //send velocity change(collision) to stop clipping
                    playerPosition.Y += pPixelVelocity;
                    pJustJumped = false;
                }
                else
                {
                    //send velocity change(collision) to stop clipping
                    gameTimeChange = gameTime.ElapsedGameTime.TotalMilliseconds;
                    floatGameTimeChange = (float)gameTimeChange;
                    pPixelVelocity = playerPhysics.falling(pPixelVelocity, floatGameTimeChange);
                    playerPosition.Y += pPixelVelocity;
                }
            }
            // TODO: Add your update logic 

            oldState = newState; //set oldstate to the state in this update

            base.Update(gameTime);
        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            spriteBatch.Begin();

            for (int i = 0; i < 50; i++)
            {
                spriteBatch.Draw(grassTile, new Vector2 ((i * 16), (39 * 16)), Color.White);
                spriteBatch.Draw(grassTile, new Vector2((20 * 16), (38 * 16)), Color.White);
                spriteBatch.Draw(grassTile, new Vector2((20 * 16), (37 * 16)), Color.White);
                spriteBatch.Draw(grassTile, new Vector2((20 * 16), (36 * 16)), Color.White);
                spriteBatch.Draw(grassTile, new Vector2((20 * 16), (35 * 16)), Color.White);
            }

            spriteBatch.Draw(lPlayer, playerPosition, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
