using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwiftCode.BBS.Common.Helper;
using System.Threading.Tasks;

namespace SwiftCode.BBS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<object> GetJwtStr(string name,string pass)
        {
            TokenModelJwt tokenModelJwt = new TokenModelJwt { Uid = 1, Role = "Admin" };
            var jwtStr = JwtHelper.IssueJwt(tokenModelJwt);
            var suc = true;
            return Ok(new
            {
                success = suc,
                token = jwtStr
            });
        }
    }
}
