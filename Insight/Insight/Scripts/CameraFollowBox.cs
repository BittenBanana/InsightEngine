using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insight.Engine;
using Microsoft.Xna.Framework;

namespace Insight.Scripts
{
    public class CameraFollowBox : BaseScript
    {
        Camera mainCam;
        public GameObject player { get; set; }
        public CameraFollowBox(GameObject gameObject) : base(gameObject)
        {
            mainCam = gameObject.GetComponent<Camera>();
        }

        public override void Update()
        {
            mainCam.Position.X = gameObject.Transform.Position.X - 3 * (float)Math.Sin(gameObject.Transform.Rotation.Y) * (float)Math.Cos(gameObject.Transform.Rotation.X);
            mainCam.Position.Z = gameObject.Transform.Position.Z - 3 * (float)Math.Cos(gameObject.Transform.Rotation.Y) * (float)Math.Cos(gameObject.Transform.Rotation.X);
            mainCam.Position.Y = gameObject.Transform.Position.Y - 3 * (float)Math.Sin(gameObject.Transform.Rotation.X);
            mainCam.view = Matrix.CreateLookAt(mainCam.Position, new Vector3(
                player.Transform.Position.X - 0.25f * MathHelper.Clamp((float)Math.Cos(gameObject.Transform.Rotation.Y),-1,1),
                player.Transform.Position.Y + (float)Math.Sin(gameObject.Transform.Rotation.X)
                , player.Transform.Position.Z + 0.25f * MathHelper.Clamp((float)Math.Sin(gameObject.Transform.Rotation.Y), -1, 1)
                ), Vector3.Up);

            base.Update();
        }
    }
}
