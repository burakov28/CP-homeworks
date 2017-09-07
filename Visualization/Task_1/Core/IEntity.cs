using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Task_1.Core
{
    public interface IEntity : IDisposable
    {
        void Update(GameTime gameTime);
        void Draw(GameTime gameTime, GraphicsDevice device, Camera camera);
    }
}
