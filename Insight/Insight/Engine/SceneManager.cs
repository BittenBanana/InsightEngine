using Insight.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
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
            currentScene = new MainScene();
        }

        public void Initialize(GraphicsDeviceManager graphicsDevice)
        {
            currentScene.Initialize(graphicsDevice);
        }

        public void LoadContent(ContentManager Content)
        {
            this.Content = new ContentManager(Content.ServiceProvider, "Content");
            currentScene.LoadContent();
        }

        public void UnloadContent()
        {
            currentScene.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            currentScene.Update(gameTime);
        }

        public void Draw()
        {
            currentScene.Draw();
        }
    }
}
