using System;
using Microsoft.AspNetCore.Mvc;
using Clockwork.API.Models;

namespace Clockwork.API.Controllers
{
    [Route("api/[controller]")]
    public class ClientInfoController : Controller
    {
        // GET api/clientInfo
        [HttpGet]
        public IActionResult Get()
        {
            var utcTime = DateTime.UtcNow;
            var serverTime = DateTime.Now;
            var ip = this.HttpContext.Connection.RemoteIpAddress.ToString();

            var returnVal = new ClientInfoList();

            using (var db = new ClockworkContext())
            {
                var queryResult = db.CurrentTimeQueries.OrderBy(x=>x.CurrentTimeQueryId);
                var count = 0;

                foreach (var item in queryResult)
                {
                    var itemResult = new CurrentTimeQuery(){
                        CurrentTimeQueryId = item.CurrentTimeQueryId,
                        ClientIp = item.ClientIp,
                        Time = item.Time,
                        UTCTime = item.UTCTime
                    }

                    returnVal.Add(itemResult);
                    count ++;
                    
                }

                Console.WriteLine(String.Format("items fetched from DB: {0}", count)
            }

            return Ok(returnVal);
        }
    }
}
