using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using static JSONtestWebsite.Models.UserModel;
using static JSONtestWebsite.Models.CommentModel;
using static JSONtestWebsite.Models.PostModel;

namespace JSONtestWebsite.Controllers
{
    public class UsersController : Controller
    {
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

    public async Task<ActionResult> PostHistory()
    {
            PostHistory userHistory = new PostHistory();
            User UserInfo = new User();
            List<Posting> PostInfo = new List<Posting>();
            //List<Comment> CommentInfo = new List<Comment>();

            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");

                client.DefaultRequestHeaders.Clear();

                //Define request data format to JSON
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource 
                HttpResponseMessage Res = await client.GetAsync("https://jsonplaceholder.typicode.com/users/" + 1);
                HttpResponseMessage Res2 = await client.GetAsync("https://jsonplaceholder.typicode.com/posts?userId=1");
                //HttpResponseMessage Res3 = await client.GetAsync("https://jsonplaceholder.typicode.com/comment?postId=" + 1);


                //Check response sucessful
                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    UserInfo = JsonConvert.DeserializeObject<User>(Response);
                }
                if (Res2.IsSuccessStatusCode)
                {
                    var Response2 = Res2.Content.ReadAsStringAsync().Result;
                    PostInfo = JsonConvert.DeserializeObject<List<Posting>>(Response2);
                }
                /*if (Res3.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    CommentInfo = JsonConvert.DeserializeObject<List<Comment>>(Response);
                }*/

                userHistory.id = UserInfo.id;
                userHistory.name = UserInfo.name;
                userHistory.username = UserInfo.username;
                userHistory.email = UserInfo.email;
                userHistory.post = PostInfo;

                //Return the User list to view
                return View(userHistory);
            }
        }
    }

        //Update

        //Delete
    
}