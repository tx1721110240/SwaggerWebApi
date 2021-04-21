using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerWebApi.Controllers.V3
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "v3")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class V3Controller : Controller
    {
        /// <summary>
        /// 这里是v3
        /// </summary>
        /// <returns></returns> 
        [HttpGet]
        [Microsoft.AspNetCore.Authorization.AllowAnonymous]
        [Route("api/[controller]/GetV3")]
        public string GetV3()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                Title = "Hello World"
            });
        }

        [HttpDelete]
        [Route("api/[controller]/DeleteV3")]
        public string DeleteV3()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                Success = true,
                Message = "操作成功"
            });
        }

        [HttpPut]
        [Route("api/[controller]/UpdateV3")]
        public string UpdateV3()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                Success = true,
                Message = "操作成功"
            });
        }

        [HttpPost]
        [Route("api/[controller]/AddV3")]
        public string AddV3()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                Success = true,
                Message = "操作成功"
            });
        }


        [HttpPost]
        [Route("api/[controller]/AddNewV3")]
        public string AddNewV3()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                Success = true,
                Message = "操作成功AddNew"
            });

        }
    }
}
