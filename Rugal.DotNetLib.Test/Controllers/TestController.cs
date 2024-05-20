using Microsoft.AspNetCore.Mvc;
using Rugal.DotNetLib.Core.ValueConvert;

namespace Rugal.DotNetLib.Test.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public dynamic Test()
        {
            string A = null;
            var B = DateTime.Now;
            return new
            {
                A = A.ToNullDash(),
                B = B.ToNullDash()
            };
        }
    }
}
