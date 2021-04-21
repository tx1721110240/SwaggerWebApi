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
    public class V2Controller : Controller
    {
        /// <summary>
        /// 这里是v2
        /// </summary>
        /// <returns></returns> 
        [HttpGet]
        public string GetV2()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                Title = "Hello World"
            });
        }

        [HttpDelete]
        public string DeleteV2()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                Success = true,
                Message = "操作成功"
            });
        }

        [HttpPut]
        public string UpdateV2()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                Success = true,
                Message = "操作成功"
            });
        }

        [HttpPost]
        public string AddV2()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                Success = true,
                Message = "操作成功"
            });
        }


        [HttpPost]
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
