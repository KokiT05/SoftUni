using System;
using System.Collections.Generic;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            List<IShape> shapes = new List<IShape>();

            IDraw draw = new ConsoleDraw();

            IShape circle = new Circle();
            shapes.Add(circle);
            IShape rectangle = new Rectangle();
            shapes.Add(rectangle);
            IShape square = new Square();
            shapes.Add(square);
            IShape triangle = new Triangle();
            shapes.Add(triangle);

            foreach (IShape shape in shapes)
            {
                GraphicEditor editor = new GraphicEditor(shape, draw);
                editor.Draw();
            }
        }
    }
}
