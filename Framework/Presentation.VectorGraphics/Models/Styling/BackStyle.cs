using JJ.Framework.Presentation.VectorGraphics.Helpers;

namespace JJ.Framework.Presentation.VectorGraphics.Models.Styling
{
    public class BackStyle
    {
        public BackStyle()
        {
            Visible = true;
            Color = ColorHelper.White;
        }

        public bool Visible { get; set; }
        public int Color { get; set; }
    }
}
