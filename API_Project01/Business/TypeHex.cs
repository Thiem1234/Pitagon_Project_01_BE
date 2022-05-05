using System.Text;
namespace API_Project01.Business
{
    public class TypeHex : IConverter
    {
        //Giai ma : conver String to hex
        public string DeCode(string input)
        {
            string outp = string.Empty;
            char[] value = input.ToCharArray();
            foreach (char l in value)
            {
                int v = Convert.ToInt32(l);
                outp += string.Format("{0:x}", v);
            }
            return outp;
        }
        //Ma hoa : Convert HexTo string
        public string EnCode(string hex)
        {
            //
            if (!OnlyHexInString(hex))
            {
                return "Non-Hex Input Values ​​cannot be Converted!!";
            }
            //
            byte[] data = FromHex(hex);
            string s = Encoding.ASCII.GetString(data);
            return s;
        }
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
        public static bool OnlyHexInString(string test)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(test, @"\A\b[0-9a-fA-F]+\b\Z");
        }
    }
}
