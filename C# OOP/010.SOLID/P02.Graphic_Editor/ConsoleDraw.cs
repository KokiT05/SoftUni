﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.Graphic_Editor
{
    public class ConsoleDraw : IDraw
    {
        public void DrawShape(IShape shape)
        {
            Console.WriteLine(shape.Draw());
        }
    }
}
