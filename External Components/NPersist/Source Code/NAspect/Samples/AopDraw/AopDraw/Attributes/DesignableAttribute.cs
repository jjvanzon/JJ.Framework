using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace AopDraw.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DesignableAttribute : Attribute
    {
       

        #region Property BorderSize 
        private float borderSize = 1;
        public float BorderSize
        {
            get
            {
                return this.borderSize;
            }
            set
            {
                this.borderSize = value;
            }
        }                        
        #endregion

        #region Property BorderColor 
        private Color borderColor = Color.Black;
        public Color BorderColor
        {
            get
            {
                return this.borderColor;
            }
            set
            {
                this.borderColor = value;
            }
        }                        
        #endregion

        #region Property FillColor 
        private Color fillColor = Color.WhiteSmoke;
        public Color FillColor
        {
            get
            {
                return this.fillColor;
            }
            set
            {
                this.fillColor = value;
            }
        }                        
        #endregion

        public DesignableAttribute()
        {
        }

        public DesignableAttribute(string borderColorHex,float borderSize,string fillColorHex)
        {
            this.borderColor = System.Drawing.ColorTranslator.FromHtml(borderColorHex);
            this.borderSize = borderSize;
            this.fillColor = System.Drawing.ColorTranslator.FromHtml(fillColorHex);
        }
    }
}
