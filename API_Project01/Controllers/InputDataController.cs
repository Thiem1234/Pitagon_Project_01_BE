using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_Project01.Model;

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
        //public ActionResult Post(InputData inputData)
        //{
        //    Common common = new Common();

        //    List<string> fields = new List<string>();
        //    //if (IsBase64String(inputData.inputData))
        //    //{
        //    //   fields.Add($"{common.ConvertBase64ToString(inputData.inputData)}");
        //    //}
        //    //else
        //    fields.Add($"{common.ConvertBase64ToString(inputData.inputData)}");

        //    return Ok(fields);
        //}
        [HttpPost]
        public JsonResult Post(InputData inputData)
        {
            List<Object> fields = new List<Object>();
            Common common = new Common();
            //Check Base64
            if((inputData.typeInputData == "Base64") && !common.IsBase64String(inputData.valueInputData))
            {
                return new JsonResult("Non-Base64 Input Values ​​cannot be Converted!!");
            }
            //Check Hex
            if(inputData.typeInputData == "Hex" && !common.OnlyHexInString(inputData.valueInputData))
            {
                return new JsonResult("Non-Hex Input Values ​​cannot be Converted!!");
            }
            //String
            if(inputData.typeInputData == "String" && inputData.typeOutputData == "Hex")
            {
                fields.Add(common.ConvertStringToHex(inputData.valueInputData));
            }
            else if (inputData.typeInputData == "String" && inputData.typeOutputData == "String")
            {
                fields.Add(inputData.valueInputData);
            }
            //String
            else if(inputData.typeInputData == "String" && inputData.typeOutputData == "Base64")
            {
                fields.Add(common.ConvertStringToBase64(inputData.valueInputData));
            }
            //Base64
            else if (inputData.typeInputData == "Base64" && inputData.typeOutputData == "String")
            {
                fields.Add(common.ConvertBase64ToString(inputData.valueInputData));
            }
            else if(inputData.typeInputData == "Base64" && inputData.typeOutputData == "Hex")
            {
                fields.Add(common.ConvertBase64ToHex(inputData.valueInputData));
            }
            else if (inputData.typeInputData == "Base64" && inputData.typeOutputData == "Base64")
            {
                fields.Add(inputData.valueInputData);
            }
            //Hex
            else if(inputData.typeInputData == "Hex" && inputData.typeOutputData == "String")
            {
                fields.Add(common.ConvertHexToString(inputData.valueInputData));
            }
            else if (inputData.typeInputData == "Hex" && inputData.typeOutputData == "Base64")
            {
                fields.Add(common.ConvertHexToBase64(inputData.valueInputData));
            }
            else if (inputData.typeInputData == "Hex" && inputData.typeOutputData == "Hex")
            {
                fields.Add(inputData.valueInputData);
            }
            else
            fields.Add( $"valueInputData: { inputData.valueInputData}, typeInputData: {inputData.typeInputData}, typeOutputData: {inputData.typeOutputData}");
            return new JsonResult(fields);
        }

    }
}