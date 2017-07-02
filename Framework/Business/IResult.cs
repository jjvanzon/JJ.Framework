namespace JJ.Framework.Business
{
    public interface IResult
    {
        bool Successful { get; set; }

        /// <summary> not nullable, auto-instantiated </summary>
        Messages Messages { get; set; }
    }
}
