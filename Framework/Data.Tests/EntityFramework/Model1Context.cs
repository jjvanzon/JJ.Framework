using System.Data.Entity;

namespace JJ.Framework.Data.Tests.EntityFramework5
{
	public class Model1Context : DbContext
	{
		public Model1Context(string specialConnectionString)
			: base(specialConnectionString)
		{ }
	}
}
