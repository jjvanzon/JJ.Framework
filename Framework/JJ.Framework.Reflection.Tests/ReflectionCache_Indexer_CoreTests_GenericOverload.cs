namespace JJ.Framework.Reflection.Legacy.Tests;

//[Suppress("Trimmer", "IL2077", Justification = TypeLoaded)]
//[Suppress("Trimmer", "IL2026", Justification = GenericMethod)]
//[Suppress("Trimmer", "IL3050", Justification = GenericMethod)]
[TestClass]
public class ReflectionCache_Indexer_CoreTests_GenericOverload
{
    // ncrunch: no coverage start
    private class HelperClass
    {
        public int this[long a] => 0;
        public int this[long a, float b] => 0;
        public int this[long a, float b, short c] => 0;
        public int this[long a, float b, short c, byte d] => 0;
        public int this[long a, float b, short c, byte d, char e] => 0;
        public int this[long a, float b, short c, byte d, char e, decimal f] => 0;
        public int this[long a, float b, short c, byte d, char e, decimal f, bool g] => 0;
    }
    // ncrunch: no coverage end

    private static readonly ReflectionCacheLegacy _reflectionCacheLegacy = new();

    [TestMethod]
    public void Test_ReflectionCache_GetIndexer_GenericOverload()
    {
        Type type = typeof(HelperClass);

        {
            // single-parameter indexer
            PropertyInfo indexer1 = _reflectionCacheLegacy.GetIndexer<long>(type);
            PropertyInfo indexer2 = _reflectionCacheLegacy.GetIndexer<long>(type);
            NotNull(indexer1);
            NotNull(indexer2);

            ParameterInfo[] parameters = indexer1.GetIndexParameters();
            AreEqual(1, () => parameters.Length);
            AreEqual(typeof(long), () => parameters[0].ParameterType);
        }

        {
            PropertyInfo indexer = _reflectionCacheLegacy.GetIndexer<long, float>(type);
            NotNull(indexer);

            ParameterInfo[] parameters = indexer.GetIndexParameters();
            AreEqual(2, () => parameters.Length);
            AreEqual(typeof(long), () => parameters[0].ParameterType);
            AreEqual(typeof(float), () => parameters[1].ParameterType);
        }

        {
            PropertyInfo indexer = _reflectionCacheLegacy.GetIndexer<long, float, short>(type);
            NotNull(indexer);

            ParameterInfo[] parameters = indexer.GetIndexParameters();
            AreEqual(3, () => parameters.Length);
            AreEqual(typeof(short), () => parameters[2].ParameterType);
        }

        {
            PropertyInfo indexer = _reflectionCacheLegacy.GetIndexer<long, float, short, byte>(type);
            NotNull(indexer);

            ParameterInfo[] parameters = indexer.GetIndexParameters();
            AreEqual(4, () => parameters.Length);
            AreEqual(typeof(byte), () => parameters[3].ParameterType);
        }

        {
            PropertyInfo indexer = _reflectionCacheLegacy.GetIndexer<long, float, short, byte, char>(type);
            NotNull(indexer);

            ParameterInfo[] parameters = indexer.GetIndexParameters();
            AreEqual(5, () => parameters.Length);
            AreEqual(typeof(char), () => parameters[4].ParameterType);
        }

        {
            PropertyInfo indexer = _reflectionCacheLegacy.GetIndexer<long, float, short, byte, char, decimal>(type);
            NotNull(indexer);

            ParameterInfo[] parameters = indexer.GetIndexParameters();
            AreEqual(6, () => parameters.Length);
            AreEqual(typeof(decimal), () => parameters[5].ParameterType);
        }

        {
            PropertyInfo indexer = _reflectionCacheLegacy.GetIndexer<long, float, short, byte, char, decimal, bool>(type);
            NotNull(indexer);
            
            ParameterInfo[] parameters = indexer.GetIndexParameters();
            AreEqual(7, () => parameters.Length);
            AreEqual(typeof(bool), () => parameters[6].ParameterType);
        }
    }

    [TestMethod]
    public void Test_ReflectionCache_TryGetIndexer_GenericOverload()
    {
        Type type = typeof(HelperClass);
        {
            PropertyInfo? indexr = _reflectionCacheLegacy.TryGetIndexer<long>(type);
            NotNull(indexr);
            ParameterInfo[] parameters = indexr.GetIndexParameters();
            AreEqual(typeof(long), () => parameters[0].ParameterType);
        }

        {
            PropertyInfo? indexer = _reflectionCacheLegacy.TryGetIndexer<long, float>(type);
            NotNull(indexer);
            ParameterInfo[] parameters = indexer.GetIndexParameters();
            AreEqual(typeof(float), () => parameters[1].ParameterType);
        }

        {
            PropertyInfo? indexer = _reflectionCacheLegacy.TryGetIndexer<long, float, short>(type);
            NotNull(indexer);
            ParameterInfo[] parameters = indexer.GetIndexParameters();
            AreEqual(typeof(short), () => parameters[2].ParameterType);
        }

        {
            PropertyInfo? indexer = _reflectionCacheLegacy.TryGetIndexer<long, float, short, byte>(type);
            NotNull(indexer);
            ParameterInfo[] parameters = indexer.GetIndexParameters();
            AreEqual(typeof(byte), () => parameters[3].ParameterType);
        }

        {
            PropertyInfo? indexer = _reflectionCacheLegacy.TryGetIndexer<long, float, short, byte, char>(type);
            NotNull(indexer);
            ParameterInfo[] parameters = indexer.GetIndexParameters();
            AreEqual(typeof(char), () => parameters[4].ParameterType);
        }

        {
            PropertyInfo? indexer = _reflectionCacheLegacy.TryGetIndexer<long, float, short, byte, char, decimal>(type);
            NotNull(indexer);
            ParameterInfo[] parameters = indexer.GetIndexParameters();
            AreEqual(typeof(decimal), () => parameters[5].ParameterType);
        }

        {
            PropertyInfo? indexer = _reflectionCacheLegacy.TryGetIndexer<long, float, short, byte, char, decimal, bool>(type);
            NotNull(indexer);
            ParameterInfo[] parameters = indexer.GetIndexParameters();
            AreEqual(typeof(bool), () => parameters[6].ParameterType);
        }
    }
}
