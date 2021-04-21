using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerWebApi.Controllers.V2
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "v2")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class V2Controller : Controller
    {
        /// <summary>
        /// 这里是v2
        /// </summary>
        /// <returns></returns> 
        [HttpGet]
        [Microsoft.AspNetCore.Authorization.AllowAnonymous]
        [Route("api/[controller]/GetV2")]
        public string GetV2()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                Title = "Hello World"
            });
        }

        [HttpDelete]
        [Route("api/[controller]/DeleteV2")]
        public string DeleteV2()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                Success = true,
                Message = "操作成功"
            });
        }

        [HttpPut]
        [Route("api/[controller]/UpdateV2")]
        public string UpdateV2()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                Success = true,
                Message = "操作成功"
            });
        }

        [HttpPost]
        [Route("api/[controller]/AddV2")]
        public string AddV2()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                Success = true,
                Message = "操作成功"
            });
        }


        [HttpPost]
        [Route("api/[controller]/AddNewV2")]
        public string AddNewV2()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                Success = true,
                Message = "操作成功AddNew"
            });

        }
    }
}
