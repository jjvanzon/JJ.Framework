using System.Collections.Generic;
using JJ.Framework.Testing;
using JJ.Framework.VectorGraphics.Enums;
using JJ.Framework.VectorGraphics.Models.Elements;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable RedundantAssignment

namespace JJ.Framework.VectorGraphics.Tests
{
	[TestClass]
	public class VectorGraphicsTests_Positioning
	{
		[TestMethod]
		public void Test_VectorGraphics_CalculationVisitor_RelativeCoordinates()
		{
			int zindex = 1;

			var diagram = new Diagram();

			var point = new Point(diagram.Background)
			{
				ZIndex = zindex++
			};
			point.Position.X = 1;
			point.Position.Y = 2;

			var childPoint1 = new Point(point)
			{
				ZIndex = zindex++
			};
			childPoint1.Position.X = 10;
			childPoint1.Position.Y = 20;

			var childPoint2 = new Point(point)
			{
				ZIndex = zindex++
			};
			childPoint2.Position.X = 12;
			childPoint2.Position.Y = 22;

			var visitor_Accessor = new CalculationVisitor_Accessor();

			IList<Element> elements = visitor_Accessor.Execute(diagram);

			AssertHelper.AreEqual(4, () => elements.Count);
			AssertHelper.AreEqual(1, () => elements[1].CalculatedValues.XInPixels);
			AssertHelper.AreEqual(2, () => elements[1].CalculatedValues.YInPixels);
			AssertHelper.AreEqual(11, () => elements[2].CalculatedValues.XInPixels);
			AssertHelper.AreEqual(22, () => elements[2].CalculatedValues.YInPixels);
			AssertHelper.AreEqual(13, () => elements[3].CalculatedValues.XInPixels);
			AssertHelper.AreEqual(24, () => elements[3].CalculatedValues.YInPixels);
		}

		[TestMethod]
		public void Test_VectorGraphics_ElementPosition_CenterY()
		{
			var diagram = new Diagram();

			var parent = new Rectangle(diagram.Background);
			parent.Position.X = 0;
			parent.Position.Y = 2;
			parent.Position.Width = 0;
			parent.Position.Height = 8;

			var child = new Rectangle(parent);
			child.Position.X = 0;
			child.Position.Y = -3;
			child.Position.Width = 0;
			child.Position.Height = 7;

			// Test getter
			AssertHelper.AreEqual(0.5f, () => child.Position.CenterY);

			// Test setter
			child.Position.CenterY = child.Position.CenterY;
			AssertHelper.AreEqual(0.5f, () => child.Position.CenterY);
		}

		[TestMethod]
		public void Test_VectorGraphics_ScaleModeEnum_ViewPort()
		{
			// A diagram of 4x8 with a child of 2x4 in the middle with a center that is (0, 0)
			// and pixel values that are 10 times the scaled coordinates.
			var diagram = new Diagram();
			diagram.Position.WidthInPixels = 40;
			diagram.Position.HeightInPixels = 80;
			diagram.Position.ScaleModeEnum = ScaleModeEnum.ViewPort;
			diagram.Position.ScaledX = -2;
			diagram.Position.ScaledY = -4;
			diagram.Position.ScaledWidth = 4;
			diagram.Position.ScaledHeight = 8;

			var child = new Rectangle(diagram.Background);

			child.Position.X = 1;
			child.Position.Y = 2;
			child.Position.Width = 2;
			child.Position.Height = 4;

			diagram.Recalculate();

			// ReSharper disable once JoinDeclarationAndInitializer
			float expectedRelative;
			// ReSharper disable once JoinDeclarationAndInitializer
			float expectedAbsolute;
			// ReSharper disable once JoinDeclarationAndInitializer
			float expectedPixels;

			// ReSharper disable once JoinDeclarationAndInitializer
			float actualRelative;
			// ReSharper disable once JoinDeclarationAndInitializer
			float actualAbsolute;
			// ReSharper disable once JoinDeclarationAndInitializer
			float actualPixels;

			expectedRelative = 0.75f;
			expectedAbsolute = -0.25f;
			expectedPixels = 17.5f;

			actualAbsolute = diagram.Position.PixelsToX(expectedPixels);
			Assert.AreEqual(expectedAbsolute, actualAbsolute);

			actualPixels = diagram.Position.XToPixels(expectedAbsolute);
			Assert.AreEqual(expectedPixels, actualPixels);

			actualAbsolute = child.Position.RelativeToAbsoluteX(expectedRelative);
			Assert.AreEqual(expectedAbsolute, actualAbsolute);

			actualRelative = child.Position.AbsoluteToRelativeX(expectedAbsolute);
			Assert.AreEqual(expectedRelative, actualRelative);

			actualRelative = child.Position.PixelsToRelativeX(expectedPixels);
			Assert.AreEqual(expectedRelative, actualRelative);

			actualPixels = child.Position.RelativeToPixelsX(expectedRelative);
			Assert.AreEqual(expectedPixels, actualPixels);

			actualAbsolute = child.Position.PixelsToAbsoluteX(expectedPixels);
			Assert.AreEqual(expectedAbsolute, actualAbsolute);

			actualPixels = child.Position.AbsoluteToPixelsX(expectedAbsolute);
			Assert.AreEqual(expectedPixels, actualPixels);

			// Copy-paste-changed code for the Y axis
			expectedRelative = 0.75f * 2;
			expectedAbsolute = -0.25f * 2;
			expectedPixels = 17.5f * 2;

			actualAbsolute = diagram.Position.PixelsToY(expectedPixels);
			Assert.AreEqual(expectedAbsolute, actualAbsolute);

			actualPixels = diagram.Position.YToPixels(expectedAbsolute);
			Assert.AreEqual(expectedPixels, actualPixels);

			actualAbsolute = child.Position.RelativeToAbsoluteY(expectedRelative);
			Assert.AreEqual(expectedAbsolute, actualAbsolute);

			actualRelative = child.Position.AbsoluteToRelativeY(expectedAbsolute);
			Assert.AreEqual(expectedRelative, actualRelative);

			actualRelative = child.Position.PixelsToRelativeY(expectedPixels);
			Assert.AreEqual(expectedRelative, actualRelative);

			actualPixels = child.Position.RelativeToPixelsY(expectedRelative);
			Assert.AreEqual(expectedPixels, actualPixels);

			actualAbsolute = child.Position.PixelsToAbsoluteY(expectedPixels);
			Assert.AreEqual(expectedAbsolute, actualAbsolute);

			actualPixels = child.Position.AbsoluteToPixelsY(expectedAbsolute);
			Assert.AreEqual(expectedPixels, actualPixels);

			// Test Properties
			Assert.AreEqual(10, child.Position.XInPixels);
			Assert.AreEqual(-1, child.Position.AbsoluteX);

			Assert.AreEqual(20, child.Position.YInPixels);
			Assert.AreEqual(-2, child.Position.AbsoluteY);

			// Test Width and Height conversions
			Assert.AreEqual(20, diagram.Position.WidthToPixels(2));
			Assert.AreEqual(20, diagram.Position.HeightToPixels(2));

			Assert.AreEqual(2, diagram.Position.PixelsToWidth(20));
			Assert.AreEqual(2, diagram.Position.PixelsToHeight(20));
		}
	}
}