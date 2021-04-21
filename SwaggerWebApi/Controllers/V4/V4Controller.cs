using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerWebApi.Controllers.V4
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "v4")]
    [ApiController]
    public class V4Controller : Controller
    {
        /// <summary>
        /// 这里是V4
        /// </summary>
        /// <returns></returns> 
        [HttpGet]
        public string GetV4()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                Title = "Hello World"
            });
        }

        [HttpDelete]
        public string DeleteV4()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                Success = true,
                Message = "操作成功"
            });
        }

        [HttpPut]
        public string UpdateV4()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                Success = true,
                Message = "操作成功"
            });
        }

        [HttpPost]
        public string AddV4()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                Success = true,
                Message = "操作成功"
            });
        }


        [HttpPost]
        public string AddNewV4()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                Success = true,
                Message = "操作成功AddNew"
            });

        }
    }
}
