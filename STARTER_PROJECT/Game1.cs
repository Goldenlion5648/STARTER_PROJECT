using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;
using System.Linq;
using System;

namespace STARTER_PROJECT
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        KeyboardState kb, oldkb;
        MouseState mouse, oldmouse;
        Point mousePos;
        SpriteFont testFont;
        Random rand = new Random();

        //Character player, playerCopyTopAndBottom, playerCopyLeftAndRight;
        Character[,] board;
        //Character[,] solutionBoard;
        //Character[,] tokens;
        int playerWidth = 64, playerHeight = 64;

        int boardXDim = 5, boardYDim = 5;

        int screenWidth = 800;
        int screenHeight = 800;

        int gameClock = 0;

        bool hasDoneOneTimeCode = false;

        enum gameState
        {
            titleScreen, gameplay, lose,
        }

        gameState state = gameState.gameplay;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.graphics.PreferredBackBufferHeight = screenHeight;
            this.graphics.PreferredBackBufferWidth = screenWidth;
            this.IsMouseVisible = true;

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

            testFont = Content.Load<SpriteFont>("testFont");

            board = new Character[boardYDim, boardXDim];

            for (int y = 0; y < boardYDim; y++)
            {
                for (int x = 0; x < boardXDim; x++)
                {
                    board[y, x] = new Character(Content.Load<Texture2D>("blankSquare"),
                        new Rectangle(x * (screenWidth / boardXDim), y * (screenHeight / boardYDim), (screenWidth / boardXDim), (screenHeight / boardYDim)));
                }
            }

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
            kb = Keyboard.GetState();
            mouse = Mouse.GetState();
            mousePos.X = mouse.X;
            mousePos.Y = mouse.Y;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            switch (state)
            {
                case gameState.titleScreen:
                    titleScreen();
                    break;
                case gameState.gameplay:
                    gameplay();
                    break;
                case gameState.lose:
                    lose();
                    break;
            }

            oldmouse = mouse;
            oldkb = kb;
            gameClock++;
            base.Update(gameTime);
        }

        public void titleScreen()
        {

        }

        public void startOfGameCode()
        {
            if (hasDoneOneTimeCode == false)
            {
                hasDoneOneTimeCode = true;
            }
        }

        public void lose()
        {

        }

        public void gameplay()
        {
            startOfGameCode();

            userControls();


        }

        public void userControls()
        {

            if (kb.IsKeyDown(Keys.W) || kb.IsKeyDown(Keys.Up))
            {

            }

            if (kb.IsKeyDown(Keys.S) || kb.IsKeyDown(Keys.Down))
            {

            }
            if (kb.IsKeyDown(Keys.A) || kb.IsKeyDown(Keys.Left))
            {

            }
            if (kb.IsKeyDown(Keys.D) || kb.IsKeyDown(Keys.Right))
            {

            }

            if (kb.IsKeyDown(Keys.R) && oldkb.IsKeyUp(Keys.R))
            {

            }

            if (kb.IsKeyDown(Keys.N) && oldkb.IsKeyUp(Keys.N))
            {

            }
            if (kb.IsKeyDown(Keys.C) && oldkb.IsKeyUp(Keys.C))
            {

            }
            if (kb.IsKeyDown(Keys.V) && oldkb.IsKeyUp(Keys.V))
            {


            }
            if (kb.IsKeyDown(Keys.U) && oldkb.IsKeyUp(Keys.U))
            {

            }

        }

        public void reset()
        {

        }

        public void checkWins()
        {

        }

        public void drawTitleScreen()
        {

        }

        public void drawGameplay()
        {


        }

        public void drawLose()
        {

        }

        //public void computerAddValidSpace(int xPos, int yPos, ref List<int[]> computerValidSpaces)
        //{
        //    int[] tempArray = new int[2];

        //    if (xPos >= 0 && xPos < boardXDim && yPos >= 0 && yPos < boardYDim && board[yPos, xPos].moveNumber == 0)
        //    {
        //        tempArray[0] = yPos;
        //        tempArray[1] = xPos;
        //        computerValidSpaces.Add(tempArray);
        //    }
        //}

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            switch (state)
            {
                case gameState.titleScreen:
                    drawTitleScreen();
                    break;
                case gameState.gameplay:
                    drawGameplay();
                    break;
                case gameState.lose:
                    drawLose();
                    break;
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
