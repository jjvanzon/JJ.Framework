using JJ.Framework.Presentation.Svg.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SvgElements = JJ.Framework.Presentation.Svg.Models.Elements;
using SvgStyling = JJ.Framework.Presentation.Svg.Models.Styling;

namespace JJ.Framework.Presentation.WinForms.TestForms
{
    public partial class HelloWorldTestForm : Form
    {
        SvgElements.Rectangle _rootSvgRectangle;

        public HelloWorldTestForm()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            Text = this.GetType().FullName;

            _rootSvgRectangle = new SvgElements.Rectangle
            {
                Children = new SvgElements.ElementBase[]
                {
                    new SvgElements.Label
                    { 
                        Text = "Hello World!",
                        Rectangle = new SvgElements.Rectangle 
                        { 
                            X = 10,
                            Y = 20,
                            Width = 500,
                            Height = 100
                        }
                    }
                }
            };
        }

        private void HelloWorldTestForm_Paint(object sender, PaintEventArgs e)
        {
            _rootSvgRectangle.Width = this.ClientSize.Width;
            _rootSvgRectangle.Height = this.ClientSize.Height;

            diagramControl1.Draw(_rootSvgRectangle);
        }
    }
}
