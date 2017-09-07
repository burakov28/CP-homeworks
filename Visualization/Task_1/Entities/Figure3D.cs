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
    public class Figure3D : IEntity
    {
        private VertexPositionColor[] myVertices = new VertexPositionColor[10];
        private int curIndex = 0;
        private BasicEffect myEffect;

        public Figure3D(GraphicsDevice device)
        {
            myEffect = new BasicEffect(device);
        }

        protected void AddVertex(Vector3 position)
        {
            if (curIndex < myVertices.Length)
            {
                myVertices[curIndex++] = new VertexPositionColor(position, Color.White);
            }
            else
            {
                var newArr = new VertexPositionColor[myVertices.Length * 2];
                myVertices.CopyTo(newArr, 0);
                myVertices = newArr;
            }
        }

        protected void Clear()
        {
            curIndex = 0;
        }

        public virtual void Update(GameTime gameTime)
        {
            for (int i = 0; i < curIndex; i++)
            {
                myVertices[i].Color = new Color((int)(255 * i / (float)curIndex), 255, 255);
            }
        }

        public void Draw(GameTime gameTime, GraphicsDevice device, Camera camera)
        {
            myEffect.VertexColorEnabled = true;
            myEffect.View = camera.View;
            myEffect.Projection = camera.Projection;
            myEffect.CurrentTechnique.Passes[0].Apply();

            if (curIndex > 1)
                device.DrawUserPrimitives(PrimitiveType.LineStrip, myVertices, 0, curIndex - 1);
        }

        public virtual void Dispose()
        {
            if (myEffect != null)
            {
                myEffect.Dispose();
                myEffect = null;
            }
        }
    }
}
