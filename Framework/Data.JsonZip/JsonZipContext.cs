using System;
using System.Collections.Generic;
using System.Reflection;
using Ionic.Zip;
using JJ.Framework.Data.Memory;
using JJ.Framework.IO;
using Newtonsoft.Json;

namespace JJ.Framework.Data.JsonZip
{
    [Obsolete("Not obsolete, but not finished either.")]
    public class JsonZipContext : ContextBase
    {
        private object _rootObject;
        private string _filePath;

        private CachedContext _underlyingContext;

        public JsonZipContext(string location, Assembly modelAssembly, Assembly mappingAssembly, string dialect)
            : base(location, modelAssembly, mappingAssembly, dialect)
        {
            _underlyingContext = new CachedContext(
                new MemoryContext(default, default, default, default),
                new LoadedContext(new MemoryContext(default, default, default, default), Load));
        }

        public override TEntity TryGet<TEntity>(object id) => throw new NotImplementedException();

        public override TEntity Create<TEntity>() => throw new NotImplementedException();

        public override void Insert(object entity) => throw new NotImplementedException();

        public override void Update(object entity) => throw new NotImplementedException();

        public override void Delete(object entity) => throw new NotImplementedException();

        public override IEnumerable<TEntity> Query<TEntity>() => throw new NotImplementedException();

        public override void Commit() => Save();

        private void Load() => throw new NotImplementedException();

        private void Save()
        {
            string json = JsonConvert.SerializeObject(_rootObject); // TODO: Stream instead.

            using (var safeFileOverwriter = new SafeFileOverwriter(_filePath))
            {
                using (var zipFile = new ZipFile())
                {
                    zipFile.AddEntry("content.json", json);
                    zipFile.Save(safeFileOverwriter.TempStream);
                }

                safeFileOverwriter.Save();
            }
        }

        public override void Flush() => throw new NotImplementedException();

        public override void Dispose() => throw new NotImplementedException();

        public override void Rollback() => throw new NotImplementedException();
    }
}