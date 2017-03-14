using System;
using System.Collections.Generic;
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
        public CameraFollowBox(GameObject gameObject) : base(gameObject)
        {
            mainCam = gameObject.GetComponent<Camera>();
        }

        public override void Update()
        {
            mainCam.Position.X = gameObject.Transform.Position.X - 15 * (float)Math.Sin(gameObject.Transform.Rotation.Y);
            mainCam.Position.Z = gameObject.Transform.Position.Z - 15 * (float)Math.Cos(gameObject.Transform.Rotation.Y);
            mainCam.view = Matrix.CreateLookAt(mainCam.Position, gameObject.Transform.Position, Vector3.Up);

            base.Update();
        }
    }
}
