
using System.Collections;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.AccessControl;

namespace News_API
{
    public class NewsService : INewsService
    {
        private HttpClient httpClient =new HttpClient();

        //public  NewsService(HttpClient httpClient)
        //{
        //    this.httpClient = httpClient;
        //}

        async Task<List<int>> INewsService.getAllStories()
        {
         var stories=  httpClient.GetByteArrayAsync("https://hacker-news.firebaseio.com/v0/topstories.json").Result;
            string result = System.Text.Encoding.UTF8.GetString(stories);
            var arr = result.Replace("[","").Replace("]", "").Split(',').Select(int.Parse).ToList();
            return arr;
            
        }

        async Task<News> INewsService.getStoriesByID(int id)
        {
            var response =  httpClient.GetFromJsonAsync<News>($"https://hacker-news.firebaseio.com/v0/item/{id}.json").Result;          

            return response;
        }


    }
}
