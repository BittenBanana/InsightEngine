using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Engine.Components;
using Insight.Materials;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Insight.Engine
{
    public class PrelightingRenderer
    {
        // Normal, depth, and light map render targets
        public RenderTarget2D depthTarg { get; private set; }
        public RenderTarget2D normalTarg { get; private set; }
        public RenderTarget2D lightTarg { get; private set; }

        // Depth/normal effect and light mapping effect
        Effect depthNormalEffect;

        private Material depthNorMaterial;
        Effect lightingEffect;

        // Point light (sphere) mesh
        private Model lightMesh;

        // List of models, lights, and the camera
        public List<Renderer> Models { get; set; }
        public List<Light> Lights { get; set; }
        public Camera Camera { get; set; }

        GraphicsDevice graphicsDevice;
        int viewWidth = 0,
            viewHeight = 0;

        public PrelightingRenderer(GraphicsDevice graphicsDevice, ContentManager content)
        {
            viewWidth = graphicsDevice.Viewport.Width;
            viewHeight = graphicsDevice.Viewport.Height;

            // Create the three render targets
            depthTarg = new RenderTarget2D(graphicsDevice, viewWidth,
                viewHeight, false, SurfaceFormat.Single, DepthFormat.Depth24);
            normalTarg = new RenderTarget2D(graphicsDevice, viewWidth,
                viewHeight, false, SurfaceFormat.Color, DepthFormat.Depth24);
            lightTarg = new RenderTarget2D(graphicsDevice, viewWidth,
                viewHeight, false, SurfaceFormat.Color, DepthFormat.Depth24);

            // Load effects
            depthNormalEffect = content.Load<Effect>("Shaders/PPDepthNormal");
            depthNorMaterial = new Material(depthNormalEffect);
            lightingEffect = content.Load<Effect>("Shaders/LightMap");

            // Set effect parameters to light mapping effect
            lightingEffect.Parameters["viewportWidth"].SetValue((float)viewWidth);
            lightingEffect.Parameters["viewportHeight"].SetValue((float)viewHeight);

            // Load point light mesh and set light mapping effect to it
            lightMesh = content.Load<Model>("Models/ball");
            
            this.graphicsDevice = graphicsDevice;
        }

        public void Draw()
        {
            drawDepthNormalMap();
            drawLightMap();
            prepareMainPass();
        }

        void drawDepthNormalMap()
        {
            // Set the render targets to 'slots' 1 and 2
            graphicsDevice.SetRenderTargets(normalTarg, depthTarg);
            // Clear the render target to 1 (infinite depth)
            graphicsDevice.Clear(Color.White);

            // Draw each model with the PPDepthNormal effect
            foreach (Renderer model in Models)
            {
                // model.CacheEffects();
                Material mat = (Material)model.Material.Clone();
                model.SetModelMaterial(depthNorMaterial, false);
                model.Draw(Camera);
                model.SetModelMaterial(mat, false);
                //model.RestoreEffects();
            }
            // Un-set the render targets
            graphicsDevice.SetRenderTargets(null);
        }

        void drawLightMap()
        {
            // Set the depth and normal map info to the effect
            lightingEffect.Parameters["DepthTexture"].SetValue(depthTarg);
            lightingEffect.Parameters["NormalTexture"].SetValue(normalTarg);

            // Calculate the view * projection matrix
            Matrix viewProjection = Camera.view * Camera.projection;

            // Set the inverse of the view * projection matrix to the effect
            Matrix invViewProjection = Matrix.Invert(viewProjection);
            lightingEffect.Parameters["InvViewProjection"].SetValue(
                invViewProjection);

            // Set the render target to the graphics device
            graphicsDevice.SetRenderTarget(lightTarg);

            // Clear the render target to black (no light)
            graphicsDevice.Clear(Color.Black);
            // Set render states to additive (lights will add their influences)
            graphicsDevice.BlendState = BlendState.Additive;
            graphicsDevice.DepthStencilState = DepthStencilState.None;

            foreach (Light light in Lights)
            {
                // Set the light's parameters to the effect
                lightingEffect.Parameters["LightColor"]?.SetValue(light.Color.ToVector3());
                lightingEffect.Parameters["LightAttenuation"]?.SetValue(light.Attenuation);
                lightingEffect.Parameters["LightPosition"]?.SetValue(light.gameObject.Transform.Position);
                lightingEffect.Parameters["Intensity"]?.SetValue(light.Intensity);

                // Calculate the world * view * projection matrix and set it to
                // the effect
                Matrix wvp = (Matrix.CreateScale(light.Attenuation)
                              * Matrix.CreateTranslation(light.gameObject.Transform.Position)) * viewProjection;
                lightingEffect.Parameters["WorldViewProjection"].SetValue(wvp);

                // Determine the distance between the light and camera
                float dist = Vector3.Distance(Camera.Position,
                    light.gameObject.Transform.Position);

                // If the camera is inside the light-sphere, invert the cull mode
                // to draw the inside of the sphere instead of the outside
                //if (dist < light.Attenuation)
                    graphicsDevice.RasterizerState = RasterizerState.CullClockwise;

                // Draw the point-light-sphere
                lightMesh.Meshes[0].MeshParts[0].Effect = lightingEffect;
                lightMesh.Meshes[0].Draw();

                // Revert the cull mode
                graphicsDevice.RasterizerState =
                    RasterizerState.CullCounterClockwise;
            }

            // Revert the blending and depth render states
            graphicsDevice.BlendState = BlendState.Opaque;
            graphicsDevice.DepthStencilState = DepthStencilState.Default;

            // Un-set the render target
            graphicsDevice.SetRenderTarget(null);
        }

        void prepareMainPass()
        {
            foreach (Renderer model in Models)
            {
                // Set the light map and viewport parameters to each model's
                //effect
                model.Material.GetEffect().Parameters["LightTexture"]?.SetValue(lightTarg);
                model.Material.GetEffect().Parameters["viewportWidth"]?.SetValue((float)viewWidth);
                model.Material.GetEffect().Parameters["viewportHeight"]?.SetValue((float)viewHeight);
            }
        }
    }
}
