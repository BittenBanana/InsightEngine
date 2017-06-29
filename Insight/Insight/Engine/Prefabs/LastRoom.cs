using Insight.Engine.Components;
using Insight.Materials;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
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
        WallVisible wall54;
        WallVisible wall55;
        WallVisible wall56;
        WallVisible wall57;
        WallVisible wall58;

        RoomFloor roomFloor26;
        RoomFloor roomFloor27;
        RoomFloor roomFloor28;
        RoomFloor roomFloor29;

        NewWall newWall18;
        NewWall newWall19;
        NewWall newWall20;
        NewWall newWall21;
        NewWall newWall22;
        NewWall newWall23;
        NewWall newWall24;
        NewWall newWall25;

        TransparencyMaterial glassMaterial;

        CeilingLastRoom lastRoomCeiling;

        GlassModel glassModel;
        GlassBaseModel glassBaseModel;

        SleepingDude dude;

        public override void Initialize(Vector3 position)
        {
            prefabGameObjects = new List<GameObject>();

            lastRoomCeiling = new CeilingLastRoom();
            lastRoomCeiling.Initialize(new Vector3(33, -10, 100), new Vector3(0));

            wall48 = new WallVisible();
            wall48.Initialize(new Vector3(28, -4, 90), new Vector3(0));

            newWall18 = new NewWall();
            newWall18.Initialize(new Vector3(28, -4, 90), new Vector3(0));

            wall55 = new WallVisible();
            wall55.Initialize(new Vector3(23, -4, 90), new Vector3(0));

            newWall19 = new NewWall();
            newWall19.Initialize(new Vector3(23, -4, 90), new Vector3(0));

            wall49 = new WallVisible();
            wall49.Initialize(new Vector3(28, -4, 100), new Vector3(0));

            wall57 = new WallVisible();
            wall57.Initialize(new Vector3(27.7f, -4, 90), new Vector3(0, 4.713f, 0));

            wall58 = new WallVisible();
            wall58.Initialize(new Vector3(27.7f, -4, 95), new Vector3(0, 4.713f, 0));

            newWall20 = new NewWall();
            newWall20.Initialize(new Vector3(33, -4, 100), new Vector3(0, 3.142f, 0));

            wall50 = new WallVisible();
            wall50.Initialize(new Vector3(23, -4, 100), new Vector3(0));

            newWall21 = new NewWall();
            newWall21.Initialize(new Vector3(28, -4, 100), new Vector3(0, 3.142f, 0));

            wall51 = new WallVisible();
            wall51.Initialize(new Vector3(33, -4, 90), new Vector3(0, 4.713f, 0));

            newWall22 = new NewWall();
            newWall22.Initialize(new Vector3(33, -4, 90), new Vector3(0, 4.713f, 0));

            wall52 = new WallVisible();
            wall52.Initialize(new Vector3(33, -4, 95), new Vector3(0, 4.713f, 0));

            newWall23 = new NewWall();
            newWall23.Initialize(new Vector3(33, -4, 95), new Vector3(0, 4.713f, 0));

            wall54 = new WallVisible();
            wall54.Initialize(new Vector3(23, -4, 95), new Vector3(0, 4.713f, 0));

            newWall24 = new NewWall();
            newWall24.Initialize(new Vector3(23, -4, 100), new Vector3(0, 1.571f, 0));

            wall56 = new WallVisible();
            wall56.Initialize(new Vector3(27, -4, 95), new Vector3(0, 4.713f, 0));

            //newWall25 = new NewWall();
            //newWall25.Initialize(new Vector3(27, -4, 95), new Vector3(0, 1.571f, 0));

            roomFloor26 = new RoomFloor();
            roomFloor26.Initialize(new Vector3(23, -4, 90));

            roomFloor27 = new RoomFloor();
            roomFloor27.Initialize(new Vector3(23, -4, 95));

            roomFloor28 = new RoomFloor();
            roomFloor28.Initialize(new Vector3(28, -4, 90));

            roomFloor29 = new RoomFloor();
            roomFloor29.Initialize(new Vector3(28, -4, 95));

            glassModel = new GlassModel();
            glassModel.Initialize(new Vector3(28, -4, 100), new Vector3(0, 1.571f, 0));

            glassBaseModel = new GlassBaseModel();
            glassBaseModel.Initialize(new Vector3(28, -4, 100), new Vector3(0, 1.571f, 0));

            dude = new SleepingDude();
            dude.Initialize(new Vector3(28, -4, 120), new Vector3(0, 0, 0));

            prefabGameObjects.Add(wall58.wallModel);
            prefabGameObjects.Add(wall57.wallModel);
            prefabGameObjects.Add(wall56.wallModel);
            prefabGameObjects.Add(wall55.wallModel);
            prefabGameObjects.Add(wall48.wallModel);
            prefabGameObjects.Add(wall49.wallModel);
            prefabGameObjects.Add(wall50.wallModel);
            prefabGameObjects.Add(wall51.wallModel);
            prefabGameObjects.Add(wall52.wallModel);

            prefabGameObjects.Add(wall54.wallModel);
            prefabGameObjects.Add(roomFloor26.floor);
            prefabGameObjects.Add(roomFloor27.floor);
            prefabGameObjects.Add(roomFloor28.floor);
            prefabGameObjects.Add(roomFloor29.floor);
            prefabGameObjects.Add(roomFloor26.corridorModel);
            prefabGameObjects.Add(roomFloor27.corridorModel);
            prefabGameObjects.Add(roomFloor28.corridorModel);
            prefabGameObjects.Add(roomFloor29.corridorModel);

            prefabGameObjects.Add(newWall18.wallModel);
            prefabGameObjects.Add(newWall19.wallModel);
            prefabGameObjects.Add(newWall20.wallModel);
            prefabGameObjects.Add(newWall21.wallModel);
            prefabGameObjects.Add(newWall22.wallModel);
            prefabGameObjects.Add(newWall23.wallModel);
            prefabGameObjects.Add(newWall24.wallModel);
            //prefabGameObjects.Add(newWall25.wallModel);
            prefabGameObjects.Add(lastRoomCeiling.wallModel);
            prefabGameObjects.Add(glassModel.columnModel);
            prefabGameObjects.Add(glassBaseModel.columnModel);
            prefabGameObjects.Add(dude.wallModel);
            base.Initialize(position);
        }

        public override void LoadContent(ContentManager content)
        {
            wall48.LoadContent(content);
            wall49.LoadContent(content);
            wall50.LoadContent(content);
            wall51.LoadContent(content);
            wall52.LoadContent(content);
            wall54.LoadContent(content);
            wall55.LoadContent(content);
            wall57.LoadContent(content);
            wall58.LoadContent(content);

            roomFloor26.LoadContent(content);
            roomFloor27.LoadContent(content);
            roomFloor28.LoadContent(content);
            roomFloor29.LoadContent(content);

            newWall18.LoadContent(content);
            newWall19.LoadContent(content);
            newWall20.LoadContent(content);
            newWall21.LoadContent(content);
            newWall22.LoadContent(content);
            newWall23.LoadContent(content);
            newWall24.LoadContent(content);
            lastRoomCeiling.LoadContent(content);
            glassModel.LoadContent(content);
            glassBaseModel.LoadContent(content);
            dude.LoadContent(content);
            //newWall25.LoadContent(content);

            Effect transparency = content.Load<Effect>("Shaders/glass");
            glassMaterial = new TransparencyMaterial(transparency);

            glassModel.columnModel.GetComponent<MeshRenderer>().Material = glassMaterial;
            //wall56.LoadContent(content);
        }
    }
}
