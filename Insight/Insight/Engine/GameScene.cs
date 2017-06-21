using Insight.Engine.Components;
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
    public class GameScene
    {
        public static DebugDraw debugDraw;
        protected ContentManager content;
        protected GraphicsDeviceManager graphics;
        protected List<GameObject> gameObjects;
        public List<GameObject> enemies;
        protected Camera mainCam;
        public UserInterface ui;
        public GameObject player;
        public bool gameOver;
        protected Matrix projection { get; set; }

        public GraphicsDevice GetGraphicsDevice()
        {
            return graphics.GraphicsDevice;
        }

        public virtual void Initialize(GraphicsDeviceManager graphicsDevice)
        {
            this.graphics = graphicsDevice;
            debugDraw = new DebugDraw(graphics.GraphicsDevice);
            gameObjects = new List<GameObject>();
            enemies = new List<GameObject>();
        }

        public virtual void LoadContent()
        {
            content = new ContentManager(
                   SceneManager.Instance.Content.ServiceProvider, "Content");

            ContentModels.Instance.LoadContent(content);
        }

        public virtual void UnloadContent()
        {
            content.Unload();
        }
        public virtual void Update(GameTime gameTime)
        {
            Time.deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Time.gameTime = gameTime;
        }

        public virtual void Draw()
        {

        }

        public Camera GetMainCamera()
        {
            return mainCam;
        }

        public List<GameObject> GetGameObjectsFromScene()
        {
            return gameObjects;
        }

        public Matrix GetProjectionMatrix()
        {
            return projection;
        }
    }
}
