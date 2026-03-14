using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Validation.Legacy
{
    /// <inheritdoc cref="_ivalidator" />
    public interface IValidator
    {
        /// <inheritdoc cref="_validationmessages" />
        ValidationMessages ValidationMessages { get; }
        /// <inheritdoc cref="_isvalid" />
        bool IsValid { get; }
        /// <inheritdoc cref="_verify" />
        void Verify();
    }
}
