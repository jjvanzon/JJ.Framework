using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Ionic.Zip;
using JJ.Framework.Collections;
using JJ.Framework.Data.Memory;
using JJ.Framework.IO;
using Newtonsoft.Json;
 
namespace JJ.Framework.Data.JsonBlobZip
{
    public class JsonBlobZipContext<TRootObject> : ContextBase
    {
        private const string JSON_FILE_NAME = "content.json";

        private MemoryContext _memoryContext;

        private string _jsonString;
        public TRootObject RootObject { get; private set; }

        public JsonBlobZipContext(string location, Assembly modelAssembly, Assembly mappingAssembly, string dialect)
            : base(location, modelAssembly, mappingAssembly, dialect)
        {
            _memoryContext = CreateMemoryContext();

            Load();
        }

        public override TEntity TryGet<TEntity>(object id) => _memoryContext.TryGet<TEntity>(id);
        public override TEntity Create<TEntity>() => _memoryContext.Create<TEntity>();
        public override void Insert(object entity) => _memoryContext.Insert(entity);
        public override void Update(object entity) => _memoryContext.Update(entity);
        public override void Delete(object entity) => _memoryContext.Delete(entity);
        public override IEnumerable<TEntity> Query<TEntity>() => _memoryContext.Query<TEntity>();
        public override void Flush() { }
        public override void Dispose() { }

        public override void Rollback()
        {
            RootObject = Deserialize(_jsonString);

            _memoryContext = CreateMemoryContext();

            FillMemoryContext(RootObject, _memoryContext);
        }

        public override void Commit() => Save();

        private void Load()
        {
            string jsonString = LoadJson(Location);

            TRootObject rootObject = Deserialize(jsonString);

            FillMemoryContext(rootObject, _memoryContext);

            _jsonString = jsonString;
            RootObject = rootObject;
        }

        /// <summary> base does nothing </summary>
        protected virtual void FillMemoryContext(TRootObject sourceRootObject, IContext destMemoryContext) { }

        private TRootObject Deserialize(string jsonString) => JsonConvert.DeserializeObject<TRootObject>(jsonString);

        private string LoadJson(string filePath)
        {
            using (var zipFile = ZipFile.Read(filePath))
            {

                ZipEntry jsonZipEntry = zipFile.Entries
                                               .Where(x => string.Equals(x.FileName, JSON_FILE_NAME))
                                               .SingleWithClearException(new { FileName = JSON_FILE_NAME });

                var memoryStream = new MemoryStream();
                jsonZipEntry.Extract(memoryStream);

                string jsonString = StreamHelper.StreamToString(memoryStream, Encoding.UTF8);

                return jsonString;
            }
        }

        private void Save()
        {
            string json = JsonConvert.SerializeObject(RootObject);

            using (var safeFileOverwriter = new SafeFileOverwriter(Location))
            {
                using (var zipFile = new ZipFile())
                {
                    zipFile.AddEntry(JSON_FILE_NAME, json);
                    zipFile.Save(safeFileOverwriter.TempStream);
                }

                safeFileOverwriter.Save();
            }

            _jsonString = json;
        }

        private MemoryContext CreateMemoryContext() => new MemoryContext(null, ModelAssembly, MappingAssembly, Dialect);
    }
}