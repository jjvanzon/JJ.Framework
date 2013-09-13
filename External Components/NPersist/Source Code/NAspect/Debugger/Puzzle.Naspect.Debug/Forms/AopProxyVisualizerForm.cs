using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Puzzle.NAspect.Debug.Serialization;
using Puzzle.NAspect.Debug.Serialization.Elements;
using System.Drawing.Drawing2D;

namespace Puzzle.NAspect.Debug.Forms
{
    public partial class AopProxyVisualizerForm : Form
    {
        #region Property Proxy
        private SerializedProxy proxy;
        public virtual SerializedProxy Proxy
        {
            get
            {
                return this.proxy;
            }
            set
            {
                this.proxy = value;
            }
        }
        #endregion

        public AopProxyVisualizerForm()
        {
            InitializeComponent();
        }

        private void AopProxyVisualizerForm_Load(object sender, EventArgs e)
        {
            SetupData();
        }

        private void SetupData()
        {
            lblTypeName.Text = proxy.ProxyType.Name;
            foreach (VizMethodBase method in Proxy.ProxyType.Methods)
            {
                lstMethods.Items.Add(method);
            }
            lstMethods.SelectedIndex = 0;
        }

        private void lstMethods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMethods.SelectedIndex == -1)
                return;

            VizMethodBase vizMethod = (VizMethodBase)lstMethods.SelectedItem;
            
