using API_Project01.Model;
using API_Project01.Business;
namespace API_Project01.AdapterConver
{
    public class AdapterConvert
    {
        InputData inputData;
        public AdapterConvert(InputData inputData)
        {
            this.inputData = inputData;
        }
        IConverter converter;
        public void ConvertEncode(InputData inputData)
        {
            
            //
            //EnCode
            if (inputData.typeInputData == "TypeBase64")
            {
                converter = new TypeBase64();
                inputData.valueInputData = converter.EnCode(inputData.valueInputData);
            }
            else if (inputData.typeInputData == "TypeHex")
            {
                converter = new TypeHex();
                inputData.valueInputData = converter.EnCode(inputData.valueInputData);
            }
            else
            {
                converter = new TypeString();
                inputData.valueInputData = converter.EnCode(inputData.valueInputData);
            }
        }
        public void ConvertDecode(InputData inputData)
        {
            //Decode
            if (inputData.typeOutputData == "TypeBase64")
            {
                converter = new TypeBase64();
                inputData.valueInputData = converter.DeCode(inputData.valueInputData);
            }
            else if (inputData.typeOutputData == "TypeHex")
            {
                converter = new TypeHex();
                inputData.valueInputData = converter.DeCode(inputData.valueInputData);
            }
            else
            {
                converter = new TypeString();
                inputData.valueInputData = converter.DeCode(inputData.valueInputData);
            }
        }

    }
}
