using Facebook;
using FacebookAds;
using FacebookAds.Object;
using FacebookAds.Object.Fields;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace cAPI_Test_Project.Controllers
{

    public class FacebookController : Controller
    {
        public class UserData{
            string Email { get; set; }
            string Id { get; set; }
            string UserPhone { get; set; }
            string FirstName { get; set; }
            string LastName { get; set; }
            string Gender { get; set; }
            string Country { get; set; }
}

    public IActionResult Index()
        {
            return View();
        }

        [HttpPost("/send")]
       
        public bool SendDataLayer()
        {
            string AccessToken = "your token";
            string PıxelId = "your pixel ıd";
            string ApıVersion = "your apı version";
            string AppId = "appId";
            string AppSecret = "appSecret";
            string connectionString = "https://graph.facebook.com/" + ApıVersion + "/" + PıxelId + "/" + "/events?access_token=" + AccessToken;
            Api.Initialize(AppId,AppSecret,AccessToken);
          

            
            if (Api.IsInitialized == false)
            {
                return false;
            }
            try
            {
                Api.Client.Get(connectionString);
            }
            catch(FacebookOAuthException e)
            {
                Console.WriteLine("Unable to retrieve own account!");
                Console.WriteLine("Error: {0}", e.Message);
                Environment.Exit(-1);
            }
            try
            {
                var id = "123";
                var insights = (new Campaign(id)).GetInsights(new string[] {
                    AdsInsightsFields.IMPRESSIONS,
                    AdsInsightsFields.UNIQUE_CLICKS,
                    AdsInsightsFields.REACH,
                }, new Dictionary<string, object>() {
                    {
                        "time_range", new Dictionary<string, string>() {
                            {"since", "2023-01-01"},
                            {"until", "2023-04-05"}
                        }
                    }
                }); ;
            }
            catch(FacebookOAuthException e)
            {
                Console.WriteLine("Unable to retrieve campaign insights!");
                Console.WriteLine("Error: {0}", e.Message);
                Environment.Exit(-1);
            }
            return (bool)Api.Client.Get(connectionString);          
    

        }
    }
}
