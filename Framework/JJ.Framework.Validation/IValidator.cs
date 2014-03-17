using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Validation
{
    public interface IValidator
    {
        ValidationMessages ValidationMessages { get; }
        bool IsValid { get; }
        void Verify();
    }
}
