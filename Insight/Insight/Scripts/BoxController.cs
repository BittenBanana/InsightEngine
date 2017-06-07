﻿using System;
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
        enum MovementState
        {
            IsRunning,
            IsIdle,
            SetRunning,
            SetIdle,
            Busy
        }
        KeyState kState = KeyState.None;
        MovementState mState = MovementState.IsIdle;
        private MouseState s;
        private Vector2 lastMousePos;
        public BoxController(GameObject gameObject) : base(gameObject)
        {

            lastMousePos = s.Position.ToVector2();
        }

        public override void Update()
        {
            gameObject.IsMoving = false;
            KeyboardState keyState = Keyboard.GetState();
            s = Mouse.GetState();

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
                gameObject.Backward = false;
                gameObject.IsMoving = true;

                kState = KeyState.Pressed;

                if(mState == MovementState.IsIdle)
                {
                    this.gameObject.GetComponent<AnimationRender>().SetFrames(0, 30);
                        mState = MovementState.IsRunning;
                }

            }
            if (keyState.IsKeyDown(Keys.Down) || keyState.IsKeyDown(Keys.S))
            {
                //gameObject.Transform.Position.X -= gameObject.velocityX;
                //gameObject.Transform.Position.Z -= gameObject.velocityZ;
                gameObject.Transform.Move(Vector3.UnitX, -gameObject.velocityX);
                gameObject.Transform.Move(Vector3.UnitZ, -gameObject.velocityZ);
                gameObject.Forward = false;
                gameObject.Backward = true;
                gameObject.IsMoving = true;

                kState = KeyState.Pressed;

                if (mState == MovementState.IsIdle)
                {
                    this.gameObject.GetComponent<AnimationRender>().SetFrames(0, 30);
                        mState = MovementState.IsRunning;
                }
            }

            if (keyState.IsKeyDown(Keys.Left) || keyState.IsKeyDown(Keys.A))
            {
                //gameObject.Transform.Position.X += gameObject.velocityX;
                //gameObject.Transform.Position.Z += gameObject.velocityZ;
                gameObject.Transform.Move(Vector3.UnitX, gameObject.velocityZ);
                gameObject.Transform.Move(Vector3.UnitZ, -gameObject.velocityX);
                gameObject.Forward = true;
                gameObject.Backward = false;
                gameObject.IsMoving = true;
            }
            if (keyState.IsKeyDown(Keys.Right) || keyState.IsKeyDown(Keys.D))
            {
                //gameObject.Transform.Position.X -= gameObject.velocityX;
                //gameObject.Transform.Position.Z -= gameObject.velocityZ;
                gameObject.Transform.Move(Vector3.UnitX, -gameObject.velocityZ);
                gameObject.Transform.Move(Vector3.UnitZ, gameObject.velocityX);
                gameObject.Forward = false;
                gameObject.Backward = true;
                gameObject.IsMoving = true;
            }
            if (keyState.IsKeyDown(Keys.Space) && gameObject.GetComponent<Rigidbody>().isGrounded)
            {
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 500, 0));
            }
            lastMousePos = s.Position.ToVector2();
            gameObject.rotationSpeed = .01f;

            Mouse.SetPosition(SceneManager.Instance.device.GraphicsDevice.Viewport.Width /2, s.Position.Y);

            if(kState == KeyState.Released && mState == MovementState.IsRunning)
            {
                this.gameObject.GetComponent<AnimationRender>().SetFrames(0, 1);
                kState = KeyState.None;
                mState = MovementState.IsIdle;
            }

            base.Update();
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
