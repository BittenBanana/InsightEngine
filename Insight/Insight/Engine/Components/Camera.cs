using Insight.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Engine
{
    public class Camera : Component
    {
        public Matrix projection { get; set; }
        public Matrix view { get;  set; }
        public Vector3 Position;

        public Camera(GameObject gameObject) : base (gameObject)
        {
            projection = SceneManager.Instance.currentScene.GetProjectionMatrix();
            Position = new Vector3(gameObject.Transform.Position.X, gameObject.Transform.Position.Y, gameObject.Transform.Position.Z);
            view = Matrix.CreateFromQuaternion(gameObject.Transform.quaterion);
        }
        
        
    }
}
