using System;

namespace Commento_sso_example.Extensions
{
    public static class ByteExtensions
    {
        public static string HexEncode(this byte[] bytes)
        {
            var hexString = BitConverter.ToString(bytes);
            hexString = hexString.Replace("-", "");
            return hexString;
        }
    }
}