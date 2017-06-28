using Insight.Engine;
using Insight.Engine.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Scenes
{
    class SettingsMenu : GameScene
    {
        enum PressState
        {
            Free,
            Pressed,
            Released
        }
        PressState pressState = PressState.Free;

        enum OptionPressState
        {
            Free,
            Pressed,
            Released
        }
        OptionPressState optionPressState = OptionPressState.Free;

        int currentlySelected = 1;
        int option = 0;
        int shadowOption = 0;
        int fullscreenOption = 0;
        int brightnessOption = 5;
        int menuCount = 3;

        public override void Initialize(GraphicsDeviceManager graphicsDevice)
        {

            base.Initialize(graphicsDevice);

            if (SceneManager.Instance.useShadows)
                shadowOption = 1;
            else
                shadowOption = 0;

            if (SceneManager.Instance.isFullscreen)
                fullscreenOption = 1;
            else
                fullscreenOption = 0;

            if (SceneManager.Instance.brightnessLevel == 1.0f)
                brightnessOption = 5;
            if (SceneManager.Instance.brightnessLevel == 0.9f)
                brightnessOption = 4;
            if (SceneManager.Instance.brightnessLevel == 0.8f)
                brightnessOption = 3;
            if (SceneManager.Instance.brightnessLevel == 0.7f)
                brightnessOption = 2;
            if (SceneManager.Instance.brightnessLevel == 0.6f)
                brightnessOption = 1;
            if (SceneManager.Instance.brightnessLevel == 0.5f)
                brightnessOption = 0;
        }

        public override void LoadContent()
        {
            base.LoadContent();

            ui = new UserInterface(graphics.GraphicsDevice, content);
            ui.AddSprite("Sprites/Menu/Settings/bg", "settingsBg", new Vector2(0, 0), Color.White, 1);
            ui.AddSprite("Sprites/Menu/Settings/pasek", "settingsPasek", new Vector2(0, 0), Color.White, 1);
            ui.AddSprite("Sprites/Menu/Settings/tekst", "settingsTekst", new Vector2(0, 0), Color.White, 1);

            ui.AddSprite("Sprites/Menu/Settings/on", "shadowOn", new Vector2(0, 380), Color.White, 0);
            ui.AddSprite("Sprites/Menu/Settings/off", "shadowOff", new Vector2(0, 380), Color.White, 1);

            ui.AddSprite("Sprites/Menu/Settings/on", "fullscreenOn", new Vector2(0, 570), Color.White, 0);
            ui.AddSprite("Sprites/Menu/Settings/off", "fullscreenOff", new Vector2(0, 570), Color.White, 1);

            ui.AddSprite("Sprites/Menu/Settings/50", "50", new Vector2(0, 760), Color.White, 0);
            ui.AddSprite("Sprites/Menu/Settings/60", "60", new Vector2(0, 760), Color.White, 0);
            ui.AddSprite("Sprites/Menu/Settings/70", "70", new Vector2(0, 760), Color.White, 0);
            ui.AddSprite("Sprites/Menu/Settings/80", "80", new Vector2(0, 760), Color.White, 0);
            ui.AddSprite("Sprites/Menu/Settings/90", "90", new Vector2(0, 760), Color.White, 0);
            ui.AddSprite("Sprites/Menu/Settings/100", "100", new Vector2(0, 760), Color.White, 1);

        }

        public override void UnloadContent()
        {
            base.UnloadContent();


        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            KeyboardState keyState = Keyboard.GetState();
            if (pressState == PressState.Free)
            {
                if (keyState.IsKeyDown(Keys.Down) || keyState.IsKeyDown(Keys.S))
                {
                    currentlySelected++;
                    if (currentlySelected > menuCount)
                        currentlySelected = 3;
                    option = 0;
                }
                if (keyState.IsKeyDown(Keys.Up) || keyState.IsKeyDown(Keys.W))
                {
                    currentlySelected--;
                    if (currentlySelected <= 0)
                        currentlySelected = 1;
                    option = 0;
                }
                pressState = PressState.Pressed;
            }
            if (!keyState.IsKeyDown(Keys.Down) && !keyState.IsKeyDown(Keys.S)
                && !keyState.IsKeyDown(Keys.Up) && !keyState.IsKeyDown(Keys.W))
            {
                pressState = PressState.Free;
            }


            if (currentlySelected == 1)
            {
                ui.ChangeSpritePosition("settingsPasek", 0, 350);
            }
            if (currentlySelected == 2)
            {
                ui.ChangeSpritePosition("settingsPasek", 0, 540);
            }
            if (currentlySelected == 3)
            {
                ui.ChangeSpritePosition("settingsPasek", 0, 720);
            }


            if (keyState.IsKeyDown(Keys.A) && optionPressState == OptionPressState.Free)
            {
                if(currentlySelected == 1)
                {
                    shadowOption--;
                    if (shadowOption < 0)
                        shadowOption = 1;
                }
                if(currentlySelected == 2)
                {
                    fullscreenOption--;
                    if (fullscreenOption < 0)
                        fullscreenOption = 1;
                }

                if(currentlySelected == 3)
                {
                    brightnessOption--;
                    if (brightnessOption < 0)
                        brightnessOption = 5;
                }

                optionPressState = OptionPressState.Pressed;
            }
            if (keyState.IsKeyDown(Keys.D) && optionPressState == OptionPressState.Free)
            {
                if (currentlySelected == 1)
                {
                    shadowOption++;
                    if (shadowOption >= 2)
                        shadowOption = 0;
                }
                if (currentlySelected == 2)
                {
                    fullscreenOption++;
                    if (fullscreenOption >= 2)
                        fullscreenOption = 0;
                }

                if (currentlySelected == 3)
                {
                    brightnessOption++;
                    if (brightnessOption >= 6)
                        brightnessOption = 0;
                }

                optionPressState = OptionPressState.Pressed;
            }
            if (keyState.IsKeyUp(Keys.D) && keyState.IsKeyUp(Keys.A) && optionPressState == OptionPressState.Pressed)
            {
                optionPressState = OptionPressState.Free;
            }
           

            if (currentlySelected == 1 && shadowOption == 0)
            {
                ui.ChangeSpriteOpacity("shadowOff", 1);
                ui.ChangeSpriteOpacity("shadowOn", 0);
            }
            if (currentlySelected == 1 && shadowOption == 1)
            {
                ui.ChangeSpriteOpacity("shadowOn", 1);
                ui.ChangeSpriteOpacity("shadowOff", 0);
            }

            if (currentlySelected == 2 && fullscreenOption == 0)
            {
                ui.ChangeSpriteOpacity("fullscreenOff", 1);
                ui.ChangeSpriteOpacity("fullscreenOn", 0);
            }
            if (currentlySelected == 2 && fullscreenOption == 1)
            {
                ui.ChangeSpriteOpacity("fullscreenOn", 1);
                ui.ChangeSpriteOpacity("fullscreenOff", 0);
            }

            if (currentlySelected == 3 && brightnessOption == 0)
            {
                ui.ChangeSpriteOpacity("50", 0);
                ui.ChangeSpriteOpacity("60", 1);
                ui.ChangeSpriteOpacity("70", 0);
                ui.ChangeSpriteOpacity("80", 0);
                ui.ChangeSpriteOpacity("90", 0);
                ui.ChangeSpriteOpacity("100", 0);
            }
            if (currentlySelected == 3 && brightnessOption == 1)
            {
                ui.ChangeSpriteOpacity("50", 0);
                ui.ChangeSpriteOpacity("60", 1);
                ui.ChangeSpriteOpacity("70", 0);
                ui.ChangeSpriteOpacity("80", 0);
                ui.ChangeSpriteOpacity("90", 0);
                ui.ChangeSpriteOpacity("100", 0);
            }
            if (currentlySelected == 3 && brightnessOption == 2)
            {
                ui.ChangeSpriteOpacity("50", 0);
                ui.ChangeSpriteOpacity("60", 0);
                ui.ChangeSpriteOpacity("70", 1);
                ui.ChangeSpriteOpacity("80", 0);
                ui.ChangeSpriteOpacity("90", 0);
                ui.ChangeSpriteOpacity("100", 0);
            }
            if (currentlySelected == 3 && brightnessOption == 3)
            {
                ui.ChangeSpriteOpacity("50", 0);
                ui.ChangeSpriteOpacity("60", 0);
                ui.ChangeSpriteOpacity("70", 0);
                ui.ChangeSpriteOpacity("80", 1);
                ui.ChangeSpriteOpacity("90", 0);
                ui.ChangeSpriteOpacity("100", 0);
            }
            if (currentlySelected == 3 && brightnessOption == 4)
            {
                ui.ChangeSpriteOpacity("50", 0);
                ui.ChangeSpriteOpacity("60", 0);
                ui.ChangeSpriteOpacity("70", 0);
                ui.ChangeSpriteOpacity("80", 0);
                ui.ChangeSpriteOpacity("90", 1);
                ui.ChangeSpriteOpacity("100", 0);
            }
            if (currentlySelected == 3 && brightnessOption == 5)
            {
                ui.ChangeSpriteOpacity("50", 0);
                ui.ChangeSpriteOpacity("60", 0);
                ui.ChangeSpriteOpacity("70", 0);
                ui.ChangeSpriteOpacity("80", 0);
                ui.ChangeSpriteOpacity("90", 0);
                ui.ChangeSpriteOpacity("100", 1);
            }



            if (keyState.IsKeyDown(Keys.Enter) || keyState.IsKeyDown(Keys.Space))
            {
                SaveChanges();
            }

        }

        public override void Draw()
        {
            base.Draw();

            ui.Draw();
        }

        private void SaveChanges()
        {
            if (fullscreenOption == 1)
            {
                graphics.IsFullScreen = true;
                graphics.ApplyChanges();
            }
            else
            {
                graphics.IsFullScreen = false;
                graphics.ApplyChanges();
            }
            if (shadowOption == 1)
                SceneManager.Instance.useShadows = true;
            else
                SceneManager.Instance.useShadows = false;

            if (brightnessOption == 0)
                SceneManager.Instance.brightnessLevel = 0.5f;
            if (brightnessOption == 1)
                SceneManager.Instance.brightnessLevel = 0.6f;
            if (brightnessOption == 2)
                SceneManager.Instance.brightnessLevel = 0.7f;
            if (brightnessOption == 3)
                SceneManager.Instance.brightnessLevel = 0.8f;
            if (brightnessOption == 4)
                SceneManager.Instance.brightnessLevel = 0.9f;
            if (brightnessOption == 5)
                SceneManager.Instance.brightnessLevel = 1.0f;
            SceneManager.Instance.LoadMenu();
        }
    }
}
