namespace JJ.Framework.Logging.Core.Loggers
{
    public interface ILogger
    {
        bool WillLog(string category);
        void Log(string message);
        void Log(string category, string message);
        void LogRaw(string message);
        void LogRaw(string category, string message);

        IList<string> GetCategories();
        void SetCategories(params string[] categories);
        void SetCategories(ICollection<string> categories);
        void AddCategories(params string[] categories);
        void AddCategories(ICollection<string> categories);
        void RemoveCategories(params string[] categories);
        void RemoveCategories(ICollection<string> categories);
        void ClearCategories();
        
        string Format { get; set; } 
    }
}
