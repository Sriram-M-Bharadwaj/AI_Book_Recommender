using AIrecommender.Entity;
using AIRecommender.Entity;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommender.DataAggregator
{
    public  interface IRatingsAggregator
    {
        Dictionary<string , List<int>> Aggregate(BookDetails bookDetails, Preference preference);
    }
}
