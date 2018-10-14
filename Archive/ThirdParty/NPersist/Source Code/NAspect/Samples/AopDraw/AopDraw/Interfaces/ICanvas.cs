using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using AopDraw.Classes.Shapes;

namespace AopDraw.Interfaces
{
    public interface ICanvas
    {
        bool IsDirty { get;set;}
        void Render(Graphics g);
        double Width { get;set;}
        double Height { get;set;}
        void MoveSelectedShapes(double xOffset, double yOffset);
        void ResizeSelectedShapes(double width, double height);
        void DeleteSelectedShapes();
        void AddShape(Shape shape);
        void ClearSelection();
        Shape GetShapeAt(double x, double y);
        IList<Shape> GetShapesAt(double x, double y, double width, double height);               
    }
}
