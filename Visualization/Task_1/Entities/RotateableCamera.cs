using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Task_1.Core;

namespace Task_1.Entities
{
    public class RotateableCamera : Camera
    {

        public float Yaw { get; set; }
        public float Pitch { get; set; }
        public float Radius { get; set; }
        public float RotationSpeed { get; set; }
        private MouseState myPrevMouseState = new MouseState();

        public RotateableCamera(GraphicsDevice device, float rotationSpeed = 0.5f, float yaw = 0.2f, float pitch = 0f, float radius = 15f) : base(device)
        {
            RotationSpeed = rotationSpeed;
            Yaw = yaw;
            Pitch = pitch;
            Radius = radius;
            UpdateViewMatrix(Vector3.Transform(new Vector3(0, 0, Radius), Matrix.CreateFromYawPitchRoll(Yaw, Pitch, 0)),
                Vector3.Zero, Vector3.Up);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            MouseState mouseState = Mouse.GetState();

            if (mouseState.LeftButton == ButtonState.Pressed && myPrevMouseState.LeftButton == ButtonState.Pressed)
            {
                float elapsedTime = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 1000.0f;
                float deltaX = mouseState.X - myPrevMouseState.X;
                float deltaY = mouseState.Y - myPrevMouseState.Y;
                Yaw -= RotationSpeed * deltaX * elapsedTime;
                Pitch -= RotationSpeed * deltaY * elapsedTime;

                Pitch = MathHelper.Clamp(Pitch, -MathHelper.Pi / 2.2f, MathHelper.Pi / 2.2f);
            }
            Radius += (mouseState.ScrollWheelValue - myPrevMouseState.ScrollWheelValue) * 0.05f;

            var result = Vector3.Transform(new Vector3(0, 0, Radius), Matrix.CreateFromYawPitchRoll(Yaw, Pitch, 0));
            UpdateViewMatrix(result, Vector3.Zero, Vector3.Up);
            myPrevMouseState = mouseState;
        }
    }
}
