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
            Debug.WriteLine(gameObject.Transform.Rotation);
            mainCam.Position.X = gameObject.Transform.Position.X - 10 * (float)Math.Sin(gameObject.Transform.Rotation.Y) * (float)Math.Cos(gameObject.Transform.Rotation.X);
            mainCam.Position.Z = gameObject.Transform.Position.Z - 10 * (float)Math.Cos(gameObject.Transform.Rotation.Y) * (float)Math.Cos(gameObject.Transform.Rotation.X);
            mainCam.Position.Y = gameObject.Transform.Position.Y - 10 * (float)Math.Sin(gameObject.Transform.Rotation.X);
            mainCam.view = Matrix.CreateLookAt(mainCam.Position, player.Transform.Position, Vector3.Up);

            base.Update();
        }
    }
}
