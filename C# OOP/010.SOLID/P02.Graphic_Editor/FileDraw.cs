using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.Graphic_Editor
{
    public class FileDraw : IDraw
    {
        public void DrawShape(IShape shape)
        {
            using (StreamWriter writer = new StreamWriter
            ("C:\\Users\\acer\\Desktop\\SoftUni\\C# OOP\\010.SOLID\\P02.Graphic_Editor\\TextFile.txt", true))
            {
                char[] buffer = shape.Draw().ToCharArray();
                writer.WriteLine(buffer);
                //writer.Write(Environment.NewLine);


                writer.Close();
            }
        }
    }
}
