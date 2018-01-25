//using System.Diagnostics;
//using JJ.Framework.Exceptions;
//using JJ.Framework.Presentation.VectorGraphics.Enums;
//using JJ.Framework.Presentation.VectorGraphics.Helpers;

//namespace JJ.Framework.Presentation.VectorGraphics.Models.Styling
//{
//	public class TextStyle
//	{
//		public int Color { get; set; } = ColorHelper.Black;
//		public AbbreviationMode Abbreviate { get; set; } = AbbreviationMode.Ellipsis;
//		public bool Wrap { get; set; }
//		public HorizontalAlignmentEnum HorizontalAlignmentEnum { get; set; } = HorizontalAlignmentEnum.Left;
//		public VerticalAlignmentEnum VerticalAlignmentEnum { get; set; } = VerticalAlignmentEnum.Top;

//		private Font _font = new Font();
//		/// <summary> not nullable, auto-instantiated </summary>
//		public Font Font
//		{
//			[DebuggerHidden]
//			get { return _font; }
//			set
//			{
//				_font = value ?? throw new NullException(() => value);
//			}
//		}
//	}
//}
