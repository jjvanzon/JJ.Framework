using JJ.Framework.Presentation.Svg.Enums;
using JJ.Framework.Presentation.Svg.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SvgModel = JJ.Framework.Presentation.Svg.Models;

namespace JJ.Framework.Presentation.WinForms.TestForms
{
    public partial class HierarchyTestForm : Form
    {
        ElementBase _svgModel;

        public HierarchyTestForm()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            Text = this.GetType().FullName;

            _svgModel = new SvgModel.Container
            {
                ChildRectangles = new SvgModel.Rectangle[]
                {
                    new SvgModel.Rectangle
                    {
                        X = 200,
                        Y = 10,
                        Width = 300,
                        Height = 60,
                        ChildLabels = new SvgModel.Label[]
                        {
                            new SvgModel.Label
                            {
                                Rectangle = new Rectangle { X = -150, Y = -30, Width = 300, Height = 60 },
                                Text = "Block 1",
                                HorizontalAlignment = HorizontalAlignmentEnum.Center,
                                VerticalAlignment = VerticalAlignmentEnum.Center
                            }
                        }
                    },
                    new SvgModel.Rectangle
                    {
                        X = 10,
                        Y = 200,
                        Width = 300,
                        Height = 60,
                        ChildLabels = new SvgModel.Label[]
                        {
                            new SvgModel.Label
                            {
                                Rectangle = new Rectangle { X = -150, Y = -30, Width = 300, Height = 60 },
                                Text = "Block 2",
                                HorizontalAlignment = HorizontalAlignmentEnum.Center,
                                VerticalAlignment = VerticalAlignmentEnum.Center
                            }
                        }
                    }
                }
            };
        }

        private void TestForm_Resize(object sender, EventArgs e)
        {
            //diagramControl1.Draw(_svgModel);
        }

        private void TestForm_Shown(object sender, EventArgs e)
        {
            //diagramControl1.Draw(_svgModel);
        }

        private void HierarchyTestForm_Paint(object sender, PaintEventArgs e)
        {
            diagramControl1.Draw(_svgModel);
        }
    }
}
