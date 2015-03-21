//using JJ.Framework.Presentation.Svg.Models.Styling;
//using JJ.Framework.Reflection;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace JJ.Framework.Presentation.Svg.Models.Elements
//{
//    public class Container : ElementBase
//    {
//        // TODO: Return something other than 0 for the Center coordinates?

//        public override float X
//        {
//            get { return 0; }
//            set { throw new NotSupportedException(); }
//        }

//        public override float Y
//        {
//            get { return 0; }
//            set { throw new NotSupportedException(); }
//        }

//        private BackStyle _backStyle = new BackStyle();
//        /// <summary> not nullable, auto-instantiated </summary>
//        public BackStyle BackStyle
//        {
//            get { return _backStyle; }
//            set
//            {
//                if (value == null) throw new NullException(() => value);
//                _backStyle = value;
//            }
//        }
//    }
//}
