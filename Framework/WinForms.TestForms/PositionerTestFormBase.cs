using System;
using System.Collections.Generic;
using System.Windows.Forms;
using JJ.Framework.Mathematics;
using JJ.Framework.VectorGraphics.Helpers;
using JJ.Framework.VectorGraphics.Models.Elements;
using JJ.Framework.VectorGraphics.Models.Styling;
using JJ.Framework.VectorGraphics.Positioners;
using Rectangle = JJ.Framework.VectorGraphics.Models.Elements.Rectangle;

namespace JJ.Framework.WinForms.TestForms
{
	public partial class PositionerTestFormBase : Form
	{
		private const float ROW_HEIGHT = 24;
		private const float SPACING = 4;
		private const float LARGE_SPACING = 8;
		private readonly IList<float> _itemWidths;

		private const int MIN_ITEM_COUNT = 7;
		private const int MAX_ITEM_COUNT = 20;
		private const float MIN_ITEM_WIDTH = 8;
		private const float MAX_ITEM_WIDTH = 120;

		private readonly int _itemCount;
		private readonly Rectangle _frameRectangle;
		private readonly IList<Rectangle> _rectangles;

		public PositionerTestFormBase()
		{
			_itemCount = Randomizer.GetInt32(MIN_ITEM_COUNT, MAX_ITEM_COUNT);
			_itemWidths = GenerateItemWidths(_itemCount);
			_rectangles = new List<Rectangle>(_itemCount);

			var diagram = new Diagram();

			_frameRectangle = new Rectangle(diagram.Background);
			_frameRectangle.Style.BackStyle.Color = ColorHelper.SetOpacity(ColorHelper.Black, 48);
			_frameRectangle.Position.X = LARGE_SPACING;
			_frameRectangle.Position.Y = LARGE_SPACING;

			var rectangleBackStyle = new BackStyle
			{
				Color = ColorHelper.SetOpacity(ColorHelper.Black, 128)
			};

			for (int i = 0; i < _itemCount; i++)
			{
				var rectangle = new Rectangle(_frameRectangle);
				rectangle.Style.BackStyle = rectangleBackStyle;
				_rectangles.Add(rectangle);
			}

			InitializeComponent();

			diagramControl.Diagram = diagram;
			diagramControl.Left = 0;
			diagramControl.Top = 0;
			
			PositionControls();
		}

		private void PositionControls()
		{
			diagramControl.Width = ClientSize.Width;
			diagramControl.Height = ClientSize.Height;

			_frameRectangle.Position.Width = ClientSize.Width - LARGE_SPACING * 2;
			_frameRectangle.Position.Height = ClientSize.Height - LARGE_SPACING * 2;

			IPositioner positioner = CreatePositioner(_frameRectangle.Position.Width, ROW_HEIGHT, SPACING, _itemWidths);
			positioner.Calculate(_rectangles);
		}

		protected virtual IPositioner CreatePositioner(float rowWidth, float rowHeight, float spacing, IList<float> itemWidths) => throw new NotImplementedException();

		private IList<float> GenerateItemWidths(int itemCount)
		{
			var itemWidths = new float[itemCount];

			for (int i = 0; i < itemCount; i++)
			{
				float itemWidth = Randomizer.GetSingle(MIN_ITEM_WIDTH, MAX_ITEM_WIDTH);
				itemWidths[i] = itemWidth;
			}

			return itemWidths;
		}

		private void Base_Resize(object sender, EventArgs e) => PositionControls();
		private void Base_SizeChanged(object sender, EventArgs e) => PositionControls();
	}
}
