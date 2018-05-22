using ExquisiteImages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace ExquisiteImages.Infrastructure.CommentClient
{
    public class CommentClient : ICommentClient
    {
        static HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:7001/")
        };
        

        public async Task<Comment> Create(Comment model)
        {
            string json = JsonConvert.SerializeObject(model);
            StringContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponse = await client.PostAsync("/api/comment/", httpContent);
            string responseContent = await httpResponse.Content.ReadAsStringAsync();
            Comment data = JsonConvert.DeserializeObject<Comment>(responseContent);
            return data;
        }
    }
}
