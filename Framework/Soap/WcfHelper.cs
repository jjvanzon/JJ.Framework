using System;
using System.Collections.Generic;
using JJ.Framework.Xml.Linq;

namespace JJ.Framework.Soap
{
    public static class WcfHelper
    {
        private static readonly SoapFormatter _soapFormatter;

        static WcfHelper() => _soapFormatter = new SoapFormatter(customArrayItemNameMappings: GetCustomArrayItemNameMappings());

        public static string GetStringToSend(string operationName, SoapParameter[] parameters)
            => _soapFormatter.GetStringToSend(operationName, parameters);

        public static TResult ParseStringReceived<TResult>(string operationName, string data)
            where TResult : class, new()
            => _soapFormatter.ParseStringReceived<TResult>(operationName, data);

        internal static IEnumerable<CustomArrayItemNameMapping> GetCustomArrayItemNameMappings()
            => new[]
            {
                new CustomArrayItemNameMapping(typeof(bool), "boolean"),
                new CustomArrayItemNameMapping(typeof(char), "char"),
                new CustomArrayItemNameMapping(typeof(DateTime), "dateTime"),
                new CustomArrayItemNameMapping(typeof(double), "double"),
                new CustomArrayItemNameMapping(typeof(Guid), "guid"),
                new CustomArrayItemNameMapping(typeof(short), "short"),
                new CustomArrayItemNameMapping(typeof(int), "int"),
                new CustomArrayItemNameMapping(typeof(long), "long"),
                new CustomArrayItemNameMapping(typeof(sbyte), "byte"),
                new CustomArrayItemNameMapping(typeof(float), "float"),
                new CustomArrayItemNameMapping(typeof(string), "string"),
                new CustomArrayItemNameMapping(typeof(TimeSpan), "duration"),
                new CustomArrayItemNameMapping(typeof(ushort), "unsignedShort"),
                new CustomArrayItemNameMapping(typeof(uint), "unsignedInt"),
                new CustomArrayItemNameMapping(typeof(ulong), "unsignedLong")
            };
    }
}