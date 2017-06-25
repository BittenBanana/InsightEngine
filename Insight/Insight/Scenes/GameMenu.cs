using Insight.Engine;
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

        int currentlySelected = 1;
        int menuCount = 2;

        bool isGameLoading = false;
        bool isGameLoaded = false;
        public override void Initialize(GraphicsDeviceManager graphicsDevice)
        {

            base.Initialize(graphicsDevice);


        }

        public override void LoadContent()
        {
            base.LoadContent();

            ui = new UserInterface(graphics.GraphicsDevice, content);
            ui.AddText("Fonts/gamefont", "1", "Play Game",
                new Vector2(graphics.GraphicsDevice.Viewport.Width / 2, graphics.GraphicsDevice.Viewport.Height / 2), Color.White, 1);
            ui.AddText("Fonts/gamefont", "2", "ExitGame",
                new Vector2(graphics.GraphicsDevice.Viewport.Width / 2, graphics.GraphicsDevice.Viewport.Height / 2 + 20), Color.White, 1);

            ui.ChangeTextColor(currentlySelected.ToString(), Color.Red);

        }

        public override void UnloadContent()
        {
            base.UnloadContent();


        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Down) || keyState.IsKeyDown(Keys.S))
            {
                currentlySelected++;
                if (currentlySelected > menuCount)
                    currentlySelected = 2;
            }
            if (keyState.IsKeyDown(Keys.Up) || keyState.IsKeyDown(Keys.W))
            {
                currentlySelected--;
                if (currentlySelected <= 0)
                    currentlySelected = 1;
            }

            if (currentlySelected == 1)
            {
                ui.ChangeTextColor(currentlySelected.ToString(), Color.Red);
                ui.ChangeTextColor("2", Color.White);
            }
            if (currentlySelected == 2)
            {
                ui.ChangeTextColor(currentlySelected.ToString(), Color.Red);
                ui.ChangeTextColor("1", Color.White);
            }

            if (keyState.IsKeyDown(Keys.Enter))
            {
                if (currentlySelected == 1)
                {
                    SceneManager.Instance.LoadGame();
                }
                if (currentlySelected == 2)
                {
                    SceneManager.Instance.gameApp.Quit();
                }
            }
            Debug.WriteLine(currentlySelected);
        }

        public override void Draw()
        {
            base.Draw();

            ui.Draw();
        }
    }
}
