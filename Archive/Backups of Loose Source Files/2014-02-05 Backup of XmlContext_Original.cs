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
    public class XmlContext_Original : ContextBase
    {
        public XmlContext_Original(string folderPath, params Assembly[] modelAssemblies)
            : base(folderPath, modelAssemblies)
        { }

        public override TEntity TryGet<TEntity>(object id)
        {
            XmlDocumentAcessor documentAccessor = GetXmlDocumentAccessor<TEntity>();
            XmlElement element = documentAccessor.TryGetXmlElementByEntityID(id);
            if (element == null)
            {
                return null;
            }
            return documentAccessor.ConvertXmlElementToEntity<TEntity>(element);
        }

        public override TEntity Create<TEntity>()
        {
            TEntity entity = new TEntity();
            XmlDocumentAcessor documentAccessor = GetXmlDocumentAccessor<TEntity>();
            XmlElement element = documentAccessor.CreateXmlElement<TEntity>();
            return entity;
        }

        public override void Insert<TEntity>(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            XmlDocumentAcessor documentAccessor = GetXmlDocumentAccessor<TEntity>();
            XmlElement element = documentAccessor.CreateXmlElement<TEntity>();
            documentAccessor.UpdateXmlElement(element, entity);
        }

        public override void Update<TEntity>(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            XmlDocumentAcessor documentAccessor = GetXmlDocumentAccessor<TEntity>();
            XmlElement element = documentAccessor.GetXmlElementByEntity(entity);
            documentAccessor.UpdateXmlElement(element, entity);
        }

        public override void Delete<TEntity>(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            XmlDocumentAcessor documentAccessor = GetXmlDocumentAccessor<TEntity>();
            documentAccessor.DeleteXmlElementByEntity(entity);
        }

        public override IEnumerable<TEntity> GetAll<TEntity>()
        {
            XmlDocumentAcessor documentAccessor = GetXmlDocumentAccessor<TEntity>();
            IList<XmlElement> xmlElements = documentAccessor.GetAllXmlElements();
            IList<TEntity> entities = new List<TEntity>();
            foreach (XmlElement xmlElement in xmlElements)
            {
                TEntity entity = documentAccessor.ConvertXmlElementToEntity<TEntity>(xmlElement);
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
            lock (_documentAccessorDictionaryLock)
            {
                foreach (XmlDocumentAcessor documentWrapper in _documentAccessorDictionary.Values)
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

        private object _documentAccessorDictionaryLock = new object();
        private Dictionary<string, XmlDocumentAcessor> _documentAccessorDictionary = new Dictionary<string, XmlDocumentAcessor>();
        
        private XmlDocumentAcessor GetXmlDocumentAccessor<TEntity>()
        {
            lock (_documentAccessorDictionary)
            {
                string entityName = typeof(TEntity).Name;
                
                if (_documentAccessorDictionary.ContainsKey(entityName))
                {
                    return _documentAccessorDictionary[entityName];
                }

                string filePath = Path.Combine(Location, entityName) + ".xml";
                XmlDocumentAcessor documentAccessor = XmlDocumentAccessorFactory.Create(typeof(TEntity), filePath, ModelAssemblies);

                _documentAccessorDictionary[entityName] = documentAccessor;

                return documentAccessor;
            }
        }
    }
}
