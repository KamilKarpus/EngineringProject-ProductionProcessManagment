namespace PPM.Locations.Application.Queries
{
    public static class Queries
    {
        public static class V1
        {
            public class GetLocationByNameShortInfo
            {
                public string Name { get; set; }
            }
            public class GetLocationsListQuery
            {
                public int PageNumber { get; set; }
                public int PageSize { get; set; }
            }
        }
    }
}

