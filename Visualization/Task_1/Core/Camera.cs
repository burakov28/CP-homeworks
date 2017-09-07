using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Task_1.Core
{
    public class Camera
    {
        public Matrix View { get; set; }
        public Matrix Projection { get; set; }

        protected GraphicsDevice device;


        public Camera(GraphicsDevice device)
        {

            Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver2, device.Viewport.AspectRatio, 0.01f, 10000f);
            this.device = device;
            UpdateViewMatrix(new Vector3(20, 10, 5), new Vector3(0, 0, 0), Vector3.Up);
        }

        public void UpdateViewMatrix(Vector3 position, Vector3 target, Vector3 up)
        {
            View = Matrix.CreateLookAt(position, target, up);
        }

        public virtual void Update(GameTime gameTime)
        {

        }


    }
}
