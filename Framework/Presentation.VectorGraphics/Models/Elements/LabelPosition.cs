namespace JJ.Framework.Presentation.VectorGraphics.Models.Elements
{
    public class LabelPosition : ElementPosition
    {
        internal LabelPosition(Label point)
            : base(point)
        { }

        public override float X { get; set; }
        public override float Y { get; set; }

        public override float Width { get; set; }
        public override float Height { get; set; }
    }
}
