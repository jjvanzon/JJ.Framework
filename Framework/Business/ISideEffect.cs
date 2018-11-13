namespace JJ.Framework.Business
{
    /// <summary>
    /// Used for some polymorphism between small pieces of business logic that go off as a result of altering or creating data.
    /// For instance storing the date time modified or setting default values
    /// or automatically generating a name might all be wrapped in side-effects,
    /// that are executed upon calling methods, like Create, Update and Delete.
    /// Using a separate class for side-effects, creates overview over those pieces of business logic,
    /// that are the most creative of all, and prevents those special things that need to happen from being entangled with other code.
    /// </summary>
	public interface ISideEffect
	{
		void Execute();
	}
}
