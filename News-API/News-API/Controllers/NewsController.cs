using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace News_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        INewsService news;
        public NewsController(INewsService newsService)
        
        {   
            this.news = newsService;
        }
        // GET: api/<NewsController>
        [HttpGet]
        public async Task<IEnumerable<News>> Get()
        {
            List<int> storyIds =await news.getAllStories();
            List<News> lstnews = new List<News>();
            //foreach (int storyId in storyIds)
            //{
            //    lstnews.Add(await news.getStoriesByID(storyId));
            //}
            for (int i = 0; i <= 10; i++)
            {
                lstnews.Add(await news.getStoriesByID(storyIds[i]));
            }

            return lstnews;
        }

        // GET api/<NewsController>/5
        [HttpGet("{id}")]
        public void GetPagingData(int page, int pageSize)
        {
           
        }

        // POST api/<NewsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<NewsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NewsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
