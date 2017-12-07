using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using static JSONtestWebsite.Models.PostModel;

namespace JSONtestWebsite.Controllers
{
    public class PostController : Controller
    {
        public async Task<ActionResult> Index()
        {
            List<Posting> PostInfo = new List<Posting>();

            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");

                client.DefaultRequestHeaders.Clear();

                //Define request data format to JSON
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource 
                HttpResponseMessage Res = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");

                //Check response sucessful
                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    PostInfo = JsonConvert.DeserializeObject<List<Posting>>(Response);

                }
                //Return the Post list to view
                return View(PostInfo);
            }
        }

        
            

        //Update

        //Delete
    }
}