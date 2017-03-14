using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Insight.Engine;
using Insight.Scripts;

namespace Insight.Scenes
{
    class MainScene : GameScene
    {

        GameObject gameObject;
        GameObject gameObject2;
        Camera mainCam;

        Matrix projection;

        public override void Initialize(GraphicsDeviceManager graphics)
        {
            base.Initialize(graphics);

            gameObject = new GameObject();
            gameObject2 = new GameObject(new Vector3(20, 0, 20));

        }

        public override void LoadContent()
        {
            base.LoadContent();
            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45f), graphics.GraphicsDevice.Viewport.AspectRatio, .1f, 1000f);

            gameObject.LoadContent(content);
            gameObject2.LoadContent(content);
            gameObject.AddNewComponent<Camera>();
            gameObject.GetComponent<Camera>().InitCamera(projection);

            mainCam = gameObject.GetComponent<Camera>();

            gameObject.AddNewComponent<CameraFollowBox>();
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            gameObject.Update();
            gameObject2.Update();
            base.Update(gameTime);
        }
        public override void Draw()
        {
            gameObject.Draw(mainCam);
            gameObject2.Draw(mainCam);

            base.Draw();
        }
    }
}
