using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Task_1.Entities
{
    public class NumericalFigure : Figure3D
    {

        private List<Vector3> points = new List<Vector3>();
        private int curIndex = 0;
        private KeyboardState prevKeyboardState;
        private bool isPaused = true;

        public NumericalFigure(GraphicsDevice device) : base(device)
        {
            var myCultureInfo = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            myCultureInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            using (var myReader = new StreamReader(new FileStream("Content\\data.csv", FileMode.Open)))
            {
                string line = "";
                while ((line = myReader.ReadLine()) != null)
                {
                    var coords = line.Split(' ');
                    points.Add(new Vector3(float.Parse(coords[0], NumberStyles.Any, myCultureInfo) / 5f,
                        float.Parse(coords[1], NumberStyles.Any, myCultureInfo) / 5f,
                        float.Parse(coords[2], NumberStyles.Any, myCultureInfo) / 5f - 5f));
                }
            }
        }

        private double time = 0;
        private int speed = 10;
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            time += gameTime.ElapsedGameTime.TotalMilliseconds;
            var curKeyBoarState = Keyboard.GetState();

            if (curKeyBoarState.IsKeyDown(Keys.Space) && prevKeyboardState.IsKeyUp(Keys.Space))
            {
                isPaused = !isPaused;
            }

            if (curKeyBoarState.IsKeyDown(Keys.R) && prevKeyboardState.IsKeyUp(Keys.R))
            {
                Clear();
                curIndex = 0;
                isPaused = true;
            }

            if (curKeyBoarState.IsKeyDown(Keys.OemPlus) && prevKeyboardState.IsKeyUp(Keys.OemPlus))
            {
                speed += 10;
            }

            if (curKeyBoarState.IsKeyDown(Keys.OemMinus) && prevKeyboardState.IsKeyUp(Keys.OemMinus))
            {
                speed -= 10;
            }

            if (time > 1 && !isPaused)
            {
                for (int i = 0; i < speed && curIndex < points.Count; i++, curIndex++)
                {
                    AddVertex(points[curIndex]);
                }
            }
            prevKeyboardState = curKeyBoarState;
        }
    }
}
