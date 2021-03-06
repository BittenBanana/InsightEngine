﻿using Insight.Engine;
using Insight.Engine.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Scenes
{
    class GameMenu : GameScene
    {
        enum PressState
        {
            Free,
            Pressed,
            Released
        }
        PressState pressState = PressState.Free;
        int currentlySelected = 1;
        int menuCount = 4;

        public override void Initialize(GraphicsDeviceManager graphicsDevice)
        {

            base.Initialize(graphicsDevice);


        }

        public override void LoadContent()
        {
            base.LoadContent();

            ui = new UserInterface(graphics.GraphicsDevice, content);
            ui.AddSprite("Sprites/Menu/bg", "menuBg", new Vector2(0, 0), Color.White, 1);
            ui.AddSprite("Sprites/Menu/menuNav", "menuNav", new Vector2(590, 800), Color.White, 1);
            ui.AddSprite("Sprites/Menu/pasek", "pasek", new Vector2(0, 0), Color.White, 1);
            ui.AddSprite("Sprites/Menu/tekst", "tekst", new Vector2(0, 0), Color.White, 1);
            ui.AddSprite("Sprites/Menu/About", "about", new Vector2(0, 0), Color.White, 0);
            
            //ui.ChangeTextColor(currentlySelected.ToString(), Color.Red);

        }

        public override void UnloadContent()
        {
            base.UnloadContent();


        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            KeyboardState keyState = Keyboard.GetState();
            if(pressState == PressState.Free)
            {
                if (keyState.IsKeyDown(Keys.Down) || keyState.IsKeyDown(Keys.S))
                {
                    currentlySelected++;
                    if (currentlySelected > menuCount)
                        currentlySelected = 4;
                }
                if (keyState.IsKeyDown(Keys.Up) || keyState.IsKeyDown(Keys.W))
                {
                    currentlySelected--;
                    if (currentlySelected <= 0)
                        currentlySelected = 1;
                }
                pressState = PressState.Pressed;
            }
            if(!keyState.IsKeyDown(Keys.Down) && !keyState.IsKeyDown(Keys.S)
                && !keyState.IsKeyDown(Keys.Up) && !keyState.IsKeyDown(Keys.W))
            {
                pressState = PressState.Free;
            }


            if (currentlySelected == 1)
            {
                ui.ChangeSpritePosition("pasek", 0, 360);
            }
            if (currentlySelected == 2)
            {
                ui.ChangeSpritePosition("pasek", 0, 500);
            }
            if (currentlySelected == 3)
            {
                ui.ChangeSpritePosition("pasek", 0, 635);
            }
            if (currentlySelected == 4)
            {
                ui.ChangeSpritePosition("pasek", 0, 770);
            }
            if (keyState.IsKeyDown(Keys.Enter) || keyState.IsKeyDown(Keys.Space))
            {
                if (currentlySelected == 1)
                {
                    SceneManager.Instance.LoadGame();
                }
                if (currentlySelected == 2)
                {
                    SceneManager.Instance.LoadSettings();
                }
                if (currentlySelected == 3)
                {
                    ui.ChangeSpriteOpacity("about", 1);
                    
                }
                if (currentlySelected == 4)
                {
                    SceneManager.Instance.gameApp.Quit();
                }
            }
            if (keyState.IsKeyDown(Keys.Escape))
                SceneManager.Instance.LoadMenu();
        }

        public override void Draw()
        {
            base.Draw();

            ui.Draw();
        }
    }
}
