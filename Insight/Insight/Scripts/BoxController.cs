using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Engine;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using Insight.Engine.Components;

namespace Insight.Scripts
{
    class BoxController : BaseScript
    {
        enum KeyState
        {
            Pressed,
            Released,
            None
        }
        public enum MovementState
        {
            IsRunning,
            IsIdle,
            SetRunning,
            SetIdle,
            Busy
        }
        KeyState kState = KeyState.None;
        public MovementState mState = MovementState.IsIdle;
        private MouseState s;
        private Vector2 lastMousePos;
        private int stepsCueNumber;

        private float soundTimer, soundDelay, moveSpeed;

        public BoxController(GameObject gameObject) : base(gameObject)
        {
            stepsCueNumber =
                SceneManager.Instance.currentScene.audioManager.AddCueWithEmitter(
                    SceneManager.Instance.currentScene.audioManager.soundBank.GetCue("PlayerSteps"), gameObject);
            lastMousePos = s.Position.ToVector2();
        }

        int timer = 0;         //Initialize a 10 second timer
        List<Vector3> lastPositions = new List<Vector3>();

        public override void Update()
        {
            gameObject.IsMoving = false;
            gameObject.Right = false;
            gameObject.Left = false;
            gameObject.Forward = false;
            gameObject.Backward = false;
            //gameObject.collision = false;
            KeyboardState keyState = Keyboard.GetState();
            s = Mouse.GetState();

            //timer++;
            //if (timer > 20)
            //{
            //    Debug.WriteLine("timer");
                gameObject.Transform.prevPosition = gameObject.Transform.Position;
            //    timer = 0;
            //}
            if(lastPositions.Count > 1)
            {
                lastPositions.RemoveAt(lastPositions.Count - 1);
            }

            lastPositions.Insert(0, gameObject.Transform.Position);

            if (s.Position.ToVector2().X < SceneManager.Instance.device.GraphicsDevice.Viewport.Width / 2)
            {
                gameObject.Transform.Rotation.Y += gameObject.rotationSpeed * Math.Abs(s.Position.X - lastMousePos.X);

                gameObject.Transform.Rotate(Vector3.UnitY, gameObject.rotationSpeed);
            }
            if (s.Position.ToVector2().X > SceneManager.Instance.device.GraphicsDevice.Viewport.Width / 2)
            {
                gameObject.Transform.Rotation.Y -= gameObject.rotationSpeed * Math.Abs(s.Position.X - lastMousePos.X);
                gameObject.Transform.Rotate(Vector3.UnitY, -gameObject.rotationSpeed);
            }

            if (kState == KeyState.Pressed)
                kState = KeyState.Released;
            if (keyState.IsKeyDown(Keys.Up) || keyState.IsKeyDown(Keys.W))
            {
                //gameObject.Transform.Position.X += gameObject.velocityX;
                //gameObject.Transform.Position.Z += gameObject.velocityZ;
                gameObject.Transform.Move(Vector3.UnitX, gameObject.velocityX);
                gameObject.Transform.Move(Vector3.UnitZ, gameObject.velocityZ);
                gameObject.Forward = true;
                gameObject.IsMoving = true; 
                
                kState = KeyState.Pressed;
               
                if(mState == MovementState.IsIdle)
                {
                    SceneManager.Instance.currentScene.audioManager.PlayCue(stepsCueNumber);
                    this.gameObject.GetComponent<AnimationRender>().ChangeAnimation(3,true);
                    //this.gameObject.GetComponent<AnimationRender>().LoadNewModel(ContentModels.Instance.playerRun);
                    mState = MovementState.IsRunning;
                    soundDelay = (float)gameObject.GetComponent<AnimationRender>().GetAnimationPlayer().CurrentClip
                                     .Duration.TotalSeconds / 2f;
                }

                if (gameObject.GetComponent<AnimationRender>().animationId == 3) {
                    if ( soundTimer > soundDelay)
                    {
                        SceneManager.Instance.currentScene.audioManager.PlayCue(stepsCueNumber);
                        soundTimer = 0;
                    }
                    soundTimer += Time.deltaTime;
                }
            }
            if (keyState.IsKeyDown(Keys.Down) || keyState.IsKeyDown(Keys.S))
            {
                //gameObject.Transform.Position.X -= gameObject.velocityX;
                //gameObject.Transform.Position.Z -= gameObject.velocityZ;
                gameObject.Transform.Move(Vector3.UnitX, -gameObject.velocityX/2);
                gameObject.Transform.Move(Vector3.UnitZ, -gameObject.velocityZ/2);
                gameObject.Backward = true;
                gameObject.IsMoving = true;

                kState = KeyState.Pressed;             

                if (mState == MovementState.IsIdle)
                {
                    this.gameObject.GetComponent<AnimationRender>().ChangeAnimation(4,true);
                    //this.gameObject.GetComponent<AnimationRender>().LoadNewModel(ContentModels.Instance.playerRun);
                    mState = MovementState.IsRunning;
                    soundDelay = (float) gameObject.GetComponent<AnimationRender>().GetAnimationPlayer().CurrentClip
                                     .Duration.TotalSeconds / 2f;
                }

                if (gameObject.GetComponent<AnimationRender>().animationId == 4)
                {
                    if (soundTimer > soundDelay)
                    {
                        SceneManager.Instance.currentScene.audioManager.PlayCue(stepsCueNumber);
                        soundTimer = 0;
                    }
                    soundTimer += Time.deltaTime;
                }
            }

            if (keyState.IsKeyDown(Keys.Left) || keyState.IsKeyDown(Keys.A))
            {
                //gameObject.Transform.Position.X += gameObject.velocityX;
                //gameObject.Transform.Position.Z += gameObject.velocityZ;
                gameObject.Transform.Move(Vector3.UnitX, gameObject.velocityZ/2);
                gameObject.Transform.Move(Vector3.UnitZ, -gameObject.velocityX/2);
                kState = KeyState.Pressed;

                if (mState == MovementState.IsIdle)
                {
                    this.gameObject.GetComponent<AnimationRender>().ChangeAnimation(6,true);
                    mState = MovementState.IsRunning;
                    soundDelay = (float)gameObject.GetComponent<AnimationRender>().GetAnimationPlayer().CurrentClip
                                     .Duration.TotalSeconds / 2f;
                }

                if (gameObject.GetComponent<AnimationRender>().animationId == 6)
                {
                    if (soundTimer > soundDelay)
                    {
                        SceneManager.Instance.currentScene.audioManager.PlayCue(stepsCueNumber);
                        soundTimer = 0;
                    }
                    soundTimer += Time.deltaTime;
                }
                //gameObject.Forward = true;
                //gameObject.Backward = false;
                //gameObject.IsMoving = true;
                gameObject.Left = true;
                gameObject.IsMoving = true;
            }
            if (keyState.IsKeyDown(Keys.Right) || keyState.IsKeyDown(Keys.D))
            {
                //gameObject.Transform.Position.X -= gameObject.velocityX;
                //gameObject.Transform.Position.Z -= gameObject.velocityZ;
                gameObject.Transform.Move(Vector3.UnitX, -gameObject.velocityZ/2);
                gameObject.Transform.Move(Vector3.UnitZ, gameObject.velocityX/2);
                kState = KeyState.Pressed;

                if (mState == MovementState.IsIdle)
                {
                    this.gameObject.GetComponent<AnimationRender>().ChangeAnimation(5,true);
                    mState = MovementState.IsRunning;
                    soundDelay = (float)gameObject.GetComponent<AnimationRender>().GetAnimationPlayer().CurrentClip
                                     .Duration.TotalSeconds / 2f;
                }

                if (gameObject.GetComponent<AnimationRender>().animationId == 5)
                {
                    if (soundTimer > soundDelay)
                    {
                        SceneManager.Instance.currentScene.audioManager.PlayCue(stepsCueNumber);
                        soundTimer = 0;
                    }
                    soundTimer += Time.deltaTime;
                }
                //gameObject.Forward = false;
                //gameObject.Backward = true;
                //gameObject.IsMoving = true;
                gameObject.Right = true;
                gameObject.IsMoving = true;
            }
            if(gameObject.GetComponent<Rigidbody>() != null)
            if (keyState.IsKeyDown(Keys.Space) && gameObject.GetComponent<Rigidbody>().isGrounded)
            {
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 500, 0));
            }
            if (keyState.IsKeyDown(Keys.Enter))
            {
                Debug.WriteLine(gameObject.Transform.Position);
            }
            lastMousePos = s.Position.ToVector2();
            gameObject.rotationSpeed = .01f;

