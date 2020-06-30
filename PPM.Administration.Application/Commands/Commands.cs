using System;

namespace PPM.Administration.Application.Commands
{

    public static class Commands
    {
        public static class V1
        {
            public class AddProductionFlow
            {
                public string Name { get; set; }
            }
            public class AddStep
            {
                public string Name { get; set; }
                public int Days { get; set; }
                public Guid LocationId { get; set; }
                public int Percentage { get; set; }
            }
            public class ChangeStatus
            {
                public int StatusId { get; set; }
            }
        }
    }
}
