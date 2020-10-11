using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BT.Application.Common
{
    public static class RemoveDiacriticsHelper
    {
        public static string RemoveDiacritics(this String text)
        {
            byte[] tempBytes;
            tempBytes = System.Text.Encoding.GetEncoding("ISO-8859-8").GetBytes(text);
            return System.Text.Encoding.UTF8.GetString(tempBytes);
        }
    }
}