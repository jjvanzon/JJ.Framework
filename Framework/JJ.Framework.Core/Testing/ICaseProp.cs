using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Core.Testing
{
    public interface ICaseProp
    {
        void CloneFrom(ICaseProp obj);
        string Descriptor { get; }
    }
}
