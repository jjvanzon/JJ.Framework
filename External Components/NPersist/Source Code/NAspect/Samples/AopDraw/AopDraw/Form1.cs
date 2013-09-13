using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AopDraw.Interfaces;
using AopDraw.Classes;
using AopDraw.Classes.Shapes;
using Puzzle.NAspect.Framework;
using Puzzle.NAspect.Framework.Aop;
using AopDraw.Mixins;
using AopDraw.Enums;
using Puzzle.NAspect.Framework.Interception;
using AopDraw.Interceptors;
using System.Drawing.Drawing2D;
using AopDraw.Attributes;

namespace AopDraw
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        MouseHandlerCanvas canvas = new MouseHandlerCanvas();

        

        RectangleShape rectangle;
        private void Form1_Load(object sender, EventArgs e)
        {
            Application.Idle += new EventHandler(Application_Idle);

            IEngine engine = new Engine("AopDraw");

            InterfaceAspect canvasAwareAspect = new InterfaceAspect("canvasAwareAspect", typeof(Shape), new Type[] { typeof(CanvasAwareMixin) }, new IPointcut[] { new SignaturePointcut("set_*", new ShapePropertyInterceptor()) });
            engine.Configuration.Aspects.Add(canvasAwareAspect);

            InterfaceAspect typeDescriptorAspect = new InterfaceAspect("typeDescriptorAspect", typeof(Shape), new Type[] { typeof(CustomTypeDescriptorMixin) }, new IPointcut[] { });
            engine.Configuration.Aspects.Add(typeDescriptorAspect);

            InterfaceAspect guidAspect = new InterfaceAspect("guidAspect", typeof(Shape), new Type[] { typeof(GuidObject) }, new IPointcut[] { });
            engine.Configuration.Aspects.Add(guidAspect);

            AttributeAspect resizableAspect = new AttributeAspect("resizableAspect", typeof(ResizableAttribute), new Type[] { typeof(ResizableShape2DMixin) }, new IPointcut[] { });
            engine.Configuration.Aspects.Add(resizableAspect);

            AttributeAspect selectable2DAspect = new AttributeAspect("selectable2DAspect", typeof(SelectableAttribute), new Type[] { typeof(SelectableShape2DMixin) }, new IPointcut[] { });
            engine.Configuration.Aspects.Add(selectable2DAspect);

            InterfaceAspect selectable1DAspect = new InterfaceAspect("selectable1DAspect", typeof(Shape1D), new Type[] { typeof(SelectableShape1DMixin) }, new IPointcut[] { });
            engine.Configuration.Aspects.Add(selectable1DAspect);

            InterfaceAspect mouseEventAspect = new InterfaceAspect("mouseEventAspect", typeof(Shape), new Type[] { typeof(MouseHandlerMixin) }, new IPointcut[] { });
            engine.Configuration.Aspects.Add(mouseEventAspect);

            AttributeAspect movableAspect = new AttributeAspect("movableAspect", typeof(MovableAttribute), new Type[] { typeof(MovableShape2DMixin) }, new IPointcut[] { });
            engine.Configuration.Aspects.Add(movableAspect);

            InterfaceAspect movableShape1DAspect = new InterfaceAspect("movableShape1DAspect", typeof(Shape1D), new Type[] { typeof(MovableShape1DMixin) }, new IPointcut[] { });
            engine.Configuration.Aspects.Add(movableShape1DAspect);

            AttributeAspect designableAspect = new AttributeAspect("designableAspect", typeof(DesignableAttribute), new Type[] { typeof(DesignableMixin) }, new IPointcut[] { });
            engine.Configuration.Aspects.Add(designableAspect);





            SquareShape square = engine.CreateProxy<SquareShape>();
            square.X = 10;
            square.Y = 10;
            square.Width = 100;
            square.Height = 100;

            canvas.AddShape(square);


            CircleShape circle = engine.CreateProxy<CircleShape>();
            circle.X = 240;
            circle.Y = 120;
            circle.Width = 200;
            circle.Height = 200;

            canvas.AddShape(circle);


            rectangle = engine.CreateProxy<RectangleShape>();
            rectangle.X = 50;
            rectangle.Y = 90;
            rectangle.Width = 200;
            rectangle.Height = 50;

            canvas.AddShape(rectangle);

            Line line = engine.CreateProxy<Line>();
            line.X = 200;
            line.Y = 200;
            line.X2 = 400;
            line.Y2 = 340;
            canvas.AddShape(line);


            TextShape text = engine.CreateProxy<TextShape>();
            text.X = 140;
            text.Y = 3;
            text.Width = 200;
            text.Height = 100;
            canvas.AddShape(text);
        }




        private void guiCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            canvas.MouseMove(sender, e);
        }

        private void guiCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            canvas.MouseDown(sender, e);
        }

        private void guiCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            canvas.MouseUp(sender, e);
        }


        void Application_Idle(object sender, EventArgs e)
        {
            if (canvas.IsDirty)
            {
                guiCanvas.Invalidate();
                canvas.IsDirty = false;
            }
        }

        private void guiCanvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            canvas.Render(e.Graphics);
        }
    }
}