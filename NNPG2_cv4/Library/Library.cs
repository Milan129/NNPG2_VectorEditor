﻿using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using static System.Math;

namespace NNPG2_cv4
{
    static class Library
    {
        public static readonly Image DEFAULT_TEXTURE = Image.FromFile(Directory.GetCurrentDirectory() + @"\..\..\rsc\btntreant-result.bmp");
        public static double DistancePoint(Point p1, Point p2)
        {
            return Sqrt(Pow(p1.X - p2.X, 2) + Pow(p1.Y - p2.Y, 2));
        }
        public static double DistanceLine(Point pt, Point p1, Point p2)
        {
            float dx = p2.X - p1.X;
            float dy = p2.Y - p1.Y;
            if ((dx == 0) && (dy == 0))
            {
                return DistancePoint(pt, p1);
            }
            float t = ((pt.X - p1.X) * dx + (pt.Y - p1.Y) * dy) / (dx * dx + dy * dy);
            if (t < 0)
            {
                dx = pt.X - p1.X;
                dy = pt.Y - p1.Y;
            }
            else if (t > 1)
            {
                dx = pt.X - p2.X;
                dy = pt.Y - p2.Y;
            }
            else
            {
                PointF closest = new PointF(p1.X + t * dx, p1.Y + t * dy);
                dx = pt.X - closest.X;
                dy = pt.Y - closest.Y;
            }
            return Sqrt(dx * dx + dy * dy);
        }
        public static bool FileDialog(FileDialog fileDialog, string filter, out string filePath)
        {
            filePath = "";
            fileDialog.Filter = filter;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = fileDialog.FileName;
                return true;
            }
            return false;
        }
        public static void SaveImage(Image image, string path)
        {
            string ext = Path.GetExtension(path).ToLower();
            switch (ext)
            {
                case ".jpg":
                    image.Save(path, ImageFormat.Jpeg);
                    break;
                case ".jpeg":
                    image.Save(path, ImageFormat.Jpeg);
                    break;
                case ".gif":
                    image.Save(path, ImageFormat.Gif);
                    break;
                case ".png":
                    image.Save(path, ImageFormat.Png);
                    break;
                case ".bmp":
                    image.Save(path, ImageFormat.Bmp);
                    break;
                case ".tiff":
                    image.Save(path, ImageFormat.Tiff);
                    break;
                default:
                    image.Save(path);
                    break;
            }           
        }
    }
}
