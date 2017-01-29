namespace NHibernate.Transaction
{
	/// <summary>
	/// A mimic to the javax.transaction.Synchronization callback to enable <see cref="ITransaction.RegisterSynchronization"/> 
	/// </summary>
	public interface ISynchronization
	{
		void BeforeCompletion();
		void AfterCompletion(bool success);
	}
}
