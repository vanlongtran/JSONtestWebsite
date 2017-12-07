using JSONtestWebsite.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static JSONtestWebsite.Models.CommentModel;

namespace JSONtestWebsite.Controllers
{
    public class CommentController : Controller
    {
        //GET: Comment
        public async Task<ActionResult> Index()
        {
            List<Comment> result = new List<Comment>();

            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");

                client.DefaultRequestHeaders.Clear();

                //Define request data format to JSON
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource 
                HttpResponseMessage Res = await client.GetAsync("https://jsonplaceholder.typicode.com/comments");

                //Check response sucessful
                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<List<Comment>>(Response);
                }
                //Return the User list to view
                return View(result);
            }
        }
    }
}