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

        public GameScene currentScene { get; set; }

        private MainScene mainS;
        private DemoScene demoS;

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
            Dimensions = new Vector2(720, 1280);
            mainS = new MainScene();
            demoS = new DemoScene();
            LoadDemoScene();
        }

        public void Initialize(GraphicsDeviceManager graphicsDevice)
        {
            currentScene.Initialize(graphicsDevice);
            mainS.Initialize(graphicsDevice);
        }

        public void LoadContent(ContentManager Content)
        {
            this.Content = new ContentManager(Content.ServiceProvider, "Content");
            currentScene.LoadContent();
            mainS.LoadContent();
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
            currentScene = mainS;
        }

        public void LoadDemoScene()
        {
            currentScene = demoS;
        }
    }
}
