using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CovertAndAsciiAPIs.Controllers
{
    public class AsciiController : ApiController
    {
        // Use Post
        [Route("api/Ascii/{value}")]
        [HttpPost]
        public IHttpActionResult AsciiToHex(string value)
        {
            AsciiResultData AsciiResultDataobj = new AsciiResultData();

            try
            {
                string str = null;
                byte[] bytes = Encoding.ASCII.GetBytes(value);
                foreach(byte b in bytes)
                {
                    str += b.ToString();
                    str += " ";
                }

                AsciiResultDataobj.Status = "OK";
                AsciiResultDataobj.AsciiResult = str;
                return Ok(AsciiResultDataobj);
            }
            catch (Exception ex)
            {
                AsciiResultDataobj.Status = "轉換Ascii時發生例外，原因如下： " + ex.Message; ;
                AsciiResultDataobj.AsciiResult = "";
                return Ok(AsciiResultDataobj);
            }
        }
    }


    // 用來儲存結果資料的內部類別，
    // 每一個欄位變數名稱將是回傳JSON物件的Key
    public class AsciiResultData
    {
        // 儲存結果之狀態
        public string Status { get; set; }
        // 儲存運算結果
        public string AsciiResult { get; set; }
    }
}