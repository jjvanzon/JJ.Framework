using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace JJ.Framework.Persistence.Xml
{
    public class XmlContext : ContextBase
    {
        public XmlContext(string folderPath, params Assembly[] modelAssemblies)
            : base(folderPath, modelAssemblies)
        { }

        public override TEntity TryGet<TEntity>(object id)
        {
            XmlDocumentWrapper documentWrapper = GetXmlDocumentWrapper<TEntity>();
            XmlElement element = documentWrapper.TryGetXmlElementByEntityID(id);
            if (element == null)
            {
                return null;
            }
            return documentWrapper.ConvertXmlElementToEntity<TEntity>(element);
        }

        public override TEntity Create<TEntity>()
        {
            TEntity entity = new TEntity();
            XmlDocumentWrapper documentWrapper = GetXmlDocumentWrapper<TEntity>();
            XmlElement element = documentWrapper.CreateXmlElement<TEntity>();
            return entity;
        }

        public override void Insert<TEntity>(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            XmlDocumentWrapper documentWrapper = GetXmlDocumentWrapper<TEntity>();
            XmlElement element = documentWrapper.CreateXmlElement<TEntity>();
            documentWrapper.UpdateXmlElement(element, entity);
        }

        public override void Update<TEntity>(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            XmlDocumentWrapper documentWrapper = GetXmlDocumentWrapper<TEntity>();
            XmlElement element = documentWrapper.GetXmlElementByEntity(entity);
            documentWrapper.UpdateXmlElement(element, entity);
        }

        public override void Delete<TEntity>(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            XmlDocumentWrapper documentWrapper = GetXmlDocumentWrapper<TEntity>();
            documentWrapper.DeleteXmlElementByEntity(entity);
        }

        public override IEnumerable<TEntity> GetAll<TEntity>()
        {
            XmlDocumentWrapper documentWrapper = GetXmlDocumentWrapper<TEntity>();
            IList<XmlElement> xmlElements = documentWrapper.GetAllXmlElements();
            IList<TEntity> entities = new List<TEntity>();
            foreach (XmlElement xmlElement in xmlElements)
            {
                TEntity entity = documentWrapper.ConvertXmlElementToEntity<TEntity>(xmlElement);
                entities.Add(entity);
            }
            return entities;
        }

        public override IEnumerable<TEntity> Query<TEntity>()
        {
            throw new NotSupportedException("XmlContext does not support Query<TEntity>().");
        }

        public override void Commit()
        {
            lock (_documentWrapperDictionaryLock)
            {
                foreach (XmlDocumentWrapper documentWrapper in _documentWrapperDictionary.Values)
                {
                    documentWrapper.Save();
                }
            }
        }

        public override void Dispose()
        {
            // No code required.
        }

        // Helpers

        private object _documentWrapperDictionaryLock = new object();
        private Dictionary<string, XmlDocumentWrapper> _documentWrapperDictionary = new Dictionary<string, XmlDocumentWrapper>();

        private XmlDocumentWrapper GetXmlDocumentWrapper<TEntity>()
        {
            lock (_documentWrapperDictionary)
            {
                string entityName = typeof(TEntity).Name;
                
                if (_documentWrapperDictionary.ContainsKey(entityName))
                {
                    return _documentWrapperDictionary[entityName];
                }

                string filePath = Path.Combine(Location, entityName) + ".xml";
                XmlDocumentWrapper documentWrapper = new XmlDocumentWrapper(filePath);

                _documentWrapperDictionary[entityName] = documentWrapper;

                return documentWrapper;
            }
        }
    }
}
