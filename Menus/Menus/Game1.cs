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

namespace Menus
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch SpriteBatch;
        SpriteFont Font1;

        Texture2D titleScreenBackground;
        Texture2D titleScreenLogo;
        Texture2D aboutButtonIdle;
        Texture2D aboutButtonSelected;
        Texture2D controlsButtonIdle;
        Texture2D controlsButtonSelected;
        Texture2D quitGameButtonIdle;
        Texture2D quitGameButtonSelected;
        Texture2D startGameButtonIdle;
        Texture2D startGameButtonSelected;
        Texture2D stageSelectHeader;
        Texture2D northWesternLogo;
        Texture2D centralLogo;
        Texture2D leftArrowIdle;
        Texture2D leftArrowSelected;
        Texture2D rightArrowIdle;
        Texture2D rightArrowSelected;
        Texture2D backButtonIdle;
        Texture2D backButtonSelected;
        Texture2D doneButtonIdle;
        Texture2D doneButtonSelected;

        string activeMenu;
        string playerOnePressedControl = "blank"; //1, 2, 3, 4, up, down, left, right, start, blank (Player One input)
        string playerTwoPressedControl = "blank"; //1, 2, 3, 4, up, down, left, right, start, blank (Player Two input)
        int Ticks = 0;

        int startMenuSelectedItem = 1;
        int stageSelectMenuSelectedItem = 1;
        int quitGameMenuSelectedItem = 1;
        int controlsMenuSelectedItem = 1;
        int aboutMenuSelectedItem = 1;
        int characterSelectMenuSelectedItem = 1;
        int pauseMenuSelectedItem = 1;
        int resetGameMenuSelectedItem = 1;
        int selectedStage = 1;
        int playerOneCharacter = 1;
        int playerTwoCharacter = 1;
  
        private void updateStartScreen()
        {
            Ticks++;

            switch (playerOnePressedControl)
            {
                case "up":
                    if (Ticks >= 10) { startMenuSelectedItem--; Ticks = 0; }
                    break;
                case "down":
                    if (Ticks >= 10) { startMenuSelectedItem++; Ticks = 0; }
                    break;
            }

            if (startMenuSelectedItem < 1) { startMenuSelectedItem = 1; }
            if (startMenuSelectedItem > 4) { startMenuSelectedItem = 4; }

            switch (startMenuSelectedItem)
            {
                case 1:
                    if (playerOnePressedControl == "start") { activeMenu = "stageSelect"; }
                    break;
                case 2:
                    if (playerOnePressedControl == "start") { activeMenu = "controls"; }
                    break;
                case 3:
                    if (playerOnePressedControl == "start") { activeMenu = "about"; }
                    break;
                case 4:
                    if (playerOnePressedControl == "start") { activeMenu = "quitGame"; }
                    break;
            }
        }

        private void updateStageSelectScreen()
        {
            Ticks++;

            switch (playerOnePressedControl)
            {
                case "left":
                    if (Ticks >= 10) { stageSelectMenuSelectedItem--; Ticks = 0; }
                    break;
                case "right":
                    if (Ticks >= 10) { stageSelectMenuSelectedItem++; Ticks = 0; }
                    break;
                case "down":
                    if (Ticks >= 10) { stageSelectMenuSelectedItem = 3; Ticks = 0; }
                    break;
            }

            if (stageSelectMenuSelectedItem <= 1) { stageSelectMenuSelectedItem = 1; }
            if (stageSelectMenuSelectedItem > 4) { stageSelectMenuSelectedItem = 4; }

            switch (stageSelectMenuSelectedItem)
            {
                case 1:
                    {
                        if (playerOnePressedControl == "1") { selectedStage = 1; }
                        break;
                    }
                case 2:
                    {
                        if (playerOnePressedControl == "1") { selectedStage = 2; }
                        break;
                    }
                case 3:
                    {
                        if (playerOnePressedControl == "1") { activeMenu = "start"; }
                        break;
                    }
                case 4:
                    {
                        if (playerOnePressedControl == "1") { activeMenu = "characterSelect"; }
                        break;
                    }
            }
        }

        private void updateQuitGameScreen()
        {
        }

        private void updateControlsScreen()
        {
        }

        private void updateAboutScreen()
        {
        }

        private void updateCharacterSelectScreen()
        {
        }

        private void updatePauseScreen()
        {
        }

        private void updateResetGameScreen()
        {
        }

        private void drawStartScreen()
        {
            //declaring rectangles to draw textures (fairly self explanatory)

            Rectangle backgroundPosition = new Rectangle(0, 0, 1024, 768); 
            Rectangle logoPosition = new Rectangle((512 - (titleScreenLogo.Width / 4)), 48, (titleScreenLogo.Width / 2), (titleScreenLogo.Height / 2));
            Rectangle buttonPosition = new Rectangle((512 - (startGameButtonIdle.Width / 2)), (logoPosition.Y + logoPosition.Height + 32), startGameButtonIdle.Width, startGameButtonIdle.Height);           

            SpriteBatch.Begin();

            SpriteBatch.Draw(titleScreenBackground, backgroundPosition, Color.White);
            SpriteBatch.Draw(titleScreenLogo, logoPosition, Color.White);

            switch (startMenuSelectedItem) //switch case based on which menu item is selected to draw appropriate textures
            {
                case 1:
                    SpriteBatch.Draw(startGameButtonSelected, new Rectangle(buttonPosition.X, buttonPosition.Y, buttonPosition.Width, startGameButtonSelected.Height), Color.White);
                    SpriteBatch.Draw(controlsButtonIdle, new Rectangle(buttonPosition.X, (buttonPosition.Y + buttonPosition.Height + 24), buttonPosition.Width, buttonPosition.Height), Color.White);
                    SpriteBatch.Draw(aboutButtonIdle, new Rectangle(buttonPosition.X, (buttonPosition.Y + ((buttonPosition.Height + 24) * 2)), buttonPosition.Width, buttonPosition.Height), Color.White);
                    SpriteBatch.Draw(quitGameButtonIdle, new Rectangle(buttonPosition.X, (buttonPosition.Y + ((buttonPosition.Height + 24) * 3)), buttonPosition.Width, buttonPosition.Height), Color.White);
                break;
                case 2:
                    SpriteBatch.Draw(startGameButtonIdle, buttonPosition, Color.White);
                    SpriteBatch.Draw(controlsButtonSelected, new Rectangle(buttonPosition.X, (buttonPosition.Y + buttonPosition.Height + 24), buttonPosition.Width, controlsButtonSelected.Height), Color.White);
                    SpriteBatch.Draw(aboutButtonIdle, new Rectangle(buttonPosition.X, (buttonPosition.Y + ((buttonPosition.Height + 24) * 2)), buttonPosition.Width, buttonPosition.Height), Color.White);
                    SpriteBatch.Draw(quitGameButtonIdle, new Rectangle(buttonPosition.X, (buttonPosition.Y + ((buttonPosition.Height + 24) * 3)), buttonPosition.Width, buttonPosition.Height), Color.White);
                break;
                case 3:
                    SpriteBatch.Draw(startGameButtonIdle, buttonPosition, Color.White);
                    SpriteBatch.Draw(controlsButtonIdle, new Rectangle(buttonPosition.X, (buttonPosition.Y + buttonPosition.Height + 24), buttonPosition.Width, buttonPosition.Height), Color.White);
                    SpriteBatch.Draw(aboutButtonSelected, new Rectangle(buttonPosition.X, (buttonPosition.Y + ((buttonPosition.Height + 24) * 2)), buttonPosition.Width, aboutButtonSelected.Height), Color.White);
                    SpriteBatch.Draw(quitGameButtonIdle, new Rectangle(buttonPosition.X, (buttonPosition.Y + ((buttonPosition.Height + 24) * 3)), buttonPosition.Width, buttonPosition.Height), Color.White);
                break;
                case 4:
                    SpriteBatch.Draw(startGameButtonIdle, buttonPosition, Color.White);
                    SpriteBatch.Draw(controlsButtonIdle, new Rectangle(buttonPosition.X, (buttonPosition.Y + buttonPosition.Height + 24), buttonPosition.Width, buttonPosition.Height), Color.White);
                    SpriteBatch.Draw(aboutButtonIdle, new Rectangle(buttonPosition.X, (buttonPosition.Y + ((buttonPosition.Height + 24) * 2)), buttonPosition.Width, buttonPosition.Height), Color.White);
                    SpriteBatch.Draw(quitGameButtonSelected, new Rectangle(buttonPosition.X, (buttonPosition.Y + ((buttonPosition.Height + 24) * 3)), buttonPosition.Width, quitGameButtonSelected.Height), Color.White);
                    break;
            }

            SpriteBatch.End();

        }

        private void drawStageSelectScreen()
        {
            Rectangle backgroundPosition = new Rectangle(0, 0, 1024, 768);
            Rectangle headerPosition = new Rectangle(0, 0, 1024, stageSelectHeader.Height);
            Rectangle logoPosition = new Rectangle((512 - (northWesternLogo.Width / 2)), (((768 + stageSelectHeader.Height) / 2) - (northWesternLogo.Height / 2)), northWesternLogo.Width, northWesternLogo.Width);
            Rectangle rightButtonIdle = new Rectangle((logoPosition.X - leftArrowIdle.Width - 24), ((logoPosition.Y + (logoPosition.Height / 2)) - (leftArrowIdle.Height / 2)), (rightArrowIdle.Width), (rightArrowIdle.Height));
            Rectangle rightButtonSelected = new Rectangle((logoPosition.X - leftArrowIdle.Width - 24), ((logoPosition.Y + (logoPosition.Height / 2)) - (leftArrowIdle.Height / 2)), (rightArrowIdle.Width), (rightArrowSelected.Height));
            Rectangle leftButtonIdle = new Rectangle((logoPosition.X + logoPosition.Width + 24), ((logoPosition.Y + (logoPosition.Height / 2)) - (leftArrowIdle.Height / 2)), (rightArrowIdle.Width), (rightArrowIdle.Height));
            Rectangle leftButtonSelected = new Rectangle((logoPosition.X + logoPosition.Width + 24), ((logoPosition.Y + (logoPosition.Height / 2)) - (leftArrowIdle.Height / 2)), (rightArrowIdle.Width), (rightArrowSelected.Height));
            Rectangle backButtonPosition = new Rectangle(24, (768 - backButtonIdle.Height - 24), backButtonIdle.Width, backButtonIdle.Height);
            Rectangle doneButtonPosition = new Rectangle((1024 - 24 - backButtonIdle.Width), (768 - backButtonIdle.Height - 24), backButtonIdle.Width, backButtonIdle.Height);

            SpriteBatch.Begin();

            SpriteBatch.Draw(titleScreenBackground, backgroundPosition, Color.White);
            SpriteBatch.Draw(stageSelectHeader, headerPosition, Color.White);
           
            switch(stageSelectMenuSelectedItem)
            {
                case 1:
                    {
                        SpriteBatch.Draw(leftArrowSelected, rightButtonSelected, Color.White);
                        SpriteBatch.Draw(rightArrowIdle, leftButtonIdle, Color.White);
                        SpriteBatch.Draw(backButtonIdle, backButtonPosition, Color.White);
                        SpriteBatch.Draw(doneButtonIdle, doneButtonPosition, Color.White);
                        if (selectedStage == 1)
                        {
                            SpriteBatch.Draw(northWesternLogo, logoPosition, Color.White);
                        }
                        else if (selectedStage == 2)
                        {
                            SpriteBatch.Draw(centralLogo, logoPosition, Color.White);
                        }
                        break;
                    }
                case 2:
                    {
                        SpriteBatch.Draw(leftArrowIdle, rightButtonIdle, Color.White);
                        SpriteBatch.Draw(rightArrowSelected, leftButtonSelected, Color.White);
                        SpriteBatch.Draw(backButtonIdle, backButtonPosition, Color.White);
                        SpriteBatch.Draw(doneButtonIdle, doneButtonPosition, Color.White);
                        if (selectedStage == 1)
                        {
                            SpriteBatch.Draw(northWesternLogo, logoPosition, Color.White);
                        }
                        else if (selectedStage == 2)
                        {
                            SpriteBatch.Draw(centralLogo, logoPosition, Color.White);
                        }
                        break;
                    }
                case 3:
                    {
                        SpriteBatch.Draw(leftArrowIdle, rightButtonIdle, Color.White);
                        SpriteBatch.Draw(rightArrowIdle, leftButtonIdle, Color.White);
                        SpriteBatch.Draw(backButtonSelected, (new Rectangle(backButtonPosition.X, backButtonPosition.Y, backButtonIdle.Width, backButtonSelected.Height)), Color.White);
                        SpriteBatch.Draw(doneButtonIdle, doneButtonPosition, Color.White);
                        if (selectedStage == 1)
                        {
                            SpriteBatch.Draw(northWesternLogo, logoPosition, Color.White);
                        }
                        else if (selectedStage == 2)
                        {
                            SpriteBatch.Draw(centralLogo, logoPosition, Color.White);
                        }
                        break;
                    }
                case 4:
                    {
                        SpriteBatch.Draw(leftArrowIdle, rightButtonIdle, Color.White);
                        SpriteBatch.Draw(rightArrowIdle, leftButtonIdle, Color.White);
                        SpriteBatch.Draw(backButtonIdle, backButtonPosition, Color.White);
                        SpriteBatch.Draw(doneButtonSelected, (new Rectangle(doneButtonPosition.X, doneButtonPosition.Y, doneButtonIdle.Width, doneButtonSelected.Height)), Color.White);
                        if (selectedStage == 1)
                        {
                            SpriteBatch.Draw(northWesternLogo, logoPosition, Color.White);
                        }
                        else if (selectedStage == 2)
                        {
                            SpriteBatch.Draw(centralLogo, logoPosition, Color.White);
                        }
                        break;
                    }
            }



            SpriteBatch.End();


        }

        private void drawQuitGameScreen()
        {
        }

        private void drawControlsScreen()
        {
        }

        private void drawAboutScreen()
        {
        }

        private void drawCharacterSelectScreen()
        {
        }

        private void drawPauseScreen()
        {
        }

        private void drawResetGameScreen()
        {
        }



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            this.graphics.PreferredBackBufferWidth = 1024;
            this.graphics.PreferredBackBufferHeight = 768;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            titleScreenBackground = Content.Load<Texture2D>("TitleScreenBackground");
            titleScreenLogo = Content.Load<Texture2D>("TitleScreenLogo");
            aboutButtonIdle = Content.Load<Texture2D>("AboutButtonIdle");
            aboutButtonSelected = Content.Load<Texture2D>("AboutButtonSelected");
            controlsButtonIdle = Content.Load<Texture2D>("ControlsButtonIdle");
            controlsButtonSelected = Content.Load<Texture2D>("ControlsButtonSelected");
            quitGameButtonIdle = Content.Load<Texture2D>("QuitGameButtonIdle");
            quitGameButtonSelected = Content.Load<Texture2D>("QuitGameButtonSelected");
            startGameButtonIdle = Content.Load<Texture2D>("StartGameButtonIdle");
            startGameButtonSelected = Content.Load<Texture2D>("StartGameButtonSelected");
            stageSelectHeader = Content.Load<Texture2D>("stageSelectHeader");
            northWesternLogo = Content.Load<Texture2D>("StageSelectNorthwestern");
            centralLogo = Content.Load<Texture2D>("StageSelectCentral");
            leftArrowIdle = Content.Load<Texture2D>("LeftArrowIdle");
            leftArrowSelected = Content.Load<Texture2D>("LeftArrowSelected");
            rightArrowIdle = Content.Load<Texture2D>("RightArrowIdle");
            rightArrowSelected = Content.Load<Texture2D>("RightArrowSelected");
            backButtonIdle = Content.Load<Texture2D>("backButtonIdle");
            backButtonSelected = Content.Load<Texture2D>("backButtonSelected");
            doneButtonIdle = Content.Load<Texture2D>("doneButtonIdle");
            doneButtonSelected = Content.Load<Texture2D>("doneButtonSelected");

            activeMenu = "start";
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            switch (activeMenu)
            {
                case "start":
                    updateStartScreen();
                    break;
                case "stageSelect":
                    updateStageSelectScreen();
                    break;
                case "quitGame":
                    updateQuitGameScreen();
                    break;
                case "controls":
                    updateControlsScreen();
                    break;
                case "about":
                    updateAboutScreen();
                    break;
                case "characterSelect":
                    updateCharacterSelectScreen();
                    break;
                case "pause":
                    updatePauseScreen();
                    break;
                case "resetGame":
                    updateResetGameScreen();
                    break;
            }

            //player one input

            if (Keyboard.GetState().IsKeyDown(Keys.W) == true) //up
            {
                playerOnePressedControl = "up";
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A) == true) //left
            {
                playerOnePressedControl = "left";
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S) == true) //down
            {
                playerOnePressedControl = "down";
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D) == true) //right
            {
                playerOnePressedControl = "right";
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Z) == true) //1
            {
                playerOnePressedControl = "1";
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.X) == true) //2
            {
                playerOnePressedControl = "2";
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.C) == true) //3
            {
                playerOnePressedControl = "3";
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.V) == true) //4
            {
                playerOnePressedControl = "4";
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Enter) == true) //start
            {
                playerOnePressedControl = "start";
            }
            else //no key pressed
            {
                playerOnePressedControl = "blank";
            }

            //player two input

            if (Keyboard.GetState().IsKeyDown(Keys.I) == true) //up
            {
                playerTwoPressedControl = "up";
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.J) == true) //left
            {
                playerTwoPressedControl = "left";
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.K) == true) //down
            {
                playerTwoPressedControl = "down";
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.L) == true) //right
            {
                playerTwoPressedControl = "right";
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.N) == true) //1
            {
                playerTwoPressedControl = "1";
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.M) == true) //2
            {
                playerTwoPressedControl = "2";
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.OemComma) == true) //3
            {
                playerTwoPressedControl = "3";
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.OemPeriod) == true) //4
            {
                playerTwoPressedControl = "4";
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.RightShift) == true) //start
            {
                playerTwoPressedControl = "start";
            }
            else //no key pressed
            {
                playerTwoPressedControl = "blank";
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            switch (activeMenu)
            {
                case "start":
                    drawStartScreen();
                    break;
                case "stageSelect":
                    drawStageSelectScreen();
                    break;
                case "quitGame":
                    drawQuitGameScreen();
                    break;
                case "controls":
                    drawControlsScreen();
                    break;
                case "about":
                    drawAboutScreen();
                    break;
                case "characterSelect":
                    drawCharacterSelectScreen();
                    break;
                case "pause":
                    drawPauseScreen();
                    break;
                case "resetGame":
                    drawResetGameScreen();
                    break;
            }

            base.Draw(gameTime);
        }
    }
}
