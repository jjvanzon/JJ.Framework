using System.ComponentModel;
using System.Web.Services;
using Puzzle.NCore.Framework.Compression;
using Puzzle.NPersist.Framework.Interfaces;
using Puzzle.NPersist.Framework.Remoting;
using Puzzle.NPersist.Framework.Remoting.Formatting;

namespace Puzzle.NPersist.Framework.Remoting.WebService.Server
{
	[WebService(
		 Description="Provides methods for remoting a persistent domain model with NPersist",
		 Namespace="http://www.npersist.com/remoting")]
	public class RemotingService : System.Web.Services.WebService
	{
		public RemotingService()
		{
			//CODEGEN: This call is required by the ASP.NET Web Services Designer
			InitializeComponent();
		}

		#region Component Designer generated code
		
		//Required by the Web Services Designer 
		private IContainer components = null;
				
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion

		private IContextFactory factory = FactoryServices.CreateContextFactory();
		private IWebServiceCompressor compressor = FactoryServices.CreateWebServiceCompressor();
		private IFormatter formatter = new XmlFormatter();

		[WebMethod(Description="Load the domain map specified in the domainKey parameter")]
		public string GetMap(string domainKey, bool useCompression)
		{
			IRemotingServer rs = new RemotingServer(factory, formatter, compressor, useCompression);
			return rs.GetMap(domainKey);
		}

		[WebMethod(Description="Load an object by identity from the domain specified in the domainKey parameter")]
		public string LoadObject(string type, string identity, string domainKey, bool useCompression)
		{
			IRemotingServer rs = new RemotingServer(factory, formatter, compressor, useCompression);
			return (string) rs.LoadObject(type, identity, domainKey);
		}

		[WebMethod(Description="Load an object by a unique key from the domain specified in the domainKey parameter")]
		public string LoadObjectByKey(string type, string keyPropertyName, string keyValue, string domainKey, bool useCompression)
		{
			return "";						
		}

		[WebMethod(Description="Commit a Unit of Work (Insert, Update and Delete objects) to the domain specified in the domainKey parameter")]
		public string CommitUnitOfWork(string obj, string domainKey, bool useCompression)
		{
			IRemotingServer rs = new RemotingServer(factory, formatter, compressor, useCompression);
			return (string) rs.CommitUnitOfWork(obj, domainKey);
		}

		[WebMethod(Description="Load a lazy loading property from the domain specified in the domainKey parameter")]
		public string LoadProperty(string obj, string propertyName, string domainKey, bool useCompression)
		{
			IRemotingServer rs = new RemotingServer(factory, formatter, compressor, useCompression);
			return (string) rs.LoadProperty(obj, propertyName, domainKey);
		}

		[WebMethod(Description="Load a list of objects by query from the domain specified in the domainKey parameter")]
		public string LoadObjects(string query, string domainKey, bool useCompression)
		{
			IRemotingServer rs = new RemotingServer(factory, formatter, compressor, useCompression);
			return (string) rs.LoadObjects(query, domainKey);					
		}

	}
}
