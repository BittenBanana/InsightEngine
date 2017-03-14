using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight
{
    public class GameScene
    {
        protected ContentManager content;
        protected GraphicsDeviceManager graphics;
        public virtual void Initialize(GraphicsDeviceManager graphicsDevice)
        {
            this.graphics = graphicsDevice;
        }

        public virtual void LoadContent()
        {
            content = new ContentManager(
                   SceneManager.Instance.Content.ServiceProvider, "Content");
        }

        public virtual void UnloadContent()
        {
            content.Unload();
        }
        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw()
        {

        }
    }
}
