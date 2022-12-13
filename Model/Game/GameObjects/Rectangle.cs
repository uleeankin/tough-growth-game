﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Enums;

namespace Model.Game.GameObjects
{
    public class Rectangle : GameObject
    {

        public double StartX { get; set; }
        public double StartY { get; set; }
        public double EndX { get; set; }
        public double EndY { get; set; }
        public int Orientation { get; set; }

        public Rectangle(GameObjectTypes parID, string parIDName, double parX,
            double parY, double parArea) : base(parID, parIDName, parX, parY, parArea)
        {

        }

        public override void SetHeight()
        {
            if (Orientation == 1)
            {
                Height = Math.Sqrt(Area);
            }
            else
            {
                Height = Math.Sqrt(Area) * 4;
            }

        }

        public override void SetWidth()
        {
            if (Orientation == 1)
            {
                Width = Math.Sqrt(Area) * 4;
            }
            else
            {
                Width = Math.Sqrt(Area);
            }
        }

        public override GameObject Clone()
        {
            Rectangle rectangle = new Rectangle(ID, IDName, X, Y, Area);
            rectangle.StartX = StartX;
            rectangle.StartY = StartY;
            rectangle.EndY = EndY;
            rectangle.EndX = EndX;
            rectangle.Orientation = Orientation;
            rectangle.Area = Area;
            return rectangle;
        }
    }
}
