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
        public RenderTarget2D SceneRenderTarget2D { get; private set; }

        public Effect PostEffect { get; set; }

        private GraphicsDevice device;

        private SpriteBatch spriteBatch;

        public PostProcessRenderer(GraphicsDevice device, Effect postEffect, RenderTarget2D sceneRenderTarget2D)
        {
            this.device = device;
            PostEffect = postEffect;
            SceneRenderTarget2D = sceneRenderTarget2D;
            spriteBatch = new SpriteBatch(this.device);
        }

        public void Draw()
        {
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend,
                SamplerState.LinearClamp, DepthStencilState.Default,
                RasterizerState.CullNone, PostEffect);

            spriteBatch.Draw(SceneRenderTarget2D, device.Viewport.Bounds, Color.White);

            spriteBatch.End();
        }
    }
}
