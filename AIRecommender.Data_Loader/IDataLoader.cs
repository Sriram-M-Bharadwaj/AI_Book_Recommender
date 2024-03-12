using AIRecommender.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommender.Data_Loader
{
    public interface IDataLoader
    {   
        BookDetails Load();
    }
}