            if (Game1.instance.IsActive)
                Mouse.SetPosition(SceneManager.Instance.device.GraphicsDevice.Viewport.Width /2, s.Position.Y);

            if(kState == KeyState.Released && mState == MovementState.IsRunning)
            {
                //this.gameObject.GetComponent<AnimationRender>().LoadNewModel(ContentModels.Instance.playerIdle);
                this.gameObject.GetComponent<AnimationRender>().ChangeAnimation(0,true);
                kState = KeyState.None;
                mState = MovementState.IsIdle;
            }

            //if(gameObject.IsMoving)
            //{
                //Debug.WriteLine(gameObject.Transform.prevPosition + "     previous");
                //Debug.WriteLine(gameObject.Transform.Position + "     current");
                //Debug.WriteLine("");
                if (gameObject.SuperCollision)
                {
                    //Debug.WriteLine(gameObject.Transform.prevPosition + "     previous");
                    //Debug.WriteLine(gameObject.Transform.Position + "     current");
                    //gameObject.Transform.Position = gameObject.Transform.prevPosition;
                    //Debug.WriteLine(gameObject.Transform.Position + "     current after");
                    while(lastPositions.Count > 0)
                    {
                        Debug.WriteLine("rewind");
                        gameObject.Transform.Position = lastPositions[0];
                        lastPositions.RemoveAt(0);
                    }
                    

                }
                gameObject.SuperCollision = false;

