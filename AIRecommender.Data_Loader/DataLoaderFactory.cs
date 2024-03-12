using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommender.Data_Loader
{
    public class DataLoaderFactory
    {
        public static readonly DataLoaderFactory Instance= new DataLoaderFactory();
        protected DataLoaderFactory()
        {
        }
           public  IDataLoader GetDataLoader()
            {
                string className = ConfigurationManager.AppSettings["Loader"];
        
            Type type = Type.GetType(className);
            return (IDataLoader)Activator.CreateInstance(type);
             
        }
        

    }
}
