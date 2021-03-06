﻿using Insight.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Engine
{
    public class SceneManager
    {
        private static SceneManager instance;
        public Vector2 Dimensions { private set; get; }
        public ContentManager Content { private set; get; }
        public GraphicsDeviceManager device { private set; get; }
        public GameScene currentScene { get; set; }
        public Game1 gameApp;
        //private MainScene mainS;
        private DemoScene demoS;

        public bool isFullscreen { get; set; }
        public bool useShadows { get; set; }
        public float brightnessLevel { get; set; }


        public static SceneManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new SceneManager();
                return instance;
            }
        }

        public SceneManager()
        {
            Dimensions = new Vector2(1920, 1080);
            //mainS = new MainScene();
            demoS = new DemoScene();
            //LoadDemoScene();
            currentScene = new GameMenu();
            isFullscreen = false;
            useShadows = false;
            brightnessLevel = 1.0f;
        }

        public void Initialize(GraphicsDeviceManager graphicsDevice)
        {
            device = graphicsDevice;
            currentScene.Initialize(graphicsDevice);
            //mainS.Initialize(graphicsDevice);
        }

        public void LoadContent(ContentManager Content)
        {
            this.Content = new ContentManager(Content.ServiceProvider, "Content");
            currentScene.LoadContent();
            //mainS.LoadContent();
        }

        public void UnloadContent()
        {
            currentScene.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            currentScene.Update(gameTime);

            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.F1))
                LoadDemoScene();
            if (keyState.IsKeyDown(Keys.F2))
                LoadMainScene();
        }

        public void Draw()
        {
            currentScene.Draw();
        }

        public List<GameObject> GetGameObjectsFromCurrentScene()
        {
            return currentScene.GetGameObjectsFromScene();
        }

        public void LoadMainScene()
        {
            //currentScene = mainS;
        }

        public void LoadDemoScene()
        {
            currentScene = demoS;
        }

        public void SetGameApp(Game1 game)
        {
            gameApp = game;
        }

        public void LoadGame()
        {
            currentScene.UnloadContent();
            currentScene = new DemoScene();
            currentScene.Initialize(device);
            currentScene.LoadContent();
        }

        public void LoadMenu()
        {
            currentScene.UnloadContent();
            currentScene = new GameMenu();
            currentScene.Initialize(device);
            currentScene.LoadContent();
        }

        public void LoadSettings()
        {
            currentScene.UnloadContent();
            currentScene = new SettingsMenu();
            currentScene.Initialize(device);
            currentScene.LoadContent();
        }
    }
}
