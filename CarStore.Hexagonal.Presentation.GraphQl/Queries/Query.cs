namespace CarStore.Hexagonal.Presentation.GraphQl.Queries
{
    public class Query
    {
        public UserQueries Users => new();
        public CarQueries Cars => new();
        public ListingQueries Listings => new();
    }
}
