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
                public int RequiredDaysToFinish { get; set; }
            }
        }
    }
}
