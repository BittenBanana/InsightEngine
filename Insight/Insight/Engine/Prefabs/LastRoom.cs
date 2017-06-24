﻿using Insight.Engine.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Engine.Prefabs
{
    class LastRoom : Prefab
    {
        WallVisible wall48;
        WallVisible wall49;
        WallVisible wall50;
        WallVisible wall51;
        WallVisible wall52;
        WallVisible wall53;
        WallVisible wall54;

        RoomFloor roomFloor26;
        RoomFloor roomFloor27;
        RoomFloor roomFloor28;
        RoomFloor roomFloor29;

        AnimatedDoor door7;

        public override void Initialize(Vector3 position)
        {
            prefabGameObjects = new List<GameObject>();

            wall48 = new WallVisible();
            wall48.Initialize(new Vector3(28, -4, 90), new Vector3(0));

            wall49 = new WallVisible();
            wall49.Initialize(new Vector3(28, -4, 100), new Vector3(0));

            wall50 = new WallVisible();
            wall50.Initialize(new Vector3(23, -4, 100), new Vector3(0));

            wall51 = new WallVisible();
            wall51.Initialize(new Vector3(33, -4, 90), new Vector3(0, 4.713f, 0));

            wall52 = new WallVisible();
            wall52.Initialize(new Vector3(33, -4, 95), new Vector3(0, 4.713f, 0));

            wall53 = new WallVisible();
            wall53.Initialize(new Vector3(23, -4, 90), new Vector3(0, 4.713f, 0));

            wall54 = new WallVisible();
            wall54.Initialize(new Vector3(23, -4, 95), new Vector3(0, 4.713f, 0));

            roomFloor26 = new RoomFloor();
            roomFloor26.Initialize(new Vector3(23, -4, 90));

            roomFloor27 = new RoomFloor();
            roomFloor27.Initialize(new Vector3(23, -4, 95));

            roomFloor28 = new RoomFloor();
            roomFloor28.Initialize(new Vector3(28, -4, 90));

            roomFloor29 = new RoomFloor();
            roomFloor29.Initialize(new Vector3(28, -4, 95));

            door7 = new AnimatedDoor();
            door7.Initialize(new Vector3(23f, -4, 90));



            prefabGameObjects.Add(wall48.wallModel);
            prefabGameObjects.Add(wall49.wallModel);
            prefabGameObjects.Add(wall50.wallModel);
            prefabGameObjects.Add(wall51.wallModel);
            prefabGameObjects.Add(wall52.wallModel);
            prefabGameObjects.Add(wall53.wallModel);
            prefabGameObjects.Add(wall54.wallModel);
            prefabGameObjects.Add(roomFloor26.floor);
            prefabGameObjects.Add(roomFloor27.floor);
            prefabGameObjects.Add(roomFloor28.floor);
            prefabGameObjects.Add(roomFloor29.floor);
            prefabGameObjects.Add(roomFloor26.corridorModel);
            prefabGameObjects.Add(roomFloor27.corridorModel);
            prefabGameObjects.Add(roomFloor28.corridorModel);
            prefabGameObjects.Add(roomFloor29.corridorModel);
            prefabGameObjects.Add(door7.wallModel);
            prefabGameObjects.Add(door7.leftDoorModel);
            prefabGameObjects.Add(door7.rightDoorModel);
            prefabGameObjects.Add(door7.frame);
            base.Initialize(position);
        }

        public override void LoadContent(ContentManager content)
        {
            wall48.LoadContent(content);
            wall49.LoadContent(content);
            wall50.LoadContent(content);
            wall51.LoadContent(content);
            wall52.LoadContent(content);
            wall53.LoadContent(content);
            wall54.LoadContent(content);

            roomFloor26.LoadContent(content);
            roomFloor27.LoadContent(content);
            roomFloor28.LoadContent(content);
            roomFloor29.LoadContent(content);

            door7.LoadContent(content);
        }
    }
}