using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Task_1.Core
{
    public class World : IDisposable
    {
        public Camera ActiveCamera { get; set; }
        private GraphicsDevice GraphicsDevice { get;}

        private List<IEntity> myEntities = new List<IEntity>();
        
        public World(GraphicsDevice device)
        {
            Debug.Assert(device != null);
            GraphicsDevice = device;
        }


        public IEntity Spawn<T>(params object[] args) where T : IEntity
        {
            var rv =  (IEntity)Activator.CreateInstance(typeof(T), args);
            myEntities.Add(rv);
            return rv;
        }
        
        public void Update(GameTime gameTime)
        {
            if (ActiveCamera != null)
            {
                ActiveCamera.Update(gameTime);
            }
            foreach (var myEntity in myEntities)
            {
                myEntity.Update(gameTime);
            }
        }

        public void Draw(GameTime gameTime)
        {
            if (ActiveCamera == null)
            {
                Debug.Print("Active camera is not setted\n");
                return;
            }

            foreach (var myEntity in myEntities)
            {
                myEntity.Draw(gameTime, GraphicsDevice, ActiveCamera);    
            }
        }

        public void Dispose()
        {
            foreach (var entity in myEntities)
            {
                entity.Dispose();
            }
        }
    }
}
