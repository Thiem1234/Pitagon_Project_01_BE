using System;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_Project01.Model;
using API_Project01.Business;
using API_Project01.Factory;
using API_Project01.AdapterConver;

namespace API_Project01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InputDataController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public InputDataController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }
        [HttpPost]
        public JsonResult Post(InputData inputData)
        {
            List<Object> fields = new List<Object>();
            AdapterConvert adapterConvert = new AdapterConvert(inputData);

            adapterConvert.ConvertEncode(inputData);
            adapterConvert.ConvertDecode(inputData);

            fields.Add(inputData.valueInputData);
            return new JsonResult(fields);
        }

    }
}