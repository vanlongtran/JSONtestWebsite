using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static JSONtestWebsite.Models.CommentModel;

namespace JSONtestWebsite.Models
{

    public class PostModel
    {
        public class Postings
        {
            public Posting[] post { get; set; }
        }

        public class Posting
        {
            public int userId { get; set; }
            public int id { get; set; }
            public string title { get; set; }
            public string body { get; set; }
        }
    }


}