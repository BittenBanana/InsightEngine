﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Insight.Engine.Components;

namespace Insight.Scripts
{
    class DoorAnimation : BaseScript
    {
        enum DoorState
        {
            Closed,
            Opened,
            Opening,
            Closing
        }
        private DoorState doorState = DoorState.Closed;
        public GameObject leftDoor { get; set; }
        public GameObject rightDoor { get; set; }
        private float openingSpeed = 0.025f;
        private float maxOffset = 1.0f;
        private float currentOffset = 0;
        public bool canOpen = true;
        public DoorAnimation(GameObject gameObject) : base(gameObject)
        {
        }

        public override void Update()
        {
            base.Update();

            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Enter))
            {
                OpenDoor();
            }
            if (keyState.IsKeyDown(Keys.RightShift))
            {
                CloseDoor();
            }

            switch (doorState)
            {
                case DoorState.Closed:
                    currentOffset = 0.0f;
                    break;
                case DoorState.Opened:
                    currentOffset = 0.0f;
                    break;
                case DoorState.Opening:
                    currentOffset += openingSpeed;
                    if (currentOffset <= 1.0f)
                    {
                        leftDoor.Transform.Move(Vector3.UnitX, openingSpeed);
                        rightDoor.Transform.Move(Vector3.UnitX, -openingSpeed);
                    }
                    else
                    {
                        doorState = DoorState.Opened;
                        currentOffset = 0.0f;
                        leftDoor.GetComponent<BoxCollider>().IsTrigger = true;
                        rightDoor.GetComponent<BoxCollider>().IsTrigger = true;
                        gameObject.GetComponent<BoxCollider>().IsTrigger = true;
                    }

                    break;
                case DoorState.Closing:
                    currentOffset += openingSpeed;
                    if (currentOffset <= 1.0f)
                    {
                        leftDoor.Transform.Move(Vector3.UnitX, -openingSpeed);
                        rightDoor.Transform.Move(Vector3.UnitX, openingSpeed);
                    }
                    else
                    {
                        doorState = DoorState.Closed;
                        currentOffset = 0.0f;
                        leftDoor.GetComponent<BoxCollider>().IsTrigger = false;
                        rightDoor.GetComponent<BoxCollider>().IsTrigger = false;
                        gameObject.GetComponent<BoxCollider>().IsTrigger = false;
                    }

                    break;
            }
        }

        public void OpenDoor()
        {
            if(canOpen)
                if(doorState == DoorState.Closed)
                    doorState = DoorState.Opening;
        }

        public void CloseDoor()
        {
            if(canOpen)
                if (doorState == DoorState.Opened)
                    doorState = DoorState.Closing;
        }
    }
}
