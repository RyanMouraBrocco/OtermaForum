using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OtermaForum.Api.Controllers.Base
{
    [ApiController]
    [Route("/api/[controller]")]
    public class BaseController : Controller
    {
        public BaseController()
        {

        }

        protected int GetUserId()
        {
            var currentUser = HttpContext.User;
            return int.Parse(currentUser.Claims.FirstOrDefault(c => c.Type == "Id").Value);
        }
    }
}
