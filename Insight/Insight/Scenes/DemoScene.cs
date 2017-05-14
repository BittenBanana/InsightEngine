using Insight.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Insight.Engine.Components;

namespace Insight.Scenes
{
    class DemoScene : GameScene
    {
        static String floorPrefab = "floor5x5";
        GameObject floor1;

        public static Matrix projection { get; private set; }
        public override void Initialize(GraphicsDeviceManager graphicsDevice)
        {
            base.Initialize(graphicsDevice);
            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45f), graphics.GraphicsDevice.Viewport.AspectRatio, .1f, 1000f);

            floor1 = new GameObject(new Vector3(0, 0, 0), false);
            floor1.AddNewComponent<MeshRenderer>();

            gameObjects.Add(floor1);
        }

        public override void LoadContent()
        {
            base.LoadContent();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw()
        {
            base.Draw();
        }
    }
}
