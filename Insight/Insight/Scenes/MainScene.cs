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
using Insight.Engine.Components;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System.Diagnostics;
using Insight.Materials;

namespace Insight.Scenes
{
    class MainScene : GameScene
    {

        private PrelightingRenderer lightRenderer;
        GameObject gameObject;
        GameObject gameObject2;
        GameObject gameObject3;
        GameObject gameObject4;
        GameObject gameObject5;
        GameObject gameObject6;
        GameObject gameObject7;
        GameObject gameObject8;
        GameObject gameObject9;
        GameObject triggerObject;
        GameObject bulletDispenser;
        GameObject dispenserTrigger;

        private GameObject pointLight1;
        private GameObject pointLight2;
        private GameObject pointLight3;
        private GameObject pointLight4;
        //GameObject box;

        //GameObject animationTest;

        ColliderManager colliderManager;
        AudioManager audioManager;
        Texture2D rocket;
        Texture2D piggyBank;
        Texture2D screen;
        Texture2D blood;
        SpriteBatch spriteBatch;
        float bloodLevel;
        SpriteFont _spr_font;
        int _total_frames = 0;
        float _elapsed_time = 0.0f;
        int _fps = 0;
        //UserInterface ui;

        Material defaultMaterial;
        Material transparencyMaterial;
        
        
        public override void Initialize(GraphicsDeviceManager graphics)
        {
            base.Initialize(graphics);
            gameObject = new GameObject(true);
            gameObject.AddNewComponent<MeshRenderer>();
            

            gameObject2 = new GameObject(new Vector3(0, -14, 0), false);
            gameObject2.AddNewComponent<MeshRenderer>();
            gameObject3 = new GameObject(new Vector3(0, -3.2f, 0), false);
            gameObject3.AddNewComponent<MeshRenderer>();
            gameObject6 = new GameObject(new Vector3(0, -3, 10), false);
            gameObject6.AddNewComponent<MeshRenderer>();
            gameObject7 = new GameObject(new Vector3(0, -3, 10), false);
            gameObject7.AddNewComponent<MeshRenderer>();
            gameObject8 = new GameObject(new Vector3(12, -3, 14), false);
            gameObject8.AddNewComponent<MeshRenderer>();
            gameObject9 = new GameObject(new Vector3(0, -3, -3), false);
            gameObject9.AddNewComponent<MeshRenderer>();
            triggerObject = new GameObject(new Vector3(0, -2, -6), false);
            triggerObject.AddNewComponent<MeshRenderer>();
            bulletDispenser = new GameObject(new Vector3(0, -2, -25), false);
            bulletDispenser.AddNewComponent<MeshRenderer>();
            dispenserTrigger = new GameObject(new Vector3(3, -2, -25), false);
            dispenserTrigger.AddNewComponent<MeshRenderer>();
            gameObject4 = new GameObject(new Vector3(0, -5, 40), false);
            gameObject4.AddNewComponent<MeshRenderer>();
            gameObject5 = new GameObject(new Vector3(18, -1.5f, 30), false);
            gameObject5.AddNewComponent<MeshRenderer>();
            //box = new GameObject(new Vector3(0, -1, 20), false);
            //box.AddNewComponent<MeshRenderer>();
            bloodLevel = 0;

            pointLight1 = new GameObject(new Vector3(-20, 1f, -20), false);
            pointLight1.AddNewComponent<Light>();
            pointLight1.GetComponent<Light>().Color = Color.Cyan;
            pointLight1.GetComponent<Light>().Attenuation = 20;

            pointLight2 = new GameObject(new Vector3(20f, 1f, 20), false);
            pointLight2.AddNewComponent<Light>();
            pointLight2.GetComponent<Light>().Color = Color.Magenta;
            pointLight2.GetComponent<Light>().Attenuation = 20;

            pointLight3 = new GameObject(new Vector3(20, 1f, -20), false);
            pointLight3.AddNewComponent<Light>();
            pointLight3.GetComponent<Light>().Color = Color.Yellow;
            pointLight3.GetComponent<Light>().Attenuation = 20;
                      
            pointLight4 = new GameObject(new Vector3(0, 0f, 0), false);
            pointLight4.AddNewComponent<Light>();
            pointLight4.GetComponent<Light>().Color = Color.White;
            pointLight4.GetComponent<Light>().Attenuation = 20;

            gameObjects.Add(pointLight1);
            gameObjects.Add(pointLight2);
            gameObjects.Add(pointLight3);
            gameObjects.Add(pointLight4);
            gameObjects.Add(gameObject);
            gameObjects.Add(gameObject2);
            gameObjects.Add(gameObject3);
            gameObjects.Add(gameObject4);
            gameObjects.Add(gameObject5);
            gameObjects.Add(gameObject6);
            gameObjects.Add(gameObject7);
            gameObjects.Add(gameObject8);
            gameObjects.Add(gameObject9);
            gameObjects.Add(triggerObject);
            gameObjects.Add(bulletDispenser);
            gameObjects.Add(dispenserTrigger);

            //animationTest = new GameObject(new Vector3(0, -5, 40), true);
            //animationTest.AddNewComponent<AnimationRender>();



            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45f), graphics.GraphicsDevice.Viewport.AspectRatio, .1f, 1000f);
        }

        public override void LoadContent()
        {
            base.LoadContent();

            #region Effects 

            Effect effect = content.Load<Effect>("Shaders/PhongBlinnShader");
            Effect pointLight = content.Load<Effect>("Shaders/PointLight");
            Effect spotLight = content.Load<Effect>("Shaders/SpotLight");
            Effect transparency = content.Load<Effect>("Shaders/glass");
            defaultMaterial = new DefaultMaterial(effect);
            transparencyMaterial = new TransparencyMaterial(transparency);
            ((TransparencyMaterial)transparencyMaterial).DiffuseLightDirection = ((DefaultMaterial)defaultMaterial).LightDirection;
            //((DefaultMaterial) defaultMaterial).LightColor = pointLight1.GetComponent<Light>().Color.ToVector3();
            //((DefaultMaterial) defaultMaterial).LightDirection = pointLight1.GetComponent<Light>().Direction;
            //((DefaultMaterial)defaultMaterial).SpecularColor = pointLight1.GetComponent<Light>().Color.ToVector3();
            #endregion

            List<MeshRenderer> models = new List<MeshRenderer>();
            List<Light> lights = new List<Light>();

            foreach (var o in gameObjects)
            {
                if (o.GetComponent<MeshRenderer>() != null)
                {
                    models.Add(o.GetComponent<MeshRenderer>());
                    o.GetComponent<MeshRenderer>().Material = defaultMaterial;
                }
                if (o.GetComponent<Light>() != null)
                {
                    lights.Add(o.GetComponent<Light>());
                }
            }

            gameObject9.GetComponent<MeshRenderer>().Material = transparencyMaterial;
            lightRenderer = new PrelightingRenderer(graphics.GraphicsDevice, content);

            //lightRenderer.Camera = mainCam;
            //lightRenderer.Models = models;
            //lightRenderer.Lights = lights;

            gameObject.LoadContent(content);
            gameObject2.LoadContent(content);
            gameObject2.GetComponent<MeshRenderer>().Load(content, "Models/ground", 0.1f);
            gameObject3.LoadContent(content);
            gameObject6.LoadContent(content);
            gameObject7.LoadContent(content);
            gameObject8.LoadContent(content);
            gameObject9.LoadContent(content);
            triggerObject.LoadContent(content);
            bulletDispenser.LoadContent(content);
            dispenserTrigger.LoadContent(content);
            //box.LoadContent(content);


            gameObject3.GetComponent<MeshRenderer>().Load(content, "Models/Konrads/Enviroment/straight", 2f);
            gameObject3.GetComponent<MeshRenderer>().LoadTexture(content, "Materials/corridor-straight_DefaultMaterial_AlbedoTransparency");
            gameObject3.GetComponent<MeshRenderer>().LoadNormalMap(content, "Materials/corridor-straight_DefaultMaterial_Normal");
            gameObject3.GetComponent<MeshRenderer>().LoadAmbientOcclusionMap(content, "Materials/corridor-straight_DefaultMaterial_AO");
            gameObject3.GetComponent<MeshRenderer>().LoadMetalnessMap(content, "Materials/corridor-straight_DefaultMaterial_MetallicSmoothness");
            gameObject6.GetComponent<MeshRenderer>().Load(content, "Models/Konrads/Enviroment/corridor-corner-colliders", 2f);
            gameObject7.GetComponent<MeshRenderer>().Load(content, "Models/Konrads/Enviroment/corner", 2f);
            gameObject8.GetComponent<MeshRenderer>().Load(content, "Models/Konrads/Enviroment/straight-rotated", 2f);
            gameObject9.GetComponent<MeshRenderer>().Load(content, "Models/Konrads/Enviroment/wall5x5withDoor", 2f);
            triggerObject.GetComponent<MeshRenderer>().Load(content, "Models/triggerbox", 1f);
            bulletDispenser.GetComponent<MeshRenderer>().Load(content, "Models/bulletdispenser", 1f);
            dispenserTrigger.GetComponent<MeshRenderer>().Load(content, "Models/dispensertrigger", 1f);

            gameObject4.LoadContent(content);
            gameObject4.GetComponent<MeshRenderer>().Load(content, "Models/stairs", 0.1f);
            gameObject5.LoadContent(content);
            gameObject5.GetComponent<MeshRenderer>().Load(content, "Models/floor", 0.1f);
            //box.GetComponent<MeshRenderer>().Load(content, "GameObject/boxMat", 2f);
            //box.AddNewComponent<BoxCollider>();
            //box.AddNewComponent<Rigidbody>();
            //box.GetComponent<Rigidbody>().useGravity = false;
            gameObject.AddNewComponent<BoxController>();
            gameObject.AddNewComponent<SphereCollider>();
            gameObject.AddNewComponent<Rigidbody>();
            gameObject.AddNewComponent<Camera>();
            gameObject2.AddNewComponent<BoxCollider>();
            gameObject3.AddNewComponent<BoxCollider>();
            gameObject4.AddNewComponent<BoxCollider>();
            gameObject5.AddNewComponent<BoxCollider>();
            gameObject6.AddNewComponent<BoxCollider>();
            gameObject8.AddNewComponent<BoxCollider>();
            gameObject9.AddNewComponent<BoxCollider>();
            triggerObject.AddNewComponent<BoxCollider>();
            triggerObject.GetComponent<BoxCollider>().IsTrigger = true;
            triggerObject.GetComponent<MeshRenderer>().IsVisible = false;
            triggerObject.physicLayer = Layer.DoorTrigger;
            bulletDispenser.AddNewComponent<BoxCollider>();
            dispenserTrigger.AddNewComponent<BoxCollider>();
            dispenserTrigger.GetComponent<BoxCollider>().IsTrigger = true;
            dispenserTrigger.GetComponent<MeshRenderer>().IsVisible = false;
            dispenserTrigger.physicLayer = Layer.DispenserTrigger;
            //gameObject.AddNewComponent<Camera>();
            gameObject2.AddNewComponent<Rigidbody>();
            gameObject3.AddNewComponent<Rigidbody>();
            //gameObject6.AddNewComponent<Rigidbody>();
            gameObject4.AddNewComponent<Rigidbody>();
            gameObject5.AddNewComponent<Rigidbody>();
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            gameObject2.GetComponent<Rigidbody>().useGravity = false;
            gameObject4.GetComponent<Rigidbody>().useGravity = false;
            gameObject5.GetComponent<Rigidbody>().useGravity = false;
            gameObject3.GetComponent<Rigidbody>().useGravity = false;
            gameObject2.physicLayer = Layer.Ground;
            gameObject3.physicLayer = Layer.IgnoreRaycast;
            gameObject.physicLayer = Layer.Player;
            gameObject4.physicLayer = Layer.Stairs;
            gameObject5.physicLayer = Layer.Ground;
            gameObject.AddNewComponent<RaycastTest>();
            //box.GetComponent<BoxCollider>().IsTrigger = true;
            gameObject6.GetComponent<MeshRenderer>().IsVisible = false;
            

            mainCam = gameObject.GetComponent<Camera>();

            gameObject.AddNewComponent<CameraFollowBox>();
            //gameObject2.AddNewComponent<BoxRotation>();
            
            gameObject3.Transform.Rotation.Y = 50f;
            //animationTest.LoadContent(content);

            colliderManager = new ColliderManager(gameObjects);
            colliderManager.ObjectColided += gameObject.OnObjectColided;
            colliderManager.ObjectColided += triggerObject.OnObjectColided;

            audioManager = new AudioManager(gameObject, content);
            audioManager.AddSoundEffectWithEmitter("Audio/tomek2", gameObject3);
            audioManager.AddSoundEffectWithEmitter("Audio/sandman", gameObject4);
            audioManager.SetSoundEffectLooped(0, true);
            audioManager.SetSoundEffectLooped(1, true);
            //audioManager.PlaySoundEffect(0);
            //audioManager.PlaySoundEffect(1);
            audioManager.AddSong("Audio/dj");
            audioManager.PlaySong(0);
            audioManager.StopCurrentSong();
            ui = new UserInterface(gameObject, graphics.GraphicsDevice, content);
            ui.AddSprite("Sprites/rakieta", "rakieta", new Vector2(30, 410), Color.White, 1);
            ui.AddSprite("Sprites/skarbonka", "skarbonka", new Vector2(90, 412), Color.White, 1);
            ui.AddSprite("Sprites/monitor", "monitor", new Vector2(150, 415), Color.White, 1);
            ui.AddSprite("Sprites/blood", "blood", new Vector2(0, 0), Color.White, 0);
            ui.AddSprite("Sprites/rakieta", "bulletRakieta", new Vector2(380, 30), Color.White, 0);
            ui.AddText("Fonts/gamefont", "generalFont", string.Format("FPS={0}", _fps), new Vector2(10, 20), Color.White, 1);
            ui.AddText("Fonts/gamefont", "hint", "Press E to open doors", new Vector2(350, 200), Color.White, 0);
            ui.AddText("Fonts/gamefont", "dispenserHint", "Press E to take the bullet", new Vector2(320, 80), Color.White, 0);

            lightRenderer.Camera = mainCam;
            lightRenderer.Lights = lights;
            lightRenderer.Models = models;
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
            foreach (GameObject go in gameObjects)
            {
                go.Update();
            }
            colliderManager.Update();
            //audioManager.Update();
            //animationTest.Update();

            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.LeftControl))
            {
                ui.ChangeSpriteOpacity("blood", 0.05f);
            }

            ui.ChangeText("generalFont", string.Format("FPS={0}", _fps));

            // Update
            _elapsed_time += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            // 1 Second has passed
            if (_elapsed_time >= 1000.0f)
            {
                _fps = _total_frames;
                _total_frames = 0;
                _elapsed_time = 0;
            }
        }
        public override void Draw()
        {
            lightRenderer.Draw();

            graphics.GraphicsDevice.Clear(Color.LightBlue);

            foreach (GameObject go in gameObjects)
            {
                go.Draw(mainCam);
            }

            ui.Draw();

            //animationTest.GetComponent<AnimationRender>().Draw(mainCam);


            //gameObject.GetComponent<SphereCollider>().DrawSphereSpikes(gameObject.GetComponent<SphereCollider>().GetPreciseBoundingSpheres()[i], graphics.GraphicsDevice, gameObject.GetComponent<MeshRenderer>().GetMatrix(), gameObject.GetComponent<Camera>().view, projection);

            //gameObject.GetComponent<SphereCollider>().DrawSphereSpikes(gameObject.GetComponent<SphereCollider>().GetPreciseBoundingSpheres()[0], graphics.GraphicsDevice, gameObject.GetComponent<MeshRenderer>().GetMatrix(), gameObject.GetComponent<Camera>().view, projection);
            //triggerObject.GetComponent<BoxCollider>().Draw(projection, graphics, gameObject.GetComponent<Camera>().view);
            //gameObject3.GetComponent<BoxCollider>().Draw(projection, graphics, mainCam.view);
            //gameObject3.GetComponent<BoxCollider>().DrawSphereSpikes(gameObject3.GetComponent<BoxCollider>().GetCompleteBoundingSphere(), graphics.GraphicsDevice, gameObject3.GetComponent<MeshRenderer>().GetMatrix(), mainCam.view, projection);
            //gameObject2.GetComponent<BoxCollider>().Draw(projection, graphics, mainCam.view);
            //gameObject2.GetComponent<BoxCollider>().DrawSphereSpikes(gameObject2.GetComponent<BoxCollider>().GetCompleteBoundingSphere(), graphics.GraphicsDevice, gameObject2.GetComponent<MeshRenderer>().GetMatrix(), mainCam.view, projection);
            // Only update total frames when drawing
            _total_frames++;

            graphics.GraphicsDevice.BlendState = BlendState.Opaque;
            graphics.GraphicsDevice.DepthStencilState = DepthStencilState.Default;
            graphics.GraphicsDevice.SamplerStates[0] = SamplerState.LinearWrap;

            base.Draw();
        }
    }
}
