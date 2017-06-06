using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Insight.Engine
{
    class PostProcessRenderer
    {
        public Effect PostEffect { get; set; }

        private GraphicsDevice device;

        private SpriteBatch spriteBatch;

        public PostProcessRenderer(GraphicsDevice device, Effect postEffect)
        {
            this.device = device;
            PostEffect = postEffect;
            spriteBatch = new SpriteBatch(device);
        }

        public void Draw(Texture2D sceneTexture2D)
        {
            device.SetRenderTarget(null);

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend,
                SamplerState.LinearClamp, DepthStencilState.Default,
                RasterizerState.CullNone, PostEffect);

            spriteBatch.Draw(sceneTexture2D, device.Viewport.Bounds, Color.White);

            spriteBatch.End();
        }
    }
}
