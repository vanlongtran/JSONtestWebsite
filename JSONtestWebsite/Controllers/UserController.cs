using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using JSONtestWebsite.Models;

namespace JSONtestWebsite.Controllers
{
    public class UsersController : Controller
    {
        //string onePost = "posts/1";
        //string tenUsers = "users";
        //string oneUser = "users/1";

        //GET: Users
        public async Task<ActionResult> Index()
        {
            List<User> UserInfo = new List<User>();

            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");

                client.DefaultRequestHeaders.Clear();

                //Define request data format to JSON
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource 
                HttpResponseMessage Res = await client.GetAsync("https://jsonplaceholder.typicode.com/users");

                //Check response sucessful
                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    UserInfo = JsonConvert.DeserializeObject<List<User>>(Response);

                }
                //Return the User list to view
                return View(UserInfo);
            }
        }

        //Update

        //Delete
    }
}