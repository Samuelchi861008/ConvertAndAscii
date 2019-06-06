using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System.Text;

using TransAndAsciiMVCClient.ViewModel;

namespace TransAndAsciiMVCClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Trans()
        {
            return View();
        }

        public ActionResult Ascii()
        {
            return View();
        }

        HttpClient client = new HttpClient();
        [HttpPost]
        public async Task<ActionResult> Trans([Bind(Exclude = "Result")] TransViewModel mathdata, string btnCompute)
        {
            string urlString, result, op, t;
            if (!ModelState.IsValid)
            {
                mathdata.Result = "bbbbb";
                return View(mathdata);
            }
            try
            {
                switch (mathdata.Type)
                {
                    case "二進位":
                        t = "B";
                        break;
                    case "八進位":
                        t = "O";
                        break;
                    case "十進位":
                        t = "D";
                        break;
                    default:
                        t = "H";
                        break;
                }

                switch (btnCompute)
                {
                    case "二進位":
                        op = "B";
                        break;
                    case "八進位":
                        op = "O";
                        break;
                    case "十進位":
                        op = "D";
                        break;
                    default:
                        op = "H";
                        break;
                }

                urlString = "http://140.137.41.136:5558/A5206572/CovertAndAsciiAPIs/api/Trans/" + t + "2" + op + "/" + mathdata.Sets;
                HttpResponseMessage response = await client.GetAsync(urlString);
                result = await response.Content.ReadAsStringAsync();
                mathdata.Result = result.Substring(1, result.Length - 2);
                return View(mathdata);
            }
            catch (Exception ex)
            {
                result = "轉換時發生例外，原因如下: " + ex.Message;
                mathdata.Result = result;
                return View(mathdata);
            }
        }


        [HttpPost]
        public async Task<ActionResult> Ascii([Bind(Exclude = "Result")] AsciiViewModel Asciidata)
        {
            string result, urlString;
            if (!ModelState.IsValid)
            {
                return View(Asciidata);
            }
            try
            {
                urlString = "http://140.137.41.136:5558/A5206572/CovertAndAsciiAPIs/api/Ascii/" + Asciidata.Sets;
                dynamic jsonString = JsonConvert.SerializeObject(Asciidata);
                HttpContent contentPost = new StringContent(jsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(urlString, contentPost);
                result = await response.Content.ReadAsStringAsync();
                dynamic jsonObject = JsonConvert.DeserializeObject(result);
                Asciidata.Result = jsonObject.AsciiResult;
                return View(Asciidata);
            }
            catch (Exception ex)
            {
                result = "轉換時發生例外，原因如下: " + ex.Message;
                Asciidata.Result = result;
                return View(Asciidata);
            }
        }
    }
}