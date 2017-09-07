using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Task_1.Core;

namespace Task_1.Entities
{
    public class Axis : IEntity
    {
        private BasicEffect myEffect;

        private VertexPositionColor[] myAxis = new VertexPositionColor[]
        {
            new VertexPositionColor(Vector3.Zero, Color.Red),
            new VertexPositionColor(new Vector3(10, 0, 0), Color.Red),
            new VertexPositionColor(Vector3.Zero, Color.Green),
            new VertexPositionColor(new Vector3(0, 10, 0), Color.Green),
            new VertexPositionColor(Vector3.Zero, Color.Blue),
            new VertexPositionColor(new Vector3(0, 0, 10), Color.Blue),
        };

        public Axis(GraphicsDevice device)
        {
            myEffect = new BasicEffect(device);
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(GameTime gameTime, GraphicsDevice device, Camera camera)
        {
            myEffect.VertexColorEnabled = true;
            myEffect.View = camera.View;
            myEffect.Projection = camera.Projection;
            myEffect.CurrentTechnique.Passes[0].Apply();
            device.DrawUserPrimitives(PrimitiveType.LineList, myAxis, 0, 3);
        }

        public void Dispose()
        {
            if (myEffect != null)
            {
                myEffect.Dispose();
                myEffect = null;
            }
        }
    }
}
