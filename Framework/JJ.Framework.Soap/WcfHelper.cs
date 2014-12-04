using JJ.Framework.Xml.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Soap
{
    public static class WcfHelper
    {
        private static SoapFormatter _soapFormatter;

        static WcfHelper()
        {
            _soapFormatter = new SoapFormatter(customArrayItemNameMappings: GetCustomArrayItemNameMappings());
        }

        public static string GetStringToSend(string operationName, SoapParameter[] parameters)
        {
            return _soapFormatter.GetStringToSend(operationName, parameters);
        }

        public static TResult ParseStringReceived<TResult>(string operationName, string data)
            where TResult : class, new()
        {
            return _soapFormatter.ParseStringReceived<TResult>(operationName, data);
        }

        internal static IEnumerable<CustomArrayItemNameMapping> GetCustomArrayItemNameMappings()
        {
            return new CustomArrayItemNameMapping[]
            {
                new CustomArrayItemNameMapping(typeof(bool), "boolean"),
                new CustomArrayItemNameMapping(typeof(char), "char"),
                new CustomArrayItemNameMapping(typeof(DateTime), "dateTime"),
                new CustomArrayItemNameMapping(typeof(double), "double"),
                new CustomArrayItemNameMapping(typeof(Guid), "guid"),
                new CustomArrayItemNameMapping(typeof(short), "short"),
                new CustomArrayItemNameMapping(typeof(int), "int"),
                new CustomArrayItemNameMapping(typeof(long), "long"),
                new CustomArrayItemNameMapping(typeof(SByte), "byte"),
                new CustomArrayItemNameMapping(typeof(float), "float"),
                new CustomArrayItemNameMapping(typeof(string), "string"),
                new CustomArrayItemNameMapping(typeof(TimeSpan), "duration"),
                new CustomArrayItemNameMapping(typeof(UInt16), "unsignedShort"),
                new CustomArrayItemNameMapping(typeof(UInt32), "unsignedInt"),
                new CustomArrayItemNameMapping(typeof(UInt64), "unsignedLong")
            };
        }
    }
}
