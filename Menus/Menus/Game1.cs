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
        Texture2D characterSelectHeader;
        Texture2D characterSelectPane;
        Texture2D characterOneIcon;
        Texture2D characterTwoIcon;
        Texture2D characterThreeIcon;
        Texture2D characterFourIcon;
        Texture2D characterFiveIcon;
        Texture2D characterSixIcon;
        Texture2D characterSevenIcon;
        Texture2D characterEightIcon;
        Texture2D characterNineIcon;
        Texture2D playerOneSelectedCharacter;
        Texture2D playerTwoSelectedCharacter;
        Texture2D controllerIdle;
        Texture2D dPadControls;
        Texture2D buttonControls;
        Texture2D startControls;
        Texture2D controlsHeader;
        Texture2D aboutHeader;
        Texture2D controllerSelected;
        Texture2D showControlsButtonIdle;
        Texture2D showControlsButtonSelected;
        Texture2D infoPane;


        string activeMenu;
        string playerOnePressedControl = "blank"; //1, 2, 3, 4, up, down, left, right, start, blank (Player One input)
        string playerTwoPressedControl = "blank"; //1, 2, 3, 4, up, down, left, right, start, blank (Player Two input)
        int Ticks = 0;
        int playerOneTicks = 0;
        int playerTwoTicks = 0;
        int globalTicks = 0;

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
        bool playerOneReady = false;
        bool playerTwoReady = false;
        bool showControls = false;

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
                    if (playerOnePressedControl == "1" && globalTicks >= 20) { activeMenu = "stageSelect"; globalTicks = 0; }
                    break;
                case 2:
                    if (playerOnePressedControl == "1" && globalTicks >= 20) { activeMenu = "controls"; globalTicks = 0; }
                    break;
                case 3:
                    if (playerOnePressedControl == "1" && globalTicks >= 20) { activeMenu = "about"; globalTicks = 0; }
                    break;
                case 4:
                    if (playerOnePressedControl == "1") { this.Exit(); }
                    break;
                case 5:
                    if (playerOnePressedControl == "start" && globalTicks >= 20) { activeMenu = "stageSelect"; globalTicks = 0; }
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
                        if (playerOnePressedControl == "1" && globalTicks >= 20) { activeMenu = "start"; globalTicks = 0; }
                        break;
                    }
                case 4:
                    {
                        if (playerOnePressedControl == "1") { activeMenu = "characterSelect"; }
                        break;
                    }
            }
        }

        private void updateControlsScreen()
        {
            Ticks++;

            switch (playerOnePressedControl)
            {
                case "left":
                    if (Ticks >= 10) { controlsMenuSelectedItem--; Ticks = 0; }
                    break;
                case "right":
                    if (Ticks >= 10) { controlsMenuSelectedItem++; Ticks = 0; }
                    break;
                case "1":
                    if (controlsMenuSelectedItem == 2 && globalTicks >= 20) { activeMenu = "start"; globalTicks = 0; };
                    if (controlsMenuSelectedItem == 1 && showControls == false && Ticks >= 10) { showControls = true; Ticks = 0; };
                    if (controlsMenuSelectedItem == 1 && showControls == true && Ticks >= 10) { showControls = false; Ticks = 0; };
                    break;
            }

            if (controlsMenuSelectedItem <= 1) { controlsMenuSelectedItem = 1; };
            if (controlsMenuSelectedItem > 2) { controlsMenuSelectedItem = 2; };

        }

        private void updateAboutScreen()
        {

         if (playerOnePressedControl == "1" && globalTicks >= 20) { activeMenu = "start"; globalTicks = 0; }

        }

        private void updateCharacterSelectScreen()
        {
            playerOneTicks++;
            playerTwoTicks++;

                switch (playerOnePressedControl)
                {
                    case "left":
                        if (playerOneTicks >= 10) { playerOneCharacter--; playerOneTicks = 0; }
                        break;
                    case "right":
                        if (playerOneTicks >= 10) { playerOneCharacter++; playerOneTicks = 0; }
                        break;
                    case "1":
                        playerOneReady = true;
                        break;
                }

                if (playerOneCharacter <= 1) { playerOneCharacter = 1; }
                if (playerOneCharacter > 9) { playerOneCharacter = 9; }

                switch (playerTwoPressedControl)
                {
                    case "left":
                        if (playerTwoTicks >= 10) { playerTwoCharacter--; playerTwoTicks = 0; }
                        break;
                    case "right":
                        if (playerTwoTicks >= 10) { playerTwoCharacter++; playerTwoTicks = 0; }
                        break;
                    case "1":
                        playerTwoReady = true;
                        break;
                }

                if (playerTwoCharacter <= 1) { playerTwoCharacter = 1; }
                if (playerTwoCharacter > 9) { playerTwoCharacter = 9; }

            if (playerOneReady == true && playerOnePressedControl == "2")
            {
                playerOneReady = false;
            }

            if (playerTwoReady == true && playerTwoPressedControl == "2")
            {
                playerTwoReady = false;
            }

            Ticks++;

            if (playerOneReady == true && playerTwoReady == true)
            {
                if (Ticks >= 50)
                {
                    activeMenu = "inGame";
                }
            }
        }

        private void updatePauseScreen()
        {
        }

        private void updateResetGameScreen()
        {
        }

        private void updateInGameScreen()
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

        private void drawControlsScreen()
        {
            SpriteBatch.Begin();

            Rectangle controllerIdlePosition = new Rectangle((512 - (controllerIdle.Width / 2)), (controlsHeader.Height + ((640 - controllerIdle.Height) / 2)), controllerIdle.Width, controllerIdle.Height);
            Rectangle showControlsButton = new Rectangle(((controllerIdlePosition.X + (controllerIdle.Width / 2)) - 265), (controllerIdlePosition.Y + controllerIdle.Height - (doneButtonIdle.Height / 2)), showControlsButtonIdle.Width, showControlsButtonIdle.Height);
            Rectangle doneButton = new Rectangle((showControlsButton.X + showControlsButtonIdle.Width + 32), (controllerIdlePosition.Y + controllerIdle.Height - (doneButtonIdle.Height / 2)), doneButtonIdle.Width, doneButtonIdle.Height);

            SpriteBatch.Draw(titleScreenBackground, (new Rectangle(0, 0, titleScreenBackground.Width, titleScreenBackground.Height)), Color.White);
            SpriteBatch.Draw(controlsHeader, (new Rectangle(0, 0, controlsHeader.Width, controlsHeader.Height)), Color.White);


            SpriteBatch.Draw(controllerIdle, controllerIdlePosition, Color.White);

            switch (showControls)
            {
                case true:
                    SpriteBatch.Draw(controllerSelected, (new Rectangle(controllerIdlePosition.X - 32, controllerIdlePosition.Y, controllerSelected.Width, controllerSelected.Height)), Color.White);
                    break;
                case false:
                    SpriteBatch.Draw(controllerIdle, controllerIdlePosition, Color.White);
                    break;
            }

            switch (controlsMenuSelectedItem)
            {
                case 1:
                    SpriteBatch.Draw(showControlsButtonSelected, new Rectangle(showControlsButton.X, showControlsButton.Y, showControlsButtonIdle.Width, showControlsButtonSelected.Height), Color.White);
                    SpriteBatch.Draw(doneButtonIdle, doneButton, Color.White);
                    break;
                case 2:
                    SpriteBatch.Draw(showControlsButtonIdle, showControlsButton, Color.White);
                    SpriteBatch.Draw(doneButtonSelected, new Rectangle(doneButton.X, doneButton.Y, doneButtonIdle.Width, doneButtonSelected.Height), Color.White);
                    break;
            }

            SpriteBatch.End();

        }

        private void drawAboutScreen()
        {
            SpriteBatch.Begin();

            Rectangle doneButton = new Rectangle(512 - (doneButtonIdle.Width / 2), aboutHeader.Height + infoPane.Height + 88 + 32, doneButtonIdle.Width, doneButtonSelected.Height);
            Rectangle infoPanePos = new Rectangle(512 - (infoPane.Width / 2), (aboutHeader.Height + ((553 - infoPane.Height) / 2)), infoPane.Width, infoPane.Height);

            SpriteBatch.Draw(titleScreenBackground, new Rectangle(0, 0, titleScreenBackground.Width, titleScreenBackground.Height), Color.White);
            SpriteBatch.Draw(aboutHeader, new Rectangle(0, 0, aboutHeader.Width, aboutHeader.Height), Color.White);
            SpriteBatch.Draw(infoPane, infoPanePos, Color.White);
            SpriteBatch.Draw(doneButtonSelected, doneButton, Color.White);

            SpriteBatch.End();
        }

        private void drawCharacterSelectScreen()
        {
            SpriteBatch.Begin();

            SpriteBatch.Draw(titleScreenBackground, (new Rectangle(0, 0, titleScreenBackground.Width, titleScreenBackground.Height)), Color.White);
            SpriteBatch.Draw(characterSelectHeader, (new Rectangle(0, 0, characterSelectHeader.Width, characterSelectHeader.Height)), Color.White);

            int charColumnOneX = 48;
            int charColumnTwoX = 160;
            int charColumnThreeX = 272;
            int charRowOneY = 164;
            int charRowTwoY = 276;
            int charRowThreeY = 388;
            int playerOneSelectedCharacterX = 48;
            int playerTwoSelectedCharacterX = 48;
            int playerOneSelectedCharacterY = 164;
            int playerTwoSelectedCharacterY = 164;

            switch (playerOneCharacter)
            {
                case 1:
                    playerOneSelectedCharacterX = charColumnOneX; playerOneSelectedCharacterY = charRowOneY;
                    break;
                case 2:
                    playerOneSelectedCharacterX = charColumnTwoX; playerOneSelectedCharacterY = charRowOneY;
                    break;
                case 3:
                    playerOneSelectedCharacterX = charColumnThreeX; playerOneSelectedCharacterY = charRowOneY;
                    break;
                case 4:
                    playerOneSelectedCharacterX = charColumnOneX; playerOneSelectedCharacterY = charRowTwoY;
                    break;
                case 5:
                    playerOneSelectedCharacterX = charColumnTwoX; playerOneSelectedCharacterY = charRowTwoY;
                    break;
                case 6:
                    playerOneSelectedCharacterX = charColumnThreeX; playerOneSelectedCharacterY = charRowTwoY;
                    break;
                case 7:
                    playerOneSelectedCharacterX = charColumnOneX; playerOneSelectedCharacterY = charRowThreeY;
                    break;
                case 8:
                    playerOneSelectedCharacterX = charColumnTwoX; playerOneSelectedCharacterY = charRowThreeY;
                    break;
                case 9:
                    playerOneSelectedCharacterX = charColumnThreeX; playerOneSelectedCharacterY = charRowThreeY;
                    break;
            }

            switch (playerTwoCharacter)
            {
                case 1:
                    playerTwoSelectedCharacterX = charColumnOneX; playerTwoSelectedCharacterY = charRowOneY;
                    break;
                case 2:
                    playerTwoSelectedCharacterX = charColumnTwoX; playerTwoSelectedCharacterY = charRowOneY;
                    break;
                case 3:
                    playerTwoSelectedCharacterX = charColumnThreeX; playerTwoSelectedCharacterY = charRowOneY;
                    break;
                case 4:
                    playerTwoSelectedCharacterX = charColumnOneX; playerTwoSelectedCharacterY = charRowTwoY;
                    break;
                case 5:
                    playerTwoSelectedCharacterX = charColumnTwoX; playerTwoSelectedCharacterY = charRowTwoY;
                    break;
                case 6:
                    playerTwoSelectedCharacterX = charColumnThreeX; playerTwoSelectedCharacterY = charRowTwoY;
                    break;
                case 7:
                    playerTwoSelectedCharacterX = charColumnOneX; playerTwoSelectedCharacterY = charRowThreeY;
                    break;
                case 8:
                    playerTwoSelectedCharacterX = charColumnTwoX; playerTwoSelectedCharacterY = charRowThreeY;
                    break;
                case 9:
                    playerTwoSelectedCharacterX = charColumnThreeX; playerTwoSelectedCharacterY = charRowThreeY;
                    break;
            }

            Rectangle playerOnePane = new Rectangle(60, ((((titleScreenBackground.Height - characterSelectHeader.Height) - characterSelectPane.Height) / 2) + characterSelectHeader.Height), characterSelectPane.Width, characterSelectPane.Height);
            Rectangle playerTwoPane = new Rectangle(544, ((((titleScreenBackground.Height - characterSelectHeader.Height) - characterSelectPane.Height) / 2) + characterSelectHeader.Height), characterSelectPane.Width, characterSelectPane.Height);

            Rectangle playerOneSelection = new Rectangle((playerOnePane.X + playerOneSelectedCharacterX), (playerOnePane.Y + playerOneSelectedCharacterY), playerOneSelectedCharacter.Width, playerOneSelectedCharacter.Height);
            Rectangle playerTwoSelection = new Rectangle((playerTwoPane.X + playerTwoSelectedCharacterX), (playerTwoPane.Y + playerTwoSelectedCharacterY), playerTwoSelectedCharacter.Width, playerTwoSelectedCharacter.Height);
            Rectangle playerOneSelectionIcon = new Rectangle((playerOnePane.X + 168), (playerOnePane.Y + 28), characterOneIcon.Width, characterOneIcon.Height);
            Rectangle playerTwoSelectionIcon = new Rectangle((playerTwoPane.X + 168), (playerTwoPane.Y + 28), characterOneIcon.Width, characterOneIcon.Height);


            SpriteBatch.Draw(characterSelectPane, playerOnePane, Color.White);
            SpriteBatch.Draw(characterSelectPane, playerTwoPane, Color.White);
            SpriteBatch.Draw(playerOneSelectedCharacter, playerOneSelection, Color.White);
            SpriteBatch.Draw(playerTwoSelectedCharacter, playerTwoSelection, Color.White);

            switch (playerOneCharacter)
            {
                case 1:
                    SpriteBatch.Draw(characterOneIcon, playerOneSelectionIcon, Color.White);
                    break;
                case 2:
                    SpriteBatch.Draw(characterTwoIcon, playerOneSelectionIcon, Color.White);
                    break;
                case 3:
                    SpriteBatch.Draw(characterThreeIcon, playerOneSelectionIcon, Color.White);
                    break;
                case 4:
                    SpriteBatch.Draw(characterFourIcon, playerOneSelectionIcon, Color.White);
                    break;
                case 5:
                    SpriteBatch.Draw(characterFiveIcon, playerOneSelectionIcon, Color.White);
                    break;
                case 6:
                    SpriteBatch.Draw(characterSixIcon, playerOneSelectionIcon, Color.White);
                    break;
                case 7:
                    SpriteBatch.Draw(characterSevenIcon, playerOneSelectionIcon, Color.White);
                    break;
                case 8:
                    SpriteBatch.Draw(characterEightIcon, playerOneSelectionIcon, Color.White);
                    break;
                case 9:
                    SpriteBatch.Draw(characterNineIcon, playerOneSelectionIcon, Color.White);
                    break;
            }

            switch (playerTwoCharacter)
            {
                case 1:
                    SpriteBatch.Draw(characterOneIcon, playerTwoSelectionIcon, Color.White);
                    break;
                case 2:
                    SpriteBatch.Draw(characterTwoIcon, playerTwoSelectionIcon, Color.White);
                    break;
                case 3:
                    SpriteBatch.Draw(characterThreeIcon, playerTwoSelectionIcon, Color.White);
                    break;
                case 4:
                    SpriteBatch.Draw(characterFourIcon, playerTwoSelectionIcon, Color.White);
                    break;
                case 5:
                    SpriteBatch.Draw(characterFiveIcon, playerTwoSelectionIcon, Color.White);
                    break;
                case 6:
                    SpriteBatch.Draw(characterSixIcon, playerTwoSelectionIcon, Color.White);
                    break;
                case 7:
                    SpriteBatch.Draw(characterSevenIcon, playerTwoSelectionIcon, Color.White);
                    break;
                case 8:
                    SpriteBatch.Draw(characterEightIcon, playerTwoSelectionIcon, Color.White);
                    break;
                case 9:
                    SpriteBatch.Draw(characterNineIcon, playerTwoSelectionIcon, Color.White);
                    break;
            }

            SpriteBatch.End();
        }

        private void drawPauseScreen()
        {
        }

        private void drawResetGameScreen()
        {
        }

        private void drawInGameScreen()
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
            characterSelectHeader = Content.Load<Texture2D>("characterSelectHeader");
            characterSelectPane = Content.Load<Texture2D>("characterSelectPane");
            characterOneIcon = Content.Load<Texture2D>("char1");
            characterTwoIcon = Content.Load<Texture2D>("char2");
            characterThreeIcon = Content.Load<Texture2D>("char3");
            characterFourIcon = Content.Load<Texture2D>("char4");
            characterFiveIcon = Content.Load<Texture2D>("char5");
            characterSixIcon = Content.Load<Texture2D>("char6");
            characterSevenIcon = Content.Load<Texture2D>("char7");
            characterEightIcon = Content.Load<Texture2D>("char8");
            characterNineIcon = Content.Load<Texture2D>("char9");
            playerOneSelectedCharacter = Content.Load<Texture2D>("playerOneSelectedCharacter");
            playerTwoSelectedCharacter = Content.Load<Texture2D>("playerTwoSelectedCharacter");
            aboutHeader = Content.Load<Texture2D>("aboutHeader");
            controlsHeader = Content.Load<Texture2D>("controlsHeader");
            buttonControls = Content.Load<Texture2D>("buttonControls");
            dPadControls = Content.Load<Texture2D>("dPadControls");
            startControls = Content.Load<Texture2D>("startControl");
            controllerIdle = Content.Load<Texture2D>("controllerIdle");
            controllerSelected = Content.Load<Texture2D>("controllerSelected");
            showControlsButtonIdle = Content.Load<Texture2D>("showControlsButtonIdle");
            showControlsButtonSelected = Content.Load<Texture2D>("showControlsButtonSelected");
            infoPane = Content.Load<Texture2D>("infoPane");


            activeMenu = "start";
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            GamePadState playerOneState = GamePad.GetState(PlayerIndex.One);
            GamePadState playerTwoState = GamePad.GetState(PlayerIndex.Two);

            globalTicks++;


            switch (activeMenu)
            {
                case "start":
                    updateStartScreen();
                    break;
                case "stageSelect":
                    updateStageSelectScreen();
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
                case "inGame":
                    updateInGameScreen();
                    break;
            }

            //player one input

            if (playerOneState.DPad.Up == ButtonState.Pressed) //up
            {
                playerOnePressedControl = "up";
            }
            else if (playerOneState.DPad.Left == ButtonState.Pressed) //left
            {
                playerOnePressedControl = "left";
            }
            else if (playerOneState.DPad.Down == ButtonState.Pressed) //down
            {
                playerOnePressedControl = "down";
            }
            else if (playerOneState.DPad.Right == ButtonState.Pressed) //right
            {
                playerOnePressedControl = "right";
            }
            else if (playerOneState.Buttons.A == ButtonState.Pressed) //1
            {
                playerOnePressedControl = "1";
            }
            else if (playerOneState.Buttons.B == ButtonState.Pressed) //2
            {
                playerOnePressedControl = "2";
            }
            else if (playerOneState.Buttons.X == ButtonState.Pressed) //3
            {
                playerOnePressedControl = "3";
            }
            else if (playerOneState.Buttons.Y == ButtonState.Pressed) //4
            {
                playerOnePressedControl = "4";
            }
            else if (playerOneState.Buttons.Start == ButtonState.Pressed) //start
            {
                playerOnePressedControl = "start";
            }
            else //no key pressed
            {
                playerOnePressedControl = "blank";
            }

            //player two input

            if (playerTwoState.DPad.Up == ButtonState.Pressed) //up
            {
                playerTwoPressedControl = "up";
            }
            else if (playerTwoState.DPad.Left == ButtonState.Pressed) //left
            {
                playerTwoPressedControl = "left";
            }
            else if (playerTwoState.DPad.Down == ButtonState.Pressed) //down
            {
                playerTwoPressedControl = "down";
            }
            else if (playerTwoState.DPad.Right == ButtonState.Pressed) //right
            {
                playerTwoPressedControl = "right";
            }
            else if (playerTwoState.Buttons.A == ButtonState.Pressed) //1
            {
                playerTwoPressedControl = "1";
            }
            else if (playerTwoState.Buttons.B == ButtonState.Pressed) //2
            {
                playerTwoPressedControl = "2";
            }
            else if (playerTwoState.Buttons.X == ButtonState.Pressed) //3
            {
                playerTwoPressedControl = "3";
            }
            else if (playerTwoState.Buttons.Y == ButtonState.Pressed) //4
            {
                playerTwoPressedControl = "4";
            }
            else if (playerTwoState.Buttons.Start == ButtonState.Pressed) //start
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
                case "inGame":
                    drawInGameScreen();
                    break;
            }

            base.Draw(gameTime);
        }
    }
}
