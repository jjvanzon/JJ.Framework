using System.Collections.Generic;

namespace JJ.Framework.Business
{
    public interface IResult
    {
        bool Successful { get; }
        Messages Messages { get; }
    }
}
