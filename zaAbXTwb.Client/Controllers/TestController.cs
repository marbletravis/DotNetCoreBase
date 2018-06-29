using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace zaAbXTwb.Client.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {

        [HttpGet("[action]")]
        public bool Test() {
            return true;
        }
    }
}