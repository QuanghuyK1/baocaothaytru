using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Application.Helpers
{
    internal class EnandDecode
    {
        // Mã hóa chuỗi thành 1 chuỗi 6 số
        public static string EncodeTo6DigitNumber(string input)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input);
            int sum = 0;
            foreach (byte b in bytes)
            {
                sum += b;
            }
            return (sum % 1000000).ToString("D6");
        }

        public static string DecodeFrom6DigitNumber(string encodedInput)
        {
            int sum = int.Parse(encodedInput);
            byte[] bytes = new byte[6];
            for (int i = 0; i < 6; i++)
            {
                bytes[5 - i] = (byte)(sum % 256);
                sum /= 256;
            }
            return System.Text.Encoding.UTF8.GetString(bytes);
        }
    }
}
