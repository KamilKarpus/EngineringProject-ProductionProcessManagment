using System;
using System.Collections.Generic;

namespace PPM.Administration.Application.ReadModels
{
    public class ProductionFlowReadModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int RequiredDaysToFinish { get; set; }
        public string StatusName { get; set; }
        public int StatusId { get; set; }
        public bool IsValid { get; set; }
        public List<StepsReadModel> Steps { get; set; } = new List<StepsReadModel>();
    }
}
