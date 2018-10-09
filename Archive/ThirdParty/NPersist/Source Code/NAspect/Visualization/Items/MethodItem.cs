using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Puzzle.NAspect.Framework.Utils;

namespace Puzzle.NAspect.Visualization.Items
{
    public class MethodItem : ItemBase
    {
        public MethodItem(MethodBase method)
            : base(AopTools.GetMethodSignature(method))
        {
            this.method = method;

            this.ImageIndex = 2;

            this.SubItems.Add(method.DeclaringType.FullName);
            this.SubItems.Add(method.DeclaringType.Assembly.GetName().Name);
        }

        private MethodBase method;
        public virtual MethodBase Method
        {
            get { return method; }
            set { method = value; }
        }
	

        public override object Object
        {
            get
            {
                return this.method; ;
            }
        }
    }
}
