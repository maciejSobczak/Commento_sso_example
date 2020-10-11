using System;

namespace Commento_sso_example.Extensions
{
    public static class StringExtensions
    {
        public static byte[] HexDecode(this string hexString)
        {
            byte[] bytes = new byte[hexString.Length / 2];
            for (int i = 0; i < hexString.Length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
            }
            return bytes;
        }
    }
}