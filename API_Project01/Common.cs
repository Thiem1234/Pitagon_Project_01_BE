using System.Text;
namespace API_Project01
{
    public class Common
    {
        // Convert Base64 to String
        public string ConvertBase64ToString(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }
        //Convert String to Hex
        public string ConvertStringToHex(string inp)
        {
            string outp = string.Empty;
            char[] value = inp.ToCharArray();
            foreach (char l in value)
            {
                int v = Convert.ToInt32(l);
                outp += string.Format("{0:x}", v);
            }
            return outp;
        }
        //Convert Base 64 to Hex
        public string ConvertBase64ToHex(string data)
        {
            byte[] bytes = Convert.FromBase64String(data);
            return BitConverter.ToString(bytes);
        }
        //Convert String to Base64
        public string ConvertStringToBase64(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        //Convert Hex to String
        public static byte[] FromHex(string hex)
        {
            hex = hex.Replace("-", "");
            byte[] raw = new byte[hex.Length / 2];
            for (int i = 0; i < raw.Length; i++)
            {
                raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            return raw;
        }
        public string ConvertHexToString(string hex)
        {
            byte[] data = FromHex(hex);
            string s = Encoding.ASCII.GetString(data);
            return s;
        }
        //
        // Convert Hex to Base 64
        public string ConvertHexToBase64(string input)
        {
            return System.Convert.ToBase64String(HexStringToHex(input));
        }
        public  byte[] HexStringToHex(string inputHex)
        {
            var resultantArray = new byte[inputHex.Length / 2];
            for (var i = 0; i < resultantArray.Length; i++)
            {
                resultantArray[i] = System.Convert.ToByte(inputHex.Substring(i * 2, 2), 16);
            }
            return resultantArray;
        }
        //
        public bool IsBase64String(string base64)
        {
            Span<byte> buffer = new Span<byte>(new byte[base64.Length]);
            return Convert.TryFromBase64String(base64, buffer, out int bytesParsed);
        }
        public bool OnlyHexInString(string test)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(test, @"\A\b[0-9a-fA-F]+\b\Z");
        }
    }
}
