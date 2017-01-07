namespace JJ.Framework.Exceptions
{
    public class NotEnumException<T> : NotEnumException
    {
        public NotEnumException()
            : base(typeof(T))
        { }
    }
}
