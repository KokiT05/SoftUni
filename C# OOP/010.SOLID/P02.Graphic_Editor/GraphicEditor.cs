using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    public class GraphicEditor
    {
        private IDraw draw;
        private IShape shape;

        public GraphicEditor(IShape shape, IDraw draw)
        {
            this.shape = shape;
            this.draw = draw;
        }

        public void Draw()
        {
            draw.DrawShape(shape);
        }
    }
}
