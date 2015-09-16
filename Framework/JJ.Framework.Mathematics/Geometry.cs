namespace JJ.Framework.Mathematics
{
    public static class Geometry
    {
        public static bool IsInRectangle(float x, float y, float x1, float y1, float x2, float y2)
        {
            return x >= x1 && x <= x2 &&
                   y >= y1 && y <= y2;
        }

        public static bool IsInRectangle(double x, double y, double x1, double y1, double x2, double y2)
        {
            return x >= x1 && x <= x2 &&
                   y >= y1 && y <= y2;
        }

        public static void GetCenter(double x1, double y1, double x2, double y2, out double x, out double y)
        {
            x = (x1 + x2) / 2.0;
            y = (y1 + y2) / 2.0;
        }

        public static void GetCenter(float x1, float y1, float x2, float y2, out float x, out float y)
        {
            x = (x1 + x2) / 2f;
            y = (y1 + y2) / 2f;
        }

        public static void GetCenter_ByWidthAndHeight(double left, double top, double width, double height, out double x, out double y)
        {
            x = left + width / 2.0;
            y = top + height / 2.0;
        }

        public static void GetCenter_ByWidthAndHeight(float left, float top, float width, float height, out float x, out float y)
        {
            x = left + width / 2f;
            y = top + height / 2f;
        }
    }
}
