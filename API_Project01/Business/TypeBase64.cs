using System.Text;
namespace API_Project01.Business
{
    public class TypeBase64 : IConverter
    {
        //Ma ho : Base 64 to String
        public string EnCode(string base64EncodedData)
        {
            if (!IsBase64String(base64EncodedData))
            {
                return "Non-Base64 Input Values ​​cannot be Converted!!";
            }
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }


        //Giai :  String to Base64
        public string DeCode(string input)
        {
            
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(input);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public static bool IsBase64String(string base64)
        {
            Span<byte> buffer = new Span<byte>(new byte[base64.Length]);
            return Convert.TryFromBase64String(base64, buffer, out int bytesParsed);
        }
    }
}
