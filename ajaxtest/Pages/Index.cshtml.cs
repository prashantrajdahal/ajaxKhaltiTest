using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ajaxtest.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
        
        [HttpGet]
        public IActionResult OnGetTest(string id)
        {
            return new JsonResult("You Sent ME " + id);
        }

        [HttpGet]
        public async Task<IActionResult> OnGetTokenAsync(string token)
        {
            /*var client = new HttpClient();
            client.BaseAddress = new Uri("https://khalti.com/api/v2/payment/verify/");
            var request = new HttpRequestMessage(HttpMethod.Post, "/");

            var byteArray = new UTF8Encoding().GetBytes("Authorization:test_secret_key_3035db5c5d44469baf705c8a3290e15e");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            var formData = new List<KeyValuePair<string, string>>();
            formData.Add(new KeyValuePair<string, string>("token", token));
            formData.Add(new KeyValuePair<string, string>("amount", "1000"));

            request.Content = new FormUrlEncodedContent(formData);
            var response = await client.SendAsync(request);*/

            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://khalti.com/api/v2/payment/verify/"))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", "Key test_secret_key_3035db5c5d44469baf705c8a3290e15e");

                    var contentList = new List<string>();
                    contentList.Add("amount=1000");
                    contentList.Add("token=" +token);
                    request.Content = new StringContent(string.Join("&", contentList));
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                    var response = await httpClient.SendAsync(request);
                    return new JsonResult(response);
                }
            }

            //Status

            
        }


    }

    public class async
    {
    }
}
