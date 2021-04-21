using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerWebApi.Controllers.V1
{

    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class V1Controller : Controller
    {
        /// <summary>
        /// 这里是V1
        /// </summary>
        /// <returns></returns> 
        [HttpGet]
        [Microsoft.AspNetCore.Authorization.AllowAnonymous]
        public string GetV1()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                Title = "Hello World"
            });
        }
        /// <summary>
        /// 这里是DeleteV1
        /// </summary>
        /// <returns>字符串</returns>
        [HttpDelete]
        [Route("api/[controller]/DeleteV1")]
        public string DeleteV1()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                Success = true,
                Message = "操作成功"
            });
        }

        [HttpPut]
        [Route("api/[controller]/UpdateV1")]
        public string UpdateV1()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                Success = true,
                Message = "操作成功"
            });
        }

        [HttpPost]
        [Route("api/[controller]/AddV1")]
        public string AddV1()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                Success = true,
                Message = "操作成功"
            });
        }


        [HttpPost]
        [Route("api/[controller]/AddNewV1")]
        public string AddNewV1()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                Success = true,
                Message = "操作成功AddNew"
            });
        }
    }
}
