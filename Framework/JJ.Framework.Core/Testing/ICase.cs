using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Core.Testing
{
    public interface ICase : ICaseProp
    {
        string             Name        { get; set; }
        string             Key         { get; }
        object[]           DynamicData { get; }
        bool               Strict      { get; set; }
        ICaseProp          MainProp    { get; }
        IList<ICaseProp>   Props       { get; }
        IList<object>      KeyElements { get; }
        /// <inheritdoc cref="docs._casetemplate" />
        ICollection<ICase> FromTemplate(ICollection<ICase> cases);
    }
}