            //}
            //Debug.WriteLine(gameObject.SuperCollision);
            base.Update();
        }

        public void OnObjectColided(object source, CollisionEventArgs args)
        {
            gameObject.SuperCollision = true;
            // Debug.WriteLine("yuuup");
            //gameObject.Transform.Position = gameObject.Transform.prevPosition;
            //gameObject.collision = true;
        }

        //public override void OnTriggerEnter(object source, CollisionEventArgs args)
        //{
        //    //Debug.WriteLine("On trigger enter");
        //    if (args.GameObject.physicLayer == Layer.DoorTrigger)
        //    {
        //        Debug.WriteLine("doors");
        //        SceneManager.Instance.currentScene.ui.ChangeTextOpacity("hint", 1);
        //    }

        //    if (args.GameObject.physicLayer == Layer.DispenserTrigger)
        //    {
        //        Debug.WriteLine("dispenser");
        //        SceneManager.Instance.currentScene.ui.ChangeSpriteOpacity("bulletRakieta", 1);
        //        SceneManager.Instance.currentScene.ui.ChangeTextOpacity("dispenserHint", 1);
        //    }
        //}

        //public override void OnTriggerStay(object source, CollisionEventArgs args)
        //{
        //    //Debug.WriteLine("On trigger stay");
        //    if (args.GameObject.physicLayer == Layer.DispenserTrigger)
        //    {
        //        KeyboardState keyState = Keyboard.GetState();
        //        if (keyState.IsKeyDown(Keys.E))
        //        {
        //            this.gameObject.GetComponent<PlayerBullets>().aggresiveBullet = true;
        //        }
        //    }


        //}

        //public override void OnTriggerExit(object source, CollisionEventArgs args)
        //{
        //    Debug.WriteLine("On trigger exit");
        //    if (args.GameObject.physicLayer == Layer.DoorTrigger)
        //        SceneManager.Instance.currentScene.ui.ChangeTextOpacity("hint", 0);
        //    if (args.GameObject.physicLayer == Layer.DispenserTrigger)
        //    {
        //        SceneManager.Instance.currentScene.ui.ChangeSpriteOpacity("bulletRakieta", 0);
        //        SceneManager.Instance.currentScene.ui.ChangeTextOpacity("dispenserHint", 0);
        //    }

        //}
    }
}
