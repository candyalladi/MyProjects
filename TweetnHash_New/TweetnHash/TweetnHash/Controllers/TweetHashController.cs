using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TweetnHash.Controllers
{
    public class TweetHashController : Controller
    {
        // GET: TweetHash
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}