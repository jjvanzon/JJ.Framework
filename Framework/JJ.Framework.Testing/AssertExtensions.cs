using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Testing
{
    // TODO: Come up with a name that does not suggest that these are extension methods.
    public static class AssertExtensions
    {
        public static void ThrowsException(Action action)
        {
            if (action == null) throw new ArgumentNullException("action");

            try
            {
                action();
            }
            catch
            {
                return;
            }

            throw new Exception("An exception should have been thrown.");
        }
    }
}
