namespace News_API
{
    public interface INewsService
    {
        public Task<List<int>> getAllStories();

        public Task<News> getStoriesByID(int id);

    }
}