            SelectMethod(vizMethod);
        }

        private void SelectMethod(VizMethodBase vizMethod)
        {
            

            int height = 230 + 70 * vizMethod.Interceptors.Count;
            foreach (VizInterceptor vizInterceptor in vizMethod.Interceptors)
            {
                height += vizInterceptor.ThrowsExceptionTypes.Count * 15;
            }
            Bitmap bmp = new Bitmap(800,height );
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle consumerBounds = new Rectangle(30, 30, 450, 30);      
            Rectangle bg = consumerBounds;
            bg.Inflate(30, 20);
            g.FillRectangle(Brushes.LightYellow, bg);

            Pen pen = new Pen (Brushes.Silver,5f);
            pen.EndCap = LineCap.ArrowAnchor;



            int bottom = height-70;
            g.DrawLine(pen, 100, 70, 100, bottom);
            g.DrawLine(pen, 410, bottom, 410, 70);

            DrawConsumer(vizMethod, g);

            DrawProxy(vizMethod, g);

            int y = 170;
            foreach (VizInterceptor vizInterceptor in vizMethod.Interceptors)
            {
                DrawInterceptor(vizInterceptor, g, y);
                y += 70;
                y += vizInterceptor.ThrowsExceptionTypes.Count * 15;
            }

            DrawBase(vizMethod, g,y);

            picInterceptors.Image = bmp;
            g.Dispose();
        }

        private void DrawBase(VizMethodBase vizMethod, Graphics g,int y)
        {
            Rectangle consumerBounds = new Rectangle(30, 00 + y, 450, 30);
            DrawBox(consumerBounds, g, Color.White, Color.FromArgb(255, 230, 210));
            DrawStringBold(consumerBounds.X + 30, consumerBounds.Y + 3, "Provider [Aop Target]", g);
            DrawString(consumerBounds.X + 30, consumerBounds.Y + 15, vizMethod.GetRealText(), g);
        }

        private void DrawInterceptor(VizInterceptor vizInterceptor, Graphics g, int y)
        {
            Rectangle consumerBounds = new Rectangle(30, y, 450, 30);

            

            if (vizInterceptor.InterceptorType == VizInterceptorType.After)
            {
                consumerBounds = new Rectangle(130, y, 350, 30);
                
            }
            else if (vizInterceptor.InterceptorType == VizInterceptorType.Around)
            {
            }
            else if (vizInterceptor.InterceptorType == VizInterceptorType.Before)
            {
                consumerBounds = new Rectangle(30, y, 350, 30);
            }

            if (vizInterceptor.ThrowsExceptionTypes.Count > 0)
            {
                Pen pen = new Pen(Brushes.Red, 1);
                int y2 = consumerBounds.Y + 15;

                for (int x = consumerBounds.X - 25; x < 350 + 130 + 25; x += 20)
                {
                    g.DrawLine(pen, x, y2, x + 10, y2 + 5);
                    g.DrawLine(pen, x + 10, y2 + 5, x + 20, y2);
                }

                Rectangle exceptionBounds = new Rectangle(350 + 130 + 25 + 5, y2-5, 200, vizInterceptor.ThrowsExceptionTypes.Count * 15 + 5);
                DrawBox(exceptionBounds, g, Color.White, Color.LightYellow);

                foreach (string exception in vizInterceptor.ThrowsExceptionTypes)
                {

                    DrawString(350 + 130 + 25 +10 , y2 -3 , string.Format("May throw {0}", exception), g);
                    y2 += 15;
                }
            }

            DrawBox(consumerBounds, g, Color.White, Color.FromArgb(230, 210, 255));

            DrawStringBold(consumerBounds.X + 30, consumerBounds.Y + 3, string.Format ("{0} interceptor",vizInterceptor.InterceptorType), g);
            DrawString(consumerBounds.X + 30, consumerBounds.Y + 15, string.Format ("{0} : from aspect {1}",vizInterceptor.Name,"xxx"), g);

            

            if (vizInterceptor.MayBreakFlow)
            {
                Pen pen = new Pen(Brushes.Silver, 3f);
                pen.EndCap = LineCap.ArrowAnchor;
                pen.DashStyle = DashStyle.Dash;
                g.DrawLine(pen, consumerBounds.X+80, consumerBounds.Y + 43, consumerBounds.Right-80, consumerBounds.Y + 43);
                DrawString(consumerBounds.X + 90, consumerBounds.Y + 45, "May break flow", g);
            }

            
        }

        private void DrawProxy(VizMethodBase vizMethod, Graphics g)
        {
            Rectangle consumerBounds = new Rectangle(30, 30 + 70, 450, 30);
            DrawBox(consumerBounds, g, Color.White, Color.FromArgb(255, 210, 230));
            DrawStringBold(consumerBounds.X + 30, consumerBounds.Y + 3, "Aop Proxy [Debugger hidden]", g);
            DrawString(consumerBounds.X + 30, consumerBounds.Y + 15, vizMethod.GetProxyText(), g);
        }

        private void DrawConsumer(VizMethodBase vizMethod, Graphics g)
        {
            Rectangle consumerBounds = new Rectangle(30, 30, 450, 30);            
            DrawBox(consumerBounds, g, Color.White, Color.FromArgb(210, 255, 230));
            DrawStringBold(consumerBounds.X + 30, consumerBounds.Y + 3, "Your consumer code", g);
            DrawString(consumerBounds.X + 30, consumerBounds.Y + 15, vizMethod.GetCallSample(), g);
        }

        private void DrawString(int x, int y, string text, Graphics g)
        {
            Font f = new Font ("Verdana",7f,FontStyle.Regular);
            g.DrawString(text, f, Brushes.Black, x, y);
        }

        private void DrawStringBold(int x, int y, string text, Graphics g)
        {
            Font f = new Font("Verdana", 7f, FontStyle.Bold);
            g.DrawString(text, f, Brushes.Black, x, y);
        }

        private void DrawBox(Rectangle bounds, Graphics g, Color startColor, Color endColor)
        {
            Rectangle shadow = bounds;
            shadow.Offset (3,3);
            g.FillRectangle(Brushes.LightGray, shadow);
            LinearGradientBrush bgbrush = new LinearGradientBrush(bounds, startColor, endColor, 0, false);
            g.FillRectangle(bgbrush, bounds);
            g.DrawRectangle(Pens.DarkGray, bounds);
        }

        private void lstMethods_DrawItem(object sender, DrawItemEventArgs e)
        {
            bool selected = (e.State & DrawItemState.Selected) != 0;
            if (selected)
            {
                Color c1 = SystemColors.ActiveCaption;
                Color c2 = Color.White;
                Color bgColor = Tools.MixColors(c1, c2);
                bgColor = Tools.MixColors(bgColor, c2);
                SolidBrush bgBrush = new SolidBrush(bgColor);
                e.Graphics.FillRectangle(bgBrush, e.Bounds);
                Rectangle borderBounds = e.Bounds;
                borderBounds.Width--;
                borderBounds.Height--;
                e.Graphics.DrawRectangle(SystemPens.ActiveCaption, borderBounds);
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);
            }
            

            if (e.Index < 0)
                return;

            


            VizMethodBase method = (VizMethodBase)lstMethods.Items[e.Index];

            if (method is VizConstructor)
            {
                VizConstructor ctor = (VizConstructor)method;
                imlIcons.Draw(e.Graphics, 3, e.Bounds.Y + 2, 1);
                string text = string.Format("ctor: {0} ({1})", ctor.OwnerType.Name, ctor.GetParamTypes ());
                e.Graphics.DrawString(text, lstMethods.Font, Brushes.Black, 25, e.Bounds.Y + 3);

            }

            Brush fgBrush = Brushes.Black;

            if (method is VizMethod)
            {
                if (method.Name.StartsWith("get_"))
                {
                    imlIcons.Draw(e.Graphics, 3, e.Bounds.Y + 3, 2);
                    string text = string.Format("getter: {0}", method.Name.Substring(4));
                    e.Graphics.DrawString(text,lstMethods.Font,Brushes.Black,25,e.Bounds.Y+3);
                }
                else if (method.Name.StartsWith("set_"))
                {
                    imlIcons.Draw(e.Graphics, 3, e.Bounds.Y + 3, 2);
                    string text = string.Format("setter: {0}", method.Name.Substring(4));
                    e.Graphics.DrawString(text, lstMethods.Font, Brushes.Black, 25, e.Bounds.Y + 3);
                }
                else
                {
                    VizMethod meth = (VizMethod)method;
                    imlIcons.Draw(e.Graphics, 3, e.Bounds.Y + 2, 0);
                    string text = string.Format("{0} {1} ({2})", meth.ReturnType,meth.Name,meth.GetParamTypes ());
                    e.Graphics.DrawString(text, lstMethods.Font, Brushes.Black, 25, e.Bounds.Y + 3);
                }
            }

        }
    }
}