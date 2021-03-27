﻿using System.Drawing;
using System.Drawing.Drawing2D;

namespace NNPG2_cv4
{
    public interface IShape
    {
        Brush Fill { get; set; }
        BrushType Mode { get; set; }
        float FillAngle { get; set; }
        Color Primary { get; set; }
        Color Secondary { get; set; }
        Pen Edge { get;}
        Color EdgeColor { get; set; }
        float EdgeWidth { get; set; }
        bool EdgeEnabled { get; set; }
        Size Size { get; }
        HatchStyle Hatch { get; set; }
        Image Texture { set;}

        IShape DeepCopy();

        void Render(Graphics g);

        void Export(string filepath);

        bool Contains(Point p);

        Point[] ControlPoints();

        void TransformMove(Size addend);

        void TransformScale(Size addend, int index);
    }
}