namespace todoAPI.models
{
    public class ToDoDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string ToDosCollectionName { get; set; } = null!;
    }
}
