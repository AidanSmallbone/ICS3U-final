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
        GraphicsDeviceManager graphics; //declare graphics engine
        SpriteBatch SpriteBatch; //declare spritebatch

        //button textures

        Texture2D aboutButtonIdle;
        Texture2D aboutButtonSelected;
        Texture2D controlsButtonIdle;
        Texture2D controlsButtonSelected;
        Texture2D quitGameButtonIdle;
        Texture2D quitGameButtonSelected;
        Texture2D startGameButtonIdle;
        Texture2D startGameButtonSelected;
        Texture2D leftArrowIdle;
        Texture2D leftArrowSelected;
        Texture2D rightArrowIdle;
        Texture2D rightArrowSelected;
        Texture2D backButtonIdle;
        Texture2D backButtonSelected;
        Texture2D doneButtonIdle;
        Texture2D doneButtonSelected;
        Texture2D showControlsButtonIdle;
        Texture2D showControlsButtonSelected;

        //header textures

        Texture2D stageSelectHeader;
        Texture2D controlsHeader;
        Texture2D aboutHeader;
        Texture2D characterSelectHeader;
        Texture2D inGameHeader;

        //logo textures

        Texture2D northWesternLogo;
        Texture2D centralLogo;
        Texture2D titleScreenLogo;

        //background textures

        Texture2D titleScreenBackground;
        Texture2D centralStageBackground;
        Texture2D northwesternStageBackground;

        //character icon textures

        Texture2D characterOneIcon;
        Texture2D characterTwoIcon;
        Texture2D characterThreeIcon;
        Texture2D characterFourIcon;
        Texture2D characterFiveIcon;
        Texture2D characterSixIcon;
        Texture2D characterSevenIcon;
        Texture2D characterEightIcon;
        Texture2D characterNineIcon;

        //misc. ui elements

        Texture2D playerOneSelectedCharacter;
        Texture2D playerTwoSelectedCharacter;
        Texture2D controllerIdle;
        Texture2D dPadControls;
        Texture2D buttonControls;
        Texture2D startControls;
        Texture2D controllerSelected;
        Texture2D infoPane;
        Texture2D characterSelectPane;

        //ingame textures

        Texture2D healthPoint;
        Texture2D specialPoint;

        //character animation textures

        Texture2D idleAnimation;
        Texture2D walkAnimation;
        Texture2D jumpAnimation;
        Texture2D punchAnimation;
        Texture2D hPunchAnimation;
        Texture2D kickAnimation;
        Texture2D hKickAnimation;
        Texture2D hitAnimation;
        Texture2D koAnimation;
        Texture2D winAnimation;
        Texture2D crouchAnimation;
        Texture2D crouchHitAnimation;


        //declare sounds

        private SoundEffect menuClick;
        private SoundEffect menuBeep;

        //variable to keep track of which menu is selected

        string activeMenu;

        //variables to keep track of user controller input

        string playerOnePressedControl = "blank"; //1, 2, 3, 4, up, down, left, right, start, blank (Player One input)
        string playerTwoPressedControl = "blank"; //1, 2, 3, 4, up, down, left, right, start, blank (Player Two input)

        //variables to use as timers

        int Ticks = 0;
        int playerOneTicks = 0;
        int playerTwoTicks = 0;
        int globalTicks = 0;
        int soundTicks = 0;

        //variables to keep track of the selected item on menus

        int startMenuSelectedItem = 1;
        int stageSelectMenuSelectedItem = 1;
        int controlsMenuSelectedItem = 1;
        int aboutMenuSelectedItem = 1;
        int characterSelectMenuSelectedItem = 1;
        int pauseMenuSelectedItem = 1;
        int resetGameMenuSelectedItem = 1;
        bool showControls = false;

        //variables to keep track of selected stage, character, etc.

        int selectedStage = 1;
        int playerOneCharacter = 1;
        int playerTwoCharacter = 1;
        bool playerOneReady = false;
        bool playerTwoReady = false;

        //varibles to keep track of ingame stats

        int playerOneHealth = 100;
        int playerTwoHealth = 100;
        int playerOneSpecial = 0;
        int playerTwoSpecial = 0;

        //variables to keep track of time for animations for player one

        int idleFrames = 4;
        int walkFrames = 5;
        int jumpFrames = 6;
        int punchFrames = 3;
        int hPunchFrames = 5;
        int kickFrames = 3;
        int hKickFrames = 5;
        int hitFrames = 4;
        int koFrames = 5;
        int winFrames = 3;
        int crouchFrames = 2;
        int crouchHitFrames = 2;

        int idleCounter = 0;
        int walkCounter = 0;
        int jumpCounter = 0;
        int punchCounter = 0;
        int hPunchCounter = 0;
        int kickCounter = 0;
        int hKickCounter = 0;
        int hitCounter = 0;
        int koCounter = 0;
        int winCounter = 0;
        int crouchCounter = 0;
        int crouchHitCounter = 0;

        int frameDelay = 4;
        int frameCounter = 0;

        int frameCounterTwo;

        int playerOneX = 0;

        //variables to keep track of animations for player two

        int idleCounterPlayerTwo = 0;
        int walkCounterPlayerTwo = 0;
        int jumpCounterPlayerTwo = 0;
        int punchCounterPlayerTwo = 0;
        int hPunchCounterPlayerTwo = 0;
        int kickCounterPlayerTwo = 0;
        int hKickCounterPlayerTwo = 0;
        int hitCounterPlayerTwo = 0;
        int koCounterPlayerTwo = 0;
        int winCounterPlayerTwo = 0;
        int crouchCounterPlayerTwo = 0;
        int crouchHitCounterPlayerTwo = 0;

        int playerTwoX = 1024 - 400;

        private void updateStartScreen() //logic and input for start screen
        {
            Ticks++; //add to timer every update

            switch (playerOnePressedControl) //change menu item based on user input
            {
                case "up": if (Ticks >= 10) { startMenuSelectedItem--; Ticks = 0; } break;
                case "down": if (Ticks >= 10) { startMenuSelectedItem++; Ticks = 0; } break;
            }

            //only allow the selected item variable to reach set values

            if (startMenuSelectedItem < 1) { startMenuSelectedItem = 1; }
            if (startMenuSelectedItem > 4) { startMenuSelectedItem = 4; }

            //changes the active menu or closes the game based on which button the user presses

            switch (startMenuSelectedItem)
            {
                case 1: if (playerOnePressedControl == "1" && globalTicks >= 20) { activeMenu = "stageSelect"; globalTicks = 0; } break; //open stage select menu
                case 2: if (playerOnePressedControl == "1" && globalTicks >= 20) { activeMenu = "controls"; globalTicks = 0; } break; //open controls menu
                case 3: if (playerOnePressedControl == "1" && globalTicks >= 20) { activeMenu = "about"; globalTicks = 0; } break; //open about menu
                case 4: if (playerOnePressedControl == "1") { this.Exit(); } break; //close the game
                case 5: if (playerOnePressedControl == "start" && globalTicks >= 20) { activeMenu = "stageSelect"; globalTicks = 0; } break; //open stage select menu
            }
        }

        private void updateStageSelectScreen() //logic and input for stage select screen
        {
            Ticks++; //add to timer every update

            switch (playerOnePressedControl) //change menu item based on user input
            {
                case "left": if (Ticks >= 10) { stageSelectMenuSelectedItem--; Ticks = 0; } break;
                case "right": if (Ticks >= 10) { stageSelectMenuSelectedItem++; Ticks = 0; } break;
                case "down": if (Ticks >= 10) { stageSelectMenuSelectedItem = 3; Ticks = 0; } break;
            }

            //only allow the selected item variable to reach set values

            if (stageSelectMenuSelectedItem <= 1) { stageSelectMenuSelectedItem = 1; }
            if (stageSelectMenuSelectedItem > 4) { stageSelectMenuSelectedItem = 4; }

            switch (stageSelectMenuSelectedItem) //select the stage and move on to the next menu based on user input
            {
                case 1: if (playerOnePressedControl == "1") { selectedStage = 1; } break;                
                case 2: if (playerOnePressedControl == "1") { selectedStage = 2; } break;    
                case 3: if (playerOnePressedControl == "1" && globalTicks >= 20) { activeMenu = "start"; globalTicks = 0; } break;
                case 4: if (playerOnePressedControl == "1") { activeMenu = "characterSelect"; } break;               
            }
        }

        private void updateControlsScreen() //logic and input for controls screen
        {
            Ticks++; //add to timer every update

            switch (playerOnePressedControl) //change menu item based on user input
            {
                case "left": if (Ticks >= 10) { controlsMenuSelectedItem--; Ticks = 0; } break;
                case "right": if (Ticks >= 10) { controlsMenuSelectedItem++; Ticks = 0; } break;
                case "1":
                if (controlsMenuSelectedItem == 2 && globalTicks >= 20) { activeMenu = "start"; globalTicks = 0; };
                if (controlsMenuSelectedItem == 1 && showControls == false && Ticks >= 10) { showControls = true; Ticks = 0; };
                if (controlsMenuSelectedItem == 1 && showControls == true && Ticks >= 10) { showControls = false; Ticks = 0; };
                break;
            }

            //only allow the selected item variable to reach set values

            if (controlsMenuSelectedItem <= 1) { controlsMenuSelectedItem = 1; };
            if (controlsMenuSelectedItem > 2) { controlsMenuSelectedItem = 2; };
        }

        private void updateAboutScreen() //logic and input for about screen
        {
        //return to start menu from about menu

        if (playerOnePressedControl == "1" && globalTicks >= 20) { activeMenu = "start"; globalTicks = 0; }
        } 

        private void updateCharacterSelectScreen() //logic and input for select character screen
        {
            playerOneTicks++; //add to player one timer every update
            playerTwoTicks++; //add to player two timer every update

            switch (playerOnePressedControl) //change menu item and select character for player one
            {
            case "left": if (playerOneTicks >= 10) { playerOneCharacter--; playerOneTicks = 0; } break;
            case "right": if (playerOneTicks >= 10) { playerOneCharacter++; playerOneTicks = 0; } break;
            case "1": playerOneReady = true; break;
            }

            //only allow the selected item variable to go to set values

            if (playerOneCharacter <= 1) { playerOneCharacter = 1; }
            if (playerOneCharacter > 9) { playerOneCharacter = 9; }

            switch (playerTwoPressedControl) //change menu item and select character for player two
            {
            case "left": if (playerTwoTicks >= 10) { playerTwoCharacter--; playerTwoTicks = 0; } break;
            case "right": if (playerTwoTicks >= 10) { playerTwoCharacter++; playerTwoTicks = 0; } break;
            case "1": playerTwoReady = true; break;
            }

            //only allow the selected item variable to go to set values

            if (playerTwoCharacter <= 1) { playerTwoCharacter = 1; }
            if (playerTwoCharacter > 9) { playerTwoCharacter = 9; }

            //allow the user to reselect a character if they change their mind

            if (playerOneReady == true && playerOnePressedControl == "2") { playerOneReady = false; }
            if (playerTwoReady == true && playerTwoPressedControl == "2") { playerTwoReady = false; }

            Ticks++; //add to timer every update

            //if both players have selected their character and 100 ticks have passed, drop the users into the game

            if (playerOneReady == true && playerTwoReady == true) { if (Ticks >= 100) { activeMenu = "inGame"; } }

            if (playerOnePressedControl == "start") { activeMenu = "inGame"; } //THIS IS DEBUG CODE DELETE BEFORE FINISHED VERSION
        }

        private void updatePauseScreen() //logic and input for pause screen (TODO)
        {
        }

        private void updateResetGameScreen() //logic and input for reset game screen (TODO)
        {
        }

        private void updateInGameScreen() //logic and input for in game (TODO)
        {
            if (frameCounter > frameDelay)
            {

                frameCounter = 0;
            }
            else
            {
                frameCounter++;
            }

            if (frameCounterTwo > frameDelay)
            {

                frameCounterTwo = 0;
            }
            else
            {
                frameCounterTwo++;
            }

            switch (playerOnePressedControl)
            {
                case "up":
                    if (jumpCounter <= jumpFrames && frameCounter == frameDelay)
                    { jumpCounter++; }
                    if (jumpCounter >= jumpFrames)
                    { jumpCounter = 0; }
                    break;
                case "down":
                    if (crouchCounter <= crouchFrames && frameCounter == frameDelay)
                    { crouchCounter++; }
                    if (crouchCounter == 2)
                    {
                        crouchCounter = 1;
                    }
                    if (crouchCounter >= crouchFrames && playerOnePressedControl == "blank" )
                    { crouchCounter = 0; }
                    break;
                case "left":
                    if (walkCounter <= walkFrames && frameCounter == frameDelay)
                    { walkCounter++; }
                    if (walkCounter >= walkFrames)
                    { walkCounter = 0; }
                    playerOneX = playerOneX - 4;
                    if (playerOneX <= 0)
                    {
                        playerOneX = 0;
                    }
                    break;
                case "right":
                    if (walkCounter <= walkFrames && frameCounter == frameDelay)
                    { walkCounter++; }
                    if (walkCounter >= walkFrames)
                    { walkCounter = 0; }
                    playerOneX = playerOneX + 4;
                    if (playerOneX >= 1024)
                    {
                        playerOneX = 1024;
                    }
                    break;
                case "1":
                    if (punchCounter <= punchFrames && frameCounter == frameDelay)
                    { punchCounter++; }
                    if (punchCounter >= punchFrames)
                    { punchCounter = 0; }
                    break;
                case "2":
                    if (hPunchCounter <= hPunchFrames && frameCounter == frameDelay)
                    { hPunchCounter++; }
                    if (hPunchCounter >= hPunchFrames)
                    { hPunchCounter = 0; }
                    break;
                case "3":
                    if (kickCounter <= kickFrames && frameCounter == frameDelay)
                    { kickCounter++; }
                    if (kickCounter >= kickFrames)
                    { kickCounter = 0; }
                    break;
                case "4":
                    if (hKickCounter <= hKickFrames && frameCounter == frameDelay)
                    { hKickCounter++; }
                    if (hKickCounter >= hKickFrames)
                    { hKickCounter = 0; }
                    break;
                case "blank":
                    if (idleCounter <= idleFrames && frameCounter == frameDelay)
                    { idleCounter++; }
                    if (idleCounter >= idleFrames)
                    { idleCounter = 0; }
                    break;
            }

            switch (playerTwoPressedControl)
            {
                case "up":
                    if (jumpCounterPlayerTwo <= jumpFrames && frameCounterTwo == frameDelay)
                    { jumpCounterPlayerTwo++; }
                    if (jumpCounterPlayerTwo >= jumpFrames)
                    { jumpCounterPlayerTwo = 0; }
                    break;
                case "down":
                    if (crouchCounterPlayerTwo <= crouchFrames && frameCounterTwo == frameDelay)
                    { crouchCounterPlayerTwo++; }
                    if (crouchCounterPlayerTwo == 2)
                    {
                        crouchCounterPlayerTwo = 1;
                    }
                    if (crouchCounterPlayerTwo >= crouchFrames && playerTwoPressedControl == "blank")
                    { crouchCounterPlayerTwo = 0; }
                    break;
                case "left":
                    if (walkCounterPlayerTwo <= walkFrames && frameCounterTwo == frameDelay)
                    { walkCounterPlayerTwo++; }
                    if (walkCounterPlayerTwo >= walkFrames)
                    { walkCounterPlayerTwo = 0; }
                    playerTwoX = playerTwoX - 4;
                    if (playerTwoX <= 0)
                    {
                        playerTwoX = 0;
                    }
                    break;
                case "right":
                    if (walkCounterPlayerTwo <= walkFrames && frameCounterTwo == frameDelay)
                    { walkCounterPlayerTwo++; }
                    if (walkCounterPlayerTwo >= walkFrames)
                    { walkCounterPlayerTwo = 0; }
                    playerTwoX = playerTwoX + 4;
                    if (playerTwoX >= 1024)
                    {
                        playerTwoX = 1024;
                    }
                    break;
                case "1":
                    if (punchCounterPlayerTwo <= punchFrames && frameCounterTwo == frameDelay)
                    { punchCounterPlayerTwo++; }
                    if (punchCounterPlayerTwo >= punchFrames)
                    { punchCounterPlayerTwo = 0; }
                    break;
                case "2":
                    if (hPunchCounterPlayerTwo <= hPunchFrames && frameCounterTwo == frameDelay)
                    { hPunchCounterPlayerTwo++; }
                    if (hPunchCounterPlayerTwo >= hPunchFrames)
                    { hPunchCounterPlayerTwo = 0; }
                    break;
                case "3":
                    if (kickCounterPlayerTwo <= kickFrames && frameCounterTwo == frameDelay)
                    { kickCounterPlayerTwo++; }
                    if (kickCounterPlayerTwo >= kickFrames)
                    { kickCounterPlayerTwo = 0; }
                    break;
                case "4":
                    if (hKickCounterPlayerTwo <= hKickFrames && frameCounterTwo == frameDelay)
                    { hKickCounterPlayerTwo++; }
                    if (hKickCounterPlayerTwo >= hKickFrames)
                    { hKickCounterPlayerTwo = 0; }
                    break;
                case "blank":
                    if (idleCounterPlayerTwo <= idleFrames && frameCounterTwo == frameDelay)
                    { idleCounterPlayerTwo++; }
                    if (idleCounterPlayerTwo >= idleFrames)
                    { idleCounterPlayerTwo = 0; }
                    break;
            }
        }

        private void drawStartScreen() //draw textures for start screen
        {
            //declare rectangles to draw textures

            Rectangle backgroundPosition = new Rectangle(0, 0, 1024, 768); 
            Rectangle logoPosition = new Rectangle((512 - (titleScreenLogo.Width / 4)), 48, (titleScreenLogo.Width / 2), (titleScreenLogo.Height / 2));
            Rectangle buttonPosition = new Rectangle((512 - (startGameButtonIdle.Width / 2)), (logoPosition.Y + logoPosition.Height + 32), startGameButtonIdle.Width, startGameButtonIdle.Height);           

            SpriteBatch.Begin(); //begin the spritebatch

            //draw static elements

            SpriteBatch.Draw(titleScreenBackground, backgroundPosition, Color.White); 
            SpriteBatch.Draw(titleScreenLogo, logoPosition, Color.White);

            switch (startMenuSelectedItem) //show the selected button as selected
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

            SpriteBatch.End(); //end the spritebatch

        } 

        private void drawStageSelectScreen() //draw textures for stage select screen
        {
            //declare rectangles to draw textures

            Rectangle backgroundPosition = new Rectangle(0, 0, 1024, 768);
            Rectangle headerPosition = new Rectangle(0, 0, 1024, stageSelectHeader.Height);
            Rectangle logoPosition = new Rectangle((512 - (northWesternLogo.Width / 2)), (((768 + stageSelectHeader.Height) / 2) - (northWesternLogo.Height / 2)), northWesternLogo.Width, northWesternLogo.Width);
            Rectangle rightButtonIdle = new Rectangle((logoPosition.X - leftArrowIdle.Width - 24), ((logoPosition.Y + (logoPosition.Height / 2)) - (leftArrowIdle.Height / 2)), (rightArrowIdle.Width), (rightArrowIdle.Height));
            Rectangle rightButtonSelected = new Rectangle((logoPosition.X - leftArrowIdle.Width - 24), ((logoPosition.Y + (logoPosition.Height / 2)) - (leftArrowIdle.Height / 2)), (rightArrowIdle.Width), (rightArrowSelected.Height));
            Rectangle leftButtonIdle = new Rectangle((logoPosition.X + logoPosition.Width + 24), ((logoPosition.Y + (logoPosition.Height / 2)) - (leftArrowIdle.Height / 2)), (rightArrowIdle.Width), (rightArrowIdle.Height));
            Rectangle leftButtonSelected = new Rectangle((logoPosition.X + logoPosition.Width + 24), ((logoPosition.Y + (logoPosition.Height / 2)) - (leftArrowIdle.Height / 2)), (rightArrowIdle.Width), (rightArrowSelected.Height));
            Rectangle backButtonPosition = new Rectangle(24, (768 - backButtonIdle.Height - 24), backButtonIdle.Width, backButtonIdle.Height);
            Rectangle doneButtonPosition = new Rectangle((1024 - 24 - backButtonIdle.Width), (768 - backButtonIdle.Height - 24), backButtonIdle.Width, backButtonIdle.Height);

            SpriteBatch.Begin(); //begin spritebatch

            //draw static elements

            SpriteBatch.Draw(titleScreenBackground, backgroundPosition, Color.White);
            SpriteBatch.Draw(stageSelectHeader, headerPosition, Color.White);
           
            switch(stageSelectMenuSelectedItem) //draw buttons and the selected stage based on uer input
            {
                case 1:
                    {
                        SpriteBatch.Draw(leftArrowSelected, rightButtonSelected, Color.White);
                        SpriteBatch.Draw(rightArrowIdle, leftButtonIdle, Color.White);
                        SpriteBatch.Draw(backButtonIdle, backButtonPosition, Color.White);
                        SpriteBatch.Draw(doneButtonIdle, doneButtonPosition, Color.White);
                        if (selectedStage == 1) { SpriteBatch.Draw(northWesternLogo, logoPosition, Color.White); }
                        else if (selectedStage == 2) { SpriteBatch.Draw(centralLogo, logoPosition, Color.White); }
                        break;
                    }
                case 2:
                    {
                        SpriteBatch.Draw(leftArrowIdle, rightButtonIdle, Color.White);
                        SpriteBatch.Draw(rightArrowSelected, leftButtonSelected, Color.White);
                        SpriteBatch.Draw(backButtonIdle, backButtonPosition, Color.White);
                        SpriteBatch.Draw(doneButtonIdle, doneButtonPosition, Color.White);
                        if (selectedStage == 1) { SpriteBatch.Draw(northWesternLogo, logoPosition, Color.White); }
                        else if (selectedStage == 2) { SpriteBatch.Draw(centralLogo, logoPosition, Color.White); }
                        break;
                    }
                case 3:
                    {
                        SpriteBatch.Draw(leftArrowIdle, rightButtonIdle, Color.White);
                        SpriteBatch.Draw(rightArrowIdle, leftButtonIdle, Color.White);
                        SpriteBatch.Draw(backButtonSelected, (new Rectangle(backButtonPosition.X, backButtonPosition.Y, backButtonIdle.Width, backButtonSelected.Height)), Color.White);
                        SpriteBatch.Draw(doneButtonIdle, doneButtonPosition, Color.White);
                        if (selectedStage == 1) { SpriteBatch.Draw(northWesternLogo, logoPosition, Color.White); }
                        else if (selectedStage == 2) { SpriteBatch.Draw(centralLogo, logoPosition, Color.White); }
                        break;
                    }
                case 4:
                    {
                        SpriteBatch.Draw(leftArrowIdle, rightButtonIdle, Color.White);
                        SpriteBatch.Draw(rightArrowIdle, leftButtonIdle, Color.White);
                        SpriteBatch.Draw(backButtonIdle, backButtonPosition, Color.White);
                        SpriteBatch.Draw(doneButtonSelected, (new Rectangle(doneButtonPosition.X, doneButtonPosition.Y, doneButtonIdle.Width, doneButtonSelected.Height)), Color.White);
                        if (selectedStage == 1) { SpriteBatch.Draw(northWesternLogo, logoPosition, Color.White); }
                        else if (selectedStage == 2) { SpriteBatch.Draw(centralLogo, logoPosition, Color.White); }
                        break;
                    }
            }

            SpriteBatch.End(); //end the spritebatch
        }

        private void drawControlsScreen() //draw textures for controls screen
        {
            SpriteBatch.Begin(); //begin the spritebatch

            //declare rectangles to draw textures

            Rectangle controllerIdlePosition = new Rectangle((512 - (controllerIdle.Width / 2)), (controlsHeader.Height + ((640 - controllerIdle.Height) / 2)), controllerIdle.Width, controllerIdle.Height);
            Rectangle showControlsButton = new Rectangle(((controllerIdlePosition.X + (controllerIdle.Width / 2)) - 265), (controllerIdlePosition.Y + controllerIdle.Height - (doneButtonIdle.Height / 2)), showControlsButtonIdle.Width, showControlsButtonIdle.Height);
            Rectangle doneButton = new Rectangle((showControlsButton.X + showControlsButtonIdle.Width + 32), (controllerIdlePosition.Y + controllerIdle.Height - (doneButtonIdle.Height / 2)), doneButtonIdle.Width, doneButtonIdle.Height);

            //draw static textures

            SpriteBatch.Draw(titleScreenBackground, (new Rectangle(0, 0, titleScreenBackground.Width, titleScreenBackground.Height)), Color.White);
            SpriteBatch.Draw(controlsHeader, (new Rectangle(0, 0, controlsHeader.Width, controlsHeader.Height)), Color.White);

            switch (showControls) //show controls on controller based on user input
            {
                case true: SpriteBatch.Draw(controllerSelected, (new Rectangle(controllerIdlePosition.X - 32, controllerIdlePosition.Y, controllerSelected.Width, controllerSelected.Height)), Color.White); break;
                case false: SpriteBatch.Draw(controllerIdle, controllerIdlePosition, Color.White); break;
            }

            switch (controlsMenuSelectedItem) //draw buttons as selected based on user input
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

            SpriteBatch.End(); //end the spritebatch
        }

        private void drawAboutScreen() //draw textures for about screen
        {
            SpriteBatch.Begin(); //begin the spritebatch

            //declare rectangles to draw textures

            Rectangle doneButton = new Rectangle(512 - (doneButtonIdle.Width / 2), aboutHeader.Height + infoPane.Height + 88 + 32, doneButtonIdle.Width, doneButtonSelected.Height);
            Rectangle infoPanePos = new Rectangle(512 - (infoPane.Width / 2), (aboutHeader.Height + ((553 - infoPane.Height) / 2)), infoPane.Width, infoPane.Height);

            //draw static textures

            SpriteBatch.Draw(titleScreenBackground, new Rectangle(0, 0, titleScreenBackground.Width, titleScreenBackground.Height), Color.White);
            SpriteBatch.Draw(aboutHeader, new Rectangle(0, 0, aboutHeader.Width, aboutHeader.Height), Color.White);
            SpriteBatch.Draw(infoPane, infoPanePos, Color.White);
            SpriteBatch.Draw(doneButtonSelected, doneButton, Color.White);

            SpriteBatch.End(); //end the spritebatch
        }

        private void drawCharacterSelectScreen() //draw textures for character selection screen
        {
            SpriteBatch.Begin(); //begin the spritebatch

            //declare rectangles to draw static textures

            Rectangle playerOnePane = new Rectangle(60, ((((titleScreenBackground.Height - characterSelectHeader.Height) - characterSelectPane.Height) / 2) + characterSelectHeader.Height), characterSelectPane.Width, characterSelectPane.Height);
            Rectangle playerTwoPane = new Rectangle(544, ((((titleScreenBackground.Height - characterSelectHeader.Height) - characterSelectPane.Height) / 2) + characterSelectHeader.Height), characterSelectPane.Width, characterSelectPane.Height);

            //draw static textures

            SpriteBatch.Draw(titleScreenBackground, (new Rectangle(0, 0, titleScreenBackground.Width, titleScreenBackground.Height)), Color.White);
            SpriteBatch.Draw(characterSelectHeader, (new Rectangle(0, 0, characterSelectHeader.Width, characterSelectHeader.Height)), Color.White);
            SpriteBatch.Draw(characterSelectPane, playerOnePane, Color.White);
            SpriteBatch.Draw(characterSelectPane, playerTwoPane, Color.White);

            //delcare variables, use them to create rectangles to move the selection box

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

            switch (playerOneCharacter) //set the value of the selection rectangle based on the selected item for player one
            {
                case 1: playerOneSelectedCharacterX = charColumnOneX; playerOneSelectedCharacterY = charRowOneY; break;
                case 2: playerOneSelectedCharacterX = charColumnTwoX; playerOneSelectedCharacterY = charRowOneY; break;
                case 3: playerOneSelectedCharacterX = charColumnThreeX; playerOneSelectedCharacterY = charRowOneY; break;
                case 4: playerOneSelectedCharacterX = charColumnOneX; playerOneSelectedCharacterY = charRowTwoY; break;
                case 5: playerOneSelectedCharacterX = charColumnTwoX; playerOneSelectedCharacterY = charRowTwoY; break;
                case 6: playerOneSelectedCharacterX = charColumnThreeX; playerOneSelectedCharacterY = charRowTwoY; break;
                case 7: playerOneSelectedCharacterX = charColumnOneX; playerOneSelectedCharacterY = charRowThreeY; break;
                case 8: playerOneSelectedCharacterX = charColumnTwoX; playerOneSelectedCharacterY = charRowThreeY; break;
                case 9: playerOneSelectedCharacterX = charColumnThreeX; playerOneSelectedCharacterY = charRowThreeY; break;
            }

            switch (playerTwoCharacter) //set the value of the selection rectangle based on the selected item for player two
            {
                case 1: playerTwoSelectedCharacterX = charColumnOneX; playerTwoSelectedCharacterY = charRowOneY; break;
                case 2: playerTwoSelectedCharacterX = charColumnTwoX; playerTwoSelectedCharacterY = charRowOneY; break;
                case 3: playerTwoSelectedCharacterX = charColumnThreeX; playerTwoSelectedCharacterY = charRowOneY; break;
                case 4: playerTwoSelectedCharacterX = charColumnOneX; playerTwoSelectedCharacterY = charRowTwoY; break;
                case 5: playerTwoSelectedCharacterX = charColumnTwoX; playerTwoSelectedCharacterY = charRowTwoY; break;
                case 6: playerTwoSelectedCharacterX = charColumnThreeX; playerTwoSelectedCharacterY = charRowTwoY; break;
                case 7: playerTwoSelectedCharacterX = charColumnOneX; playerTwoSelectedCharacterY = charRowThreeY; break;
                case 8: playerTwoSelectedCharacterX = charColumnTwoX; playerTwoSelectedCharacterY = charRowThreeY; break;
                case 9: playerTwoSelectedCharacterX = charColumnThreeX; playerTwoSelectedCharacterY = charRowThreeY; break;
            }

            //declare rectangles for changing textures

            Rectangle playerOneSelection = new Rectangle((playerOnePane.X + playerOneSelectedCharacterX), (playerOnePane.Y + playerOneSelectedCharacterY), playerOneSelectedCharacter.Width, playerOneSelectedCharacter.Height);
            Rectangle playerTwoSelection = new Rectangle((playerTwoPane.X + playerTwoSelectedCharacterX), (playerTwoPane.Y + playerTwoSelectedCharacterY), playerTwoSelectedCharacter.Width, playerTwoSelectedCharacter.Height);
            Rectangle playerOneSelectionIcon = new Rectangle((playerOnePane.X + 168), (playerOnePane.Y + 28), characterOneIcon.Width, characterOneIcon.Height);
            Rectangle playerTwoSelectionIcon = new Rectangle((playerTwoPane.X + 168), (playerTwoPane.Y + 28), characterOneIcon.Width, characterOneIcon.Height);

            //draw character selection box
        
            SpriteBatch.Draw(playerOneSelectedCharacter, playerOneSelection, Color.White);
            SpriteBatch.Draw(playerTwoSelectedCharacter, playerTwoSelection, Color.White);

            switch (playerOneCharacter) //draw character selection icon for player one
            {
                case 1: SpriteBatch.Draw(characterOneIcon, playerOneSelectionIcon, Color.White); break;
                case 2: SpriteBatch.Draw(characterTwoIcon, playerOneSelectionIcon, Color.White); break;
                case 3: SpriteBatch.Draw(characterThreeIcon, playerOneSelectionIcon, Color.White); break;
                case 4: SpriteBatch.Draw(characterFourIcon, playerOneSelectionIcon, Color.White); break;
                case 5: SpriteBatch.Draw(characterFiveIcon, playerOneSelectionIcon, Color.White); break;
                case 6: SpriteBatch.Draw(characterSixIcon, playerOneSelectionIcon, Color.White); break;
                case 7: SpriteBatch.Draw(characterSevenIcon, playerOneSelectionIcon, Color.White); break;
                case 8: SpriteBatch.Draw(characterEightIcon, playerOneSelectionIcon, Color.White); break;
                case 9: SpriteBatch.Draw(characterNineIcon, playerOneSelectionIcon, Color.White); break;
            }

            switch (playerTwoCharacter) //draw character selection icon for player two
            {
                case 1: SpriteBatch.Draw(characterOneIcon, playerTwoSelectionIcon, Color.White); break;
                case 2: SpriteBatch.Draw(characterTwoIcon, playerTwoSelectionIcon, Color.White); break;
                case 3: SpriteBatch.Draw(characterThreeIcon, playerTwoSelectionIcon, Color.White); break;
                case 4: SpriteBatch.Draw(characterFourIcon, playerTwoSelectionIcon, Color.White); break;
                case 5: SpriteBatch.Draw(characterFiveIcon, playerTwoSelectionIcon, Color.White); break;
                case 6: SpriteBatch.Draw(characterSixIcon, playerTwoSelectionIcon, Color.White); break;
                case 7: SpriteBatch.Draw(characterSevenIcon, playerTwoSelectionIcon, Color.White); break;
                case 8: SpriteBatch.Draw(characterEightIcon, playerTwoSelectionIcon, Color.White); break;
                case 9: SpriteBatch.Draw(characterNineIcon, playerTwoSelectionIcon, Color.White); break;
            }

            SpriteBatch.End(); //end the spritebatch
        }

        private void drawPauseScreen() //draw textures for pause screen (TODO)
        {
        }

        private void drawResetGameScreen() //draw textures for rest game screen (TODO)
        {
        }

        private void drawInGameScreen() //draw textures for in game (TODO)
        {
            SpriteBatch.Begin();

            if (selectedStage == 1) { SpriteBatch.Draw(northwesternStageBackground, new Rectangle(0, 0, 1024, 768), Color.White); }
            if (selectedStage == 2) { SpriteBatch.Draw(centralStageBackground, new Rectangle(0, 0, 1024, 768), Color.White); }

            Rectangle playerOneIcon = new Rectangle(28, 28, 88, 88);
            Rectangle playerTwoIcon = new Rectangle(inGameHeader.Width - 28 - 88, 28, 88, 88);

            SpriteBatch.Draw(inGameHeader, new Rectangle(0, 0, inGameHeader.Width, inGameHeader.Height), Color.White);

            switch (playerOneCharacter)
            {
                case 1: SpriteBatch.Draw(characterOneIcon, playerOneIcon, Color.White); break;
                case 2: SpriteBatch.Draw(characterTwoIcon, playerOneIcon, Color.White); break;
                case 3: SpriteBatch.Draw(characterThreeIcon, playerOneIcon, Color.White); break;
                case 4: SpriteBatch.Draw(characterFourIcon, playerOneIcon, Color.White); break;
                case 5: SpriteBatch.Draw(characterFiveIcon, playerOneIcon, Color.White); break;
                case 6: SpriteBatch.Draw(characterSixIcon, playerOneIcon, Color.White); break;
                case 7: SpriteBatch.Draw(characterSevenIcon, playerOneIcon, Color.White); break;
                case 8: SpriteBatch.Draw(characterEightIcon, playerOneIcon, Color.White); break;
                case 9: SpriteBatch.Draw(characterNineIcon, playerOneIcon, Color.White); break;
            }

            switch (playerTwoCharacter)
            {
                case 1: SpriteBatch.Draw(characterOneIcon, playerTwoIcon, Color.White); break;
                case 2: SpriteBatch.Draw(characterTwoIcon, playerTwoIcon, Color.White); break;
                case 3: SpriteBatch.Draw(characterThreeIcon, playerTwoIcon, Color.White); break;
                case 4: SpriteBatch.Draw(characterFourIcon, playerTwoIcon, Color.White); break;
                case 5: SpriteBatch.Draw(characterFiveIcon, playerTwoIcon, Color.White); break;
                case 6: SpriteBatch.Draw(characterSixIcon, playerTwoIcon, Color.White); break;
                case 7: SpriteBatch.Draw(characterSevenIcon, playerTwoIcon, Color.White); break;
                case 8: SpriteBatch.Draw(characterEightIcon, playerTwoIcon, Color.White); break;
                case 9: SpriteBatch.Draw(characterNineIcon, playerTwoIcon, Color.White); break;
            }

            switch (playerOneHealth)
            {
                case 100:
                    SpriteBatch.Draw(healthPoint, new Rectangle(136, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(160, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(184, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(208, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(232, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(256, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(280, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(304, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(328, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(352, 16, 16, 24), Color.White);
                    break;
                case 90:
                    SpriteBatch.Draw(healthPoint, new Rectangle(136, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(160, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(184, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(208, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(232, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(256, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(280, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(304, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(328, 16, 16, 24), Color.White);
                    break;
                case 80:
                    SpriteBatch.Draw(healthPoint, new Rectangle(136, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(160, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(184, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(208, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(232, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(256, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(280, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(304, 16, 16, 24), Color.White);
                    break;
                case 70:
                    SpriteBatch.Draw(healthPoint, new Rectangle(136, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(160, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(184, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(208, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(232, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(256, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(280, 16, 16, 24), Color.White);
                    break;
                case 60:
                    SpriteBatch.Draw(healthPoint, new Rectangle(136, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(160, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(184, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(208, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(232, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(256, 16, 16, 24), Color.White);
                    break;
                case 50:
                    SpriteBatch.Draw(healthPoint, new Rectangle(136, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(160, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(184, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(208, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(232, 16, 16, 24), Color.White);
                    break;
                case 40:
                    SpriteBatch.Draw(healthPoint, new Rectangle(136, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(160, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(184, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(208, 16, 16, 24), Color.White);
                    break;
                case 30:
                    SpriteBatch.Draw(healthPoint, new Rectangle(136, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(160, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(184, 16, 16, 24), Color.White);
                    break;
                case 20:
                    SpriteBatch.Draw(healthPoint, new Rectangle(136, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(160, 16, 16, 24), Color.White);
                    break;
                case 10:
                    SpriteBatch.Draw(healthPoint, new Rectangle(136, 16, 16, 24), Color.White);
                    break;
                case 0:
                    break;
            }

            switch (playerTwoHealth)
            {
                case 100:
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 136, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 160, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 184, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 208, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 232, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 256, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 280, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 304, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 328, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 352, 16, 16, 24), Color.White);
                    break;
                case 90:
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 136, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 160, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 184, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 208, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 232, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 256, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 280, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 304, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 328, 16, 16, 24), Color.White);
                    break;
                case 80:
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 136, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 160, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 184, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 208, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 232, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 256, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 280, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 304, 16, 16, 24), Color.White);
                    break;
                case 70:
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 136, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 160, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 184, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 208, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 232, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 256, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 280, 16, 16, 24), Color.White);
                    break;
                case 60:
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 136, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 160, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 184, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 208, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 232, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 256, 16, 16, 24), Color.White);
                    break;
                case 50:
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 136, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 160, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 184, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 208, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 232, 16, 16, 24), Color.White);
                    break;
                case 40:
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 136, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 160, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 184, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 208, 16, 16, 24), Color.White);
                    break;
                case 30:
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 136, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 160, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 184, 16, 16, 24), Color.White);
                    break;
                case 20:
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 136, 16, 16, 24), Color.White);
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 160, 16, 16, 24), Color.White);
                    break;
                case 10:
                    SpriteBatch.Draw(healthPoint, new Rectangle(1024 - 16 - 136, 16, 16, 24), Color.White);
                    break;
                case 0:
                    break;
            }

            switch (playerOneSpecial)
            {
                case 0: break;
                case 1:
                    SpriteBatch.Draw(specialPoint, new Rectangle(136, 48, 24, 32), Color.White);
                    break;
                case 2:
                    SpriteBatch.Draw(specialPoint, new Rectangle(136, 48, 24, 32), Color.White);
                    SpriteBatch.Draw(specialPoint, new Rectangle(168, 48, 24, 32), Color.White);
                    break;
                case 3:
                    SpriteBatch.Draw(specialPoint, new Rectangle(136, 48, 24, 32), Color.White);
                    SpriteBatch.Draw(specialPoint, new Rectangle(168, 48, 24, 32), Color.White);
                    SpriteBatch.Draw(specialPoint, new Rectangle(200, 48, 24, 32), Color.White);
                    break;
                case 4:
                    SpriteBatch.Draw(specialPoint, new Rectangle(136, 48, 24, 32), Color.White);
                    SpriteBatch.Draw(specialPoint, new Rectangle(168, 48, 24, 32), Color.White);
                    SpriteBatch.Draw(specialPoint, new Rectangle(200, 48, 24, 32), Color.White);
                    SpriteBatch.Draw(specialPoint, new Rectangle(232, 48, 24, 32), Color.White);
                    break;
                case 5:
                    SpriteBatch.Draw(specialPoint, new Rectangle(136, 48, 24, 32), Color.White);
                    SpriteBatch.Draw(specialPoint, new Rectangle(168, 48, 24, 32), Color.White);
                    SpriteBatch.Draw(specialPoint, new Rectangle(200, 48, 24, 32), Color.White);
                    SpriteBatch.Draw(specialPoint, new Rectangle(232, 48, 24, 32), Color.White);
                    SpriteBatch.Draw(specialPoint, new Rectangle(264, 48, 24, 32), Color.White);
                    break;               
            }

            switch (playerTwoSpecial)
            {
                case 0: break;
                case 1:
                    SpriteBatch.Draw(specialPoint, new Rectangle(1024 - 24 - 136, 48, 24, 32), Color.White);
                    break;
                case 2:
                    SpriteBatch.Draw(specialPoint, new Rectangle(1024 - 24 - 136, 48, 24, 32), Color.White);
                    SpriteBatch.Draw(specialPoint, new Rectangle(1024 - 24 - 168, 48, 24, 32), Color.White);
                    break;
                case 3:
                    SpriteBatch.Draw(specialPoint, new Rectangle(1024 - 24 - 136, 48, 24, 32), Color.White);
                    SpriteBatch.Draw(specialPoint, new Rectangle(1024 - 24 - 168, 48, 24, 32), Color.White);
                    SpriteBatch.Draw(specialPoint, new Rectangle(1024 - 24 - 200, 48, 24, 32), Color.White);
                    break;
                case 4:
                    SpriteBatch.Draw(specialPoint, new Rectangle(1024 - 24 - 136, 48, 24, 32), Color.White);
                    SpriteBatch.Draw(specialPoint, new Rectangle(1024 - 24 - 168, 48, 24, 32), Color.White);
                    SpriteBatch.Draw(specialPoint, new Rectangle(1024 - 24 - 200, 48, 24, 32), Color.White);
                    SpriteBatch.Draw(specialPoint, new Rectangle(1024 - 24 - 232, 48, 24, 32), Color.White);
                    break;
                case 5:
                    SpriteBatch.Draw(specialPoint, new Rectangle(1024 - 24 - 136, 48, 24, 32), Color.White);
                    SpriteBatch.Draw(specialPoint, new Rectangle(1024 - 24 - 168, 48, 24, 32), Color.White);
                    SpriteBatch.Draw(specialPoint, new Rectangle(1024 - 24 - 200, 48, 24, 32), Color.White);
                    SpriteBatch.Draw(specialPoint, new Rectangle(1024 - 24 - 232, 48, 24, 32), Color.White);
                    SpriteBatch.Draw(specialPoint, new Rectangle(1024 - 24 - 264, 48, 24, 32), Color.White);
                    break;
            }

            SpriteBatch.End();

            SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);

            GraphicsDevice.SamplerStates[0] = SamplerState.PointClamp;

            SpriteEffects flip = SpriteEffects.FlipHorizontally;

           



            switch (playerOnePressedControl)
            {
                case "up":
                    SpriteBatch.Draw(jumpAnimation, new Rectangle(playerOneX, 300, (jumpAnimation.Width * 4) / jumpFrames, jumpAnimation.Height * 4), new Rectangle((jumpAnimation.Width / jumpFrames) * jumpCounter, 0, (jumpAnimation.Width / jumpFrames), jumpAnimation.Height), Color.White);
                    break;
                case "down":
                    SpriteBatch.Draw(crouchAnimation, new Rectangle(playerOneX, 300, (crouchAnimation.Width * 4) / crouchFrames, crouchAnimation.Height * 4), new Rectangle((crouchAnimation.Width / crouchFrames) * crouchCounter, 0, (crouchAnimation.Width / crouchFrames), crouchAnimation.Height), Color.White);
                    break;
                case "left":
                    SpriteBatch.Draw(walkAnimation, new Rectangle(playerOneX, 300, (walkAnimation.Width * 4) / walkFrames, walkAnimation.Height * 4), new Rectangle((walkAnimation.Width / walkFrames) * walkCounter, 0, (walkAnimation.Width / walkFrames), walkAnimation.Height), Color.White);
                    break;
                case "right":
                    SpriteBatch.Draw(walkAnimation, new Rectangle(playerOneX, 300, (walkAnimation.Width * 4) / walkFrames, walkAnimation.Height * 4), new Rectangle((walkAnimation.Width / walkFrames) * walkCounter, 0, (walkAnimation.Width / walkFrames), walkAnimation.Height), Color.White);
                    break;
                case "1":
                    SpriteBatch.Draw(punchAnimation, new Rectangle(playerOneX, 300, (punchAnimation.Width * 4) / punchFrames, punchAnimation.Height * 4), new Rectangle((punchAnimation.Width / punchFrames) * punchCounter, 0, (punchAnimation.Width / punchFrames), punchAnimation.Height), Color.White);
                    break;
                case "2":
                    SpriteBatch.Draw(hPunchAnimation, new Rectangle(playerOneX, 300, (hPunchAnimation.Width * 4) / hPunchFrames, hPunchAnimation.Height * 4), new Rectangle((hPunchAnimation.Width / hPunchFrames) * hPunchCounter, 0, (hPunchAnimation.Width / hPunchFrames), hPunchAnimation.Height), Color.White);
                    break;
                case "3":
                    SpriteBatch.Draw(kickAnimation, new Rectangle(playerOneX, 300, (kickAnimation.Width * 4) / kickFrames, kickAnimation.Height * 4), new Rectangle((kickAnimation.Width / kickFrames) * kickCounter, 0, (kickAnimation.Width / kickFrames), kickAnimation.Height), Color.White);
                    break;
                case "4":
                    SpriteBatch.Draw(hKickAnimation, new Rectangle(playerOneX, 300, (hKickAnimation.Width * 4) / hKickFrames, hKickAnimation.Height * 4), new Rectangle((hKickAnimation.Width / hKickFrames) * hKickCounter, 0, (hKickAnimation.Width / hKickFrames), hKickAnimation.Height), Color.White);
                    break;
                case "blank":
                    SpriteBatch.Draw(idleAnimation, new Rectangle(playerOneX, 300, (idleAnimation.Width * 4) / idleFrames, idleAnimation.Height * 4), new Rectangle((idleAnimation.Width / idleFrames) * idleCounter, 0, (idleAnimation.Width / idleFrames), idleAnimation.Height), Color.White);
                    break;
            }

            switch (playerTwoPressedControl)
            {
                case "up":
                    SpriteBatch.Draw(jumpAnimation, new Rectangle(playerTwoX, 300, (jumpAnimation.Width * 4) / jumpFrames, jumpAnimation.Height * 4), new Rectangle((jumpAnimation.Width / jumpFrames) * jumpCounterPlayerTwo, 0, (jumpAnimation.Width / jumpFrames), jumpAnimation.Height), Color.White, 0.0f, new Vector2(0, 0), flip, 0.0f);
                    break;
                case "down":
                    SpriteBatch.Draw(crouchAnimation, new Rectangle(playerTwoX, 300, (crouchAnimation.Width * 4) / crouchFrames, crouchAnimation.Height * 4), new Rectangle((crouchAnimation.Width / crouchFrames) * crouchCounterPlayerTwo, 0, (crouchAnimation.Width / crouchFrames), crouchAnimation.Height), Color.White, 0.0f, new Vector2(0, 0), flip, 0.0f);
                    break;
                case "left":
                    SpriteBatch.Draw(walkAnimation, new Rectangle(playerTwoX, 300, (walkAnimation.Width * 4) / walkFrames, walkAnimation.Height * 4), new Rectangle((walkAnimation.Width / walkFrames) * walkCounterPlayerTwo, 0, (walkAnimation.Width / walkFrames), walkAnimation.Height), Color.White, 0.0f, new Vector2(0, 0), flip, 0.0f);
                    break;
                case "right":
                    SpriteBatch.Draw(walkAnimation, new Rectangle(playerTwoX, 300, (walkAnimation.Width * 4) / walkFrames, walkAnimation.Height * 4), new Rectangle((walkAnimation.Width / walkFrames) * walkCounterPlayerTwo, 0, (walkAnimation.Width / walkFrames), walkAnimation.Height), Color.White, 0.0f, new Vector2(0, 0), flip, 0.0f);
                    break;
                case "1":
                    SpriteBatch.Draw(punchAnimation, new Rectangle(playerTwoX, 300, (punchAnimation.Width * 4) / punchFrames, punchAnimation.Height * 4), new Rectangle((punchAnimation.Width / punchFrames) * punchCounterPlayerTwo, 0, (punchAnimation.Width / punchFrames), punchAnimation.Height), Color.White, 0.0f, new Vector2(0, 0), flip, 0.0f);
                    break;
                case "2":
                    SpriteBatch.Draw(hPunchAnimation, new Rectangle(playerTwoX, 300, (hPunchAnimation.Width * 4) / hPunchFrames, hPunchAnimation.Height * 4), new Rectangle((hPunchAnimation.Width / hPunchFrames) * hPunchCounterPlayerTwo, 0, (hPunchAnimation.Width / hPunchFrames), hPunchAnimation.Height), Color.White, 0.0f, new Vector2(0, 0), flip, 0.0f);
                    break;
                case "3":
                    SpriteBatch.Draw(kickAnimation, new Rectangle(playerTwoX, 300, (kickAnimation.Width * 4) / kickFrames, kickAnimation.Height * 4), new Rectangle((kickAnimation.Width / kickFrames) * kickCounterPlayerTwo, 0, (kickAnimation.Width / kickFrames), kickAnimation.Height), Color.White, 0.0f, new Vector2(0, 0), flip, 0.0f);
                    break;
                case "4":
                    SpriteBatch.Draw(hKickAnimation, new Rectangle(playerTwoX, 300, (hKickAnimation.Width * 4) / hKickFrames, hKickAnimation.Height * 4), new Rectangle((hKickAnimation.Width / hKickFrames) * hKickCounterPlayerTwo, 0, (hKickAnimation.Width / hKickFrames), hKickAnimation.Height), Color.White, 0.0f, new Vector2(0, 0), flip, 0.0f);
                    break;
                case "blank":
                    SpriteBatch.Draw(idleAnimation, new Rectangle(playerTwoX, 300, (idleAnimation.Width * 4) / idleFrames, idleAnimation.Height * 4), new Rectangle((idleAnimation.Width / idleFrames) * idleCounterPlayerTwo, 0, (idleAnimation.Width / idleFrames), idleAnimation.Height), Color.White, 0.0f, new Vector2(0, 0), flip, 0.0f);
                    break;
            }

            SpriteBatch.End();
        }

        public Game1() //start the game
        {
            graphics = new GraphicsDeviceManager(this); //start the graphics engine
            Content.RootDirectory = "Content"; //set the directory for music and textures

            //set the resolution

            this.graphics.PreferredBackBufferWidth = 1024;
            this.graphics.PreferredBackBufferHeight = 768;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice); //declare the spritebatch

            //load all resources

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
            centralStageBackground = Content.Load<Texture2D>("CentralStageBackground");
            northwesternStageBackground = Content.Load<Texture2D>("NorthwesternStageBackground");
            inGameHeader = Content.Load<Texture2D>("inGameHeader");
            healthPoint = Content.Load<Texture2D>("healthPoint");
            specialPoint = Content.Load<Texture2D>("specialPoint");
            idleAnimation = Content.Load<Texture2D>("idleAnimation");
            walkAnimation = Content.Load<Texture2D>("walkAnimation");
            jumpAnimation = Content.Load<Texture2D>("jumpAnimation");
            punchAnimation = Content.Load<Texture2D>("punchAnimation");
            hPunchAnimation = Content.Load<Texture2D>("hPunchAnimation");
            kickAnimation = Content.Load<Texture2D>("kickAnimation");
            hKickAnimation = Content.Load<Texture2D>("hKickAnimation");
            hitAnimation = Content.Load<Texture2D>("hitAnimation");
            crouchAnimation = Content.Load<Texture2D>("crouchAnimation");
            crouchHitAnimation = Content.Load<Texture2D>("crouchHitAnimation");
            winAnimation = Content.Load<Texture2D>("winAnimation");
            koAnimation = Content.Load<Texture2D>("koAnimation");

            //load all sounds

            menuClick = Content.Load<SoundEffect>("menuClick");
            menuBeep = Content.Load<SoundEffect>("menuBeep");

            activeMenu = "start"; //start the game on the start menu
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime) //global updates, keeps track of input and selected menu
        {
            //keep track of gamepad input

            GamePadState playerOneState = GamePad.GetState(PlayerIndex.One);
            GamePadState playerTwoState = GamePad.GetState(PlayerIndex.Two);

            KeyboardState playerOneKBState = Keyboard.GetState();
            KeyboardState playerTwoKBState = Keyboard.GetState();


            globalTicks++; //add to the timer every update (use this for timers that need to be maintained between menus)
            soundTicks++;

            switch (activeMenu) //switch what menu logic is used based on the selected menu
            {
                case "start": updateStartScreen(); break;
                case "stageSelect": updateStageSelectScreen(); break;
                case "controls": updateControlsScreen(); break;
                case "about": updateAboutScreen(); break;
                case "characterSelect": updateCharacterSelectScreen(); break;
                case "pause": updatePauseScreen(); break;
                case "resetGame": updateResetGameScreen(); break;
                case "inGame": updateInGameScreen(); break;
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

            //player one input for kb

            if (playerOneKBState.IsKeyDown(Keys.W)) //up
            {
                playerOnePressedControl = "up";
            }
            else if (playerOneKBState.IsKeyDown(Keys.A)) //left
            {
                playerOnePressedControl = "left";
            }
            else if (playerOneKBState.IsKeyDown(Keys.S)) //down
            {
                playerOnePressedControl = "down";
            }
            else if (playerOneKBState.IsKeyDown(Keys.D)) //right
            {
                playerOnePressedControl = "right";
            }
            else if (playerOneKBState.IsKeyDown(Keys.Z)) //1
            {
                playerOnePressedControl = "1";
            }
            else if (playerOneKBState.IsKeyDown(Keys.X)) //2
            {
                playerOnePressedControl = "2";
            }
            else if (playerOneKBState.IsKeyDown(Keys.C)) //3
            {
                playerOnePressedControl = "3";
            }
            else if (playerOneKBState.IsKeyDown(Keys.V)) //4
            {
                playerOnePressedControl = "4";
            }
            else if (playerOneKBState.IsKeyDown(Keys.LeftControl)) //start
            {
                playerOnePressedControl = "start";
            }
            else //no key pressed
            {
                playerOnePressedControl = "blank";
            }

            //player two input for kb

            if (playerTwoKBState.IsKeyDown(Keys.I)) //up
            {
                playerTwoPressedControl = "up";
            }
            else if (playerTwoKBState.IsKeyDown(Keys.J)) //left
            {
                playerTwoPressedControl = "left";
            }
            else if (playerTwoKBState.IsKeyDown(Keys.K)) //down
            {
                playerTwoPressedControl = "down";
            }
            else if (playerTwoKBState.IsKeyDown(Keys.L)) //right
            {
                playerTwoPressedControl = "right";
            }
            else if (playerTwoKBState.IsKeyDown(Keys.N)) //1
            {
                playerTwoPressedControl = "1";
            }
            else if (playerTwoKBState.IsKeyDown(Keys.M)) //2
            {
                playerTwoPressedControl = "2";
            }
            else if (playerTwoKBState.IsKeyDown(Keys.OemComma)) //3
            {
                playerTwoPressedControl = "3";
            }
            else if (playerTwoKBState.IsKeyDown(Keys.OemPeriod)) //4
            {
                playerTwoPressedControl = "4";
            }
            else if (playerTwoKBState.IsKeyDown(Keys.RightControl)) //start
            {
                playerTwoPressedControl = "start";
            }
            else //no key pressed
            {
                playerTwoPressedControl = "blank";
            }

            if (playerOnePressedControl != "blank" && playerOnePressedControl != "1" && activeMenu != "inGame" && soundTicks >= 10) { menuClick.Play(); soundTicks = 0; }
            if (playerTwoPressedControl != "blank" && playerTwoPressedControl != "1" && activeMenu != "inGame" && soundTicks >= 10) { menuClick.Play(); soundTicks = 0; }
            if (playerOnePressedControl == "1" && activeMenu != "inGame" && soundTicks >= 10) { menuBeep.Play(); soundTicks = 0; }
            if (playerTwoPressedControl == "1" && activeMenu != "inGame" && soundTicks >= 10) { menuBeep.Play(); soundTicks = 0; }





        }

        protected override void Draw(GameTime gameTime) //draw the selected state
        {
            GraphicsDevice.Clear(Color.White); //set the background color

            switch (activeMenu) //draw the selected state
            {
                case "start": drawStartScreen(); break;
                case "stageSelect": drawStageSelectScreen(); break;
                case "controls": drawControlsScreen(); break;
                case "about": drawAboutScreen(); break;
                case "characterSelect": drawCharacterSelectScreen(); break;
                case "pause": drawPauseScreen(); break;
                case "resetGame": drawResetGameScreen(); break;
                case "inGame": drawInGameScreen(); break;
            }

            base.Draw(gameTime); //draw every tick
        }
    }
}
