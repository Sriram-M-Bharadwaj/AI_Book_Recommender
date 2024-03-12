﻿using AIRecommender.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIRecommendationEngine.Cache
{
    public interface IDataCacher
    {
        BookDetails GetData();
        void SetData(BookDetails bookDetails);

    }
}
