using JJ.Framework.Presentation.Svg.Enums;
using JJ.Framework.Presentation.Svg.Models;
using JJ.Framework.Presentation.Svg.Models.Styling;
using JJ.Framework.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SvgElements = JJ.Framework.Presentation.Svg.Models.Elements;

namespace JJ.Framework.Presentation.WinForms.TestForms
{
    public partial class HierarchyTestForm : Form
    {
        SvgElements.Container _svgModel;

        public HierarchyTestForm()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            Text = this.GetType().FullName;

            _svgModel = new SvgElements.Container
            {
                ChildRectangles = new SvgElements.Rectangle[]
                {
                    //CreateRectangle(200, 10, "Block 1")
                    new SvgElements.Rectangle
                    {
                        X = 200,
                        Y = 10,
                        Width = 300,
                        Height = 60,
                        ChildLabels = new SvgElements.Label[]
                        {
                            new SvgElements.Label
                            {
                                Rectangle = new SvgElements.Rectangle { Width = 300, Height = 60 },
                                Text = "Block 1",
                                TextStyle = SvgHelper.DefaultTextStyle
                            }
                        }
                    },
                    new SvgElements.Rectangle
                    {
                        X = 10,
                        Y = 200,
                        Width = 300,
                        Height = 60,
                        ChildLabels = new SvgElements.Label[]
                        {
                            new SvgElements.Label
                            {
                                Rectangle = new SvgElements.Rectangle { Width = 300, Height = 60 },
                                Text = "Block 2",
                                TextStyle = SvgHelper.DefaultTextStyle
                            }
                        }
                    }
                }
            };

            _svgModel.ChildRectangles.ForEach(x => x.SetLineStyle(SvgHelper.DefaultLineStyle));
        }

        private void HierarchyTestForm_Paint(object sender, PaintEventArgs e)
        {
            diagramControl1.Draw(_svgModel);
        }

        private SvgElements.Rectangle CreateRectangle(float x, float y, string text)
        {
            var rectangle = new SvgElements.Rectangle
            {
                X = x,
                Y = y,
                Width = 300,
                Height = 60,
                ChildLabels = new SvgElements.Label[]
                {
                    new SvgElements.Label
                    {
                        Rectangle = new SvgElements.Rectangle { Width = 300, Height = 60 },
                        Text = text,
                        TextStyle = SvgHelper.DefaultTextStyle
                    }
                }
            };

            rectangle.SetLineStyle(SvgHelper.DefaultLineStyle);

            return rectangle;
        }
    }
}
