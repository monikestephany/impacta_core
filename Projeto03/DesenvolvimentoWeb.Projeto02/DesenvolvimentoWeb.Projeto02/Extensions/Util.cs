using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DesenvolvimentoWeb.Projeto02.Extensions
{
    public static class Util
    {
        public static byte[] ToByteArray(this IFormFile file)
        {
            using (BinaryReader reader = new BinaryReader(file.OpenReadStream()))
            {
                return reader.ReadBytes((int)file.Length);
            }
        }
        public static string ValidarEmail(this string txt)
        {
            if (!Regex.IsMatch(txt,
                @"^[a-zA-Z0-9\._\-]+\@+[a-zA-Z0-9\._\-]+\.[a-zA-Z]+$"))
            {
                throw new Exception("Informe um email válido!");
            }
            return txt;
        }
    }
}
