using System;

namespace PPM.Administration.Application.Queries
{
    public static class Queries
    {
        public static class V1
        {
            public class GetProductionInfoListQuery
            {
                public int PageNumber { get; set; }
                public int PageSize { get; set; }
            }

            public class GetProductionFlowByNameQuery
            {
                public string FlowName { get; set; }
            }
         
        }
    }
}
