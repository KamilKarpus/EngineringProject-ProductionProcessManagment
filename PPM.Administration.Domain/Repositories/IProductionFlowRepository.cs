﻿using PPM.Administration.Domain.Flows;
using System;
using System.Threading.Tasks;

namespace PPM.Administration.Domain.Repositories
{
    public interface IProductionFlowRepository
    {
        Task<ProductionFlow> GetById(Guid id);
        Task AddAsync(ProductionFlow flow);
    }
}