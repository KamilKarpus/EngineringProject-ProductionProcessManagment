using System;
using System.Collections.Generic;

namespace PPM.Administration.Infrastucture.Documents.Flow
{
    public class ProductionFlowDocument
    {
        public StepDocument[] Steps { get; set; }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int RequiredDaysToFinish { get; set; }
        public int Status { get; set; }
        public bool IsValid { get; set; }
    }
}
