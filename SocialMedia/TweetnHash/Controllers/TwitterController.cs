using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tweetinvi;

namespace TweetnHash.Controllers
{
    public class TwitterController : Controller
    {
        //private AuthenticationContext _authenticationContext;
        // GET: Twitter
        public ActionResult Index()
        {
            Auth.SetUserCredentials("CONSUMER_KEY", "CONSUMER_SECRET", "ACCESS_TOKEN", "ACCESS_TOKEN_SECRET");
            Tweet.PublishTweet();
            return View();
        }

        //public ActionResult TwitterAuth()
        //{
        //    var appCreds = new ConsumerCredentials("CONSUMER_KEY", "CONSUMER_SECRET");

        //    // Specify the url you want the user to be redirected to
        //    var redirectURL = "http://" + Request.Url.Authority + "/Home/ValidateTwitterAuth";
        //    _authenticationContext = AuthFlow.InitAuthentication(appCreds, redirectURL);

        //    return new RedirectResult(authenticationContext.AuthorizationURL);
        //}
    }
}