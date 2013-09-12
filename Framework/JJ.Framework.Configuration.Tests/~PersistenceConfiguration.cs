//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace JJ.Framework.Configuration.Tests
//{
//    public class PersistenceConfiguration : IPersistenceConfiguration
//    {
//        private ConfigurationSection<IPersistenceConfiguration> configurationSection;
            
//        public PersistenceConfiguration() 
//        {
//            configurationSection = new ConfigurationSection<IPersistenceConfiguration>("jj.framework.persistence");
//        }

//        public string Location
//        {
//            get { return configurationSection.GetValue(x => x.Location); }
//        }

//        public string ContextType
//        {
//            get { return configurationSection.GetValue(x => x.ContextType); }
//        }

//        public string[] ModelAssemblies
//        {
//            get { return configurationSection.GetValue(x => x.ModelAssemblies); }
//        }
//    }
//}
