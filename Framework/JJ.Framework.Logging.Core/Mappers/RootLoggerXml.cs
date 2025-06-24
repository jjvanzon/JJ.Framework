namespace JJ.Framework.Logging.Core.Mappers
{
    public class RootLoggerXml : LoggerXml
    {
        [XmlArrayItem("log")]
        public IList<LoggerXml> Logs { get; set; } = [ ];
    }
}
