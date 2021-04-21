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
    public class V3Controller : Controller
    {
        /// <summary>
        /// 这里是v3
        /// </summary>
        /// <returns></returns> 
        [HttpGet]
        public string GetV3()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                Title = "Hello World"
            });
        }

        [HttpDelete]
        public string DeleteV3()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                Success = true,
                Message = "操作成功"
            });
        }

        [HttpPut]
        public string UpdateV3()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                Success = true,
                Message = "操作成功"
            });
        }

        [HttpPost]
        public string AddV3()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                Success = true,
                Message = "操作成功"
            });
        }


        [HttpPost]
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
