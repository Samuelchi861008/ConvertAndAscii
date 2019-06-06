using System;
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
    public class TransController : ApiController
    {
        // Use Get
        /* ==========   Convert from Binary   ========== */
        // BIN to OCT
        [Route("api/Trans/B2O/{num}")]
        [HttpGet]
        public IHttpActionResult B2O(int num)
        {
            return Ok(Convert.ToString(Convert.ToInt32(num.ToString(), 2), 8));
        }

        // BIN to DEC
        [Route("api/Trans/B2D/{num}")]
        [HttpGet]
        public IHttpActionResult B2D(int num)
        {
            return Ok(Convert.ToInt32(num.ToString(), 2).ToString());
        }

        // BIN to HEX
        [Route("api/Trans/B2H/{num}")]
        [HttpGet]
        public IHttpActionResult B2H(int num)
        {
            return Ok(Convert.ToString(Convert.ToInt32(num.ToString(), 2), 16).ToUpper());
        }

        // BIN to BIN
        [Route("api/Trans/B2B/{num}")]
        [HttpGet]
        public IHttpActionResult B2B(int num)
        {
            return Ok(num.ToString());
        }


        /* ==========   Convert from Octal   ========== */
        // OCT to BIN
        [Route("api/Trans/O2B/{num}")]
        [HttpGet]
        public IHttpActionResult O2B(int num)
        {
            return Ok(Convert.ToString(Convert.ToInt32(num.ToString(), 8), 2));
        }

        // OCT to DEC
        [Route("api/Trans/O2D/{num}")]
        [HttpGet]
        public IHttpActionResult O2D(int num)
        {
            return Ok(Convert.ToInt32(num.ToString(), 8).ToString());
        }

        // OCT to HEX
        [Route("api/Trans/O2H/{num}")]
        [HttpGet]
        public IHttpActionResult O2H(int num)
        {
            return Ok(Convert.ToString(Convert.ToInt32(num.ToString(), 8), 16).ToUpper());
        }

        // OCT to OCT
        [Route("api/Trans/O2O/{num}")]
        [HttpGet]
        public IHttpActionResult O2O(int num)
        {
            return Ok(num.ToString());
        }


        /* ==========   Convert from Decimal   ========== */
        // DEC to BIN
        [Route("api/Trans/D2B/{num}")]
        [HttpGet]
        public IHttpActionResult D2B(int num)
        {
            return Ok(Convert.ToString(Convert.ToInt32(num.ToString()), 2));
        }

        // DEC to OCT
        [Route("api/Trans/D2O/{num}")]
        [HttpGet]
        public IHttpActionResult D2O(int num)
        {
            return Ok(Convert.ToString(Convert.ToInt32(num.ToString()), 8));
        }

        // DEC to HEX
        [Route("api/Trans/D2H/{num}")]
        [HttpGet]
        public IHttpActionResult D2H(int num)
        {
            return Ok(Convert.ToString(Convert.ToInt32(num.ToString()), 16).ToUpper());
        }

        // DEC to DEC
        [Route("api/Trans/D2D/{num}")]
        [HttpGet]
        public IHttpActionResult D2D(int num)
        {
            return Ok(num.ToString());
        }


        /* ==========   Convert from Hexadecimal   ========== */
        // HEX to BIN
        [Route("api/Trans/H2B/{num}")]
        [HttpGet]
        public IHttpActionResult H2B(string num)
        {
            return Ok(Convert.ToString(Convert.ToInt32(num, 16), 2));
        }

        // HEX to OCT
        [Route("api/Trans/H2O/{num}")]
        [HttpGet]
        public IHttpActionResult H2O(string num)
        {
            return Ok(Convert.ToString(Convert.ToInt32(num, 16), 8));
        }

        // HEX to DEC
        [Route("api/Trans/H2D/{num}")]
        [HttpGet]
        public IHttpActionResult H2D(string num)
        {
            return Ok(Convert.ToInt32(num, 16).ToString());
        }

        // HEX to HEX
        [Route("api/Trans/H2H/{num}")]
        [HttpGet]
        public IHttpActionResult H2H(string num)
        {
            return Ok(num.ToUpper());
        }
    }
}